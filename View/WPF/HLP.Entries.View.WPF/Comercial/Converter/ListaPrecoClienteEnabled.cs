using HLP.Entries.ViewModel.Services.Comercial;
using HLP.Entries.ViewModel.ViewModels.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Comercial.Converter
{
    public class ListaPrecoClienteEnabled : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int idRota = 0;
            if (values[1] != null)
                int.TryParse(s: values[1].ToString(), result: out idRota);

            bool rotaPossuiLista = false;

            if (values[2] != DependencyProperty.UnsetValue)
                rotaPossuiLista = (values[2] as ClienteViewModel).RotaPossuiListaPrecoPai(idRota: idRota);

            return ((bool)values[0]) && !rotaPossuiLista;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
