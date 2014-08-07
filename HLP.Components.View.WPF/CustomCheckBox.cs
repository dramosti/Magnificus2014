using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    ///     <MyNamespace:CustomCheckBox/>
    ///
    /// </summary>
    public class CustomCheckBox : CheckBox
    {
        static CustomCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomCheckBox), new FrameworkPropertyMetadata(typeof(CustomCheckBox)));
        }

        public CustomCheckBox()
        {
            ResourceDictionary resource = new ResourceDictionary
            {
                Source = new Uri("/HLP.Resources.View.WPF;component/Styles/Components/UserControlStyles.xaml", UriKind.RelativeOrAbsolute)
            };
            this.Style = resource["CheckBoxStyle"] as Style;

            this.LostFocus += CustomCheckBox_LostFocus;
        }

        void CustomCheckBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.actionOnLostFocus != null)
            {
                Type t = this.actionOnLostFocus.GetType();

                if (t == typeof(RelayCommand))
                {
                    if (((RelayCommand)this.actionOnLostFocus).CanExecute(parameter: null))
                        ((RelayCommand)this.actionOnLostFocus).Execute(parameter: null);
                }
                else if (t == typeof(Action<object>))
                {
                    ((Action<object>)this.actionOnLostFocus).Invoke(obj: this.actionParameter);
                }
                else
                {
                    ((Action)this.actionOnLostFocus).Invoke();
                }
            }
        }

        private object _actionParameter;

        public object actionParameter
        {
            get { return _actionParameter; }
            set { _actionParameter = value; }
        }

        private object _actionOnLostFocus;

        public object actionOnLostFocus
        {
            get { return _actionOnLostFocus; }
            set { _actionOnLostFocus = value; }
        }

        private statusComponentePosicao _stCompPosicao;
        [Category("HLP.Owner")]
        public statusComponentePosicao stCompPosicao
        {
            get { return _stCompPosicao; }
            set { _stCompPosicao = value; }
        }

        private StVisibilityButtonQuickSearch _stVisibilityBtnQuickSearch;

        public StVisibilityButtonQuickSearch stVisibilityBtnQuickSearch
        {
            get { return _stVisibilityBtnQuickSearch; }
            set { _stVisibilityBtnQuickSearch = value; }
        }
    }
}
