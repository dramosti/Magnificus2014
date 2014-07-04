using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Gerais.Converters
{
    public class xDisplayFormaPagamentoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //<System:String>0-Anos</System:String>
            //            <System:String>1-Dias</System:String>
            //            <System:String>2-Meses</System:String>

            if (value == null)
                return string.Empty;

            switch ((int)value)
            {
                case 0: return "ANO/ANOS";
                case 1: return "DIA/DIAS";
                case 2: return "MÊS/MESES";
                default: return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
