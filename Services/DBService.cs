using GestaoAgro.Models;
using Newtonsoft.Json;
using Realms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestaoAgro.Services
{
    public class DBService
    {
        private static string _dBPath;
        private string _mainFolder;
        private Realm _realm = null;
        private static RealmConfiguration _realmConfiguration;
        public bool KeyAvailable { get; set; }
        public DBService()
        {
            try
            {
                _mainFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var realmDirectoryName = "\\GestaoAgro";

                if (!Directory.Exists(_mainFolder + realmDirectoryName))
                {
                    Directory.CreateDirectory(_mainFolder + realmDirectoryName);
                }
                _dBPath = Path.Combine(_mainFolder + realmDirectoryName, "GestaoAgro.realm");

                _realmConfiguration = RealmSetup();
                _realm = Realm.GetInstance(_realmConfiguration);
                KeyAvailable = false;

            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }
        private RealmConfiguration RealmSetup()
        {
            var config = new RealmConfiguration(_dBPath)
            {
                SchemaVersion = 1, // Versão do esquema do Realm
                Schema = new[] { typeof(RealmDataModel) } // Lista das classes de objetos Realm que serão gerenciadas pelo Realm
            };

            return config;
        }
        public async Task<T> GetObject<T>(string key)
        {
            var result = default(T);
            try
            {
                result = await GetFromCacheQueue<T>(key).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                result = default;
            }

            return result;
        }
        private async Task<T> GetFromCacheQueue<T>(string key)
        {
            try
            {
                if (key != null)
                {
                    _realm = Realm.GetInstance(_realmConfiguration);
                    var persistedObject = _realm?.All<RealmDataModel>()?.FirstOrDefault(p => p.Key == key);

                    if (persistedObject != null /*&& !IsCacheExpired(persistedObject.Timestamp)*/)
                    {
                        KeyAvailable = true;

                        if (persistedObject.JsonData != null)
                        {
                            return DeserializeJson<T>(persistedObject.JsonData);
                        }

                        KeyAvailable = false;
                        return default;
                    }

                    KeyAvailable = false;
                    return default;
                }

                return default;
            }
            catch (Exception ex)
            {
                KeyAvailable = false;
                return default;
            }
        }
        public async Task InsertObject<T>(string key, T originalObject)
        {
            try
            {
                await InsertObjectToCacheQueue(key, originalObject).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }
        private async Task InsertObjectToCacheQueue<T>(string key, T originalObject)
        {
            var _lockObject = new object();

            try
            {
                if (originalObject != null && key != null)
                {
                    lock (_lockObject)
                    {
                        _realm = Realm.GetInstance(_realmConfiguration);
                        object safeCopy;

                        if (originalObject is IEnumerable && originalObject.GetType().IsGenericType)
                        {
                            var itemType = originalObject.GetType().GetGenericArguments()[0];
                            var toListMethod = typeof(Enumerable).GetMethod("ToList", BindingFlags.Static | BindingFlags.Public)
                                .MakeGenericMethod(itemType);
                            safeCopy = toListMethod.Invoke(null, new object[] { originalObject });
                        }
                        else
                        {
                            safeCopy = originalObject;
                        }

                        _realm?.WriteAsync(() =>
                        {
                            if (safeCopy != null)
                            {
                                var jsonData = JsonConvert.SerializeObject(safeCopy);

                                if (jsonData != null)
                                {
                                    _realm.Add(new RealmDataModel
                                    {
                                        JsonData = jsonData,
                                        Key = key,
                                        FullDataModel = originalObject.GetType().FullName,
                                        DataModel = originalObject.GetType().Name,
                                        Timestamp = DateTimeOffset.Now
                                    }, update: true);
                                }
                            }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public async Task Invalidate(string key)
        {
            try
            {
                await InvalidateObjectQueue(key).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }
        private async Task InvalidateObjectQueue(string key)
        {
            try
            {
                if (key != null)
                {
                    _realm = Realm.GetInstance(_realmConfiguration);
                    _realm?.WriteAsync(() =>
                    {
                        var persistedObject = _realm?.All<RealmDataModel>()?.FirstOrDefault(p => p.Key == key);

                        if (persistedObject != null)
                        {
                            _realm.Remove(persistedObject);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<T>> GetAllObjects<T>()
        {
            var tcs = new TaskCompletionSource<IEnumerable<T>>();

            try
            {
                var result = await GetAllObjectsQueue<T>().ConfigureAwait(false);
                tcs.SetResult(result);
            }
            catch (Exception ex)
            {
                // Handle exceptions from EnqueueCommand itself if any
                tcs.SetException(ex);
            }

            return await tcs.Task;
        }
        private async Task<IEnumerable<T>> GetAllObjectsQueue<T>()
        {
            var result = new List<T>();

            try
            {
                _realm = Realm.GetInstance(_realmConfiguration);
                var persistedObjects = _realm?.All<RealmDataModel>();

                if (persistedObjects != null)
                {
                    var filteredObjects = persistedObjects?
                        .Where(p => p.FullDataModel.Contains(typeof(T).Name));

                    foreach (var item in filteredObjects)
                    {
                        try
                        {
                            if (item != null && item.JsonData != null)
                            {
                                var deserializedObject = DeserializeJsonNow<T>(item.JsonData);
                                result.Add(deserializedObject);
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<string>> GetAllKeys()
        {
            var tcs = new TaskCompletionSource<IEnumerable<string>>();
            try
            {
                var result = await GetAllKeysQueue().ConfigureAwait(false);
                tcs.SetResult(result);
            }
            catch (Exception ex)
            {
                // Handle exceptions from EnqueueCommand itself if any
                tcs.SetException(ex);
            }

            return await tcs.Task;
        }
        private async Task<IEnumerable<string>> GetAllKeysQueue()
        {
            try
            {
                _realm = Realm.GetInstance(_realmConfiguration);
                var persistedDataModels = _realm?.All<RealmDataModel>()?.ToList();
                var persistedKeys = persistedDataModels?.Select(p => p.Key)?.ToList();
                return persistedKeys;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private T DeserializeJsonNow<T>(string jsonData)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return JsonConvert.DeserializeObject<T>(jsonData, settings);
        }
        private T DeserializeJson<T>(string jsonData)
        {
            // Verifica se T é uma coleção IEnumerable<T>
            if (typeof(T).GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>)) && typeof(T).Name != "String")
            {
                // Verifica se o jsonData é um array JSON
                if (jsonData.StartsWith("[") && jsonData.EndsWith("]"))
                {
                    // Desserializa diretamente como uma coleção
                    return JsonConvert.DeserializeObject<T>(jsonData);
                }
                else
                {
                    // Se não for um array JSON, tenta desserializar como um único objeto
                    var singleObject = JsonConvert.DeserializeObject<T[]>(jsonData);
                    return singleObject.FirstOrDefault();
                }
            }
            else
            {
                // Se não for uma coleção, desserializa normalmente
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
        }
    }
}
