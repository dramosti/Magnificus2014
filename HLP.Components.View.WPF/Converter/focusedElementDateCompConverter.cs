using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Components.View.WPF.Converter
{
    public class focusedElementDateCompConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            switch ((StFormatoDatePicker)value)
            {
                case StFormatoDatePicker.date:
                case StFormatoDatePicker.datetime:
                    {
                        return "txtData";
                    }
                case StFormatoDatePicker.time:
                    {
                        return "txtHora";
                    }
                default:
                    {
                        return "txtData";
                    }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
