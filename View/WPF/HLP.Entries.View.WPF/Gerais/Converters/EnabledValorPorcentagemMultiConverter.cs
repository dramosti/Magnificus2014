using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Gerais.Converters
{
    public class EnabledValorPorcentagemMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
            try
            {
                if (values[0] == DependencyProperty.UnsetValue
                    || values[1] == DependencyProperty.UnsetValue
                    || values[2] == DependencyProperty.UnsetValue)
                    return true;

                if (!(bool)values[2])
                    return true;

                if ((int)values[0] == 1)
                {
                    switch ((int)values[1])
                    {
                        case 0:
                        case 1:
                        case 3:
                            {
                                return true;
                            }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
