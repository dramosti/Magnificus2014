using HLP.Base.ClassesBases;
using HLP.Base.Modules;
using HLP.Base.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for HlpPesquisa.xaml
    /// </summary>
    public partial class HlpPesquisa : BaseControl
    {
        public string Display
        {
            get { return (string)GetValue(DisplayProperty); }
            set { SetValue(DisplayProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Display.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayProperty =
            DependencyProperty.Register("Display", typeof(string), typeof(HlpPesquisa), new PropertyMetadata(string.Empty));



        public HlpPesquisa()
        {
            InitializeComponent();
        }

        public void ExecutaPesquisa(string sValor)
        {
            if (sValor.Equals("") || sValor.Equals("0"))
            {
                this.Display = string.Empty;
            }

            int iValida;
            if (int.TryParse(sValor, out iValida))
            {
                //if (this.servicoPesquisaRapida == null)
                //    this.servicoPesquisaRapida = new IservicePesquisaRapidaClient();

                //if (!sValor.Equals("0"))
                //{

                //    string[] teste = ((List<string>)this.Items).ToArray();

                //    int i = CompanyData.idEmpresa;

                //    var objRet = this.servicoPesquisaRapida.GetValorDisplayAsync
                //         (
                //         _TableView: this.TableView,
                //         _Items: teste,
                //         _FieldPesquisa: this.FieldPesquisa,
                //         idEmpresa: CompanyData.idEmpresa,
                //         _iValorPesquisa: Convert.ToInt32(sValor)
                //         );

                //    if (objRet != null)
                //    {
                //        if (objRet == "")
                //        {
                //            this.Display = objRet.ToString();
                //            this.txtID.Text = "0";
                //            this.txtID.Focus();
                //        }
                //        else
                //            this.Display = objRet.ToString();
                //    }
                //}
            }
        }

        #region Dependendy Property


        [Category("HLP.Owner")]
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(HlpPesquisa), new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnChanged)));

        public static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                HlpPesquisa comp = d as HlpPesquisa;
                if (e.NewValue != null)
                {
                    comp.ExecutaPesquisa(e.NewValue.ToString());
                    comp.Text = e.NewValue.ToString();
                }
                else
                {
                    comp.txtDisplay.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Category("HLP.Owner")]
        public string FieldPesquisa
        {
            get { return (string)GetValue(FieldPesquisaProperty); }
            set
            {
                SetValue(FieldPesquisaProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for FieldPesquisa.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FieldPesquisaProperty =
            DependencyProperty.Register("FieldPesquisa", typeof(string), typeof(HlpPesquisa), new PropertyMetadata(string.Empty));

        [Category("HLP.Owner")]
        public string TableView
        {
            get { return (string)GetValue(TableViewProperty); }
            set
            {
                SetValue(TableViewProperty, value);

            }
        }

        private string _NameWindowCadastro;

        public string NameWindowCadastro
        {
            get { return _NameWindowCadastro; }
            set { _NameWindowCadastro = value; }
        }


        // Using a DependencyProperty as the backing store for TableView.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TableViewProperty =
            DependencyProperty.Register("TableView", typeof(string), typeof(HlpPesquisa), new PropertyMetadata(string.Empty));

        //public static readonly DependencyProperty ItemsProperty =
        //DependencyProperty.Register("Items",
        //typeof(IList),
        //typeof(HlpPesquisa),
        //new PropertyMetadata(new List<string>()));

        //[Category("HLP.Owner")]
        //public IList Items
        //{
        //    get { return (IList)GetValue(ItemsProperty); }
        //    set
        //    {
        //        SetValue(ItemsProperty, new List<string>());
        //        SetValue(ItemsProperty, value);
        //    }
        //}


        private List<string> _Items = new List<string>();
        [Category("HLP.Owner")]
        public List<string> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }
        #endregion

        #region Eventos

        public event TextChangedEventHandler ucTxtTextChanged;

        private void ucTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ucTxtTextChanged != null)
            {
                ucTxtTextChanged(sender: sender, e: e);
            }
        }

        public event RoutedEventHandler ucTxtLostFocus;

        private void ucTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ucTxtLostFocus != null)
            {
                ucTxtLostFocus(sender: sender, e: e);
            }
        }

        public event TextChangedEventHandler ucTxtPesquisaTextChanged;

        private void ucTxtPesquisa_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ucTxtPesquisaTextChanged != null)
            {
                ucTxtPesquisaTextChanged(sender: sender, e: e);
            }
        }

        #endregion

        #region Propriedades
        private string _nameWindow;

        public string nameWindow
        {
            get { return _nameWindow; }
            set { _nameWindow = value; }
        }

        #endregion

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                this.IniciaPesquisa();
            }
        }

        private void IniciaPesquisa()
        {
            Window winPesquisa = GerenciadorModulo.Instancia.CarregaForm("WinPesquisaPadrao", Base.InterfacesBases.TipoExibeForm.Normal);
            this.txtID.Focus();
            winPesquisa.WindowState = WindowState.Maximized;
            winPesquisa.SetPropertyValue("NameView", this.TableView);
            winPesquisa.GetType().GetProperty(name: "NameWindowCadastro").SetValue(obj: winPesquisa, value: this.nameWindow);

            if (winPesquisa != null)
            {
                winPesquisa.ShowDialog();

                if ((winPesquisa.GetPropertyValue("lResult") as List<int>).Count > 0)
                {
                    this.Text = (winPesquisa.GetPropertyValue("lResult") as List<int>).FirstOrDefault().ToString();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.IniciaPesquisa();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (this.nameWindow != null)
            {
                object form = GerenciadorModulo.Instancia.CarregaForm(nome: this.nameWindow, exibeForm: Base.InterfacesBases.TipoExibeForm.Modal);

                Type t = form.GetType();
                ConstructorInfo constr = t.GetConstructor(Type.EmptyTypes);
                object inst = constr.Invoke(new object[] { });


                Window w = GerenciadorModulo.Instancia.CarregaForm(nome: "HlpPesquisaInsert",
                    exibeForm: Base.InterfacesBases.TipoExibeForm.Modal);

                (w.FindName(name: "ctrContent") as ContentControl).DataContext = (inst as Window).DataContext;
                (w.FindName(name: "ctrContent") as ContentControl).Content = (inst as Window).Content;

                Type tVm = (w.FindName(name: "ctrContent") as ContentControl).DataContext.GetType();
                object instVm = (w.FindName(name: "ctrContent") as ContentControl).DataContext;
                MethodInfo met = tVm.GetMethod(name: "get_commandNovo");
                ICommand comm = met.Invoke(instVm, new object[] { }) as ICommand;
                comm.Execute(parameter: (w.FindName(name: "ctrContent") as ContentControl).Content);
                if (w.ShowDialog() == true)
                {
                    this.Text = w.GetType().GetProperty(name: "idSalvo").GetValue(obj: w).ToString();
                }
            }
        }
    }
}
