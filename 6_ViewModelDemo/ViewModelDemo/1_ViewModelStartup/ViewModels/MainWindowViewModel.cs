using _1_ViewModelStartup.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1_ViewModelStartup.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Book book;

        public Book Book 
        {
            get => book;
            set
            {
                book = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Book"));
            }
        }

        public MainWindowViewModel()
        {
            LoadBook();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void LoadBook()
        {
            Book = new Book();
            Book.CoverImageUrl = "http://img3m1.ddimg.cn/16/5/29681701-1_w_1709623057.jpg";
            Book.Title = "小学生C++创意编程（视频教学版）";
            Book.Descrption = "本书让入门C++变得轻松易懂，逐步入学。学习一步一个台阶，让孩子不会被其中的难度而吓退。";
            Book.Author = "刘凤飞";
            Book.Publish = "清华大学出版社";
            Book.Date = "2024年01月 ";
            Book.Price = "74.00";
        }
    }
}
