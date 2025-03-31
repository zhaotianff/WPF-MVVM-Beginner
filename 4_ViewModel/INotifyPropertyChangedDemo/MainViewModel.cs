using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace INotifyPropertyChangedDemo
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string currentTime;

        public string CurrentTime
        {
            get => currentTime;
            set
            {
                currentTime = value;

                RaiseChanged();
            }
        }

        private void RaiseChanged([CallerMemberName] string memeberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memeberName));
        }

        public MainViewModel()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += (sender, args) => { CurrentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); };
            dispatcherTimer.IsEnabled = true;
        }
    }
}
