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
    ///     <MyNamespace:CustomHlpStatus/>
    ///
    /// </summary>
    public class CustomHlpStatus : StackPanel
    {
        static CustomHlpStatus()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomHlpStatus), new FrameworkPropertyMetadata(typeof(CustomHlpStatus)));
        }

        private List<string> _lStatus;

        public List<string> lStatus
        {
            get { return _lStatus; }
            set
            {
                _lStatus = value;
                CheckBox cb = null;
                foreach (string item in _lStatus)
                {
                    cb = new CheckBox();
                    cb.Content = item;
                    this.Children.Add(
                        element: cb);
                }
            }
        }

        public byte selectedStatus
        {
            get { return (byte)GetValue(selectedStatusProperty); }
            set { SetValue(selectedStatusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for selectedStatus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectedStatusProperty =
            DependencyProperty.Register("selectedStatus", typeof(byte), typeof(CustomHlpStatus), new PropertyMetadata(null));

    }
}
