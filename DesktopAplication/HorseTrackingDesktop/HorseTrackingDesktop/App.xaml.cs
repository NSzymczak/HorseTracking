using PasswordHashing;
using System.Windows;

namespace HorseTrackingDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            PasswordHasher.SetDefaultSettings(HashAlgorithm.SHA384, 20);
            StartUp.Init();
        }
    }
}