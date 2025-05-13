using _6_ValidationSummaryInfo.Commands;
using _6_ValidationSummaryInfo.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _6_ValidationSummaryInfo.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private ObservableCollection<ValidationErrorInfo> validationErrorInfoList;

        public ObservableCollection<ValidationErrorInfo> ValidationErrorInfoList
        {
            get
            {
                if (validationErrorInfoList == null)
                {
                    validationErrorInfoList = new ObservableCollection<ValidationErrorInfo>()
                    {
                        new ValidationErrorInfo(){PropertyName = "Id" },
                        new ValidationErrorInfo(){ PropertyName = "Name"}
                    };
                }

                return validationErrorInfoList;
            }
        }

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

        private string error = "";

        public string Error
        {
            get => error;
            set
            {
                error = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Error"));
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (ValidationState < Validations.ValidationState.Loaded)
                    return null;

                string errorMsg = null;

                object propertyValue = this.GetType().GetProperty(columnName).GetValue(this, null);

                if (propertyValue == null || string.IsNullOrEmpty(propertyValue.ToString().Trim()))
                {
                    errorMsg =  $"{columnName}不能为空";
                }

                switch(columnName)
                {
                    case nameof(Id):
                        break;
                    case nameof(Name):
                        break;
                }

                ValidationErrorInfoList.FirstOrDefault(x => x.PropertyName == columnName).ValidationError = errorMsg;

                return errorMsg;
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

            Error = string.Join("\r\n", ValidationErrorInfoList.Select<ValidationErrorInfo, string>(e => e.ValidationError).ToArray<string>());

           if(!string.IsNullOrEmpty(Error.Trim()))
            {
                MessageBox.Show($"数据验证失败:\r\n{Error}");
            }
        }
    }
}
