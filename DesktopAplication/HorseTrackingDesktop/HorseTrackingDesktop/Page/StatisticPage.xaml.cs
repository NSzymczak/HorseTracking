﻿using HorseTrackingDesktop.PageModel;
using System.Windows;
using System.Windows.Controls;

namespace HorseTrackingDesktop.View
{
    /// <summary>
    /// Logika interakcji dla klasy StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage : Page
    {
        private StatisticPageModel viewModel;

        public StatisticPage()
        {
            InitializeComponent();
            viewModel = new StatisticPageModel();
            DataContext = viewModel;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // viewModel.LoadData();
        }
    }
}