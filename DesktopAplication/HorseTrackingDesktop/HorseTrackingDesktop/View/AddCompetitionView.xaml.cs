using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows;

namespace HorseTrackingDesktop.View
{
    public partial class AddCompetitionView : Window
    {
        private AddCompetitionViewModel? viewModel;

        public AddCompetitionView(Competitions? competitions = null)
        {
            InitializeComponent();
            viewModel = StartUp.ServiceProvider?.GetService<AddCompetitionViewModel>();
            if (viewModel != null)
            {
                DataContext = viewModel;
                if (competitions != null)
                {
                    viewModel.Title = "Edytuj zawody";
                    viewModel.IsEdit = true;
                    viewModel.Spot = competitions.Spot;
                    viewModel.Date = competitions.Date;
                    viewModel.Description = competitions.Description;
                    viewModel.Rank = competitions.Rank;
                    viewModel.ListOfContests = new ObservableCollection<Contests>(competitions.Contests);
                }
                else
                {
                    viewModel.Title = "Dodaj zawody";
                }
            }
        }
    }
}