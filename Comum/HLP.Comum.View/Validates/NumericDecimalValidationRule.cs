using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HLP.Comum.View.Validates
{
    public class NumericDecimalValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            decimal result;

            if (decimal.TryParse(value.ToString(), out result))
                return ValidationResult.ValidResult;

            return new ValidationResult(isValid: false,
                errorContent: "Valor deve ser um decimal válido");
        }
    }
}
