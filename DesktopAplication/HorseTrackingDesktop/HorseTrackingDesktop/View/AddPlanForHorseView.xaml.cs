using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.ViewModel;
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
using System.Windows.Shapes;

namespace HorseTrackingDesktop.View
{
    /// <summary>
    /// Logika interakcji dla klasy AddPlanForHorse.xaml
    /// </summary>
    public partial class AddPlanForHorseView : Window
    {
        private AddPlanForHorseViewModel? viewModel;

        public AddPlanForHorseView(NutritionPlans nutritionPlans)
        {
            InitializeComponent();
            viewModel = StartUp.ServiceProvider?.GetService<AddPlanForHorseViewModel>();
            DataContext = viewModel;
            if (viewModel != null)
            {
                viewModel.Plans = nutritionPlans;
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