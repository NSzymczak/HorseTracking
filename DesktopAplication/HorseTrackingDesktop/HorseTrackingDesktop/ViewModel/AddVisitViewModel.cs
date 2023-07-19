using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HorseTrackingDesktop.ViewModel
{
    public partial class AddVisitViewModel
    {

        [RelayCommand]
        public Task GoBack(Window window)
        {
            window.Close();
            return Task.CompletedTask;
        }
    }
}
