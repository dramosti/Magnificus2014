using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Comum.View.Converters
{
    public class DateTimeToStringHourConverter : IValueConverter
    {
        //propriedade to comp
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {

                return System.Convert.ToDateTime(value).ToString("hh:mm");

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
