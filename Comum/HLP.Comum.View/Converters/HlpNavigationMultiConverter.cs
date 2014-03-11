using HLP.Comum.View.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            int tg = 100;

            stk.Orientation = Orientation.Horizontal;

            if (values == null)
                return stk;
            else if (values[0] == null)
                return stk;

            Button btn;
            ResourceDictionary resource = new ResourceDictionary
            {
                Source = new Uri("/HLP.Comum.Resources;component/Styles/Components/ComponentsStyles.xaml", UriKind.RelativeOrAbsolute)
            };


            foreach (int item in (values[0] as List<int>))
            {
                btn = new Button();
                btn.Content = item.ToString();
                btn.Command = values[1] as ICommand;
                btn.CommandParameter = btn.Content;
                btn.Style = resource["ButtonVersao"] as Style;
                btn.Tag = tg;

                if (item == (int)values[2])
                {
                    tg = 0;
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
