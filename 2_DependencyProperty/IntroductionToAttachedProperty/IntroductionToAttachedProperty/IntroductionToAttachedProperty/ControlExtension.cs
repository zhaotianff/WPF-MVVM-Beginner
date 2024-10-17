using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IntroductionToAttachedProperty
{
    public class ControlExtension : DependencyObject
    {
        public static readonly DependencyProperty IdProperty = DependencyProperty.RegisterAttached("Id", typeof(int), typeof(ControlExtension));

        public static int GetId(DependencyObject dependencyObject)
        {
            return (int)dependencyObject.GetValue(IdProperty);
        }

        public static void SetId(DependencyObject dependencyObject,int value)
        {
            dependencyObject.SetValue(IdProperty, value);
        }
    }
}
