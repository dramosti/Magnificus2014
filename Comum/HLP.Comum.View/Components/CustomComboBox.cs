using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HLP.Comum.View.Components
{
    public class CustomComboBox : ComboBox
    {
        public CustomComboBox()
        {
            ResourceDictionary resource = new ResourceDictionary
            {
                Source = new Uri("/HLP.Comum.Resources;component/Styles/Components/ComponentsStyles.xaml", UriKind.RelativeOrAbsolute)
            };

            this.Style = resource["ComboBoxStyleLogin"] as Style;
        }
    }
}
