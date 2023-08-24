using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace HorseTrackingDesktop.View
{
    /// <summary>
    /// Logika interakcji dla klasy AddUserForHorseView.xaml
    /// </summary>
    public partial class AddUserForHorseView : Window
    {
        private AddUserForHorseViewModel? viewModel;

        public AddUserForHorseView(Horses horse)
        {
            InitializeComponent();
            viewModel = StartUp.ServiceProvider?.GetService<AddUserForHorseViewModel>();
            DataContext = viewModel;
            Loaded += async (s, e) =>
            {
                if (viewModel != null)
                {
                    viewModel.Horse = horse;
                    await viewModel.SetUp();
                }
            };
        }
    }
}