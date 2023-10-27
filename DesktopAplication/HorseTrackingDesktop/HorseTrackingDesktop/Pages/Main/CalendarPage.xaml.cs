using HorseTrackingDesktop.PageModel.Main;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HorseTrackingDesktop.Pages.MainPage
{
    public partial class CalendarPage : Page
    {
        public CalendarPage()
        {
            InitializeComponent();
            var pageModel = StartUp.ServiceProvider?.GetService<CalendarPageModel>();

            if (pageModel != null)
            {
                DataContext = pageModel;
                Loaded += async (e, s) =>
                {
                    await pageModel.Load();
                };
            }
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            var border = sender as Border;
            if (border == null)
            {
                return;
            }
            border.Opacity = 1;
            string hexColor = "#95B17F"; // Przykładowy kolor czerwony
            var brush = (SolidColorBrush)new BrushConverter().ConvertFrom(hexColor);
            if (brush != null)
            {
                border.Background = brush;
            }
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            var border = sender as Border;
            if (border == null)
            {
                return;
            }
            border.Opacity = 0.6;
            string hexColor = "#FFFFFF"; // Przykładowy kolor czerwony
            var brush = (SolidColorBrush)new BrushConverter().ConvertFrom(hexColor);
            if (brush != null)
            {
                border.Background = brush;
            }
        }
    }
}