using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MachekhinZodiak
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private ZodiakCalculator _datesToZodiakCalculator;
        public ViewModel()
        { 
            _datesToZodiakCalculator = new ZodiakCalculator();
            _datesToZodiakCalculator.PropertyChanged += OnModelPropertyChanged;
        }

        public DateTime Date
        {
            get { return _datesToZodiakCalculator.Date; }
            set { _datesToZodiakCalculator.Date=value; }
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
                    OnPropertyChanged(nameof(Date));
                    break;
                case (nameof(ZodiakCalculator.IsDateValid)):
                    if (!IsDateValid) IncorrectDate.Invoke(this, false);
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<bool> IncorrectDate;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
