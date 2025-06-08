using GestaoAgro.View.Forms;

namespace GestãoAgro
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("CattleFarmPage/FormNewAnimal", typeof(FormNewAnimal));
            Routing.RegisterRoute("CattleFarmPage/FormNewVaccine", typeof(FormNewVaccine));
        }
    }
}
