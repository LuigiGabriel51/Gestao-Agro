using AsyncAwaitBestPractices;
using GestaoAgro.ViewModels.Forms;

namespace GestaoAgro.View.Forms;

public partial class FormNewVaccine : ContentPage
{
	public FormNewVaccine(FormNewVaccineViewModel formNewVaccineViewModel)
	{
		InitializeComponent();
        BindingContext = formNewVaccineViewModel;
        formNewVaccineViewModel.InitializeViewModel().SafeFireAndForget();
    }
}