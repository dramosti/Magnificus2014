using HLP.Components.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Components.View.WPF.Converter
{
    public class ComboBoxDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                string retorno = "";
                if (value != null)
                {
                    FillComboBoxViewModel fillCbxViewModel = new FillComboBoxViewModel();

                    retorno = fillCbxViewModel.GetDisplay(source: (parameter as ObjectDataProvider).Data, value: (int?)value ?? 0);
                    //modelToComboBox obj =
                    //    ((parameter as ObjectDataProvider).Data as ObservableCollection<modelToComboBox>).FirstOrDefault(i => i.id == (int)value);

                    //if (obj != null)
                    //    retorno = obj.display;
                }
                return retorno;
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
