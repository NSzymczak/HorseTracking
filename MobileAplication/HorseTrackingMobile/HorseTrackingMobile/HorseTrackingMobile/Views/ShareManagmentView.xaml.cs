using HorseTrackingMobile.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HorseTrackingMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShareManagmentView : ContentPage
    {
        public ShareManagmentView()
        {
            InitializeComponent();
            var viewModel = Startup.ServiceProvider?.GetService<ShareManagmentViewModel>();
            if (viewModel != null)
            {
                BindingContext = viewModel;
            }
        }
    }
}