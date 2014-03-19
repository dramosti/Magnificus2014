using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Gerais.Converters
{
    public class StCustoProdutoConverter : IValueConverter
    {
        //produtoService.IserviceProdutoClient servico = new produtoService.IserviceProdutoClient();

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //if ((int)value == 0)
            //    return false;

            //return servico.getProduto((int)value).stCusto != 2 ? true : false;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
