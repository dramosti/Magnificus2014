using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Comercial.Converter
{
    public class StatusOrcamentoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter.ToString() == "c")
            {
                switch (((int)value))
                {
                    case 0:
                        return true;
                    default:
                        return false;
                }
            }
            else if (parameter.ToString() == "e")
            {
                switch (((int)value))
                {
                    case 1:
                        return true;
                    default:
                        return false;
                }
            }
            else if (parameter.ToString() == "f")
            {
                switch (((int)value))
                {
                    case 2:
                    case 3:
                    case 4:
                        return true;
                    default:
                        return false;
                }
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
