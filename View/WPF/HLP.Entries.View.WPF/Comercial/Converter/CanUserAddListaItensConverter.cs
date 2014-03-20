using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Comercial.Converter
{
    public class CanUserAddListaItensConverter : IMultiValueConverter
    {
        //public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //{
        //    if (((Visibility)value) == Visibility.Visible)
        //        return false;
        //    else
        //        return true;
        //}

        //public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //{
        //    throw new NotImplementedException();
        //}
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] == DependencyProperty.UnsetValue)
                return true;

            if (((Visibility)values[0]) == Visibility.Visible || (int)values[1] == (int)0)
                return false;
            else
                return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
