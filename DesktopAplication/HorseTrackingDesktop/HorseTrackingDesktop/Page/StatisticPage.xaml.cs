using HorseTrackingDesktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HorseTrackingDesktop.PageModel;

namespace HorseTrackingDesktop.View
{
    /// <summary>
    /// Logika interakcji dla klasy StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage : Page
    {
        StatisticPageModel viewModel;
        public StatisticPage()
        {
            InitializeComponent();
            viewModel = new StatisticPageModel();
            DataContext = viewModel;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           // viewModel.LoadData();
        }
    }
}
