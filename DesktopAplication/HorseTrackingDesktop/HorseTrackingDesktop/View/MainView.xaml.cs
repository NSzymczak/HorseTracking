using HorseTrackingDesktop.Control;
using System.Windows;

namespace HorseTrackingDesktop.View
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            navigationFrame.Navigate(Statistic.Routing);
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