using HorseTrackingMobile.Services.Database;
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
            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
