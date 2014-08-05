using HLP.Base.EnumsBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HLP.Components.View.WPF
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:HLP.Components.View.WPF"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:HLP.Components.View.WPF;assembly=HLP.Components.View.WPF"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomTextBlock/>
    ///
    /// </summary>
    public class CustomTextBlock : TextBlock
    {
        public CustomTextBlock()
        {
            ResourceDictionary resource = new ResourceDictionary
            {
                Source = new Uri("/HLP.Resources.View.WPF;component/Styles/Components/UserControlStyles.xaml", UriKind.RelativeOrAbsolute)
            };

            this.Style = resource["TextBlocktyleComponents"] as Style;

            this.MouseLeftButtonDown += CustomTextBlock_MouseLeftButtonDown;
        }

        void CustomTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.labelFor != null)
            {
                if (this.labelFor.GetType() == typeof(ucTextBoxIntellisense))
                {
                    (this.labelFor as ucTextBoxIntellisense).txt.Focus();
                }
                if (this.labelFor.GetType() == typeof(CustomTextBox))
                {
                    if ((this.labelFor as CustomTextBox).IsReadOnly == true)
                    {
                        TextBox txt = (this.labelFor as CustomTextBox).Template.FindName(name: "txt", 
                            templatedParent: (this.labelFor as CustomTextBox)) as TextBox;

                        if (txt != null)
                            txt.Focus();
                    }
                    else
                        this.labelFor.Focus();
                }
                else
                    this.labelFor.Focus();
            }
        }



        public UIElement labelFor
        {
            get { return (UIElement)GetValue(labelForProperty); }
            set { SetValue(labelForProperty, value); }
        }

        // Using a DependencyProperty as the backing store for labelFor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty labelForProperty =
            DependencyProperty.Register("labelFor", typeof(UIElement), typeof(CustomTextBlock), new PropertyMetadata(null));

        private StVisibilityButtonQuickSearch _stVisibilityBtnQuickSearch;

        public StVisibilityButtonQuickSearch stVisibilityBtnQuickSearch
        {
            get { return _stVisibilityBtnQuickSearch; }
            set { _stVisibilityBtnQuickSearch = value; }
        }
    }
}
