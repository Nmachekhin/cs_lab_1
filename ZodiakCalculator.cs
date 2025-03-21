using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Controls;

namespace MachekhinZodiak
{
    public class ZodiakCalculator : INotifyPropertyChanged
    {
        private DateTime _date;
        private int _age;
        private bool _dateValid = false;


        public ZodiakCalculator()
        {
            Date = DateTime.Today;
        }

        public int Age
        {
            get => _age;
        }

        private void CalculateAge()
        {
            DateTime today = DateTime.Today;
            _age = (DateTime.Today.Year - Date.Year);
            if (DateTime.Today.Month < Date.Month) _age--;
            if (DateTime.Today.Month == Date.Month && DateTime.Today.Day > Date.Day) _age--;
            OnPropertyChanged(nameof(Age));
        }


        public bool IsDateValid
        {
            get => _dateValid;
        }

        public DateTime Date
        {
            get { return _date; }
            set 
            {
                if (DateValidator(value))
                {
                    _date = value;
                    _dateValid = true;
                    CalculateAge();
                    Trace.WriteLine(Age);
                    
                }
                else
                {
                    _date = DateTime.Today;
                    _dateValid = false;
                }
                OnPropertyChanged(nameof(IsDateValid));
                OnPropertyChanged(nameof(Date));
                

            }
        }


        private bool DateValidator(DateTime date)
        {
            DateTime today = DateTime.Today;
            return today >= date && (today.Year - date.Year) <= 135;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
