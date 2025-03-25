using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace UseRelayCommand
{
    public class MainWindowViewModel
    {
        /// <summary>
        /// 获取时间
        /// </summary>
        public ICommand GetTimeCommand { get; private set; }

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
