using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace RecordApp
{
    public class NumValidator: ValidationRule
{
    public override ValidationResult Validate
      (object value, System.Globalization.CultureInfo cultureInfo)
    {
            int n;
            bool isNumeric = int.TryParse(value.ToString(), out n);
            if (isNumeric != true)
            {
                return new ValidationResult(false, "Numeric Values Only.");
            }

            return ValidationResult.ValidResult;
    }
}
}
