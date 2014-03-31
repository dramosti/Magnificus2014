using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Converters
{
    public class ChangeColorStatusCompConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                ResourceDictionary resource = new ResourceDictionary
                {
                    Source = new Uri("/HLP.Comum.Resources;component/Styles/Components/ComponentsStyles.xaml", UriKind.RelativeOrAbsolute)
                };
                if (value != null)
                {
                    if (value.ToString().ToUpper().Equals("EMBRANCO"))
                    {
                        return resource["EllipsePreta"] as Style;
                    }
                    else if (value.ToString().ToUpper().Equals("FALTOU"))
                    {
                        return resource["EllipseVermelha"] as Style;
                    }
                    else if (value.ToString().ToUpper().Equals("ABONO"))
                    {
                        return resource["EllipseAzul"] as Style;
                    }
                    else if (value.ToString().ToUpper().Equals("NORMAL"))
                    {
                        return resource["EllipseVerde"] as Style;
                    }
                }
                return resource["EllipsePreta"] as Style;

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
