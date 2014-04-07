using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Gerais.Financeiro.Converter
{
    public class DiaPagamento_Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value != null)
                    return value.ToString();

                return null;
                //int selectedIndex = 0;

                //if (value != null)
                //    int.TryParse(s: value.ToString(), result: out selectedIndex);

                //if (parameter.ToString() == "stDiaUtil")
                //{
                //    if (selectedIndex == 0)
                //        return Visibility.Visible;
                //}
                //else if (parameter.ToString() == "nDia")
                //{
                //    if (selectedIndex == 1)
                //        return Visibility.Visible;
                //}
                //return Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
