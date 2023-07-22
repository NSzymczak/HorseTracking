using HorseTrackingDesktop.PageModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using System.Windows.Input;

namespace HorseTrackingDesktop.View
{
    public partial class VisitPage : Page
    {
        VisitPageModel? pageModel;
        public VisitPage()
        {
            InitializeComponent();
            pageModel = StartUp.ServiceProvider?.GetService<VisitPageModel>();
            DataContext= pageModel;
            if(pageModel != null )
            {
                Loaded += async(s, e) => await pageModel.SetUp();
            }
        }

        private async void SwitchHorses(object sender, SelectionChangedEventArgs e)
        {
            if(pageModel== null)
            {
                return;
            }
            await pageModel.SwitchHorse();
        }

        private void GotoDetails(object sender, MouseButtonEventArgs e)
        {
            if(pageModel== null)
            {
                return;
            }
            pageModel.GoToDetails();
        }
    }
}
