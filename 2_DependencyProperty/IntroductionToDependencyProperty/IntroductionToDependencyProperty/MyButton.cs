using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IntroductionToDependencyProperty
{
    public class MyButton : Button
    {
        public static readonly DependencyProperty ImageProperty;


        static MyButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyButton), new FrameworkPropertyMetadata(typeof(MyButton)));

            ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(MyButton),new PropertyMetadata(null, OnImagePropertyChanged));
        }


        /// <summary>
        /// 当ImageProperty依赖属性值更改时会被调用
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnImagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        /// <summary>
        /// 属性包装器
        /// </summary>
        public ImageSource Image
        {
            get => (ImageSource)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }
    }
}
