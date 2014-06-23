using HLP.Base.Static;
using HLP.Sales.ViewModel.ViewModel.Comercio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Sales.View.WPF.Converters
{
    public class SumPorcItemsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal vTotal = decimal.Zero;

            foreach (var item in value as IEnumerable)
            {
                if (parameter.ToString() == "porc")
                {
                    vTotal += (item as ItensComissoes).pComissao;
                }
                else if (parameter.ToString() == "vlr")
                {
                    vTotal += (item as ItensComissoes).vComissao;
                }
            }

            if (parameter.ToString() == "porc")
                return string.Format(format: "{0:P2}", arg0: (vTotal / 100));
            else if (parameter.ToString() == "vlr")
                return string.Format(format: "{0:C2}", arg0: vTotal);
            else
                return decimal.Zero;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
