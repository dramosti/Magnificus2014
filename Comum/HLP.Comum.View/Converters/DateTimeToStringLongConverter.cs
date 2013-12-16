using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HLP.Comum.View.Converters
{
    public class DateTimeToStringLongConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                    DatePicker dt = new DatePicker();
                dt.SelectedDate = (DateTime)value;
                dt.SelectedDateFormat = DatePickerFormat.Long;
                return dt.Text;
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
