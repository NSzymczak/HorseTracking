using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.Database.NutritionService;
using HorseTrackingDesktop.View;
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
        private string? title;

        public string? Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        private string? color;

        public string? Color
        {
            get => color;
            set => SetProperty(ref color, value);
        }

        private int? icon;

        public int? Icon
        {
            get => icon;
            set => SetProperty(ref icon, value);
        }

        private string? description;

        public string? Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public NutritionPlans? NutritionPlans { get; set; }
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
            if (NutritionPlans != null)
            {
                Title = NutritionPlans.Title;
                Color = NutritionPlans.Color;
                Description = NutritionPlans.Description;
                var meals = (await _nutritionService.GetMealsForPlan(NutritionPlans.NutritionPlanId)).ToList();
                Meals = new ObservableCollection<Meals>(meals);
                OnPropertyChanged(nameof(Meals));
            }
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
                new SelectHorseView(false, nutritionPlan).ShowDialog();
                window.Close();
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