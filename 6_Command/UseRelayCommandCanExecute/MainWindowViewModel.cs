using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;

namespace UseRelayCommandCanExecute
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool canGetTime;

        public bool CanGetTime
        {
            get => canGetTime;
            set
            {
                canGetTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CanGetTime"));
            }
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        public ICommand GetTimeCommand { get; private set; }

        public MainWindowViewModel()
        {
            GetTimeCommand = new RelayCommand(GetTime, CanGetTimeExecute);
        }

        /// <summary>
        /// GetTimeCommand是否可以被执行的回调函数
        /// </summary>
        /// <returns></returns>
        public bool CanGetTimeExecute()
        {
            //返回CanGetTime变量，该变量绑定到界面上的CheckBox
            return CanGetTime;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void GetTime()
        {
            MessageBox.Show(DateTime.Now.ToString());
        }
    }
}
