using HLP.Base.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HLP.Magnificus.View.WPF.Converter
{
    public class visibilityCtrlsWdMain : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return Visibility.Hidden;

            foreach (var m in GerenciadorModulo.Instancia.Modulos)
            {
                if (m.objectModulo.lFormularios.Count(i => i.xName == value.ToString()) > 0)
                {
                    return Visibility.Visible;
                }
            }

            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
