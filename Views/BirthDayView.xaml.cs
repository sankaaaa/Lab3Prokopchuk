using Lab3Prokopchuk.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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