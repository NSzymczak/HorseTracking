using HorseTrackingDesktop.PageModel.Main;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using System.Windows.Input;

namespace HorseTrackingDesktop.Pages.MainPage
{
    /// <summary>
    /// Logika interakcji dla klasy CompetitionPage.xaml
    /// </summary>
    public partial class CompetitionPage : Page
    {
        public readonly CompetitionPageModel? pageModel;

        public CompetitionPage()
        {
            InitializeComponent();
            pageModel = StartUp.ServiceProvider?.GetService<CompetitionPageModel>();

            if (pageModel != null)
            {
                DataContext = pageModel;
                Loaded += async (e, s) =>
                {
                    await pageModel.Load();
                };
            }
        }
    }
}