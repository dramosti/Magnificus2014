using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.ViewModel.ViewModels.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Comercial.Converter
{
    public class StCustoProdutoConverter : IValueConverter
    {
        //ProdutoService objServico;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return false;

            return (value as ProdutoModel).stCusto == (byte)1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
