using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.PageModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HorseTrackingDesktop.View
{
    /// <summary>
    /// Logika interakcji dla klasy VisitPage.xaml
    /// </summary>
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(pageModel== null)
                return;
            _ = pageModel.SwitchHorse();
        }
    }
}
