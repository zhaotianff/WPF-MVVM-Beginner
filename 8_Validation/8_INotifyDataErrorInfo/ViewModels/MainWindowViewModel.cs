using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Controls;

namespace _8_INotifyDataErrorInfo.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private Dictionary<string, ICollection<string>> validationErrorInfoList;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Dictionary<string, ICollection<string>> ValidationErrorInfoList
        {
            get
            {
                if (validationErrorInfoList == null)
                    validationErrorInfoList = new Dictionary<string, ICollection<string>>();

                return validationErrorInfoList;
            }
        }

        private string id;

        public string Id
        {
            get => id;
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
                ValidatePropertyAsync("Id");
            }
        }


        public bool HasErrors
        {
            get { return ValidationErrorInfoList.Count > 0; }
        }  

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        private void RaiseErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)|| !ValidationErrorInfoList.ContainsKey(propertyName))
                return null;

            if(ValidationErrorInfoList.ContainsKey(propertyName))
            {
                return ValidationErrorInfoList[propertyName];
            }

            return null;
        }

        private async void ValidatePropertyAsync(string propertyName)
        {
            ICollection<string> validationErrors = null;

            //异步验证
            bool isValid = await Task.Run(() =>
            {
                return ValidatePropertyInternal(propertyName, out validationErrors);
            })
            .ConfigureAwait(false);

            if (!isValid)
            {
                ValidationErrorInfoList[propertyName] = validationErrors;
                RaiseErrorsChanged(propertyName);
            }
            else if (ValidationErrorInfoList.ContainsKey(propertyName))
            {
                ValidationErrorInfoList.Remove(propertyName);
                RaiseErrorsChanged(propertyName);
            }
        }

        private bool ValidatePropertyInternal(string propertyName, out ICollection<string> validationErrors)
        {
            validationErrors = new List<string>();

            if (string.IsNullOrEmpty(propertyName))
                return false;

            object propertyValue = this.GetType().GetProperty(propertyName).GetValue(this, null);


            if (propertyValue == null || propertyValue.ToString().Trim().Equals(string.Empty))
            {
                validationErrors.Add($"{propertyName}是必须的");
            }


            switch (propertyName)
            {
                case nameof(Id):
                    {
                        if (int.TryParse(propertyValue.ToString(), out int nId) == false)
                        {
                            validationErrors.Add($"{propertyName}必须填入数字");
                        }

                        if (propertyValue.ToString().Length > 4)
                        {
                            validationErrors.Add($"{propertyName}限制长度为4");
                        }
                        break;
                    }

            }

            return validationErrors.Count == 0;

        }
    }
}
