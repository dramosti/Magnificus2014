using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Gerais.Financeiro.Converter
{
    public class EnableDiaMultValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != DependencyProperty.UnsetValue || values[1] != DependencyProperty.UnsetValue)
            {
                bool bValue;
                bool.TryParse(values[1].ToString(), out bValue);

                if (values[0].ToString().Equals("0") && bValue)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
