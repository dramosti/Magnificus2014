using System;
using System.Collections;
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
using HLP.Comum.Model.Components;
using HLP.Comum.Model.Repository.Interfaces.Components;
using HLP.Comum.ViewModel.ViewModels.Components;
using HLP.Dependencies;
using HLP.Comum.View.PesquisaRapidaService;
using HLP.Comum.Infrastructure.Static;

namespace HLP.Comum.View.Components
{
    /// <summary>
    /// Interaction logic for HlpPesquisa1.xaml
    /// </summary>
    public partial class HlpPesquisa : BaseControl
    {

        private IservicePesquisaRapidaClient servicoPesquisaRapida;

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
            //this.DataContext = this;

        }

        public async void ExecutaPesquisa(string sValor)
        {
            if (sValor.Equals("") || sValor.Equals("0"))
            {
                this.Display = string.Empty;
            }

            int iValida;
            if (int.TryParse(sValor, out iValida))
            {
                if (this.servicoPesquisaRapida == null)
                    this.servicoPesquisaRapida = new IservicePesquisaRapidaClient();

                if (!sValor.Equals("0"))
                {

                    string[] teste = ((List<string>)this.Items).ToArray();

                    int i = CompanyData.idEmpresa;

                    var objRet = await this.servicoPesquisaRapida.GetValorDisplayAsync
                         (
                         _TableView: this.TableView,
                         _Items: teste,
                         _FieldPesquisa: this.FieldPesquisa,
                         idEmpresa: CompanyData.idEmpresa,
                         _iValorPesquisa: Convert.ToInt32(sValor)
                         );

                    if (objRet != null)
                    {
                        if (objRet == "")
                        {
                            this.Display = objRet.ToString();
                            this.txtID.Text = "0";
                            this.txtID.Focus();
                        }
                        else
                            this.Display = objRet.ToString();
                    }
                }
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

        #endregion
    }
}
