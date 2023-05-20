using HorseTrackingMobile.Models;
using HorseTrackingMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HorseTrackingMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        readonly LoginViewModel viewModel;
        public LoginView()
        {
            InitializeComponent();
            viewModel = Startup.ServiceProvider.GetService<LoginViewModel>();
            BindingContext = viewModel;
            Appearing += (s, e) => { viewModel.CheckLogin(); };
        }

    }
}