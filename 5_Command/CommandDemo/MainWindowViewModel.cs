using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CommandDemo
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string inputText;

        public string InputText
        {
            get => inputText;
            set
            {
                inputText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InputText"));
            }
        }

        /// <summary>
        /// 获取输入
        /// </summary>
        public ICommand GetInputCommand { get; private set; }

        public MainWindowViewModel()
        {
            GetInputCommand = new RelayCommand(GetInput);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GetInput()
        {
            MessageBox.Show(InputText);
        }
    }
}
