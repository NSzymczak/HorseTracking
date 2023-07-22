using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace HorseTrackingDesktop.View
{
    public partial class AddVisitView : Window
    {
        private AddVisitViewModel? viewModel;

        public AddVisitView(Visits? visits = null)
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