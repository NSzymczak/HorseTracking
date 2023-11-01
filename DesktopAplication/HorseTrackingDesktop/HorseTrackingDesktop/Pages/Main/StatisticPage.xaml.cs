using HorseTrackingDesktop.PageModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace HorseTrackingDesktop.Pages.MainPage
{
    public partial class StatisticPage : Page
    {
        private StatisticPageModel? viewModel;

        public StatisticPage()
        {
            InitializeComponent();
            viewModel = StartUp.ServiceProvider?.GetService<StatisticPageModel>();
            if (viewModel != null)
            {
                DataContext = viewModel;
                Loaded += async (e, s) =>
                {
                    await viewModel.Load();
                };
            }
        }

        private void PieChart_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            var d = 1;
        }
    }
}