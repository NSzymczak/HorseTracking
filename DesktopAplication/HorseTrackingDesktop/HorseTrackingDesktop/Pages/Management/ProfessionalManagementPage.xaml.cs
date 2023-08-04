using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Models.Dto;
using HorseTrackingDesktop.PageModel.Management;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace HorseTrackingDesktop.Pages.ManagmentPage
{
    /// <summary>
    /// Logika interakcji dla klasy ProfessionalManagmentPage.xaml
    /// </summary>
    public partial class ProfessionalManagmentPage : Page
    {
        private ProfessionalManagementPageModel? managementPageModel;

        public ProfessionalManagmentPage()
        {
            InitializeComponent();
            managementPageModel = StartUp.ServiceProvider?.GetService<ProfessionalManagementPageModel>();
            DataContext = managementPageModel;
            Loaded += async (s, e) =>
            {
                if (managementPageModel != null)
                    await managementPageModel.SetUp();
            };
        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var dataGrid = (sender as DataGrid);
            if (dataGrid == null)
            {
                return;
            }
            if (dataGrid.SelectedItem != null)
            {
                dataGrid.RowEditEnding -= DataGrid_RowEditEnding;
                dataGrid.CommitEdit();
                dataGrid.Items.Refresh();
                dataGrid.RowEditEnding += DataGrid_RowEditEnding;
            }

            var professional = dataGrid.SelectedItem as ProfessionalsDto;

            if (professional != null)
            {
                if (professional.Specialisation == null || professional.Surname == null)
                {
                    managementPageModel?.GetProfessional();

                    return;
                }

                managementPageModel?.Add(professional);
            }
        }
    }
}