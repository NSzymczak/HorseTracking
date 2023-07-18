using HorseTrackingMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HorseTrackingMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddVisitView : ContentPage
    {
        VisitDetailsViewModel viewmodel;

        public AddVisitView()
        {
            InitializeComponent();
            viewmodel = Startup.ServiceProvider.GetService<VisitDetailsViewModel>();
            BindingContext = viewmodel;
        }
    }
}