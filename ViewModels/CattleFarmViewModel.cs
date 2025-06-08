using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestaoAgro.Models;
using GestaoAgro.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.ViewModels
{
    public partial class CattleFarmViewModel : BaseViewModel
    {
        public CattleFarmViewModel(DBService dBService,
            OperationStateService operationStateService)
            : base(dBService, operationStateService)
        {

        }

        public async override Task InitializeViewModel()
        {
            await base.InitializeViewModel();
            if (!ViewModelInitialized)
            {
                ViewModelInitialized = true;
                await OperationStateService.InitializeOperationState();
            }

            AnimalAnalyticsSelected = ListAnimalAnalytics.FirstOrDefault();
        }

        #region Animal Analytics

        [ObservableProperty]
        private ObservableCollection<string> _listAnimalAnalytics =
        [
            "bovinos",
            "suínos",
            "ovinos",
            "caprinos",
            "equinos",
            "aves"
        ];

        [ObservableProperty]
        private string _animalAnalyticsSelected;
        partial void OnAnimalAnalyticsSelectedChanged(string value)
        {
            RefreshAnimalAnalytics(value);
        }

        [ObservableProperty]
        private string _totalHerd;
        
        [ObservableProperty]
        private string _herdBirthRate;
        
        [ObservableProperty]
        private string _averageWeight;
        
        [ObservableProperty]
        private string _animalIcon;

        [ObservableProperty]
        private string _indicatorIcon;

        [ObservableProperty]
        private string _colorIndicatorIcon;

        public void RefreshAnimalAnalytics(string animal)
        {
            switch (animal)
            {
                case "bovinos":
                    AnimalIcon = "🐄";
                    var bovineAnimal = OperationStateService.OperationState.DataRepository.BovineAnimals;
                    TotalHerd = bovineAnimal.Count.ToString();
                    if (bovineAnimal.Count > 0)
                    {
                        AverageWeight = bovineAnimal.Average(a => a.CurrentWeight).ToString("F2") + " kg";
                        var herdBirthRate = CalculateBirthRate(bovineAnimal, DateTime.Now.AddMonths(-12), DateTime.Now);
                        HerdBirthRate = herdBirthRate.ToString() + "%";
                        (ColorIndicatorIcon, IndicatorIcon) = SortBirthRateIndicator(herdBirthRate);
                    }
                    else
                    {
                        AverageWeight = "N/A";
                        HerdBirthRate = "N/A";
                        ColorIndicatorIcon = "#FF0016";
                        IndicatorIcon = "❌";
                    }
                    break;
                case "suínos":
                    AnimalIcon = "🐖";
                    var swineAnimal = OperationStateService.OperationState.DataRepository.SwineAnimals;
                    TotalHerd = swineAnimal.Count.ToString();
                    if (swineAnimal.Count > 0)
                    {
                        AverageWeight = swineAnimal.Average(a => a.CurrentWeight).ToString("F2") + " kg";
                        var herdBirthRate = CalculateBirthRate(swineAnimal, DateTime.Now.AddMonths(-12), DateTime.Now);
                        HerdBirthRate = herdBirthRate.ToString() + "%";
                        (ColorIndicatorIcon, IndicatorIcon) = SortBirthRateIndicator(herdBirthRate);
                    }
                    else
                    {
                        AverageWeight = "N/A";
                        HerdBirthRate = "N/A";
                        ColorIndicatorIcon = "#FF0016";
                        IndicatorIcon = "❌";
                    }
                    break;
                case "ovinos":
                    AnimalIcon = "🐏";
                    //var ovineAnimal = OperationStateService.OperationState.DataRepository.BovineAnimals;
                    //TotalHerd = bovineAnimal.Count.ToString();
                    //if (bovineAnimal.Count > 0)
                    //{
                    //    AverageWeight = bovineAnimal.Average(a => a.CurrentWeight).ToString("F2") + " kg";
                    //    HerdBirthRate = CalculateBirthRate(bovineAnimal, DateTime.Now.AddMonths(-12), DateTime.Now).ToString() + "%";
                    //}
                    //else
                    //{
                    //    AverageWeight = "N/A";
                    //    HerdBirthRate = "N/A";
                    //}
                    break;
                case "caprinos":
                    AnimalIcon = "🐐";
                    var caprineAnimal = OperationStateService.OperationState.DataRepository.CaprineAnimals;
                    TotalHerd = caprineAnimal.Count.ToString();
                    if (caprineAnimal.Count > 0)
                    {
                        AverageWeight = caprineAnimal.Average(a => a.CurrentWeight).ToString("F2") + " kg";
                        var herdBirthRate = CalculateBirthRate(caprineAnimal, DateTime.Now.AddMonths(-12), DateTime.Now);
                        HerdBirthRate = herdBirthRate.ToString() + "%";
                        (ColorIndicatorIcon, IndicatorIcon) = SortBirthRateIndicator(herdBirthRate);
                    }
                    else
                    {
                        AverageWeight = "N/A";
                        HerdBirthRate = "N/A";
                        ColorIndicatorIcon = "#FF0016";
                        IndicatorIcon = "❌";
                    }
                    break;
                case "equinos":
                    AnimalIcon = "🐎";
                    //var bovineAnimal = OperationStateService.OperationState.DataRepository.BovineAnimals;
                    //TotalHerd = bovineAnimal.Count.ToString();
                    //if (bovineAnimal.Count > 0)
                    //{
                    //    AverageWeight = bovineAnimal.Average(a => a.CurrentWeight).ToString("F2") + " kg";
                    //    HerdBirthRate = CalculateBirthRate(bovineAnimal, DateTime.Now.AddMonths(-12), DateTime.Now).ToString() + "%";
                    //}
                    //else
                    //{
                    //    AverageWeight = "N/A";
                    //    HerdBirthRate = "N/A";
                    //}
                    break;
                case "aves":
                    AnimalIcon = "🐓";
                    //var bovineAnimal = OperationStateService.OperationState.DataRepository.BovineAnimals;
                    //TotalHerd = bovineAnimal.Count.ToString();
                    //if (bovineAnimal.Count > 0)
                    //{
                    //    AverageWeight = bovineAnimal.Average(a => a.CurrentWeight).ToString("F2") + " kg";
                    //    HerdBirthRate = CalculateBirthRate(bovineAnimal, DateTime.Now.AddMonths(-12), DateTime.Now).ToString() + "%";
                    //}
                    //else
                    //{
                    //    AverageWeight = "N/A";
                    //    HerdBirthRate = "N/A";
                    //}
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Commands

        [RelayCommand]
        private async Task GoToNewAnimal()
        {
            await Shell.Current.GoToAsync("FormNewAnimal", animate:true, CreateNavigationParameter());
        }

        [RelayCommand]
        private async Task GoToNewVaccine()
        {
            await Shell.Current.GoToAsync("FormNewVaccine", animate: true, CreateNavigationParameter());
        }

        #endregion
    }
}
