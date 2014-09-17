using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HLP.Components.View.WPF.MultiConverter
{
    public class ReadOnlyMultiConverter : IMultiValueConverter
    {
        
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isInvalid = false;

            foreach (object it in values)
            {
                if (it == DependencyProperty.UnsetValue)
                {
                    isInvalid = true;
                    break;
                }
                else if (((bool)it) == false)
                {
                    isInvalid = true;
                    break;
                }
            }

            return isInvalid; // Por ser readonly está está sendo retornado false como verdadeiro e true como falso
                              // Conceito de readonly: quando readonly true, não é possível editar componente, quando falto, edição é permitida
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
