using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace UseCommunityToolkitMVVM
{
    public class MainWindowViewModel : ObservableObject
    {
        public ICommand GetTimeCommand { get; set; }

        public RelayCommand<string> dd { get; set; }

        public MainWindowViewModel()
        {
            GetTimeCommand = new RelayCommand(GetTime);
        }

        private void GetTime()
        {
            MessageBox.Show(DateTime.Now.ToString());
        }
    }
}
