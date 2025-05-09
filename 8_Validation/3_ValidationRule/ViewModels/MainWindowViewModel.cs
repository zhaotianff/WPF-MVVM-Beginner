using _3_ValidationRule.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _3_ValidationRule.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand SwitchChsCommand { get; private set; }

        public ICommand SwitchEnCommand { get; private set; }

        private int rangeDigitValue;

        public int RangeDigitValue 
        { 
            get => rangeDigitValue; 
            set
            {
                rangeDigitValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RangeDigitValue"));
            }
        }

        private int rangeDigitValueWithConverter = 1;

        public int RangeDigitValueWithConverter
        {
            get => rangeDigitValueWithConverter;
            set
            {
                rangeDigitValueWithConverter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RangeDigitValueWithConverter"));
            }
        }

        public MainWindowViewModel()
        {
            SwitchChsCommand = new RelayCommand(SwtichToChs);
            SwitchEnCommand = new RelayCommand(SwitchToEn);
        }


        public void SwtichToChs()
        {
            //中文
            Application.Current.Resources.MergedDictionaries[0] = new ResourceDictionary() { Source = new Uri("Lang/zh-CN.xaml", UriKind.Relative) };
        }

        public void SwitchToEn()
        {
            //英文
            Application.Current.Resources.MergedDictionaries[0] = new ResourceDictionary() { Source = new Uri("Lang/en-US.xaml", UriKind.Relative) };
        }
    }
}
