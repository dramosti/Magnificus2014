using HLP.Comum.Modules;
using HLP.Comum.ViewModel.Commands;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.ViewModel.Services.Comercial;
using HLP.Entries.ViewModel.ViewModels.Comercial;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Entries.ViewModel.Commands.Comercial
{
    public class Lista_PrecoCommands
    {
        BackgroundWorker bWorkerAcoes;
        Lista_PrecoViewModel objViewModel;
        ProdutoService objServicoProduto;

        Lista_PrecoService objServico;

        public Lista_PrecoCommands(Lista_PrecoViewModel objViewModel)
        {
            objServico = new Lista_PrecoService();

            this.objViewModel = objViewModel;

            this.objViewModel.commandDeletar = new RelayCommand(paramExec => Delete(),
                    paramCanExec => objViewModel.deletarBaseCommand.CanExecute(null));

            this.objViewModel.commandSalvar = new RelayCommand(paramExec => Save(_panel: paramExec),
                    paramCanExec => SaveCanExecute(paramCanExec));

            this.objViewModel.commandNovo = new RelayCommand(execute: paramExec => this.Novo(_panel: paramExec),
                   canExecute: paramCanExec => this.NovoCanExecute());

            this.objViewModel.commandAlterar = new RelayCommand(execute: paramExec => this.Alterar(_panel: paramExec),
                    canExecute: paramCanExec => this.AlterarCanExecute());

            this.objViewModel.commandCancelar = new RelayCommand(execute: paramExec => this.Cancelar(),
                    canExecute: paramCanExec => this.CancelarCanExecute());

            this.objViewModel.commandCopiar = new RelayCommand(execute: paramExec => this.Copy(),
            canExecute: paramCanExec => this.CopyCanExecute());

            this.objViewModel.commandPesquisar = new RelayCommand(execute: paramExec => this.ExecPesquisa(),
                    canExecute: paramCanExec => false);

            this.objViewModel.navegarCommand = new RelayCommand(execute: paramExec => this.Navegar(ContentBotao: paramExec),
                canExecute: paramCanExec => objViewModel.navegarBaseCommand.CanExecute(paramCanExec));

            this.objViewModel.gerarListaCommand = new RelayCommand(execute: paramExec => this.GerarLista(),
                canExecute: paramCanExec => this.GerarListaCanExecute());

            this.objViewModel.AtribuicaoColetivaCommand = new RelayCommand(execute: paramExec => this.AtribuicaoColetiva(xForm: paramExec),
                canExecute: paramCanExec => this.AtribuicaoColetivaCanExecute());

            //this.objViewModel.AtribuicaoColetivaCommand = new RelayCommand(execute: paramExec => this.AtribuirPercentual(param: paramExec),
            //    canExecute: paramCanExec => this.AtribuirPercentualCanExecute(param: paramCanExec));

            this.objViewModel.AumVlrVendaCustoCommand = new RelayCommand(execute: paramExec => this.AumentarVlrVendaCustoExecute(),
                canExecute: paramCanExec => this.AumentarVlrVendaCustoCanExecute());

            this.objViewModel.ConfAumVlrVendaCommand = new RelayCommand(execute: paramExec => this.ConfAumVlrExecute(),
                canExecute: paramCanExec => this.ConfAumVlrCanExec());

            this.objViewModel.CancAumVlrVendaCommand = new RelayCommand(execute: paramExec => this.CancAumVlrExecute());

            this.objViewModel.navigatePesquisa = new Comum.Model.Models.MyObservableCollection<int>(
                collection: this.objServico.GetAllIdsListaPreco());

            this.objServicoProduto = new ProdutoService();

            int currentId = objServico.getIdListaPreferencial();
            int currentPosition = 0;
            int i = 0;
            if (currentId != 0)
            {
                currentPosition = this.objViewModel.navigatePesquisa.IndexOf(item: currentId);

                while (i < currentPosition)
                {
                    this.objViewModel.navegarBaseCommand.Execute(parameter: "btnProximo");
                    i++;
                }

            }
            else
            {
                this.objViewModel.navegarBaseCommand.Execute(parameter: "btnPrimeiro");
                //this.objViewModel.currentID = this.objViewModel.navigatePesquisa.FirstOrDefault();
            }
            this.getListaPreco(this, null);

            this.objViewModel.SetValorCurrentOp(op: Comum.Resources.RecursosBases.OperacaoCadastro.pesquisando);
        }

        private void IniciaCollection()
        {
            if (this.objViewModel.currentModel != null)
                this.objViewModel.currentModel.lLista_preco.CollectionCarregada();
        }

        #region Implementação Commands

        private void ConfAumVlrExecute()
        {
            decimal p = decimal.Zero;

            if (decimal.TryParse(s: this.objViewModel.dPorcAumento.ToString(), result: out p))
            {
                foreach (Lista_precoModel item in this.objViewModel.currentModel.lLista_preco.Where(i => i.bChecked).ToList())
                {
                    if (this.objViewModel.byteIndex == 0)
                        item.vVenda *= (1 + (this.objViewModel.dPorcAumento / 100));
                    else if (this.objViewModel.byteIndex == 1)
                        item.vCustoProduto *= (1 + (this.objViewModel.dPorcAumento / 100));
                }
            }

            this.objViewModel.visAumentoVlr = Visibility.Collapsed;
        }

        private bool ConfAumVlrCanExec()
        {
            decimal p = decimal.Zero;

            return decimal.TryParse(s: this.objViewModel.dPorcAumento.ToString(), result: out p);
        }

        private void CancAumVlrExecute()
        {
            this.objViewModel.visAumentoVlr = Visibility.Collapsed;
        }

        private void AumentarVlrVendaCustoExecute()
        {
            this.objViewModel.visAumentoVlr = Visibility.Visible;
            this.objViewModel.dPorcAumento = decimal.Zero;
        }

        private bool AumentarVlrVendaCustoCanExecute()
        {
            return this.objViewModel.bIsEnabled && this.objViewModel.visAumentoVlr != Visibility.Visible;
        }

        private void AtribuirPercentual(object param)
        {
            decimal d;

            if (param == null)
            {
                d = decimal.Zero;
            }

            if (!decimal.TryParse(s: param.ToString(), result: out d))
            {
                d = decimal.Zero;
            }

            foreach (Lista_precoModel it in this.objViewModel.currentModel.lLista_preco)
            {
                it.vVenda *= 1 + (d / 100);
            }
        }

        private bool AtribuirPercentualCanExecute(object param)
        {
            return this.objViewModel.bIsEnabled;
        }

        private void AtribuicaoColetiva(object xForm)
        {
            Window form = GerenciadorModulo.Instancia.CarregaForm(nome: xForm.ToString(),
                exibeForm: HLP.Comum.Modules.Interface.TipoExibeForm.Modal);

            object vm = null;
            vm = form.GetType().GetProperty(name: "DataContext").GetValue(obj: form);

            ((AtribuicaoColetivaListaPrecoViewModel)vm).currentList = new Comum.Model.Models.ObservableCollectionBaseCadastros<Lista_precoModel>(
                list: this.objViewModel.currentModel.lLista_preco);

            ((AtribuicaoColetivaListaPrecoViewModel)vm).stAtualizacaoLista = this.objViewModel.currentModel.stAtualizacao;

            form.Show();
        }

        private bool AtribuicaoColetivaCanExecute()
        {
            return this.objViewModel.bIsEnabled;
        }

        private void GerarLista()
        {
            if (this.objViewModel.currentModel.idListaPrecoOrigem != null)
            {
                foreach (Lista_precoModel item in
                    this.objServico.GetItensListaPreco(idListaPrecoPai: (int)this.objViewModel.currentModel.idListaPrecoOrigem))
                {
                    if (this.objViewModel.currentModel.lLista_preco.Count(i => i.idProduto == item.idProduto) == 0)
                    {
                        this.objViewModel.currentModel.lLista_preco.Add(item: new Lista_precoModel
                        {
                            idProduto = item.idProduto,
                            idUnidadeMedida = item.idUnidadeMedida,
                            vCustoProduto = item.vCustoProduto,
                            vVenda = item.vVenda * (1 + ((this.objViewModel.currentModel.pPercentual ?? 0) / 100))
                        });
                    }
                }
            }
            else
            {
                foreach (ProdutoModel p in this.objServicoProduto.GetAll())
                {
                    if (this.objViewModel.currentModel.lLista_preco.Count(i => i.idProduto == p.idProduto) == 0)
                    {
                        this.objViewModel.currentModel.lLista_preco.Add(item: new Lista_precoModel
                        {
                            idProduto = (int)p.idProduto,
                            idUnidadeMedida = p.idUnidadeMedidaVendas,
                            vCustoProduto = p.vCompra
                        });
                    }
                }
            }
        }

        private bool GerarListaCanExecute()
        {
            if (this.objViewModel.currentModel == null)
                return false;

            return this.objViewModel.bIsEnabled;
        }

        public void Save(object _panel)
        {
            try
            {
                objViewModel.SetFocusFirstTab(_panel as Panel);
                foreach (int id in objViewModel.currentModel.lLista_preco.idExcluidos)
                {
                    this.objViewModel.currentModel.lLista_preco.Add(
                        item: new Lista_precoModel
                        {
                            idListaPreco = id,
                            status = Comum.Resources.RecursosBases.statusModel.excluido
                        });
                }
                bWorkerAcoes.DoWork += bwSalvar_DoWork;
                bWorkerAcoes.RunWorkerCompleted += bwSalvar_RunWorkerCompleted;
                bWorkerAcoes.RunWorkerAsync(_panel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        void bwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
            {
                objViewModel.currentModel = this.objServico.Save(objModel: this.objViewModel.currentModel);
            });
            
            e.Result = e.Argument;
        }

        void bwSalvar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    throw new Exception(message: e.Error.Message);
                }
                else
                {
                    this.objViewModel.salvarBaseCommand.Execute(parameter: e.Result as Panel);
                    object w = objViewModel.GetParentWindow(e.Result);

                    if (w != null)
                        if (w.GetType() == typeof(HLP.Comum.View.Formularios.HlpPesquisaInsert))
                        {
                            (w as HLP.Comum.View.Formularios.HlpPesquisaInsert).idSalvo = this.objViewModel.currentID;
                            (w as HLP.Comum.View.Formularios.HlpPesquisaInsert).DialogResult = true;
                            (w as HLP.Comum.View.Formularios.HlpPesquisaInsert).Close();
                        }
                    this.IniciaCollection();
                    this.objViewModel.bCompGeral = this.objViewModel.bCompListaAut = this.objViewModel.bCompListaManual = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool SaveCanExecute(object objDependency)
        {
            if (objViewModel.currentModel == null || objDependency == null)
                return false;

            return (this.objViewModel.salvarBaseCommand.CanExecute(parameter: null)
                && this.objViewModel.IsValid(objDependency as Panel));
        }

        public void Delete()
        {
            int iExcluir = 0;

            try
            {
                if (MessageBox.Show(messageBoxText: "Deseja excluir o cadastro?",
                    caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
                {
                    if (this.objServico.Delete(this.objViewModel.currentModel))
                    {
                        MessageBox.Show(messageBoxText: "Cadastro excluido com sucesso!", caption: "Ok",
                            button: MessageBoxButton.OK, icon: MessageBoxImage.Information);
                        iExcluir = (int)this.objViewModel.currentModel.idListaPrecoPai;
                        this.objViewModel.currentModel = null;
                    }
                    else
                    {
                        MessageBox.Show(messageBoxText: "Não foi possível excluir o cadastro!", caption: "Falha",
                            button: MessageBoxButton.OK, icon: MessageBoxImage.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.objViewModel.currentModel == null)
                {
                    this.objViewModel.deletarBaseCommand.Execute(parameter: iExcluir);
                    this.PesquisarRegistro();
                }
            }
        }

        private void Novo(object _panel)
        {
            this.objViewModel.currentModel = new Lista_Preco_PaiModel();
            this.objViewModel.currentModel.nDiasSemAtualicao = 0;
            this.objViewModel.currentModel.dListaPreco = DateTime.Now;
            this.objViewModel.currentModel.stAtualizacao = (byte)1;
            this.objViewModel.currentModel.Ativo = true;
            this.objViewModel.novoBaseCommand.Execute(parameter: _panel);
            this.objViewModel.bCompGeral = this.objViewModel.bCompListaAut = this.objViewModel.bCompListaManual = true;
            bWorkerAcoes = new BackgroundWorker();
            bWorkerAcoes.DoWork += bwNovo_DoWork;
            bWorkerAcoes.RunWorkerCompleted += bwNovo_RunWorkerCompleted;
            bWorkerAcoes.RunWorkerAsync(_panel);
        }

        void bwNovo_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            e.Result = e.Argument;
        }
        void bwNovo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            objViewModel.FocusToComponente(e.Result as Panel, Comum.Infrastructure.Static.Util.focoComponente.Segundo);
        }
        private bool NovoCanExecute()
        {
            return this.objViewModel.novoBaseCommand.CanExecute(parameter: null);
        }

        private void Alterar(object _panel)
        {
            this.objViewModel.alterarBaseCommand.Execute(parameter: _panel);

            if (this.objViewModel.currentModel.stAtualizacao == 0)
            {
                this.objViewModel.bCompListaManual = true;

            }
            else
            {
                this.objViewModel.bCompListaAut = true;
            }

            bWorkerAcoes = new BackgroundWorker();
            bWorkerAcoes.DoWork += bwAlterar_DoWork;
            bWorkerAcoes.RunWorkerCompleted += bwAlterar_RunWorkerCompleted;
            bWorkerAcoes.RunWorkerAsync(_panel);
        }

        void bwAlterar_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            e.Result = e.Argument;
        }
        void bwAlterar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            objViewModel.FocusToComponente(e.Result as Panel, Comum.Infrastructure.Static.Util.focoComponente.Segundo);
        }
        private bool AlterarCanExecute()
        {
            return this.objViewModel.alterarBaseCommand.CanExecute(parameter: null);
        }

        private void Cancelar()
        {
            if (MessageBox.Show(messageBoxText: "Deseja realmente cancelar a transação?", caption: "Cancelar?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question) == MessageBoxResult.No) return;
            this.PesquisarRegistro();
            this.objViewModel.cancelarBaseCommand.Execute(parameter: null);
            this.objViewModel.bCompGeral = this.objViewModel.bCompListaAut = this.objViewModel.bCompListaManual = false;
        }
        private bool CancelarCanExecute()
        {
            return this.objViewModel.cancelarBaseCommand.CanExecute(parameter: null);
        }

        public void Copy()
        {
            try
            {
                BackgroundWorker bwCopy = new BackgroundWorker();
                bwCopy.DoWork += bwCopy_DoWork;
                bwCopy.RunWorkerCompleted += bwCopy_RunWorkerCompleted;
                bwCopy.RunWorkerAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        void bwCopy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.objViewModel.currentID = (int)e.Result;
                this.getListaPreco(sender: this, e: null);
                this.objViewModel.copyBaseCommand.Execute(null);
                this.IniciaCollection();
            }
            catch (Exception)
            {

                throw;
            }
        }

        void bwCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = this.objServico.Copy(objModel: this.objViewModel.currentModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CopyCanExecute()
        {
            return this.objViewModel.copyBaseCommand.CanExecute(null);
        }

        public void Navegar(object ContentBotao)
        {
            try
            {
                objViewModel.navegarBaseCommand.Execute(ContentBotao);
                this.PesquisarRegistro();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecPesquisa()
        {
            this.objViewModel.pesquisarBaseCommand.Execute(null);
            this.PesquisarRegistro();
        }

        private void PesquisarRegistro()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(this.getListaPreco);
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    throw new Exception(message: e.Error.Message);
                }
                else
                {
                    this.IniciaCollection();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void getListaPreco(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentModel = this.objServico.GetObjeto(id: this.objViewModel.currentID);
        }
        #endregion


    }
}
