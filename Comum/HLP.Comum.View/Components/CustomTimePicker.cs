using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xceed.Wpf.Toolkit;

namespace HLP.Comum.View.Components
{
    public class CustomTimePicker : Xceed.Wpf.Toolkit.TimePicker
    {
        public CustomTimePicker() 
        {
            ResourceDictionary resource = new ResourceDictionary
            {
                Source = new Uri("/HLP.Comum.Resources;component/Styles/mainStyle.xaml", UriKind.RelativeOrAbsolute)
            };

            this.Style = resource["TimePickerStyle"] as Style;

        }
    }
}
