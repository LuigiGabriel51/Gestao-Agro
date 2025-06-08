using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestaoAgro.Models.Animals;
using GestaoAgro.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoAgro.ViewModels.Forms
{
    public partial class FormNewAnimalViewModel : BaseViewModel
    {
        public FormNewAnimalViewModel
            (
                OperationStateService operationStateService,
                DBService dBService
            )
            :
            base
            (
                dBService: dBService,
                operationStateService: operationStateService
            )
        {

        }

        [ObservableProperty]
        private ObservableCollection<string> _listAnimals =
        [
            "bovinos",
            "suínos",
            "ovinos",
            "caprinos",
            "equinos",
            "aves"
        ];
        
        [ObservableProperty]
        private ObservableCollection<string> _genderType =
        [
            "macho",
            "fêmea"
        ];


        [ObservableProperty]
        private Animal _currentAnimal = new();
        [ObservableProperty]
        private Bovine _currentBovine = new();
        [ObservableProperty]
        private Swine _currentSwine = new();
        [ObservableProperty]
        private Caprine _currentCaprine = new();


        [ObservableProperty]
        private bool _bovineSelected;
        [ObservableProperty]
        private bool _swineSelected;
        [ObservableProperty]
        private bool _sheepSelected;
        [ObservableProperty]
        private bool _goatsSelected;
        [ObservableProperty]
        private bool _horsesSelected;
        [ObservableProperty]
        private bool _birdsSelected;
        [ObservableProperty]
        private bool _isBatchCreation;
        [ObservableProperty]
        private bool _confirmNewAnimalIsEnable;


        [ObservableProperty]
        private string _iconAnimalSelected;
        [ObservableProperty]
        private string _birthDate;
        partial void OnBirthDateChanged(string Value)
        {
            CurrentAnimal.BirthDate = DateTime.Parse(Value);
            CanConfirmNewAnimal();
        }
        [ObservableProperty]
        private string _animalSelected;
        partial void OnAnimalSelectedChanged(string value)
        {
            SetAnimalType(value);
        }


        [ObservableProperty]
        private int _numberAnimalsAdded = 1;
        partial void OnNumberAnimalsAddedChanged(int value)
        {
            if(value == 0)
            {
                value = 1;
            }
        }


        private void SetAnimalType(string value)
        {
            switch(value)
            {
                case "bovinos":
                    BovineSelected = true;
                    SwineSelected = false;
                    SheepSelected = false;
                    GoatsSelected = false;
                    HorsesSelected = false;
                    BirdsSelected = false;
                    IconAnimalSelected = "Bovino 🐄";
                    break;
                case "suínos":
                    BovineSelected = false;
                    SwineSelected = true;
                    SheepSelected = false;
                    GoatsSelected = false;
                    HorsesSelected = false;
                    BirdsSelected = false;
                    IconAnimalSelected = "Suíno 🐖";
                    break;
                case "ovinos":
                    BovineSelected = false;
                    SwineSelected = false;
                    SheepSelected = true;
                    GoatsSelected = false;
                    HorsesSelected = false;
                    BirdsSelected = false;
                    IconAnimalSelected = "Ovinos 🐏";
                    break;
                case "caprinos":
                    BovineSelected = false;
                    SwineSelected = false;
                    SheepSelected = false;
                    GoatsSelected = true;
                    HorsesSelected = false;
                    BirdsSelected = false;
                    IconAnimalSelected = "Caprinos 🐐";
                    break;
                case "equinos":
                    BovineSelected = false;
                    SwineSelected = false;
                    SheepSelected = false;
                    GoatsSelected = false;
                    HorsesSelected = true;
                    BirdsSelected = false;
                    IconAnimalSelected = "Equinos 🐎";
                    break;
                case "aves":
                    BovineSelected = false;
                    SwineSelected = false;
                    SheepSelected = false;
                    GoatsSelected = false;
                    HorsesSelected = false;
                    BirdsSelected = true;
                    IconAnimalSelected = "Aves 🐓";
                    break;
            }
        }

        [RelayCommand]
        private async Task ConfirmNewAnimal()
        {
            if (!IsBatchCreation)
            {
                if(BovineSelected)
                {
                    CurrentBovine.Id = Guid.NewGuid();
                    CurrentBovine.Name = CurrentAnimal.Name;
                    CurrentBovine.TagNumber = CurrentAnimal.TagNumber;
                    CurrentBovine.CurrentWeight = CurrentAnimal.CurrentWeight;
                    CurrentBovine.Species = CurrentAnimal.Species;
                    CurrentBovine.Breed = CurrentAnimal.Breed;
                    CurrentBovine.Category = CurrentAnimal.Category;
                    CurrentBovine.BirthDate = CurrentAnimal.BirthDate;

                    OperationStateService.OperationState.DataRepository.BovineAnimals.Add(CurrentBovine);
                    await Toast.Make("Bovino adicionado com sucesso!", ToastDuration.Long).Show();
                }
                else if (SwineSelected)
                {
                    CurrentSwine.Id = Guid.NewGuid();
                    CurrentSwine.Name = CurrentAnimal.Name;
                    CurrentSwine.TagNumber = CurrentAnimal.TagNumber;
                    CurrentSwine.CurrentWeight = CurrentAnimal.CurrentWeight;
                    CurrentSwine.Species = CurrentAnimal.Species;
                    CurrentSwine.Breed = CurrentAnimal.Breed;
                    CurrentSwine.Category = CurrentAnimal.Category;
                    CurrentSwine.BirthDate = CurrentAnimal.BirthDate;

                    OperationStateService.OperationState.DataRepository.BovineAnimals.Add(CurrentBovine);
                    await Toast.Make("Suíno adicionado com sucesso!", ToastDuration.Long).Show();
                }
                //else if (SheepSelected)
                //{
                //}
                else if (GoatsSelected)
                {
                    CurrentCaprine.Id = Guid.NewGuid();
                    CurrentCaprine.Name = CurrentAnimal.Name;
                    CurrentCaprine.TagNumber = CurrentAnimal.TagNumber;
                    CurrentCaprine.CurrentWeight = CurrentAnimal.CurrentWeight;
                    CurrentCaprine.Species = CurrentAnimal.Species;
                    CurrentCaprine.Breed = CurrentAnimal.Breed;
                    CurrentCaprine.Category = CurrentAnimal.Category;
                    CurrentCaprine.BirthDate = CurrentAnimal.BirthDate;

                    OperationStateService.OperationState.DataRepository.BovineAnimals.Add(CurrentBovine);
                    await Toast.Make("Caprino adicionado com sucesso!", ToastDuration.Long).Show();
                }
                //else if (HorsesSelected)
                //{
                //}
                //else if (BirdsSelected)
                //{
                //}

                await OperationStateService.SaveOperationState(OperationStateService.OperationState);
            }
            else
            {
                
                if (BovineSelected)
                {
                    for (int i = 0; i < NumberAnimalsAdded; i++)
                    {
                        CurrentBovine.Id = Guid.NewGuid();
                        CurrentBovine.Name = $"{CurrentAnimal.Name} {i + 1}";
                        CurrentBovine.TagNumber = $"{CurrentAnimal.TagNumber}-{i + 1}";
                        CurrentBovine.CurrentWeight = CurrentAnimal.CurrentWeight;
                        CurrentBovine.Species = CurrentAnimal.Species;
                        CurrentBovine.Breed = CurrentAnimal.Breed;
                        CurrentBovine.Category = CurrentAnimal.Category;
                        CurrentBovine.BirthDate = CurrentAnimal.BirthDate;

                        OperationStateService.OperationState.DataRepository.BovineAnimals.Add(CurrentBovine);
                    }
                    await Toast.Make("Bovinos adicionado com sucesso!", ToastDuration.Long).Show();
                }
                else if (SwineSelected)
                {
                    for (int i = 0; i < NumberAnimalsAdded; i++)
                    {
                        CurrentSwine.Id = Guid.NewGuid();
                        CurrentSwine.Name = $"{CurrentAnimal.Name} {i + 1}";
                        CurrentSwine.TagNumber = $"{CurrentAnimal.TagNumber}-{i + 1}";
                        CurrentSwine.CurrentWeight = CurrentAnimal.CurrentWeight;
                        CurrentSwine.Species = CurrentAnimal.Species;
                        CurrentSwine.Breed = CurrentAnimal.Breed;
                        CurrentSwine.Category = CurrentAnimal.Category;
                        CurrentSwine.BirthDate = CurrentAnimal.BirthDate;

                        OperationStateService.OperationState.DataRepository.SwineAnimals.Add(CurrentSwine);
                    }

                    await Toast.Make("Suínos adicionado com sucesso!", ToastDuration.Long).Show();
                }
                else if (GoatsSelected)
                {
                    for (int i = 0; i < NumberAnimalsAdded; i++)
                    {
                        CurrentCaprine.Id = Guid.NewGuid();
                        CurrentCaprine.Name = $"{CurrentAnimal.Name} {i + 1}";
                        CurrentCaprine.TagNumber = $"{CurrentAnimal.TagNumber}-{i + 1}";
                        CurrentCaprine.CurrentWeight = CurrentAnimal.CurrentWeight;
                        CurrentCaprine.Species = CurrentAnimal.Species;
                        CurrentCaprine.Breed = CurrentAnimal.Breed;
                        CurrentCaprine.Category = CurrentAnimal.Category;
                        CurrentCaprine.BirthDate = CurrentAnimal.BirthDate;

                        OperationStateService.OperationState.DataRepository.CaprineAnimals.Add(CurrentCaprine);
                    }
                    await Toast.Make("Caprinos adicionado com sucesso!", ToastDuration.Long).Show();
                }

                await OperationStateService.SaveOperationState(OperationStateService.OperationState);
            }
        }

        public void CanConfirmNewAnimal()
        {
            // Validate required fields
            ConfirmNewAnimalIsEnable =
                !string.IsNullOrWhiteSpace(CurrentAnimal.Name) &&
                !string.IsNullOrWhiteSpace(CurrentAnimal.Gender) &&
                !string.IsNullOrWhiteSpace(CurrentAnimal.TagNumber) &&
                !string.IsNullOrWhiteSpace(CurrentAnimal.Breed) &&
                !string.IsNullOrWhiteSpace(CurrentAnimal.Category) &&
                CurrentAnimal.BirthDate > DateTime.UtcNow.AddYears(-10) &&
                (BovineSelected || SwineSelected || SheepSelected || 
                GoatsSelected || HorsesSelected || BirdsSelected); 
        }
    }
}
