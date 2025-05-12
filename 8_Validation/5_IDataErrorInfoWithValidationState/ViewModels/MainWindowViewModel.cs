using _5_IDataErrorInfoWithValidationState.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _5_IDataErrorInfoWithValidationState.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public Validations.ValidationState ValidationState { get; private set; } = Validations.ValidationState.Initial;

        public event PropertyChangedEventHandler? PropertyChanged;

        private string id;
        public string Id
        {
            get => id;
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
            }
        }


        private string name;
        public string Name 
        {
            get => name;
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        public ICommand ConfirmCommand { get; private set; }

        public ICommand LoadedCommand { get; private set; }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (ValidationState < Validations.ValidationState.Loaded)
                    return null;

                object propertyValue = this.GetType().GetProperty(columnName).GetValue(this, null);

                if (propertyValue == null || string.IsNullOrEmpty( propertyValue.ToString().Trim()))
                {
                    return $"{columnName}不能为空";
                }

                return null;
            }

        }

        public MainWindowViewModel()
        {
            ConfirmCommand = new RelayCommand(Confirm);
            LoadedCommand = new RelayCommand(Loaded);
        }

        private void Loaded()
        {
            ValidationState = Validations.ValidationState.Loaded;
        }

        private void RaiseChanges()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
        }

        private void Confirm()
        {
            ValidationState = Validations.ValidationState.Submit;
            RaiseChanges();

            if (this[nameof(Id)] != null || this[nameof(Name)] != null)
                return;

            MessageBox.Show($"Id:{Id}\r\nName:{Name}");
        }
    }
}
