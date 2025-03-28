using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace INotifyPropertyChangedDemo
{
    public class ObservableData : INotifyPropertyChanged
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
    }
}
