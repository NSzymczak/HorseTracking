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
    /// Logika interakcji dla klasy AddNutritionView.xaml
    /// </summary>
    public partial class AddNutritionView : Window
    {
        private readonly AddNutritionViewModel? viewModel;

        public AddNutritionView(NutritionPlans? nutrition = null, Horses? horse = null)
        {
            InitializeComponent();
            viewModel = StartUp.ServiceProvider?.GetService<AddNutritionViewModel>();
            DataContext = viewModel;
            Loaded += async (s, e) =>
            {
                if (viewModel != null)
                {
                    if (nutrition != null)
                        viewModel.NutritionPlans = nutrition;
                    if (horse != null)
                        viewModel.Horse = horse;
                    await viewModel.LoadData();
                }
            };
        }
    }
}