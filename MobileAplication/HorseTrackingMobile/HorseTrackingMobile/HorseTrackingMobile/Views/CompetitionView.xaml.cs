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
    public partial class CompetitionView : ContentPage
    {
        private CompetitionViewModel viewModel;

        public CompetitionView()
        {
            InitializeComponent();
            viewModel = Startup.ServiceProvider.GetService<CompetitionViewModel>();
            BindingContext = viewModel;
            Appearing += (s, e) =>
            {
                viewModel.Load();
            };
        }
    }
}