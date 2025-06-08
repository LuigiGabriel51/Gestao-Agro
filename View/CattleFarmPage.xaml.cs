using AsyncAwaitBestPractices;
using GestaoAgro.ViewModels;

namespace GestãoAgro.View;

public partial class CattleFarmPage : ContentPage
{
	public CattleFarmPage(CattleFarmViewModel cattleFarmViewModel)
	{
		InitializeComponent();
        BindingContext = cattleFarmViewModel;
		cattleFarmViewModel.InitializeViewModel().SafeFireAndForget();
    }
}