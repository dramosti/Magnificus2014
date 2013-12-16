using HLP.Comum.Resources.Util;
using HLP.Comum.ViewModel.Commands;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class AtribuicaoColetivaListaPrecoCommands
    {
        AtribuicaoColetivaListaPrecoViewModel objViewModel;

        public AtribuicaoColetivaListaPrecoCommands(AtribuicaoColetivaListaPrecoViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            this.objViewModel.commAplicarAtribuicaoColetiva = new RelayCommand(
                execute: paramExec => this.AtribuicaoColetiva(o: paramExec),
                canExecute: paramCanExec => this.AtribuicaoColetivaCanExecute(o: paramCanExec));
        }

        private void AtribuicaoColetiva(object o)
        {
            if (MessageBox.Show(messageBoxText: "Deseja aplicar novos valores?",
                caption: "Confirma?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question) ==
                 MessageBoxResult.Yes)
            {
                object cell;
                int id = 0;
                if (((DataGrid)o).ItemsSource != null)
                {
                    foreach (object i in ((DataGrid)o).ItemsSource)
                    {
                        DataGridRow r = ((DataGrid)o).ItemContainerGenerator.ContainerFromItem(item: i) as DataGridRow;

                        if (r != null)
                        {
                            cell = StaticUtil.GetCell((DataGrid)o, r, 0);
                            if ((bool)((CheckBox)((DataGridCell)cell).Content).IsChecked)
                            {
                                cell = StaticUtil.GetCell((DataGrid)o, r, 1);
                                //id = Convert.ToInt32(value: ((DataGridCell)cell).Content);

                                id = Convert.ToInt32(value: ((ComboBox)((DataGridCell)cell).Content).SelectedValue);

                                switch (this.objViewModel.selectedIndex)
                                {
                                    case 0:
                                        {
                                            this.objViewModel.currentList.FirstOrDefault(it => it.idProduto == id).pDescontoMaximo
                                                = this.objViewModel.valor;
                                        } break;
                                    case 1:
                                        {
                                            this.objViewModel.currentList.FirstOrDefault(it => it.idProduto == id).pAcrescimoMaximo
                                                = this.objViewModel.valor;
                                        } break;
                                    case 2:
                                        {
                                            this.objViewModel.currentList.FirstOrDefault(it => it.idProduto == id).pComissaoAvista
                                                = this.objViewModel.valor;
                                        } break;
                                    case 3:
                                        {
                                            this.objViewModel.currentList.FirstOrDefault(it => it.idProduto == id).pComissaoAprazo
                                                = this.objViewModel.valor;
                                        } break;
                                    case 4:
                                        {
                                            this.objViewModel.currentList.FirstOrDefault(it => it.idProduto == id).vCustoProduto
                                                *= (1 + (this.objViewModel.valor / 100));
                                        } break;
                                    case 5:
                                        {
                                            this.objViewModel.currentList.FirstOrDefault(it => it.idProduto == id).vVenda
                                                *= (1 + (this.objViewModel.valor / 100));
                                        } break;
                                }

                            }
                        }
                    }
                }
                this.objViewModel.FechaForm(p: ((DataGrid)o).Parent);
            }
        }

        private bool AtribuicaoColetivaCanExecute(object o)
        {
            return true;
        }

    }
}
