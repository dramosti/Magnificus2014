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
using Ninject;

namespace HLP.Comum.View.Components
{
    /// <summary>
    /// Interaction logic for HlpPesquisa1.xaml
    /// </summary>
    public partial class HlpPesquisa : BaseControl
    {
        [Inject]
        public IHlpPesquisaRapidaRepository iHlpPesquisaRapidaRepository { get; set; }
        private IKernel kernel = null;

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

        public void ExecutaPesquisa(string sValor)
        {
            if (sValor.Equals(""))
            {
                this.Display = string.Empty;
            }

            int iValida;
            if (int.TryParse(sValor, out iValida))
            {
                PesquisaRapidaModel objRet = iHlpPesquisaRapidaRepository.GetValorDisplay
                    (
                    _TableView: this.TableView,
                    _Items: this.Items,
                    _FieldPesquisa: this.FieldPesquisa,
                    _iValorPesquisa: Convert.ToInt32(sValor)
                    );

                if (objRet != null)
                {
                    this.Display = objRet.Display;
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
                if (e.NewValue != null)
                {
                    HlpPesquisa comp = d as HlpPesquisa;
                    if (comp.kernel == null)
                    {
                        comp.kernel = new StandardKernel(new MagnificusDependenciesModule());
                        comp.kernel.Settings.ActivationCacheDisabled = false;
                        comp.kernel.Inject(comp);
                    }

                    comp.ExecutaPesquisa(e.NewValue.ToString());
                    comp.Text = e.NewValue.ToString();
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

        public static readonly DependencyProperty ItemsProperty =
        DependencyProperty.Register("Items",
        typeof(IList),
        typeof(HlpPesquisa),
        new PropertyMetadata(new List<string>()));

        [Category("HLP.Owner")]
        public IList Items
        {
            get { return (IList)GetValue(ItemsProperty); }
            set
            {
                SetValue(ItemsProperty, new List<string>());
                SetValue(ItemsProperty, value);
            }
        }
        #endregion

    }
}
