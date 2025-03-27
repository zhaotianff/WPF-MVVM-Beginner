using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BindingEventToCommand
{
    public class MainWindowViewModel : ObservableObject
    {
        public RelayCommand<object> OnSelectionChangedCommand { get; set; }

        public MainWindowViewModel()
        {
            OnSelectionChangedCommand = new RelayCommand<object>(OnSelectionChanged);
        }

        private void OnSelectionChanged(object? obj)
        {
            var listboxItem = obj as ListBoxItem;

            if(listboxItem != null)
            {
                MessageBox.Show(listboxItem.Content.ToString());
            }
        }
    }
}
