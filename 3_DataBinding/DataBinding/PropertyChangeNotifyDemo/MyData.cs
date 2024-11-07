using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChangeNotifyDemo
{
    public class MyData
    {
        private string displayText = "HelloWorld";

        public string DisplayText
        {
            get => displayText;
            set => displayText = value;
        }
    }

    public class MyData2 : INotifyPropertyChanged
    {
        private string displayText2 = "HelloWorld";

        public string DisplayText2
        {
            get => displayText2;
            set
            {
                displayText2 = value;

                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("DisplayText2"));

                //or
                //OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
