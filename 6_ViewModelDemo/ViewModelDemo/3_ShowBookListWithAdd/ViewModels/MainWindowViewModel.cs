using _3_ShowBookListWithAdd.Commands;
using _3_ShowBookListWithAdd.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _3_ShowBookListWithAdd.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Book> bookList = new ObservableCollection<Book>();

        public ObservableCollection<Book> BookList
        {
            get => bookList;
            set
            {
                bookList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BookList"));
            }
        }


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

        private Book newBook = new Book();

        public Book NewBook
        {
            get => newBook;
            set
            {
                newBook = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewBook"));
            }
        }

        public ICommand BrowseCoverCommand { get; private set; }

        public ICommand AddBookCommand { get; private set; }

        public ICommand OrderByPriceAscCommand { get; private set; }

        public ICommand OrderByPriceDescCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            BrowseCoverCommand = new RelayCommand(BrowseCover);
            AddBookCommand = new RelayCommand(AddBook);
            OrderByPriceAscCommand = new RelayCommand(OrderByPriceAsc);
            OrderByPriceDescCommand = new RelayCommand(OrderByPriceDesc);

            LoadDemoData();
        }

        private void LoadDemoData()
        {
            Book book = new Book();
            book.CoverImageUrl = "http://img3m1.ddimg.cn/16/5/29681701-1_w_1709623057.jpg";
            book.Title = "小学生C++创意编程（视频教学版）";
            book.Descrption = "本书让入门C++变得轻松易懂，逐步入学。学习一步一个台阶，让孩子不会被其中的难度而吓退。";
            book.Author = "刘凤飞";
            book.Publish = "清华大学出版社";
            book.Date = "2024年01月 ";
            book.Price = 74.00f;

            Book book2 = new Book();
            book2.CoverImageUrl = "http://img3m4.ddimg.cn/64/13/29798074-1_u_1731275892.jpg";
            book2.Title = "漫画趣读西游记（7-14岁）和大人一起读四大名著儿童文学，十万个为什么中小学课外阅读快乐读书吧";
            book2.Descrption = "拼音标注、无障阅读、名著导读、有声伴读、Q版漫画、全彩印刷，鲜活的人物形象，激发兴趣，提升孩子的学习力！";
            book2.Author = "陈春燕";
            book2.Publish = "四川美术出版社";
            book2.Date = "2024年09月";
            book2.Price = 4.89f;

            BookList.Add(book);
            BookList.Add(book2);
        }

        private void AddBook()
        {
            var tempBook = new Book();
            tempBook.Title = NewBook.Title;
            tempBook.Descrption = NewBook.Descrption;
            tempBook.Author = NewBook.Author;
            tempBook.Publish = NewBook.Publish;
            tempBook.Price = NewBook.Price;
            tempBook.Date = NewBook.Date;
            tempBook.CoverImageUrl = NewBook.CoverImageUrl;

            //将NewBook添加到列表中
            BookList.Add(tempBook);

            //重置NewBook
            NewBook.Title = "";
            NewBook.Descrption = "";
            NewBook.Author = "";
            NewBook.Publish = "";
            NewBook.Price = 0f;
            NewBook.Date = "";
            NewBook.CoverImageUrl = null;
        }

        private void BrowseCover()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "图片文件|*.jpg;*.bmp;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                NewBook.CoverImageUrl = openFileDialog.FileName;
            }
        }

        private void OrderByPriceDesc()
        {
            BookList = new ObservableCollection<Book>(BookList.OrderByDescending(x => x.Price));
        }

        private void OrderByPriceAsc()
        {
            BookList = new ObservableCollection<Book>(BookList.OrderBy(x => x.Price));
        }
    }
}
