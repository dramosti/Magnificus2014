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
using HLP.Entries.ViewModel.ViewModels.Comercial;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using System.Collections;
using HLP.Comum.Resources.Util;
using System.Reflection;

namespace HLP.Entries.View.WPF.Gerais
{
    /// <summary>
    /// Interaction logic for WinListaPreco.xaml
    /// </summary>
    public partial class WinListaPreco : WindowsBase
    {
        produtoService.IserviceProdutoClient servico = new produtoService.IserviceProdutoClient();
        public WinListaPreco()
        {
            InitializeComponent();
            try
            {
                this.ViewModel = new Lista_PrecoViewModel();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Lista_PrecoViewModel ViewModel
        {
            get
            {
                return this.DataContext as Lista_PrecoViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void btnAtribuicaoColetiva_Click(object sender, RoutedEventArgs e)
        {
            WinAtribuicaoColetivaListaPreco winAtrib = new WinAtribuicaoColetivaListaPreco();
            this.ViewModel.AtribuicaoColetivaCommand.Execute(parameter: winAtrib);
        }

        private void gridItens_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            this.gridItens.BindingGroup.UpdateSources();
            switch (e.Column.DisplayIndex)
            {
                case 0:
                    {
                        DataGridCell c = StaticUtil.GetCell(grid: (DataGrid)sender, row: e.Row, column: 1);
                        DataGridCell cProduto = StaticUtil.GetCell(grid: (DataGrid)sender, row: e.Row, column: e.Column.DisplayIndex);
                        if (!c.IsEnabled)
                        {
                            try
                            {
                                e.Row.DataContext.GetType().GetProperty("vCustoProduto").SetValue(e.Row.DataContext,
                                    servico.getProduto(idProduto: (int)((ComboBox)cProduto.Content).SelectedValue).vCompra);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    } break;
            }
        }

        private void cbxStAtualizacao_UCSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.gridItens.Columns[2].IsReadOnly =
                this.gridItens.Columns[3].IsReadOnly =
                this.gridItens.Columns[6].IsReadOnly =
                this.gridItens.Columns[7].IsReadOnly =
                this.gridItens.Columns[8].IsReadOnly = (((HLP.Comum.View.Components.CustomComboBox)sender).SelectedIndex == 0);
        }
    }
}
