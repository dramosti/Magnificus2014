using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Comercial.Converter
{
    public class IsEnabledCompMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter.ToString() == "cbx")
            {
                if ((bool)values[0] == false || (int)values[1] == (int)1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if ((bool)values[0] == false || (bool)values[1] == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
