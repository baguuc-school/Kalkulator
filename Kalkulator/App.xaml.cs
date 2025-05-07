using Kalkulator.Views;

namespace Kalkulator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            this.MainPage = new MainPage();
        }
    }
}
