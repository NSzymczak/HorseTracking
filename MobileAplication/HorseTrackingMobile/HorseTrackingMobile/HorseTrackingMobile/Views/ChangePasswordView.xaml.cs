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
    public partial class ChangePasswordView : ContentPage
    {
        private readonly ChangePasswordViewModel viewModel;

        public ChangePasswordView()
        {
            InitializeComponent();

            viewModel = Startup.ServiceProvider.GetService<ChangePasswordViewModel>();
            BindingContext = viewModel;
        }
    }
}