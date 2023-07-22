﻿using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace HorseTrackingDesktop.View
{
    /// <summary>
    /// Logika interakcji dla klasy AddVisitView.xaml
    /// </summary>
    public partial class AddVisitView : Window
    {
        private AddVisitViewModel? viewModel;

        public AddVisitView(Visits? visits = null)
        {
            InitializeComponent();
            viewModel = StartUp.ServiceProvider?.GetService<AddVisitViewModel>();
            DataContext = viewModel;
            if (viewModel != null)
            {
                Loaded += async (s, e) =>
                {
                    await viewModel.SetUp();

                    if (visits != null)
                    {
                        viewModel.SetVist(visits);
                    }
                    else
                    {
                        viewModel.SetDefault();
                    }
                };
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}