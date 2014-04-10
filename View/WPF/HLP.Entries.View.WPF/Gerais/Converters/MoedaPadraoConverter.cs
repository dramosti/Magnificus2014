using HLP.Resources.View.WPF.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Gerais.Converters
{
    public class MoedaPadraoConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != DependencyProperty.UnsetValue && values[0] != null)
            {
                int contador = 0;

                foreach (var item in values[1] as ObservableCollection<padraoMoeda>)
                {
                    if (item.xMoeda.ToUpper() == values[0].ToString().ToUpper())
                    {
                        return contador;
                    }
                    else
                        contador++;
                }
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return new object[0];
        }
    }
}
