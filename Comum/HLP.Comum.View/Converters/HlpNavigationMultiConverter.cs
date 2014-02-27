using HLP.Comum.View.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace HLP.Comum.View.Converters
{
    public class HlpNavigationMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            StackPanel stk = new StackPanel();

            stk.Orientation = Orientation.Horizontal;

            if (values == null)
                return stk;
            else if (values[0] == null)
                return stk;

            HlpButtonNavigation btn;

            foreach (int item in (values[0] as List<int>))
            {
                btn = new HlpButtonNavigation();

                if ((values[0] as List<int>).Last() == item)
                    btn.ImgBtnNavigation.Visibility = System.Windows.Visibility.Collapsed;

                btn.xContentButton = item.ToString().PadLeft(totalWidth: 8, paddingChar: '0');
                btn.btn.Command = values[1] as ICommand;
                btn.btn.CommandParameter = btn.xContentButton;
                if (item == (int)values[2])
                {
                }

                stk.Children.Add(element: btn);
            }

            return stk;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return new object[1];
        }
    }
}
