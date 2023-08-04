using HorseTrackingDesktop.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace HorseTrackingDesktop
{
    public partial class LoginView : Window
    {
        private LoginViewModel? LoginViewModel;

        public LoginView()
        {
            InitializeComponent();
            LoginViewModel = StartUp.ServiceProvider?.GetService<LoginViewModel>();
            DataContext = LoginViewModel;
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (LoginViewModel != null)
            {
                LoginViewModel.UserPassword = ((PasswordBox)sender).Password;
            }
        }
    }
}