using HorseTrackingMobile.Services.Database;
using HorseTrackingMobile.Views;
using PasswordHashing;
using Xamarin.Forms;

namespace HorseTrackingMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Startup.Init();
            PasswordHasher.SetDefaultSettings(HashAlgorithm.SHA384, 20);
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