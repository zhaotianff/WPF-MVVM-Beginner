using _1_DependencyPropertyValidation.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _1_DependencyPropertyValidation.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int positiveNumber;

        public int PositiveNumber 
        { 
            get => positiveNumber;
            set
            {
                positiveNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PositiveNumber"));
            }
        }

        public ICommand ConfirmCommand { get; private set; }

        public MainWindowViewModel()
        {
            ConfirmCommand = new RelayCommand(Confirm);
        }

        private void Confirm()
        {
            
        }
    }
}
