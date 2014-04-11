using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Gerais.Financeiro.Converter
{
    public class qtdDiasMesesEnabledConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(bool)values[0])
                return false;

            decimal p = 0;

            decimal.TryParse(s: values[1].ToString(), result: out p);

            if (!(p > 0))
                return false;

            return true;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
