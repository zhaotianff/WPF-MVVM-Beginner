using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1_ComplexDataObject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : TianXiaTech.BlurWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadBook();
            LoadObservableBook();
        }

        private void LoadBook()
        {
            ObservableBook observableBook = new ObservableBook();
            observableBook.CoverImageUrl = "http://img3m1.ddimg.cn/16/5/29681701-1_w_1709623057.jpg";
            observableBook.Title = "小学生C++创意编程（视频教学版）";
            observableBook.Descrption = "本书让入门C++变得轻松易懂，逐步入学。学习一步一个台阶，让孩子不会被其中的难度而吓退。";
            observableBook.Author = "刘凤飞";
            observableBook.Publish = "清华大学出版社";
            observableBook.Date = "2024年01月 ";
            observableBook.Price = "74.00";
            this.tab_ObservableBook.DataContext = observableBook;
        }

        private void LoadObservableBook()
        {
            Book book = new Book();
            book.CoverImageUrl = "http://img3m1.ddimg.cn/16/5/29681701-1_w_1709623057.jpg";
            book.Title = "小学生C++创意编程（视频教学版）";
            book.Descrption = "本书让入门C++变得轻松易懂，逐步入学。学习一步一个台阶，让孩子不会被其中的难度而吓退。";
            book.Author = "刘凤飞";
            book.Publish = "清华大学出版社";
            book.Date = "2024年01月 ";
            book.Price = "74.00";
            this.tab_Book.DataContext = book;
        }

        private void btn_ModifyBook_Click(object sender, RoutedEventArgs e)
        {
            var book = this.tab_Book.DataContext as Book;
            //修改价格后，会发现界面并没有生效，因为没有实现INotifyPropertyChanged接口，没有进行属性更改通知
            book.Price = "99.00";
        }

        private void btn_ModifyObservableBook_Click(object sender, RoutedEventArgs e)
        {
            var observableBook = this.tab_ObservableBook.DataContext as ObservableBook;
            //修改价格后，会发现界面显示也变化了
            observableBook.Price = "99.00";
        }
    }
}