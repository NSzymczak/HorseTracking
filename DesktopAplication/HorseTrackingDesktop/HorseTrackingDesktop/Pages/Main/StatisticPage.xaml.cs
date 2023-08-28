using HorseTrackingDesktop.PageModel;
using System.Windows;
using System.Windows.Controls;

namespace HorseTrackingDesktop.Pages.MainPage
{
    public partial class StatisticPage : Page
    {
        private StatisticPageModel viewModel;

        public StatisticPage()
        {
            InitializeComponent();
            // viewModel = new StatisticPageModel();
            DataContext = viewModel;
        }
    }
}