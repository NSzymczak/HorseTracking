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
    public partial class ShareHorseSearchView : ContentPage
    {
        public ShareHorseSearchView()
        {
            InitializeComponent();
            var viewModel = Startup.ServiceProvider?.GetService<ShareHorseSearchViewModel>();
            if (viewModel != null)
            {
                BindingContext = viewModel;
                Appearing += ((s, e) =>
                {
                    viewModel.Load();
                });
            }
        }
    }
}