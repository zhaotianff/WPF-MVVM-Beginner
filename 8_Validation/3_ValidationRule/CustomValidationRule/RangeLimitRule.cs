using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _3_ValidationRule.CustomValidationRule
{
    public class RangeLimitRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out int number) == false)
            {
                return new ValidationResult(false, "请输入数字");
            }
            else
            {
                if (number >= 0 && number <= 100)
                    return ValidationResult.ValidResult;

                return new ValidationResult(false, $"输入{value}格式错误，请输入0-100的数字");
            }
        }
    }
}
