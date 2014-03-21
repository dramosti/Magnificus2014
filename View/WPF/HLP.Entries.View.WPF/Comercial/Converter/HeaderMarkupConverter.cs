using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Comercial.Converter
{
    public class HeaderMarkupConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                switch ((byte?)value)
                {
                    case 0:
                        {
                            return "Margem Bruta";
                        }
                    default:
                        {
                            return "Markup";
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
