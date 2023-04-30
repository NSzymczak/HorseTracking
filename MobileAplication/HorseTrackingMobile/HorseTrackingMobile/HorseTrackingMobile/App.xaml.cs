using HorseTrackingMobile.Database;
using HorseTrackingMobile.Views;
using Xamarin.Forms;

namespace HorseTrackingMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Startup.Init();
            DataBaseConnection.Connect();
            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
