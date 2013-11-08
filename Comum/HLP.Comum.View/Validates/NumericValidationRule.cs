using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HLP.Comum.View.Validates
{
    public class NumericIntValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int result;

            if (int.TryParse(s: value.ToString(), result: out result))
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(isValid: false,
                errorContent: "Valor deve ser um número inteiro válido");
        }
    }
}
