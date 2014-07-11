using HLP.Components.ViewModel.ViewModels;
using System;
using System.Collections;
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
    ///     <MyNamespace:CustomTextintellisense/>
    ///
    /// </summary>
    public class CustomTextintellisense : TextBox
    {

        public IEnumerable Items
        {
            get { return (IEnumerable)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(IEnumerable), typeof(CustomTextintellisense), new PropertyMetadata(
                propertyChangedCallback: new PropertyChangedCallback(ItemsChanged)));

        private static void ItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                foreach (var item in e.NewValue as IEnumerable)
                {
                    (d as CustomTextintellisense).ContextMenu.Items.Add(newItem:
                        new MenuItem
                        {
                            Header = item.ToString(),
                        });
                }

            }
        }

        public CustomTextintellisense()
        {
            this.ViewModel = new CustomTextIntellisenseViewModel();

            ResourceDictionary resource = new ResourceDictionary
            {
                Source = new Uri("/HLP.Resources.View.WPF;component/Styles/Components/UserControlStyles.xaml", UriKind.RelativeOrAbsolute)
            };

            this.Style = resource["txtIntellisense"] as Style;
            this.ContextMenu.PlacementTarget = this;

            this.TextChanged += this.CustomTextintellisense_TextChanged;
            this.ContextMenu.Opened += ContextMenu_Opened;
        }

        void ContextMenu_Opened(object sender, RoutedEventArgs e)
        {
        }

        void CustomTextintellisense_TextChanged(object sender, TextChangedEventArgs e)
        {
            ContextMenuService.SetPlacementTarget(element: this.ContextMenu, value: this);
            ContextMenuService.SetPlacement(element: this.ContextMenu, value: System.Windows.Controls.Primitives.PlacementMode.Bottom);

            this.ContextMenu.IsOpen = true;
        }
               

        private CustomTextIntellisenseViewModel _ViewModel;

        public CustomTextIntellisenseViewModel ViewModel
        {
            get { return _ViewModel; }
            set { _ViewModel = value; }
        }


    }
}
