using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Converters
{
    public class HoraMinConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
                return string.Format("{0}:{1}", ((TimeSpan)value).Hours.ToString().PadLeft(2, '0'), ((TimeSpan)value).Minutes.ToString().PadLeft(2, '0'));
            else return "00:00";

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
