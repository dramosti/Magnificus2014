using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Comercial.Converters
{
    public class IdMotivoVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((byte)value)
            {
                case 0:
                case 1:
                case 2:
                    {
                        return false;
                    }
                default:
                    {
                        return true;
                    }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
