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
using HLP.Comum.ViewModel.Components;

namespace HLP.Comum.View.Components
{
    /// <summary>
    /// Interaction logic for HlpPesquisa.xaml
    /// </summary>
    public partial class HlpPesquisa : BaseControl
    {
        public HlpPesquisa()
        {
            Items = new List<string>();
            InitializeComponent();
            this.DataContext = new HlpPesquisaViewModel(_TableView: this.TableView, _FieldPesquisa: this.FieldPesquisa, _Items: this.Items);
        }

        [Category("HLP")]
        public string FieldPesquisa
        {
            get { return (string)GetValue(FieldPesquisaProperty); }
            set { SetValue(FieldPesquisaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FieldPesquisa.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FieldPesquisaProperty =
            DependencyProperty.Register("FieldPesquisa", typeof(string), typeof(HlpPesquisa), new PropertyMetadata(string.Empty));

        [Category("HLP")]
        public string TableView
        {
            get { return (string)GetValue(TableViewProperty); }
            set { SetValue(TableViewProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TableView.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TableViewProperty =
            DependencyProperty.Register("TableView", typeof(string), typeof(HlpPesquisa), new PropertyMetadata(string.Empty));


        public static readonly DependencyProperty ItemsProperty =
        DependencyProperty.Register("Items",
        typeof(IList),
        typeof(HlpTextBox),
        new PropertyMetadata(new List<string>()));

        [Category("HLP")]
        public IList Items
        {
            get { return (IList)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
    }



}
