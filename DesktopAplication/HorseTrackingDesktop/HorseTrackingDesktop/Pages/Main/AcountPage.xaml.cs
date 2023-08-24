using HorseTrackingDesktop.PageModel;
using HorseTrackingDesktop.PageModel.Main;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace HorseTrackingDesktop.Pages.MainPage
{
    public partial class AcountPage : Page
    {
        private AcountPageModel? pageModel;

        public AcountPage()
        {
            InitializeComponent();
            pageModel = StartUp.ServiceProvider?.GetService<AcountPageModel>();
            if (pageModel != null)
            {
                DataContext = pageModel;
            }
        }
    }
}