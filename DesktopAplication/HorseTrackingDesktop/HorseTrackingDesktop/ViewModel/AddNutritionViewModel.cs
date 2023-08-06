using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Models;
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
    public partial class AddNutritionViewModel : BaseViewModel
    {
        private readonly INutritionService _nutritionService;
        public string Title { get; set; }
        public string Color { get; set; }
        public int Icon { get; set; }
        public string Description { get; set; }

        public List<MealNames> AllMealsName { get; set; }
        public List<UnitOfMeasures> AllUnit { get; set; }
        public List<Forages> AllForage { get; set; }
        public ObservableCollection<Meals> Meals { get; set; }

        public AddNutritionViewModel(INutritionService nutritionService)
        {
            _nutritionService = nutritionService;
            Meals = new ObservableCollection<Meals>();
        }

        public async Task LoadData()
        {
            AllForage = (await _nutritionService.GetForage()).ToList();
            AllMealsName = (await _nutritionService.GetMealName()).ToList();
            AllUnit = (await _nutritionService.GetUnitOfMeasure()).ToList();
            OnPropertyChanged(nameof(AllForage));
            OnPropertyChanged(nameof(AllMealsName));
            OnPropertyChanged(nameof(AllUnit));
        }

        [RelayCommand]
        public void AddMeal()
        {
            var newMeal = new Meals()
            {
                Portions = new ObservableCollection<Portions>()
                {
                    new Portions()
                }
            };
            Meals.Add(newMeal);
        }

        [RelayCommand]
        public void RemoveMeal()
        {
            Meals.RemoveAt(Meals.Count - 1);
        }

        [RelayCommand]
        public void AddPortion(Meals meals)
        {
            meals.Portions.Add(new Portions());
        }

        [RelayCommand]
        public void RemovePortion(Meals meals)
        {
            var portionToRemove = meals.Portions.ElementAt(meals.Portions.Count - 1);
            meals.Portions.Remove(portionToRemove);
        }

        [RelayCommand]
        public void AddNutritionPlan(Window window)
        {
            var nutritionPlan = new NutritionPlans()
            {
                Title = Title,
                Icon = Icon,
                Color = Color,
                Description = Description,
                Meals = Meals
            };

            if (CheckNutritionPlan(nutritionPlan))
            {
                _nutritionService.AddNutritionPlan(nutritionPlan);
                window.Close();
            }
            else
            {
            }
        }

        public bool CheckNutritionPlan(NutritionPlans plan)
        {
            if (plan.Title == null)
                return false;
            foreach (var meals in plan.Meals)
            {
                if (meals.MealName == null)
                    return false;
                foreach (var portion in meals.Portions)
                {
                    if (portion.Unit == null || portion.Forage == null || portion.Amount == 0)
                        return false;
                }
            }
            return true;
        }
    }
}