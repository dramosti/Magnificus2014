using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace HLP.Components.View.WPF.Converter
{
    public class SelectedItemToTextConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int index = 0;
            int iValue = 0;

            foreach (var item in parameter as System.Windows.Data.CompositeCollection)
            {
                if (int.TryParse(s: value.ToString(), result: out iValue))
                {
                    if (index == iValue)
                        return item.ToString();
                    index++;
                }
            }

            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            byte index = 0;

            foreach (var item in parameter as System.Windows.Data.CompositeCollection)
            {
                if (value.ToString() == item.ToString())
                    return index;

                index++;
            }

            return index;
        }
    }
}
