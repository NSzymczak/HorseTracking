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
    public partial class VisitView : ContentPage
    {

        VisitViewModel viewModel = new VisitViewModel();
        public VisitView()
        {
            InitializeComponent();
            BindingContext = viewModel;
            Appearing += (s, e) => 
            { 
                viewModel.LoadVisit(); 
            };
        }
        private void SwichHorse(object sender, EventArgs e)
        {
            viewModel.SwitchHorseCommand.Execute(true);
        }
    }
}