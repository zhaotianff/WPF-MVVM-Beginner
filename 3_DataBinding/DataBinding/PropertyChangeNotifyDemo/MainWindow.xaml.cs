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

namespace PropertyChangeNotifyDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var myData = new MyData();
            this.textbox.DataContext = myData;

            var myData2 = new MyData2();
            this.textbox2.DataContext = myData2;
        }


        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            var myData = this.textbox.DataContext as MyData;
            myData.DisplayText = "tragedy";  //ui not update
        }


        private void btn_Read_Click(object sender, RoutedEventArgs e)
        {
            //after edit textbox
            //property update 
            var myData = this.textbox.DataContext as MyData;
            MessageBox.Show(myData.DisplayText);
        }

        private void btn_Read2_Click(object sender, RoutedEventArgs e)
        {
            //after edit textbox
            //property update
            var myData2 = this.textbox2.DataContext as MyData2;
            MessageBox.Show(myData2.DisplayText2);
        }

        private void btn_Update2_Click(object sender, RoutedEventArgs e)
        {
            var myData2 = this.textbox2.DataContext as MyData2;
            myData2.DisplayText2 = "tragedy";  //ui update
        }
    }
}