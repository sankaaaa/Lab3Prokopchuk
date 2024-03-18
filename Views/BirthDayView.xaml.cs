﻿using Lab3Prokopchuk.ViewModels;
using System;
using System.Windows.Controls;

namespace Lab3Prokopchuk.Views
{
    /// <summary>
    /// Interaction logic for BirthDayView.xaml
    /// </summary>
    public partial class BirthDayView : UserControl
    {
        private readonly BirthDayViewModel _viewModel;

        public BirthDayView()
        {
            InitializeComponent();
            DataContext = _viewModel = new BirthDayViewModel();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = datePicker.SelectedDate;
            if (selectedDate != null)
            {
                _viewModel.Date = selectedDate.Value;
            }
        }
    }
}