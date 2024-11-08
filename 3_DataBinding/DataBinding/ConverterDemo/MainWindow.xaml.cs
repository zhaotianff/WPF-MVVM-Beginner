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

namespace ConverterDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadDemoData();
        }

        private async void LoadDemoData()
        {
            MyData myData = new MyData();
            this.label.DataContext = myData;

            myData.Status = "未完成";

            //wait 3 seconds
            await Task.Delay(3000);

            myData.Status = "完成";
        }
    }
}