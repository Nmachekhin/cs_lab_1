using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MachekhinZodiak
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private ZodiakCalculator _datesToZodiakCalculator;
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<bool> IncorrectDate;

        private DateTime _selectedDate;

        public ViewModel()
        { 
            _datesToZodiakCalculator = new ZodiakCalculator();
            _datesToZodiakCalculator.PropertyChanged += OnModelPropertyChanged;
            Date = _datesToZodiakCalculator.Date;
        }

        public DateTime Date
        {
            get { return _selectedDate; }
            set { _selectedDate=value; }
        }

        public bool IsDateValid
        {
            get { return _datesToZodiakCalculator.IsDateValid; }
        }



        private void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case (nameof(ZodiakCalculator.Date)):
                    Date = _datesToZodiakCalculator.Date;
                    OnPropertyChanged(nameof(Date));
                    break;
                case (nameof(ZodiakCalculator.IsDateValid)):
                    if (!IsDateValid) IncorrectDate.Invoke(this, false);
                    break;
            }
        }

        public void ConfirmDateButtonClick(object sender, RoutedEventArgs e)
        {
            _datesToZodiakCalculator.Date = Date;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
