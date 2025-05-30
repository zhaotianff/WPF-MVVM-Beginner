﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ObservableCollectionDemo
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> normalList = new ObservableCollection<string>();

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<string> NormalList
        {
            get
            {
                return normalList;
            }

            set
            {
                normalList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NormalList"));
            }
        }

        public MainViewModel()
        {
            InitializeList();
        }

        private async void InitializeList()
        {
            NormalList.Add("1");
            NormalList.Add("2");
            NormalList.Add("3");
            NormalList.Add("4");

            await Task.Delay(2000);
            //等待两秒,移除最后一项
            NormalList.RemoveAt(3);
            MessageBox.Show("移除最后一项");
        }

    }
}
