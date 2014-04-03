using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Components.View.WPF.Converter
{
    public class ByteToBoolConverter : IValueConverter
    {
        //propriedade to comp
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {

                bool bReturn = false;
                if (value != null)
                    if (value.ToString() == "1")
                        bReturn = true;

                return bReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if ((bool)value)
                    return 1;
                else return 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
