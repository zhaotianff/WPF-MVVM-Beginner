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
        }

        private void LoadBook()
        {
            ObservableBook observableBook = new ObservableBook();
            observableBook.CoverImageUrl = "http://img3m1.ddimg.cn/16/5/29681701-1_w_1709623057.jpg";
            this.DataContext = observableBook;
        }
    }
}