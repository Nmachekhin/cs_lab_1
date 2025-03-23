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
    internal class ZodiakCalculator : INotifyPropertyChanged
    {
        private DateTime _date;
        private int _age;
        private bool _dateValid = false;
        private bool _isBirthdayToday = false;
        private ZodiakSign _currentSign=null;
        private static ZodiakSign[] s_zodiakSignsTimespan = {
            new ZodiakSign(new DateTime(1, 3, 21), new DateTime(1, 4, 19), "Aries"),
            new ZodiakSign(new DateTime(1, 4, 20), new DateTime(1, 5, 20), "Taurus"),
            new ZodiakSign(new DateTime(1, 5, 21), new DateTime(1, 6, 20), "Gemini"),
            new ZodiakSign(new DateTime(1, 6, 21), new DateTime(1, 7, 22), "Cancer"),
            new ZodiakSign(new DateTime(1, 7, 23), new DateTime(1, 8, 22), "Leo"),
            new ZodiakSign(new DateTime(1, 8, 23), new DateTime(1, 9, 22), "Virgo"),
            new ZodiakSign(new DateTime(1, 9, 23), new DateTime(1, 10, 22), "Libra"),
            new ZodiakSign(new DateTime(1, 10, 23), new DateTime(1, 11, 21), "Scorpio"),
            new ZodiakSign(new DateTime(1, 11, 22), new DateTime(1, 12, 21), "Sagittarius"),
            new ZodiakSign(new DateTime(1, 12, 22), new DateTime(2, 1, 19), "Capricorn"),
            new ZodiakSign(new DateTime(1, 1, 20), new DateTime(1, 2, 18), "Aquarius"),
            new ZodiakSign(new DateTime(1, 2, 19), new DateTime(1, 3, 20), "Pisces")
        };


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
            if (DateTime.Today.Month == Date.Month && DateTime.Today.Day > Date.Day && _age>0) _age--;
            OnPropertyChanged(nameof(Age));
        }

        public bool IsBirthdayToday
        {
            get { return _isBirthdayToday; }
        }

        public bool IsDateValid
        {
            get => _dateValid;
        }

        public string CurrentZodiakSign
        {
            get
            {
                if (_currentSign == null)
                    return "";
                return _currentSign.SignName;
            }
        }

        private void CalculateZodiakSign()
        {
            DateTime yearlessDate;
            if (_date.Month==1 && _date.Day<=19) yearlessDate = new DateTime(2, _date.Month, _date.Day);
            else yearlessDate = new DateTime(1, _date.Month, _date.Day);
            for(int i =0; i<12; i++)
            {
                if (s_zodiakSignsTimespan[i].CheckBirthDate(yearlessDate))
                    _currentSign = s_zodiakSignsTimespan[i];
            }
            OnPropertyChanged(nameof(CurrentZodiakSign));
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
                    _isBirthdayToday = _date.Day == DateTime.Today.Day && _date.Month == DateTime.Today.Month;
                    CalculateAge();
                    CalculateZodiakSign();
                }
                else
                {
                    _date = DateTime.Today;
                    _dateValid = false;
                    _isBirthdayToday = false;
                }
                OnPropertyChanged(nameof(IsDateValid));
                OnPropertyChanged(nameof(IsBirthdayToday));
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
