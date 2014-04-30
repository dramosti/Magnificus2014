using HLP.Base.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Magnificus.View.WPF.Converter
{
    public class StConnectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (((StConnection)value) == StConnection.OnlineWeb)
                return true;
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool?)value == true)
                return StConnection.OnlineWeb;
            else
                return StConnection.OnlineNetwork;
        }
    }
}
