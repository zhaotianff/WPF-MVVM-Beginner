using _7_ValidationWithMultiField.Commands;
using _7_ValidationWithMultiField.Validation;
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

namespace _7_ValidationWithMultiField.ViewModels
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
                        new ValidationErrorInfo(){PropertyName = "Password" },
                        new ValidationErrorInfo(){ PropertyName = "ConfirmPassword"}
                    };
                }

                return validationErrorInfoList;
            }
        }

        public Validations.ValidationState ValidationState { get; private set; } = Validations.ValidationState.Initial;

        public event PropertyChangedEventHandler? PropertyChanged;

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
            }
        }


        private string confirmPassword;
        public string ConfirmPassword
        {
            get => confirmPassword;
            set
            {
                confirmPassword = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ConfirmPassword"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
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
                    case nameof(ConfirmPassword):
                        if(!string.IsNullOrEmpty(Password) && Password != ConfirmPassword)
                        {
                            errorMsg = "两次密码不一致.";
                        }    

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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ConfirmPassword"));
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
