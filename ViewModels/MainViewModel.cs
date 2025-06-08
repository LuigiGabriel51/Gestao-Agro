using GestaoAgro.Models;
using GestaoAgro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel
            (DBService dBService,
            OperationStateService operationStateService)
            : base(dBService, operationStateService)
        {

        }

        public override async Task InitializeViewModel()
        {
            var dataRepository = await DBService.GetObject<DataRepository>("data");
            if (dataRepository != null)
            {
                OperationStateService.OperationState.DataRepository = dataRepository;
            }
            else
            {
                OperationStateService.OperationState.DataRepository = new DataRepository()
                {
                    BovineAnimals = new List<Models.Animals.Bovine>(),
                    SwineAnimals = new List<Models.Animals.Swine>(),
                    CaprineAnimals = new List<Models.Animals.Caprine>(),
                    PastureManagements = new List<Models.PastureManagements.PastureManagement>(),
                    ZootechnicalReports = new List<ZootechnicalReport>()
                };
                await DBService.InsertObject("data", OperationStateService.OperationState.DataRepository);
            }

            MainThread.BeginInvokeOnMainThread(async() =>
            {
                await Shell.Current.GoToAsync("//CattleFarmPage");
            });
        }
    }
}
