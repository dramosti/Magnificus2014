using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Gerais.Converters
{
    public class DiasSemanasMesesIsEnabledConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // values[0] isEnabled
            // values[1] campo Meses
            // values[2] campo Semanas
            // values[3] campo Dias

            if (values[0] == null || values[0] == DependencyProperty.UnsetValue)
                return false;

            if (!((bool)values[0]))
                return false;

            if (values[1] == DependencyProperty.UnsetValue
                || values[2] == DependencyProperty.UnsetValue
                || values[3] == DependencyProperty.UnsetValue
                || values[4] == DependencyProperty.UnsetValue)
                return true;

            if (values[4] != null)
                if (!(string.IsNullOrEmpty(value: values[4].ToString())))
                    return false;
                else
                    return true;

            decimal m = 0;
            decimal s = 0;
            decimal d = 0;

            if (values[1] != null)
                decimal.TryParse(s: values[1].ToString(), result: out m);

            if (values[2] != null)
                decimal.TryParse(s: values[2].ToString(), result: out s);

            if (values[3] != null)
                decimal.TryParse(s: values[3].ToString(), result: out d);

            if (parameter.ToString() == "m")
            {
                if (s > 0 || d > 0)
                    return false;
            }
            else if (parameter.ToString() == "s")
            {
                if (m > 0 || d > 0)
                    return false;
            }
            else if (parameter.ToString() == "d")
            {
                if (m > 0 || s > 0)
                    return false;
            }
            else
            {
                return false;
            }

            return true;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
