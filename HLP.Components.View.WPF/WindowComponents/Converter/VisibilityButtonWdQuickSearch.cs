using HLP.Base.EnumsBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HLP.Components.View.WPF.WindowComponents.Converter
{
    public class VisibilityButtonWdQuickSearch : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            object currentOp = value;

            if (currentOp != null)
            {
                if (((OperacaoCadastro)currentOp) == OperacaoCadastro.pesquisando
                    || ((OperacaoCadastro)currentOp) == OperacaoCadastro.livre)
                    return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
