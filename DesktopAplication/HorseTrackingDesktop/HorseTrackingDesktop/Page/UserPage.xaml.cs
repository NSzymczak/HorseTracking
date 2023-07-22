using HorseTrackingDesktop.PageModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace HorseTrackingDesktop.View
{
    /// <summary>
    /// Logika interakcji dla klasy UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private readonly UserPageModel? UserPageModel;

        public UserPage()
        {
            InitializeComponent();
            UserPageModel = StartUp.ServiceProvider?.GetService<UserPageModel>();
            DataContext = UserPageModel;
        }
    }
}