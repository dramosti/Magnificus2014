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
using System.Windows.Shapes;
using HLP.Comum.View.Formularios;
using HLP.Sales.ViewModel.ViewModel.Comercio;
using HLP.Comum.ViewModel.ViewModels.Components;
using System.Reflection;
using HLP.Comum.Infrastructure.Static;
using System.ComponentModel;

namespace HLP.Entries.View.WPF.Comercial
{
    /// <summary>
    /// Interaction logic for WinOrcamento.xaml
    /// </summary>
    public partial class WinOrcamento : WindowsBase
    {
        public WinOrcamento()
        {
            InitializeComponent();
            this.ViewModel = new OrcamentoViewModel();
        }

        public OrcamentoViewModel ViewModel
        {
            get
            {
                return this.DataContext as OrcamentoViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void pesquisaCliente_ucTxtPesquisaTextChanged(object sender, TextChangedEventArgs e)
        {
            FillComboBoxViewModel cbxFill = new FillComboBoxViewModel();
            cbxContato.ItemsSource = cbxFill.GetAllValuesToComboBox(sNameView: "getAuthorsToComboBox", sParameter: pesquisaCliente.Text);
            clListaPreco.IsReadOnly = this.ViewModel.bListaPrecoHabilitado;
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void HlpComboBox_UCSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource cvs = FindResource(resourceKey: "cvsItens") as CollectionViewSource;
            cvs.Filter += new FilterEventHandler(this.ViewModel.ItensOrcamentoFilter);
            CollectionViewSource cvsImpostos = FindResource(resourceKey: "cvsImpostos") as CollectionViewSource;
            cvsImpostos.Filter += new FilterEventHandler(this.ViewModel.ItensOrcamentoFilter);
        }

        private void HlpComboBox_UCSelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            byte b = Convert.ToByte(value: cbxStatusFinanceiro.SelectedIndex);
        }
    }
}
