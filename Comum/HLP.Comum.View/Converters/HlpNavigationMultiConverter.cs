using HLP.Comum.Resources.RecursosBases;
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
            string tg = "100";

            stk.Orientation = Orientation.Horizontal;

            if (values == null)
                return stk;
            else if (values[0] == null)
                return stk;
            else if ((values[0] as List<HlpButtonHierarquiaStruct>).Count < 1)
                return stk;

            HlpButtonHierarquia btn;


            foreach (HlpButtonHierarquiaStruct item in (values[0] as List<HlpButtonHierarquiaStruct>))
            {
                btn = new HlpButtonHierarquia();
                btn.xTextId = item.xId;
                if (item.xOpcional != "")
                {
                    btn.xTextOpcional = item.xOpcional;
                    btn.ExibeTextOpcional = true;
                }
                else
                {
                    btn.ExibeTextOpcional = false;
                }
                btn.btn.Command = values[1] as ICommand;
                btn.btn.CommandParameter = btn.Content;

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
