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
    public partial class AddActivityView : ContentPage
    {
        ActivityDetailsViewModel viewmodel;
        public AddActivityView()
        {
            InitializeComponent();
            viewmodel = new ActivityDetailsViewModel();
            BindingContext = viewmodel;
        }



        private void SatisfactionLevel(object sender, EventArgs e)
        {
            if (((Button)sender) == Satisfactionlvl1)
            {
                Satisfactionlvl1.BackgroundColor = Color.FromHex("#BFE390");
                Satisfactionlvl2.BackgroundColor = Color.White;
                Satisfactionlvl3.BackgroundColor = Color.White;
                Satisfactionlvl4.BackgroundColor = Color.White;
                Satisfactionlvl5.BackgroundColor = Color.White;
                viewmodel.Satisfaction = 1;
            }
            if (((Button)sender) == Satisfactionlvl2)
            {
                Satisfactionlvl1.BackgroundColor = Color.FromHex("#BFE390");
                Satisfactionlvl2.BackgroundColor = Color.FromHex("#BFE390");
                Satisfactionlvl3.BackgroundColor = Color.White;
                Satisfactionlvl4.BackgroundColor = Color.White;
                Satisfactionlvl5.BackgroundColor = Color.White;
                viewmodel.Satisfaction = 2;
            }
            if (((Button)sender) == Satisfactionlvl3)
            {
                Satisfactionlvl1.BackgroundColor = Color.FromHex("#BFE390");
                Satisfactionlvl2.BackgroundColor = Color.FromHex("#BFE390");
                Satisfactionlvl3.BackgroundColor = Color.FromHex("#BFE390");
                Satisfactionlvl4.BackgroundColor = Color.White;
                Satisfactionlvl5.BackgroundColor = Color.White;
                viewmodel.Satisfaction = 3;
            }
            if (((Button)sender) == Satisfactionlvl4)
            {
                Satisfactionlvl1.BackgroundColor = Color.FromHex("#BFE390");
                Satisfactionlvl2.BackgroundColor = Color.FromHex("#BFE390");
                Satisfactionlvl3.BackgroundColor = Color.FromHex("#BFE390");
                Satisfactionlvl4.BackgroundColor = Color.FromHex("#BFE390");
                Satisfactionlvl5.BackgroundColor = Color.White;
                viewmodel.Satisfaction = 4;
            }
            if (((Button)sender) == Satisfactionlvl5)
            {
                Satisfactionlvl1.BackgroundColor = Color.FromHex("#BFE390");
                Satisfactionlvl2.BackgroundColor = Color.FromHex("#BFE390");
                Satisfactionlvl3.BackgroundColor = Color.FromHex("#BFE390");
                Satisfactionlvl4.BackgroundColor = Color.FromHex("#BFE390");
                Satisfactionlvl5.BackgroundColor = Color.FromHex("#BFE390");
                viewmodel.Satisfaction = 5;
            }
            else
            {
                viewmodel.Satisfaction = 0;
            }
        }

        private void IntensivityLevel(object sender, EventArgs e)
        {
            if (((Button)sender) == Intensivitylv1)
            {
                Intensivitylv1.BackgroundColor = Color.FromHex("#BFE390");
                Intensivitylv2.BackgroundColor = Color.White;
                Intensivitylv3.BackgroundColor = Color.White;
                Intensivitylv4.BackgroundColor = Color.White;
                Intensivitylv5.BackgroundColor = Color.White;
                viewmodel.Intensivity = 1;
            }
            if (((Button)sender) == Intensivitylv2)
            {
                Intensivitylv1.BackgroundColor = Color.FromHex("#BFE390");
                Intensivitylv2.BackgroundColor = Color.FromHex("#BFE390");
                Intensivitylv3.BackgroundColor = Color.White;
                Intensivitylv4.BackgroundColor = Color.White;
                Intensivitylv5.BackgroundColor = Color.White;
                viewmodel.Intensivity = 2;

            }
            if (((Button)sender) == Intensivitylv3)
            {
                Intensivitylv1.BackgroundColor = Color.FromHex("#BFE390");
                Intensivitylv2.BackgroundColor = Color.FromHex("#BFE390");
                Intensivitylv3.BackgroundColor = Color.FromHex("#BFE390");
                Intensivitylv4.BackgroundColor = Color.White;
                Intensivitylv5.BackgroundColor = Color.White;
                viewmodel.Intensivity = 3;
            }
            if (((Button)sender) == Intensivitylv4)
            {
                Intensivitylv1.BackgroundColor = Color.FromHex("#BFE390");
                Intensivitylv2.BackgroundColor = Color.FromHex("#BFE390");
                Intensivitylv3.BackgroundColor = Color.FromHex("#BFE390");
                Intensivitylv4.BackgroundColor = Color.FromHex("#BFE390");
                Intensivitylv5.BackgroundColor = Color.White;
                viewmodel.Intensivity = 4;
            }
            if (((Button)sender) == Intensivitylv5)
            {
                Intensivitylv1.BackgroundColor = Color.FromHex("#BFE390");
                Intensivitylv2.BackgroundColor = Color.FromHex("#BFE390");
                Intensivitylv3.BackgroundColor = Color.FromHex("#BFE390");
                Intensivitylv4.BackgroundColor = Color.FromHex("#BFE390");
                Intensivitylv5.BackgroundColor = Color.FromHex("#BFE390");
                viewmodel.Intensivity = 5;
            }
            else
            {
                viewmodel.Intensivity = 0;
            }
        }
    }
}