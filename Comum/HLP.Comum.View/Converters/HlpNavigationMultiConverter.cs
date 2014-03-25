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
            const string tg = "100";

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
                    decimal porc = decimal.Zero;

                    decimal.TryParse(s: item.xOpcional, result: out porc);

                    porc = Math.Round(d: porc, decimals: 1);

                    btn.xTextOpcional = String.Format("{0:P1}", (porc / 100));
                    btn.ExibeTextOpcional = true;
                }
                else
                {
                    btn.ExibeTextOpcional = false;
                }

                if (item.xId == values[2].ToString())
                    btn.btn.Tag = tg;

                (btn.FindName(name: "btn") as Button).Command = values[1] as ICommand;
                (btn.FindName(name: "btn") as Button).CommandParameter = btn.Content;

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
