using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HLP.Components.View.WPF.Converter
{
    public class DateTimeToStringLongConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return ((DateTime)value).Date.ToShortDateString() + " - " + ((DateTime)value).ToString("dddddd").ToUpper();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
