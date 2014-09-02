using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Base.Modules;
using HLP.Comum.ViewModel.ViewModel;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Services.Comercial;
using HLP.Entries.Services.Gerais;
using HLP.Entries.ViewModel.ViewModels.Comercial;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Entries.ViewModel.Commands.Comercial
{
    public class Lista_PrecoCommands
    {
        ClienteService objServiceCliente;
        Lista_PrecoViewModel objViewModel;
        ProdutoService objServicoProduto;
        int idOld = 0;
        bool bOpCancelada = false;
        Lista_PrecoService objService;
        Unidade_MedidaService objUnidadeMedidaService;

        public Lista_PrecoCommands(Lista_PrecoViewModel objViewModel)
        {
            objService = new Lista_PrecoService();
            this.objUnidadeMedidaService = new Unidade_MedidaService();
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
                    canExecute: paramCanExec => this.objViewModel.pesquisarBaseCommand.CanExecute(parameter: null));

            this.objViewModel.navegarCommand = new RelayCommand(execute: paramExec => this.Navegar(ContentBotao: paramExec),
                canExecute: paramCanExec => objViewModel.navegarBaseCommand.CanExecute(paramCanExec));

            this.objViewModel.gerarListaCommand = new RelayCommand(execute: paramExec => this.GerarLista(),
                canExecute: paramCanExec => this.GerarListaCanExecute());

            this.objViewModel.AtribuicaoColetivaCommand = new RelayCommand(execute: paramExec => this.AtribuicaoColetiva(xForm: paramExec),
                canExecute: paramCanExec => this.AtribuicaoColetivaCanExecute());

            this.objViewModel.AumVlrVendaCustoCommand = new RelayCommand(execute: paramExec => this.AumentarVlrVendaCustoExecute(),
                canExecute: paramCanExec => this.AumentarVlrVendaCustoCanExecute());

            this.objViewModel.ConfAumVlrVendaCommand = new RelayCommand(execute: paramExec => this.ConfAumVlrExecute(),
                canExecute: paramCanExec => this.ConfAumVlrCanExec());

            this.objViewModel.CancAumVlrVendaCommand = new RelayCommand(execute: paramExec => this.CancAumVlrExecute());

            this.objViewModel.navigatePesquisa = new MyObservableCollection<int>(
                collection: this.objService.GetAllIdsListaPreco());

            this.objServicoProduto = new ProdutoService();
            this.objViewModel.bwHierarquia = new BackgroundWorker();
            this.objViewModel.bwHierarquia.WorkerSupportsCancellation = true;
            this.objViewModel.bwHierarquia.DoWork += bwHierarquia_DoWork;
            this.objViewModel.bwHierarquia.RunWorkerCompleted += bwHierarquia_RunWorkerCompleted;

            objViewModel.bWorkerSave.DoWork += bwSalvar_DoWork;
            objViewModel.bWorkerSave.RunWorkerCompleted += bwSalvar_RunWorkerCompleted;

            objViewModel.bWorkerCopy.DoWork += bwCopy_DoWork;
            objViewModel.bWorkerCopy.RunWorkerCompleted += bwCopy_RunWorkerCompleted;

            objViewModel.bWorkerPesquisa.DoWork += new DoWorkEventHandler(this.getListaPreco);
            objViewModel.bWorkerPesquisa.RunWorkerCompleted += bw_RunWorkerCompleted;

            int currentId = objService.getIdListaPreferencial();
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
            this.PesquisarRegistro();
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
                exibeForm: Base.InterfacesBases.TipoExibeForm.Modal);

            object vm = null;
            vm = form.GetType().GetProperty(name: "DataContext").GetValue(obj: form);

            ((AtribuicaoColetivaListaPrecoViewModel)vm).currentList = new ObservableCollectionBaseCadastros<Lista_precoModel>(
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
            if (this.objViewModel.currentModel.stAtualizacao == (byte)0)
            {
                foreach (Lista_precoModel item in
                    this.objService.GetItensListaPreco(idListaPrecoPai: (int)this.objViewModel.currentModel.idListaPrecoOrigem))
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
                            idUnidadeMedida = p.idUnidadeMedidaVendas ?? 0,
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

            if (this.objViewModel.currentModel.stAtualizacao == (byte)0
                && (this.objViewModel.currentModel.idListaPrecoOrigem == 0 ||
                this.objViewModel.currentModel.idListaPrecoOrigem == null))
                return false;

            return this.objViewModel.bIsEnabled;
        }

        public void Save(object _panel)
        {
            try
            {
                foreach (int id in objViewModel.currentModel.lLista_preco.idExcluidos)
                {
                    this.objViewModel.currentModel.lLista_preco.Add(
                        item: new Lista_precoModel
                        {
                            idListaPreco = id,
                            status = statusModel.excluido
                        });
                }
                this.objViewModel.bWorkerSave.RunWorkerAsync(argument: _panel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        void bwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            if (objViewModel.message.Save())
            {
                objViewModel.currentModel = this.objService.Save(objModel: this.objViewModel.currentModel);
                e.Result = e.Argument;
            }
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
                    if (objViewModel.message.bSave)
                    {
                        this.objViewModel.salvarBaseCommand.Execute(parameter: null);

                        this.IniciaCollection();
                        this.objViewModel.bCompGeral = this.objViewModel.bCompListaAut = this.objViewModel.bCompListaManual = false;

                        this.objViewModel.navigatePesquisa = new MyObservableCollection<int>(
                    collection: this.objService.GetAllIdsListaPreco());

                        int currentId = this.objViewModel.currentModel.idListaPrecoPai ?? 0;
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
                            this.PesquisarRegistro();
                        }
                        else
                        {
                            this.objViewModel.navegarBaseCommand.Execute(parameter: "btnPrimeiro");
                        }

                        object w = objViewModel.GetParentWindow(e.Result);

                        if (w != null)
                        {
                            w.GetType().GetProperty(name: "idSalvo").SetValue(obj: w, value: this.objViewModel.currentID);
                            (w as Window).DialogResult = true;
                            (w as Window).Close();
                        }
                    }
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
                if (objViewModel.message.Excluir())
                {
                    if (this.objService.Delete(this.objViewModel.currentModel))
                    {
                        MessageBox.Show(messageBoxText: "Cadastro excluido com sucesso!", caption: "Ok",
                            button: MessageBoxButton.OK, icon: MessageBoxImage.Information);
                        iExcluir = (int)this.objViewModel.currentModel.idListaPrecoPai;
                        this.objViewModel.currentModel = null;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    OperacoesDataBaseViewModel vm = new OperacoesDataBaseViewModel();
                    vm.ShowWinExclusionDenied(xMessage: ex.Message, xValor: this.objViewModel.currentID.ToString());
                }
                else
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
            idOld = this.objViewModel.currentModel.idListaPrecoPai ?? 0;
            this.objViewModel.currentModel = new Lista_Preco_PaiModel();
            this.objViewModel.lIdsHierarquia = new List<Components.Model.Models.HlpButtonHierarquiaStruct>();
            this.objViewModel.currentModel.nDiasSemAtualicao = 0;
            this.objViewModel.currentModel.dListaPreco = DateTime.Now;
            this.objViewModel.currentModel.stAtualizacao = (byte)1;
            this.objViewModel.currentModel.Ativo = true;
            this.objViewModel.novoBaseCommand.Execute(parameter: _panel);
            this.objViewModel.bCompGeral = this.objViewModel.bCompListaAut = this.objViewModel.bCompListaManual = true;
            this.objViewModel.hierarquiaListaPreco = null;
            this.objViewModel.bWorkerNovo.RunWorkerAsync();
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

            this.objViewModel.bWorkerAlterar.RunWorkerAsync();
        }
        private bool AlterarCanExecute()
        {
            return this.objViewModel.alterarBaseCommand.CanExecute(parameter: null);
        }

        private void Cancelar()
        {
            if (objViewModel.message.Cancelar())
            {
                this.objViewModel.navigatePesquisa = new MyObservableCollection<int>(
                collection: this.objService.GetAllIdsListaPreco());
                int currentId = this.idOld;
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
                }
                this.PesquisarRegistro();
                this.objViewModel.cancelarBaseCommand.Execute(parameter: null);
                this.objViewModel.bCompGeral = this.objViewModel.bCompListaAut = this.objViewModel.bCompListaManual = false;
            }
        }
        private bool CancelarCanExecute()
        {
            return this.objViewModel.cancelarBaseCommand.CanExecute(parameter: null);
        }

        public void Copy()
        {
            try
            {
                this.objViewModel.bWorkerCopy.RunWorkerAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        void bwCopy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                throw new Exception(message: e.Error.Message);
            }
            else
            {
                this.objViewModel.viewModelComumCommands.SetFocusFirstControl();
            }
        }

        void bwCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.objViewModel.copyBaseCommand.Execute(null);
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
            if (this.objViewModel.bwHierarquia != null)
                if (this.objViewModel.bwHierarquia.IsBusy)
                {
                    this.bOpCancelada = true;
                }
            this.objViewModel.hierarquiaListaPreco = null;
            this.objViewModel.bWorkerPesquisa.RunWorkerAsync();
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
                    if (this.objViewModel.currentModel != null)
                    {
                        if (this.objViewModel.currentID > 0)
                        {
                            this.objViewModel.lIdsHierarquia = this.objService.getHierarquiaLista(idListaPreco: this.objViewModel.currentID);
                        }

                        foreach (Lista_precoModel item in this.objViewModel.currentModel.lLista_preco)
                        {
                            item.refListaPrecoPai = GCHandle.Alloc(value: this.objViewModel.currentModel);
                        }

                        this.objViewModel.currentModel.lLista_preco.CollectionChanged 
                            += this.objViewModel.currentModel.lLista_preco_CollectionChanged;
                    }

                    this.objViewModel.bTreeCarregada = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void getListaPrecoHierarquia(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentModel = this.objService.GetObjeto(id: this.objViewModel.selectedId);

            //if (this.objViewModel.currentModel != null)
            //    if (this.objViewModel.currentModel.lLista_preco != null)
            //        this.objViewModel.currentModel.lLista_preco.CollectionChanged += this.objViewModel.currentModel.lLista_preco_CollectionChanged;
        }

        private void getListaPreco(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentModel = this.objService.GetObjeto(id: this.objViewModel.currentID);

            this.objViewModel.selectedId = this.objViewModel.currentID;
        }
        #endregion

        public bool RotaPossuiListaPrecoPai(int idRota)
        {
            objServiceCliente = new ClienteService();
            return objServiceCliente.RotaPossuiListaPrecoPai(idRota: idRota);
        }

        public void MontraTreeView()
        {
            TreeView t = new TreeView();
            t.Items.Add(newItem:
            new TreeViewItem
            {
                Header = "Hierarquia Lista Preço"
            });


            TextBlock txt = new TextBlock();
            txt.Text = "Carregando Hierarquia...";

            this.objViewModel.hierarquiaListaPreco = txt;

            if (this.bOpCancelada)
            {
                txt.Text = "Cancelando carregamento de Hierarquia anterior, por favor, aguarde...";
                this.objViewModel.hierarquiaListaPreco = txt;
            }
            else
            {
                this.objViewModel.bwHierarquia.RunWorkerAsync(argument: t);
                this.objViewModel.bTreeCarregada = true;
            }
        }

        void bwHierarquia_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                throw new Exception(message: e.Error.Message);
            }
            else
            {
                if (this.bOpCancelada)
                {
                    this.bOpCancelada = false;
                    this.MontraTreeView();
                }
                else
                {
                    this.objViewModel.hierarquiaListaPreco = (TreeView)e.Result;
                }
            }
        }

        void bwHierarquia_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (!this.bOpCancelada)
                    this.GetHierarquiaListaPreco();

                if (!this.bOpCancelada)
                {
                    this.objViewModel.lObjHierarquia.MontaHierarquia(m: this.objViewModel.lObjHierarquia,
                        tvi: ((TreeView)e.Argument).Items[0] as TreeViewItem);
                    e.Result = e.Argument;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetHierarquiaListaPreco()
        {
            this.objViewModel.lObjHierarquia = new Components.Model.Models.modelToTreeView();
            this.objViewModel.lObjHierarquia = this.objService.GetHierarquiaListaFull(
                idListaPreco: this.objViewModel.selectedId);
        }

        public bool PrecoCustoManual(int idProduto)
        {
            return this.objServicoProduto.PrecoCustoManual(idProduto: idProduto);
        }

        public decimal GetPrecoCustoProduto(int idProduto)
        {
            return this.objServicoProduto.GetPrecoCustoProduto(idProduto: idProduto);
        }

        public ProdutoModel GetProduto(int idProduto)
        {
            return objServicoProduto.GetObjeto(id: idProduto);
        }

        public Unidade_medidaModel GetUnidadeMedida(int idUnidadeMedida)
        {
            return objUnidadeMedidaService.GetObject(id: idUnidadeMedida);
        }
    }
}
