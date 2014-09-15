using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;


namespace HLP.Entries.View.WPF.Converters
{
    public class ChangeStyleButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                ResourceDictionary resource = new ResourceDictionary
                {
                    Source = new Uri("/HLP.Resources.View.WPF;Revisar/ComponentsStyles.xaml", UriKind.RelativeOrAbsolute)
                };
                if (value != null)
                {
                    if (value.ToString().ToUpper().Equals("DOMINGO") || value.ToString().ToUpper().Equals("SÁBADO"))
                    {
                        return resource["ButtonDiasSabadoDomingo"] as Style;
                    }
                }
                return resource["ButtonDias"] as Style;
            
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
