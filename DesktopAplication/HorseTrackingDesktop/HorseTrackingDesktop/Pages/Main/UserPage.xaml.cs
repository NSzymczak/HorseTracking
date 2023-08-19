using HorseTrackingDesktop.Control;
using HorseTrackingDesktop.PageModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace HorseTrackingDesktop.Pages.MainPage
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
            navigationFrame.Navigate(User.Routing);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is NavigationButton selectedpage)
            {
                navigationFrame.Navigate(selectedpage.Routing);
            }
        }
    }
}