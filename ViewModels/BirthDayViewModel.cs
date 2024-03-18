using Lab3Prokopchuk.Models;
using Lab3Prokopchuk.Tools.Extensions;
using Lab3Prokopchuk.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Lab3Prokopchuk.ViewModels
{
    class BirthDayViewModel : INotifyPropertyChanged
    {
        #region Fields
        private Person _person;
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _date;

        private string _information = "";
        private bool _enableButton = true;

        private RelayCommand<object> _proceedCommand;
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }
        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged("Person");
            }
        }
        public string Information
        {
            get { return _information; }
            set
            {
                _information = value;
                OnPropertyChanged("Information");
            }
        }
        public bool ProceedEnabled
        {
            get { return _enableButton; }
            set
            {
                _enableButton = value;
                OnPropertyChanged("ProceedEnabled");
            }
        }
        public RelayCommand<object> ProceedCommand
        {
            get { return _proceedCommand ??= new RelayCommand<object>(InfomationProceedCommand, _ => CanExecute()); }
        }
        #endregion

        private async void InfomationProceedCommand(object obj)
        {
            Information = "";
            try
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(500);
                    Person = new Person(Name, Surname, Email, Date);
                    Information = Person.ToString();
                    Thread.Sleep(500);
                });
            }
            catch (MyException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private bool CanExecute()
        {
            return !string.IsNullOrWhiteSpace(Name)
                && !string.IsNullOrWhiteSpace(Surname)
                && !string.IsNullOrWhiteSpace(Email)
                && Date != DateTime.MinValue;
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
