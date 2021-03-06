﻿using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Components.View.WPF.Converter;
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
        public CustomTextBox()
        {
            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
    new DependencyObject());

            if (!designTime)
            {
                Binding b = new Binding();

                RelativeSource r = new RelativeSource();
                r.Mode = RelativeSourceMode.Self;

                PropertyPath p = new PropertyPath(path: "IsReadOnly", pathParameters: new object[] { });

                b.Path = p;
                b.RelativeSource = r;

                TextboxStyleSelectorConverter txtConverter = new TextboxStyleSelectorConverter();
                b.Converter = txtConverter;

                BindingOperations.SetBinding(target: this,
                    dp: TextBox.StyleProperty, binding: b);

                this.CustomViewModel = new CustomTextBoxViewModel();

                this.ApplyTemplate();

                this.LostFocus += CustomTextBox_LostFocus;
            }
        }

        void CustomTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.actionOnLostFocus != null)
            {
                Type t = this.actionOnLostFocus.GetType();

                if (t == typeof(RelayCommand))
                {
                    FrameworkElement parent = this.Parent as FrameworkElement;

                    while (true)
                    {
                        if ((parent as FrameworkElement).Parent != null)
                        {
                            parent = (parent as FrameworkElement).Parent as FrameworkElement;
                        }
                        else
                            break;
                    }

                    if (((RelayCommand)this.actionOnLostFocus).CanExecute(parameter: parent))
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

        private CustomTextBoxViewModel _CustomViewModel;

        public CustomTextBoxViewModel CustomViewModel
        {
            get { return _CustomViewModel; }
            set { _CustomViewModel = value; }
        }

        private object _actionOnLostFocus;

        public object actionOnLostFocus
        {
            get { return _actionOnLostFocus; }
            set { _actionOnLostFocus = value; }
        }

        private object _actionParameter;

        public object actionParameter
        {
            get { return _actionParameter; }
            set { _actionParameter = value; }
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
    }
}