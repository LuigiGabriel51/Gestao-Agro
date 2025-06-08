using GestaoAgro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.Services
{
    public class OperationStateService
    {
        private readonly DBService DBService;
        public OperationStateService(DBService dBService)
        {
            DBService = dBService;
        }
        public OperationState OperationState { get; set; } = new OperationState();

        public async Task SaveOperationState(OperationState operationState)
        {
            await DBService.InsertObject("data", operationState.DataRepository);
        }

        public async Task GetOperationState()
        {
            var dataRepository = await DBService.GetObject<DataRepository>("data");
            if (dataRepository != null)
            {
                OperationState.DataRepository = dataRepository;
            }
        }

        public async Task InitializeOperationState()
        {
            var dataRepository = await DBService.GetObject<DataRepository>("data");

            if (dataRepository != null)
            {
                OperationState.DataRepository = dataRepository;
            }
            else
            {
                OperationState.DataRepository = new DataRepository()
                {
                    BovineAnimals = new List<Models.Animals.Bovine>(),
                    SwineAnimals = new List<Models.Animals.Swine>(),
                    CaprineAnimals = new List<Models.Animals.Caprine>(),
                    PastureManagements = new List<Models.PastureManagements.PastureManagement>(),
                    ZootechnicalReports = new List<ZootechnicalReport>()
                };
                await DBService.InsertObject("data", OperationState.DataRepository);
            }
        }
    }
}
