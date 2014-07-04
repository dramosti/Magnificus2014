using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HLP.Components.View.WPF.Converter
{
    public class MoedaPorcentagemSelectorConverter : IMultiValueConverter
    {
        PorcentagemConverter pConverter;
        MoedaConverter mConverter;

        public MoedaPorcentagemSelectorConverter()
        {
            pConverter = new PorcentagemConverter();
            mConverter = new MoedaConverter();
        }

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] == DependencyProperty.UnsetValue
                || values[1] == DependencyProperty.UnsetValue)
            {
                return string.Empty;
            }

            switch ((byte)values[1])
            {
                case 0:
                    {
                        return pConverter.Convert(value: values[0], targetType: targetType, parameter: parameter, culture: culture);
                    }
                case 1:
                    {
                        return mConverter.Convert(value: values[0], targetType: targetType, parameter: parameter, culture: culture);
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return new object[] { };
        }
    }
}
