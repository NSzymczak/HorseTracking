using HorseTrackingDesktop.Control;
using HorseTrackingDesktop.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace HorseTrackingDesktop.View
{
    public partial class MainView : Window
    {
        private MainViewModel? viewModel;

        public MainView()
        {
            InitializeComponent();
            viewModel = StartUp.ServiceProvider?.GetService<MainViewModel>();
            if (viewModel != null)
            {
                DataContext = viewModel;
            }
            navigationFrame.Navigate(Statistic.Routing);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is NavigationButton selectedpage)
            {
                navigationFrame.Navigate(selectedpage.Routing);
            }
        }
    }
}