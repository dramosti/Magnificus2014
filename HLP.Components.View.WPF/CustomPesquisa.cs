﻿using System;
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
using HLP.Components.ViewModel.ViewModels;
using HLP.Base.Static;
using System.ComponentModel;
using HLP.Base.EnumsBases;

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
    ///     <MyNamespace:CustomPesquisa/>
    ///
    /// </summary>
    public class CustomPesquisa : TextBox
    {
        public CustomPesquisa()
        {
            this.Items = new List<string>();
            ResourceDictionary resource = new ResourceDictionary
            {
                Source = new Uri("/HLP.Resources.View.WPF;component/Styles/Components/UserControlStyles.xaml", UriKind.RelativeOrAbsolute)
            };
            this.Style = resource["TextBox_PESQUISA"] as Style;
            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
    new DependencyObject());

            if (!designTime)
            {
                this.ViewModel = new CustomPesquisaViewModel();
                this.Loaded += CustomPesquisa_Loaded;                
            }

            this.KeyUp += CustomPesquisa_KeyUp;
        }

        void CustomPesquisa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
                this.ViewModel.searchCommand.Execute(parameter: this);
        }

        void CustomPesquisa_Loaded(object sender, RoutedEventArgs e)
        {
            this.SetCommands();
        }

        public void SetCommands()
        {

            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
    new DependencyObject());

            if (!designTime)
            {
                this.GotFocus += CustomPesquisa_GotFocus;

                this.ApplyTemplate();
                object txt = this.Template.FindName(name: "xId", templatedParent: this);

                if (txt != null)
                {
                    ((TextBox)txt).ApplyTemplate();
                    object button = ((TextBox)txt).Template.FindName(name: "btnPesquisa", templatedParent: (TextBox)txt);

                    if (button != null)
                    {
                        ((Button)button).Command = this.ViewModel.searchCommand;
                        ((Button)button).CommandParameter = this;
                    }

                    foreach (MenuItem item in ((TextBox)txt).ContextMenu.Items)
                    {
                        if (item.Name == "insertItem")
                        {
                            item.Command = this.ViewModel.insertCommand;
                            item.CommandParameter = this;
                        }
                        else if (item.Name == "goItem")
                        {
                            item.Command = this.ViewModel.goToRecordCommand;
                            item.CommandParameter = this;
                        }
                    }
                }
            }
        }

        void CustomPesquisa_GotFocus(object sender, RoutedEventArgs e)
        {
            object txt = this.Template.FindName(name: "xId", templatedParent: this);
            (txt as TextBox).Focus();
        }

        public void SetEventFocusToTxtId(RoutedEventHandler _event)
        {
            this.ApplyTemplate();

            object txt = this.Template.FindName(name: "xId", templatedParent: this);

            if (txt != null)
            {
                (txt as TextBox).LostFocus += _event;
            }
        }

        private CustomPesquisaViewModel _ViewModel;

        public CustomPesquisaViewModel ViewModel
        {
            get
            {
                return this._ViewModel;
            }
            set
            {
                this._ViewModel = value;
            }
        }

        #region Propriedades Customizadas componentes

        private string _TableView;
        [Category("HLP.Owner")]
        public string TableView
        {
            get { return _TableView; }
            set { _TableView = value; }
        }

        private List<string> _Items;
        [Category("HLP.Owner")]
        public List<string> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

        private string _FieldPesquisa;
        [Category("HLP.Owner")]
        public string FieldPesquisa
        {
            get { return _FieldPesquisa; }
            set { _FieldPesquisa = value; }
        }

        private string _NameWindowCadastro;
        [Category("HLP.Owner")]
        public string NameWindowCadastro
        {
            get { return _NameWindowCadastro; }
            set { _NameWindowCadastro = value; }
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

        #endregion

        #region Dependency Properties

        public string xIdPesquisa
        {
            get { return (string)GetValue(xIdPesquisaProperty); }
            set { SetValue(xIdPesquisaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for xIdPesquisa.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty xIdPesquisaProperty =
            DependencyProperty.Register(
            "xIdPesquisa", typeof(string),
            typeof(CustomPesquisa),
            new FrameworkPropertyMetadata(defaultValue: string.Empty,
                propertyChangedCallback: new PropertyChangedCallback(OnxIdChanged)));

        public static void OnxIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d != null && e.NewValue != null)
            {
                int valorPesquisa = 0;
                int.TryParse(s: e.NewValue.ToString(), result: out valorPesquisa);

                (d as CustomPesquisa).ViewModel.GetValorDisplay(
                    _TableView: (d as CustomPesquisa)._TableView,
                    _Items: (d as CustomPesquisa)._Items,
                    _FieldPesquisa: (d as CustomPesquisa)._FieldPesquisa,
                    idEmpresa: CompanyData.idEmpresa,
                    _iValorPesquisa: valorPesquisa);
            }
        }

        #endregion
    }
}
