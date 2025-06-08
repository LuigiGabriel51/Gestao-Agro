using AsyncAwaitBestPractices;
using GestaoAgro.ViewModels.Forms;

namespace GestaoAgro.View.Forms;

public partial class FormNewAnimal : ContentPage
{
	public FormNewAnimal(FormNewAnimalViewModel formNewAnimalViewModel)
	{
		InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
        BindingContext = formNewAnimalViewModel;
        formNewAnimalViewModel.InitializeViewModel().SafeFireAndForget();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void CanConfirmTextChanged(object sender, TextChangedEventArgs e)
    {
        var viewModel = BindingContext as FormNewAnimalViewModel;
        viewModel.CanConfirmNewAnimal();
    }
}