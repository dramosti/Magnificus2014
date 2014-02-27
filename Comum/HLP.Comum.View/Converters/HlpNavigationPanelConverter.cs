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
    public class HlpNavigationPanelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            StackPanel stkPanel = new StackPanel();
            HlpButtonNavigation btn;

            foreach (int item in ((List<int>)value))
            {
                btn = new HlpButtonNavigation();
                btn.xContentBtn = item.ToString();
                stkPanel.Children.Add(element: btn);
            }

            return stkPanel;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
