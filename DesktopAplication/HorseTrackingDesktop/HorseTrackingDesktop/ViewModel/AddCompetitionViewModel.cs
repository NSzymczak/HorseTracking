using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.Database.CompetitionService;
using HorseTrackingDesktop.Services.Database.NutritionService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HorseTrackingDesktop.ViewModel
{
    public partial class AddCompetitionViewModel : BaseViewModel
    {
        private readonly ICompetitionService _competitionService;

        private string? spot;
        private string? rank;
        private DateTime? date;
        private string? description;

        public string? Spot
        {
            get => spot;
            set => SetProperty(ref spot, value);
        }

        public string? Rank
        {
            get => rank;
            set => SetProperty(ref rank, value);
        }

        public DateTime? Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public string? Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string Title { get; set; }
        public bool IsEdit { get; set; } = false;

        public ObservableCollection<Contests> ListOfContests { get; set; }

        public AddCompetitionViewModel(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
            ListOfContests = new ObservableCollection<Contests>();
        }

        [RelayCommand]
        public void AddContests()
        {
            var contests = new Contests();
            ListOfContests?.Add(contests);
            OnPropertyChanged(nameof(ListOfContests));
        }

        [RelayCommand]
        public void RemoveContests()
        {
            if (ListOfContests.Count > 0)
            {
                ListOfContests?.RemoveAt(ListOfContests.Count - 1);
                OnPropertyChanged(nameof(ListOfContests));
            }
        }

        [RelayCommand]
        public async Task AddCompetiton(Window window)
        {
            var competition = new Competitions()
            {
                Contests = ListOfContests,
                Spot = Spot,
                Description = Description,
            };

            if (!Date.HasValue)
            {
                return;
            }
            competition.Date = Date.Value;
            if (CheckCompetition(competition))
            {
                if (IsEdit)
                {
                    await _competitionService.AddCompetiton(competition);
                    window.Close();
                }
                else
                {
                    await _competitionService.EditCompetition(competition);
                    window.Close();
                }
            }
            else
            {
                MessageBox.Show("Uzupełnij poprawnie wszystkie dane");
            }
        }

        public bool CheckCompetition(Competitions competitions)
        {
            if (competitions == null)
                return false;
            if (competitions.Contests == null)
                return false;
            if (competitions.Spot == null || competitions.Spot == String.Empty)
                return false;
            foreach (var con in competitions.Contests)
            {
                if (con.Name == null || con.Name == String.Empty)
                    return false;
                if (con.Level == null || con.Level == String.Empty)
                    return false;
            }
            return true;
        }
    }
}