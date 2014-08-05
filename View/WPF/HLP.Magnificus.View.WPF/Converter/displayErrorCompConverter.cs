using HLP.Base.ClassesBases;
using HLP.Components.View.WPF;
using HLP.ComumView.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace HLP.Magnificus.View.WPF.Converter
{
    public class displayErrorCompConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<DetailsErrorModel> lReturn = new List<DetailsErrorModel>();
            DetailsErrorModel e;
            CustomTextBlock txt = null;
            ValidationError error = null;

            if (values[0] != null && values[0] != DependencyProperty.UnsetValue)
            {
                foreach (FrameworkElement comp in (values[0] as ObservableCollection<FrameworkElement>))
                {

                    e = new DetailsErrorModel();

                    error = Validation.GetErrors(element: comp).FirstOrDefault();

                    foreach (CustomTextBlock _txt in (Application.Current.MainWindow.DataContext as wdMainViewModel).winMan._currentTab.lTextBlock
                        .Where(i => i.GetType() == typeof(CustomTextBlock)))
                    {
                        if (_txt.labelFor == comp)
                        {
                            txt = _txt;
                            break;
                        }
                    }

                    if (error != null)
                        e.xError = error.ErrorContent.ToString();

                    if (txt != null)
                        e.xLabelComp = txt.Text;

                    e.isDataGridError = false;
                    e.comp = comp;

                    lReturn.Add(item: e);
                }
            }

            if (values[1] != null && values[1] != DependencyProperty.UnsetValue)
            {
                lReturn.AddRange(collection: (values[1] as ObservableCollection<DetailsErrorModel>).ToList());
            }

            return lReturn;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
