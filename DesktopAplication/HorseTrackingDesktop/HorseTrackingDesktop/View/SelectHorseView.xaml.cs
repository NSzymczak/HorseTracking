using HorseTrackingDesktop.Enumerable;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HorseTrackingDesktop.View
{
    public partial class SelectHorseView : Window
    {
        public SelectHorseViewModel? viewModel;

        public SelectHorseView()
        {
            InitializeComponent();
            viewModel = StartUp.ServiceProvider?.GetService<SelectHorseViewModel>();
            DataContext = viewModel;
            if (viewModel != null)
            {
                Loaded += async (s, e) => await viewModel.SetUP();
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (viewModel == null)
                return;

            var horses = ((ListBox)sender).SelectedItems.Cast<Horses>().ToList();

            if (horses == null)
                return;
            viewModel.SelectedHorses = horses;
        }
    }
}