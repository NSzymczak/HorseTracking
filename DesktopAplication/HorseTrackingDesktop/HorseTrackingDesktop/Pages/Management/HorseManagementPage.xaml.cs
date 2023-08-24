using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.PageModel.Management;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

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
                if (managmentPageModel != null)
                    await managmentPageModel.GetHorses();
            };
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var editedTextBox = e.EditingElement as TextBox;
                if (editedTextBox != null)
                {
                    var columnName = (e.EditingElement as FrameworkElement)?.Name;
                    var editedText = editedTextBox.Text;
                    if (editedText != null && columnName != null)
                    {
                        var result = managmentPageModel?.CellValid(columnName, editedText) ?? false;
                    }
                }
            }
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

            var horse = dataGrid.SelectedItem as Horses;
            if (horse != null)
            {
                if (horse.Gender == null || horse.Status == null)
                {
                    managmentPageModel?.GetHorses();

                    return;
                }

                managmentPageModel?.AddHorse(horse);
            }
        }
    }
}