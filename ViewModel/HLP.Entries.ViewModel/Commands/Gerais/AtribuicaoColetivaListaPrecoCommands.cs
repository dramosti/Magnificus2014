using HLP.Base.ClassesBases;
using HLP.Comum.Resources.Util;
using HLP.Entries.ViewModel.Services.Comercial;
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
        ProdutoService objServico;

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
                string msgCustoNaoAtualizado = "";

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

                                var v = ((ComboBox)((DataGridCell)cell).Content).SelectedValue;

                                if (int.TryParse(s: v.ToString(), result: out id))
                                {

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
                                                objServico = new ProdutoService();
                                                if (objServico.PrecoCustoManual(idProduto: id))
                                                    this.objViewModel.currentList.FirstOrDefault(it => it.idProduto == id).vCustoProduto
                                                        *= (1 + (this.objViewModel.valor / 100));
                                                else
                                                    msgCustoNaoAtualizado += msgCustoNaoAtualizado == "" ? "Os itens com os seguintes códigos não foram atualizados." +
                                                        Environment.NewLine + "Motivo: Tipo de atualização no cadastro de produtos é diferente de 1 - Manual. " +
                                                        Environment.NewLine + "Ids: " + id.ToString() : ", " + id.ToString();
                                            } break;
                                        case 5:
                                            {
                                                this.objViewModel.currentList.FirstOrDefault(it => it.idProduto == id).pComissao
                                                    = this.objViewModel.valor;
                                            } break;
                                        case 6:
                                            {
                                                this.objViewModel.currentList.FirstOrDefault(it => it.idProduto == id).pDesconto
                                                    = this.objViewModel.valor;
                                            } break;
                                        case 7:
                                            {
                                                this.objViewModel.currentList.FirstOrDefault(it => it.idProduto == id).pOutros
                                                    = this.objViewModel.valor;
                                            } break;
                                        case 8:
                                            {
                                                this.objViewModel.currentList.FirstOrDefault(it => it.idProduto == id).pLucro
                                                    = this.objViewModel.valor;
                                            } break;
                                        case 9:
                                            {
                                                this.objViewModel.currentList.FirstOrDefault(it => it.idProduto == id).vVenda
                                                    *= (1 + (this.objViewModel.valor / 100));
                                            } break;
                                    }
                                }

                            }
                        }
                    }

                    if (msgCustoNaoAtualizado != "")
                        MessageBox.Show(messageBoxText: msgCustoNaoAtualizado, caption: "Atenção!",
                            button: MessageBoxButton.OK, icon: MessageBoxImage.Information);
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
