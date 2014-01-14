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

        private void DataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            FillComboBoxViewModel cbxFill = new FillComboBoxViewModel();
            int? valor = (int?)cbxStDocumento.SelectedValue;
            clTipoOperacao.ItemsSource = cbxFill.GetAllValuesToComboBox(sNameView: "getTipoOperacaoValidaToComboBoxOrcamento",
                sParameter: valor != null ? valor.ToString() : "");
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender != null)
            {
                if ((sender as DataGrid).CurrentColumn != null)
                {
                    if ((sender as DataGrid).CurrentColumn.Header.ToString() == "Produtos")
                    {
                        int? id = null;
                        PropertyInfo pi;
                        foreach (var item in e.AddedItems)
                        {
                            pi = item.GetType().GetProperty(name: "id");

                            if (pi != null)
                                id = (int?)pi.GetValue(obj: item);
                        }

                        FillComboBoxViewModel cbxFill = new FillComboBoxViewModel();

                        if (id != null)
                            clUnidadeMedida.ItemsSource = cbxFill.GetAllValuesToComboBox(sNameView: "getUnidadeMedidaToComboBox",
                                sParameter: id.ToString());
                    }
                }
            }
        }

        private void pesquisaCliente_ucTxtPesquisaTextChanged(object sender, TextChangedEventArgs e)
        {
            FillComboBoxViewModel cbxFill = new FillComboBoxViewModel();
            cbxContato.ItemsSource = cbxFill.GetAllValuesToComboBox(sNameView: "getAuthorsToComboBox", sParameter: pesquisaCliente.Text);
            clListaPreco.IsReadOnly = this.ViewModel.bListaPrecoHabilitado;
        }

        private void cbxStDocumento_UCSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillComboBoxViewModel cbxFill = new FillComboBoxViewModel();
            int? valor = (int?)cbxStDocumento.SelectedValue;
            clTipoOperacao.ItemsSource = cbxFill.GetAllValuesToComboBox(sNameView: "getTipoOperacaoValidaToComboBoxOrcamento",
                sParameter: valor != null ? valor.ToString() : "");
        }
    }
}
