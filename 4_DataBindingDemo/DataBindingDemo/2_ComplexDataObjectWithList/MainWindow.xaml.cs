using System.Collections.ObjectModel;
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

namespace _2_ComplexDataObjectWithList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : TianXiaTech.BlurWindow
    {
        MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = mainWindowViewModel;
        }

        private void btn_AddBook_Click(object sender, RoutedEventArgs e)
        {
            //等后面学习命令绑定以后，这里的逻辑也是放到ViewModel中进行处理

            var tempBook = new Book();
            tempBook.Title = mainWindowViewModel.NewBook.Title;
            tempBook.Descrption = mainWindowViewModel.NewBook.Descrption;
            tempBook.Author = mainWindowViewModel.NewBook.Author;
            tempBook.Publish = mainWindowViewModel.NewBook.Publish;
            tempBook.Price = mainWindowViewModel.NewBook.Price;
            tempBook.Date = mainWindowViewModel.NewBook.Date;
            tempBook.CoverImageUrl = mainWindowViewModel.NewBook.CoverImageUrl;

            //将NewBook添加到列表中
            mainWindowViewModel.BookList.Add(tempBook);

            //重置NewBook
            mainWindowViewModel.NewBook.Title = "";
            mainWindowViewModel.NewBook.Descrption = "";
            mainWindowViewModel.NewBook.Author = "";
            mainWindowViewModel.NewBook.Publish = "";
            mainWindowViewModel.NewBook.Price = "";
            mainWindowViewModel.NewBook.Date = "";
            mainWindowViewModel.NewBook.CoverImageUrl = null;
        }

        private void btn_BrowserCoverClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "图片文件|*.jpg;*.bmp;*.png";

            if(openFileDialog.ShowDialog() == true)
            {
                mainWindowViewModel.NewBook.CoverImageUrl = openFileDialog.FileName;
            }
        }
    }
}