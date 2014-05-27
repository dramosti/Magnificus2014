using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Components.View.WPF.Converter
{
    public class RadioButtonCheckedButtonQuickSearchConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter.ToString() == "eq")
            {
                switch ((HLP.Base.EnumsBases.stFilterQuickSearch)value)
                {
                    case HLP.Base.EnumsBases.stFilterQuickSearch.equal: return true;
                    default: return false;
                }
            }
            else if (parameter.ToString() == "start")
            {
                switch ((HLP.Base.EnumsBases.stFilterQuickSearch)value)
                {
                    case HLP.Base.EnumsBases.stFilterQuickSearch.startWith: return true;
                    default: return false;
                }
            }
            else if (parameter.ToString() == "contains")
            {
                switch ((HLP.Base.EnumsBases.stFilterQuickSearch)value)
                {
                    case HLP.Base.EnumsBases.stFilterQuickSearch.contains: return true;
                    default: return false;
                }
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter.ToString() == "eq")
            {
                if ((bool)value)
                    return HLP.Base.EnumsBases.stFilterQuickSearch.equal;
            }
            else if (parameter.ToString() == "start")
            {
                if ((bool)value)
                    return HLP.Base.EnumsBases.stFilterQuickSearch.startWith;
            }
            else if (parameter.ToString() == "contains")
            {
                if ((bool)value)
                    return HLP.Base.EnumsBases.stFilterQuickSearch.contains;
            }
            return null;
        }
    }
}
