using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HorseTrackingMobile.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisitDetailsView : ContentPage
    {
        VisitDetailsViewModel viewModel;
        public VisitDetailsView()
        {
            InitializeComponent();
            viewModel= Startup.ServiceProvider.GetService<VisitDetailsViewModel>();
            BindingContext = viewModel;
        }
    }
}