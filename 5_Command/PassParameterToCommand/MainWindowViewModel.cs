using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PassParameterToCommand
{
    public class MainWindowViewModel : ObservableObject
    {
        public RelayCommand<string> ShowMessageCommand { get; set; }

        public MainWindowViewModel()
        {
            ShowMessageCommand = new RelayCommand<string>(ShowMessage);
        }

        private void ShowMessage(string? obj)
        {
            MessageBox.Show("消息来自-" + obj);
        }
    }
}
