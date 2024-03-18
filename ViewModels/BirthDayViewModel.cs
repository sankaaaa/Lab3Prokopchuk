using Lab3Prokopchuk.Models;
using Lab3Prokopchuk.Tools.Extensions;
using Lab3Prokopchuk.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
        private string _lastname;
        private string _email;
        private DateTime _date;

        private string _userData = "";
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
        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged("Lastname");
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
        public string UserData
        {
            get { return _userData; }
            set
            {
                _userData = value;
                OnPropertyChanged("UserData");
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
            UserData = "";
            try
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(500);
                    Person = new Person(Name, Lastname, Email, Date);
                    UserData = Person.ToString();
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
                && !string.IsNullOrWhiteSpace(Lastname)
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
