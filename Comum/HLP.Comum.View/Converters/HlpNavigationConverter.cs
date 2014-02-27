using HLP.Comum.View.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HLP.Comum.View.Converters
{
    public class HlpNavigationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            StackPanel stk = new StackPanel();

            stk.Orientation = Orientation.Horizontal;

            if (value == null)
                return stk;


            HlpButtonNavigation btn;

            foreach (int item in (value as List<int>))
            {
                btn = new HlpButtonNavigation();
                btn.xContentButton = item.ToString();
                stk.Children.Add(element: btn);
            }

            return stk;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
