using HorseTrackingDesktop.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace HorseTrackingDesktop
{
    public partial class LoginView : Window
    {
        LoginViewModel? LoginViewModel;
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
                LoginViewModel.UserHash = ((PasswordBox)sender).Password;
            }
        }
    }
}
