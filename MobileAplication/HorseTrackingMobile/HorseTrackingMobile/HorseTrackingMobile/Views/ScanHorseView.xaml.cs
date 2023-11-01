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
    public partial class ScanHorseView : ContentPage
    {
        private ScanHorseViewModel viewModel;

        public ScanHorseView()
        {
            InitializeComponent();
            viewModel = Startup.ServiceProvider?.GetService<ScanHorseViewModel>();
            if (viewModel != null)
            {
                BindingContext = viewModel;
            }
        }

        private async void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            if (viewModel != null)
            {
                var text = result.Text;
                await viewModel.Scan(text);
            }
        }
    }
}