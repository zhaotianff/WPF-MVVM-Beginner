using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ErrorTemplate.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int digitValue;

        public int DigitValue
        { 
            get => digitValue;
            set
            {
                digitValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DigitValue"));
            }
        }
    }
}
