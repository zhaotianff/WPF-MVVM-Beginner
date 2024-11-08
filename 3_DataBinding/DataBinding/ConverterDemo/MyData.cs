using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterDemo
{
    public class MyData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string status;

        public string Status 
        {
            get => status;
            set
            {
                status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Status"));
            }
        }
    }
}
