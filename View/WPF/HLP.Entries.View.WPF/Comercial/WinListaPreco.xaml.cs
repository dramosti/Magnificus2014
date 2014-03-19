﻿using HLP.Comum.Resources.Util;
using HLP.Comum.View.Formularios;
using HLP.Entries.View.WPF.Gerais;
using HLP.Entries.ViewModel.Services.Comercial;
using HLP.Entries.ViewModel.ViewModels.Comercial;
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

namespace HLP.Entries.View.WPF.Comercial
{
    /// <summary>
    /// Interaction logic for WinListaPreco.xaml
    /// </summary>
    public partial class WinListaPreco : WindowsBase
    {
        ProdutoService servico;

        public WinListaPreco()
        {
            InitializeComponent();
            try
            {
                this.ViewModel = new Lista_PrecoViewModel();
                this.servico = new ProdutoService();
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

            if (e.Column.Header.ToString() == "Produtos")
            {
                DataGridCell c = StaticUtil.GetCell(grid: (DataGrid)sender, row: e.Row, column: 1);
                DataGridCell cProduto = StaticUtil.GetCell(grid: (DataGrid)sender, row: e.Row, column: e.Column.DisplayIndex);
                object o = (cProduto.Content as ContentPresenter).Content.GetType().GetProperty(name: "idProduto")
                    .GetValue(obj: (cProduto.Content as ContentPresenter).Content);

                if (o != null)
                {
                    if (this.ViewModel.ProdutoJaInserido(idProduto: (int)o))
                    {
                        e.Cancel = true;
                        (cProduto.Content as ContentPresenter).Content.GetType().GetProperty(name: "idProduto").SetValue(
                            obj: (cProduto.Content as ContentPresenter).Content, value: 0);
                        MessageBox.Show(messageBoxText: "Produto já inserido na lista, verifique!", caption: "Atenção!",
                            button: MessageBoxButton.OK, icon: MessageBoxImage.Exclamation);
                    }
                    else
                    {
                        if (!c.IsEnabled)
                        {
                            try
                            {
                                e.Row.DataContext.GetType().GetProperty("vCustoProduto").SetValue(e.Row.DataContext,
                                    servico.GetPrecoCustoProduto(idProduto: (int)o));
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
            }
        }

        private void cbxStAtualizacao_UCSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //this.gridItens.Columns[2].IsReadOnly =
            //    this.gridItens.Columns[3].IsReadOnly =
            //    this.gridItens.Columns[6].IsReadOnly =
            //    this.gridItens.Columns[7].IsReadOnly =
            //    this.gridItens.Columns[8].IsReadOnly = (((HLP.Comum.View.Components.CustomComboBox)sender).SelectedIndex == 0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
