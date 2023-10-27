using HorseTrackingDesktop.PageModel.Main;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace HorseTrackingDesktop.Pages.MainPage
{
    public partial class NutritionPage : Page
    {
        private NutritionPageModel? pageModel;

        public NutritionPage()
        {
            InitializeComponent();
            pageModel = StartUp.ServiceProvider?.GetService<NutritionPageModel>();
            DataContext = pageModel;
            if (pageModel != null)
            {
                Loaded += async (s, e) => await pageModel.GetPlans();
            }
        }
    }
}