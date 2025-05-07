using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_ValidationRule.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int rangeDigitValue;

        public int RangeDigitValue 
        { 
            get => rangeDigitValue; 
            set
            {
                rangeDigitValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RangeDigitValue"));
            }
        }
    }
}
