using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Comum.View.Converters
{
    public class OperacoesAritmetConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal valorTotal = decimal.Zero;
            decimal valor = decimal.Zero;
            switch (parameter.ToString())
            {
                case "soma":
                    {
                        foreach (object item in values)
                        {
                            if (decimal.TryParse(s: item.ToString(), result: out valor))
                                valorTotal += valor;
                        }
                    } break;
            }
            return valorTotal;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
