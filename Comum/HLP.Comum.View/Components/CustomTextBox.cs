using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Comum.View.Components
{
    public class CustomTextBox : TextBox
    {
        public CustomTextBox() 
        {
            ResourceDictionary resource = new ResourceDictionary
            {
                Source = new Uri("/HLP.Comum.Resources;component/Styles/mainStyle.xaml", UriKind.RelativeOrAbsolute)
            };

            this.Style = resource["TextBoxComponentStyle"] as Style;

        }
    }
}
