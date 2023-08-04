using HorseTrackingDesktop.Models.Dto;
using HorseTrackingDesktop.PageModel.Management;
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
    /// <summary>
    /// Logika interakcji dla klasy UserManagmentPage.xaml
    /// </summary>
    public partial class UserManagmentPage : Page
    {
        private UserManagementPageModel? managementPageModel;

        public UserManagmentPage()
        {
            InitializeComponent();
            managementPageModel = StartUp.ServiceProvider?.GetService<UserManagementPageModel>();
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

            var user = dataGrid.SelectedItem as UserDto;

            if (user != null)
            {
                if (user.Type == null || user.Surname == null)
                {
                    managementPageModel?.GetUsers();

                    return;
                }

                managementPageModel?.Add(user);
            }
        }
    }
}