using HLP.Comum.View.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HLP.Comum.View.Converters
{
    public class ColumnVisibilityUcContatosVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if ((value as ObservableCollection<VisibilityToColumns>).FirstOrDefault(
                    i => i.xCampos == parameter.ToString()).isVisible)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
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
