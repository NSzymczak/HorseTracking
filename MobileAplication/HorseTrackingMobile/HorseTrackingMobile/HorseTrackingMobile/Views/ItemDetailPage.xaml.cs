using HorseTrackingMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace HorseTrackingMobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}