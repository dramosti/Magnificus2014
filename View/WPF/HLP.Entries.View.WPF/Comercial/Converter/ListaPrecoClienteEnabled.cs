using HLP.Entries.ViewModel.Services.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Comercial.Converter
{
    public class ListaPrecoClienteEnabled : IMultiValueConverter
    {
        ClienteService objServico;

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            objServico = new ClienteService();

            int idRota = 0;

            int.TryParse(s: values[1].ToString(), result: out idRota);

            bool rotaPossuiLista = objServico.RotaPossuiListaPrecoPai(idRota: idRota);

            return ((bool)values[0]) && !rotaPossuiLista;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
