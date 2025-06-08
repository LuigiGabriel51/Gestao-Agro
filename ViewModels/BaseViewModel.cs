using CommunityToolkit.Mvvm.ComponentModel;
using GestaoAgro.Models;
using GestaoAgro.Models.Animals;
using GestaoAgro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.ViewModels
{
    public partial class BaseViewModel : ObservableObject, IQueryAttributable
    {
        public DBService DBService;
        public OperationStateService OperationStateService;

        public BaseViewModel(DBService dBService = null, OperationStateService operationStateService = null)
        {
            DBService = dBService;
            OperationStateService = operationStateService;
        }
        public virtual async Task InitializeViewModel() { }

        #region properties boolean

        [ObservableProperty]
        private bool _isLoading;

        public bool ViewModelInitialized;
        #endregion

        #region Miscellaneous 
        public double CalculateBirthRate<T>(List<T> animals, DateTime dataInicio, DateTime dataFim) where T : Animal
        {
            // Fêmeas em idade reprodutiva (exemplo: idade >= 2 anos e ativas)
            var femeasReprodutivas = animals
                .Where(a => a.Gender == "F"
                            && a.IsActive
                            && (DateTime.Now.Year - a.BirthDate.Year) >= 2)
                .ToList();

            // Nascimentos no período
            var nascimentos = animals
                .Where(a => a.BirthDate >= dataInicio && a.BirthDate <= dataFim)
                .ToList();

            if (femeasReprodutivas.Count == 0)
                return 0;

            double taxa = (double)nascimentos.Count / femeasReprodutivas.Count * 100;
            return Math.Round(taxa, 2);
        }

        public (string color, string icon) SortBirthRateIndicator(double taxa)
        {
            if (taxa < 60)
                return ("#FF0016", "▼");
            else if (taxa < 80)
                return ("#FFD000", "▬");
            else
                return ("#04FF00", "▲");
        }

        public ShellNavigationQueryParameters CreateNavigationParameter()
        {
            return new ShellNavigationQueryParameters
            {
                { "data", OperationStateService.OperationState }
            };
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query == null) return;
            OperationStateService.OperationState = (OperationState)query["data"];
        }
        #endregion
    }
}
