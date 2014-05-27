using HLP.Base.EnumsBases;
using HLP.Components.ViewModel.ViewModels;
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
    ///     <MyNamespace:CustomTextBox/>
    ///
    /// </summary>
    public class CustomTextBox : TextBox
    {
        static CustomTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomTextBox), new FrameworkPropertyMetadata(typeof(CustomTextBox)));


        }

        public CustomTextBox()
        {
            ResourceDictionary resource = new ResourceDictionary
            {
                Source = new Uri("/HLP.Resources.View.WPF;component/Styles/Components/UserControlStyles.xaml", UriKind.RelativeOrAbsolute)
            };


            this.Style = resource["TextBoxComponentStyle"] as Style;

            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
    new DependencyObject());

            if (!designTime)
            {
                this.CustomViewModel = new CustomTextBoxViewModel();

                this.ApplyTemplate();

                Button btn = this.Template.FindName(name: "btn", templatedParent: this) as Button;

                this.GotFocus += CustomTextBox_GotFocus;
            }
        }

        private CustomTextBoxViewModel _CustomViewModel;

        public CustomTextBoxViewModel CustomViewModel
        {
            get { return _CustomViewModel; }
            set { _CustomViewModel = value; }
        }


        void CustomTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.ApplyTemplate();

            TextBox txt = this.Template.FindName(name: "txt", templatedParent: this) as TextBox;

            txt.Focus();
        }

        public void SetEventFocusToTxtId(RoutedEventHandler _event)
        {
            this.ApplyTemplate();

            object txt = this.Template.FindName(name: "txt", templatedParent: this);

            if (txt != null)
            {
                (txt as TextBox).LostFocus += _event;
            }
        }

        private statusComponentePosicao _stCompPosicao;

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
        

        public bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.Register("IsEnabled", typeof(bool), typeof(CustomTextBox), new PropertyMetadata(defaultValue: false,
                propertyChangedCallback: new PropertyChangedCallback(
                OnIsEnabledChanged)));

        public static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d != null && e.NewValue != null)
            {
                if (((bool?)e.NewValue) == true)
                {
                    (d as CustomTextBox).CustomViewModel.visibility = Visibility.Collapsed;
                }
                else
                {
                    (d as CustomTextBox).CustomViewModel.visibility = Visibility.Visible;
                }
            }
        }

    }    
}
