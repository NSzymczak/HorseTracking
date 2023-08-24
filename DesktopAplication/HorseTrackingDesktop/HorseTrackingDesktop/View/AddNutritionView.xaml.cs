using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

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