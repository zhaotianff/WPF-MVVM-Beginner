using MethodsToSetViewModel.ViewModels;
using MethodsToSetViewModel.Views;
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

namespace MethodsToSetViewModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewA viewA = new ViewA();
            viewA.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ViewB viewB = new ViewB();
            viewB.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ViewC viewC = new ViewC();
            viewC.Show();
        }
    }
}