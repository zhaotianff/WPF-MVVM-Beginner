using System.ComponentModel;
using System.Windows;

namespace WpfMVVMDemo
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string inputText;

        public string InputText
        {
            get => this.inputText;
            set
            {
                inputText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InputText"));
            }
        }

        public DelegateCommand GetInputCommand { get; set; }

        public MainWindowViewModel()
        {
            GetInputCommand = new DelegateCommand(GetInput);
        }


        private void GetInput()
        {
            MessageBox.Show(InputText);
        }
    }
}
