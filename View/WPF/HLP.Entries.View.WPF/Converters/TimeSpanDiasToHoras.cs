using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Converters
{
    public class TimeSpanDiasToHoras : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                int iTotHoras = (((TimeSpan)value).Days * 24) + ((TimeSpan)value).Hours;

                int iMinutes;
                if (((TimeSpan)value).Minutes<0)
                    iMinutes = ((TimeSpan)value).Minutes * -1;
                else
                    iMinutes = ((TimeSpan)value).Minutes;
                return  iTotHoras.ToString().PadLeft(2, '0') + ":"
                    + iMinutes.ToString().PadLeft(2, '0');
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
