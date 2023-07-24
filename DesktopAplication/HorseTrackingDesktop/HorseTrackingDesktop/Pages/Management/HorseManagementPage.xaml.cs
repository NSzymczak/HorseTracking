using HorseTrackingDesktop.Management.PageModel;
using HorseTrackingDesktop.PageModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HorseTrackingDesktop.Pages.ManagmentPage
{
    public partial class HorseManagmentPage : Page
    {
        private HorseManagmentPageModel? managmentPageModel;

        public HorseManagmentPage()
        {
            InitializeComponent();
            managmentPageModel = StartUp.ServiceProvider?.GetService<HorseManagmentPageModel>();
            DataContext = managmentPageModel;
            Loaded += async (s, e) =>
            {
                await managmentPageModel.GetHorses();
            };
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var s = sender;
            var erg = e;
        }
    }
}