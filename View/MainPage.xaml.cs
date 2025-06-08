using AsyncAwaitBestPractices;
using GestaoAgro.ViewModels;

namespace GestãoAgro.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent(); 
            BindingContext = mainViewModel;
            Task.Run(async () =>
            {
                await Task.Delay(3000);
                mainViewModel.InitializeViewModel().SafeFireAndForget();
            });
        }
    }

}
