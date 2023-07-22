using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.ViewModel;
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
using System.Windows.Shapes;

namespace HorseTrackingDesktop.View
{
    /// <summary>
    /// Logika interakcji dla klasy VisitDetailsView.xaml
    /// </summary>
    public partial class VisitDetailsView : Window
    {
        AddVisitViewModel? viewModel;

        public VisitDetailsView(Visits? visits = null)
        {
            InitializeComponent();
            viewModel = StartUp.ServiceProvider?.GetService<AddVisitViewModel>();
            DataContext = viewModel;
            if (viewModel != null)
            {
                Loaded += async (s, e) =>
                {
                    await viewModel.SetUp();

                    if (visits != null)
                    {
                        viewModel.SetVist(visits);
                    }
                    else
                    {
                        viewModel.SetDefault();
                    }

                };
            }
        }
    }
}
