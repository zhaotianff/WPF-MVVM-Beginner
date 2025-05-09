using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace _3_ValidationRule.Converters
{
    public class MultiLangDigitConverter : IValueConverter
    {
        /// <summary>
        /// 从源到目标
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        /// <summary>
        /// 从目标到源
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value.ToString();

            //直接输入了数字
            if (int.TryParse(val, out int numValue))
            {
                return numValue;
            }
            else
            {
                var res = Application.Current.TryFindResource(val);

                if(res != null)
                {
                    return res;
                }

                return value;
            }
        }
    }
}
