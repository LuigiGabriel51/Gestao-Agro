using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.Models
{
    public class RealmDataModel : RealmObject
    {
        [PrimaryKey]
        public string Key { get; set; }
        public string JsonData { get; set; }
        public string DataModel { get; set; }
        public string FullDataModel { get; set; }
        public DateTimeOffset Timestamp { get; set; }

    }
}
