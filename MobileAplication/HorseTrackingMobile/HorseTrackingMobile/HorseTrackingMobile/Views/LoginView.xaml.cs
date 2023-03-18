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
        public LoginView()
        {
            InitializeComponent();
            var viewModel=new LoginViewModel();
            this.BindingContext = viewModel;
            Appearing += (s,e) => { viewModel.CheckLogin(); };
        }

    }
}