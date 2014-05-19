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
using HLP.Components.ViewModel.ViewModels;
using HLP.Base.Static;
using System.ComponentModel;

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
            this.ViewModel = new CustomPesquisaViewModel();
        }

        public CustomPesquisaViewModel ViewModel
        {
            get
            {
                return this.DataContext as CustomPesquisaViewModel;
            }
            set
            {
                this.DataContext = value;
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

        private string[] _Items;
        [Category("HLP.Owner")]
        public string[] Items
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
