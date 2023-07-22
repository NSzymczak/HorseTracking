using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace HorseTrackingDesktop.View
{
    /// <summary>
    /// Logika interakcji dla klasy VisitDetailsView.xaml
    /// </summary>
    public partial class VisitDetailsView : Window
    {
        private AddVisitViewModel? viewModel;

        public VisitDetailsView(Visits? visits = null)
        {
            InitializeComponent();
            viewModel = StartUp.ServiceProvider?.GetService<AddVisitViewModel>();
            DataContext = viewModel;
            if (viewModel != null)
            {
                Loaded += async (s, e) =>
                {
                    await viewModel.SetUp();

                    if (visits != null)
                    {
                        viewModel.SetVist(visits);
                    }
                    else
                    {
                        viewModel.SetDefault();
                    }
                };
            }
        }
    }
}