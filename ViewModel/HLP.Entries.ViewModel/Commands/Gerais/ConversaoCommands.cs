using HLP.Base.EnumsBases;
using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using HLP.Entries.Services.Gerais;
using HLP.Comum.ViewModel.ViewModel;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class ConversaoCommands
    {
        ConversaoViewModel objViewModel;
        ConversaoService objService;
        Unidade_MedidaService objUnidade_MedidaService;


        List<Unidade_medidaModel> lUnidadesMedida;

        public ConversaoCommands(ConversaoViewModel objViewModel)
        {
            objService = new ConversaoService();
            this.objUnidade_MedidaService = new Unidade_MedidaService();
            this.lUnidadesMedida = new List<Unidade_medidaModel>();

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

            objViewModel.bWorkerSave.DoWork += bwSalvar_DoWork;
            objViewModel.bWorkerSave.RunWorkerCompleted += bwSalvar_RunWorkerCompleted;

            objViewModel.bWorkerPesquisa.DoWork += new DoWorkEventHandler(this.metodoGetModel);
            objViewModel.bWorkerPesquisa.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        public Unidade_medidaModel getUnidadeMedida(int id, bool bOptionalSearch = false)
        {
            return objUnidade_MedidaService.GetObject(id);
        }

        #region Implementação Commands

        public void Save(object _panel)
        {
            try
            {
                foreach (int item in this.objViewModel.currentModel.lProdutos_Conversao.idExcluidos)
                {
                    this.objViewModel.currentModel.lProdutos_Conversao.Add(
                        item: new ConversaoModel
                        {
                            idConversao = item,
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
            try
            {
                if (objViewModel.message.Save())
                {
                    objViewModel.currentModel.lProdutos_Conversao =
                    new ObservableCollectionBaseCadastros<ConversaoModel>(objService.SaveList(obj: this.objViewModel.currentModel));
                    e.Result = e.Argument;
                }

            }
            catch (Exception ex)
            {
                throw ex;
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

                        object w = objViewModel.GetParentWindow(e.Result);

                        if (w != null)
                        {
                            w.GetType().GetProperty(name: "idSalvo").SetValue(obj: w, value: this.objViewModel.currentID);
                            (w as Window).DialogResult = true;
                            (w as Window).Close();
                        }
                    }
                    this.IniciaCollection();
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
            int idRegistroDeletado = 0;
            try
            {
                if (objViewModel.message.Excluir())
                {
                    if (this.objService.DeleteObject(id: this.objViewModel.currentID))
                    {
                        objViewModel.message.Excluido();
                        idRegistroDeletado = (int)objViewModel.currentModel.idProduto;
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
                this.objViewModel.deletarBaseCommand.Execute(parameter: idRegistroDeletado);
            }
        }


        private void Novo(object _panel)
        {
            //this.objViewModel.currentModel = new ProdutoModel();
            //this.objViewModel.novoBaseCommand.Execute(parameter: _panel);
            //this._panel = _panel;
        }
        private bool NovoCanExecute()
        {
            //return this.objViewModel.novoBaseCommand.CanExecute(parameter: null);
            return false;
        }

        private void Alterar(object _panel)
        {
            this.objViewModel.alterarBaseCommand.Execute(parameter: _panel);
        }
        private bool AlterarCanExecute()
        {
            return this.objViewModel.alterarBaseCommand.CanExecute(parameter: null);
        }

        private void Cancelar()
        {
            if (objViewModel.message.Cancelar())
            {
                this.PesquisarRegistro();
                this.objViewModel.cancelarBaseCommand.Execute(parameter: null);
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
            try
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
            catch (Exception ex)
            {
                throw ex;
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
            return false;
            //return this.objViewModel.copyBaseCommand.CanExecute(null);
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
            this.objViewModel.bWorkerPesquisa.RunWorkerAsync();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.objViewModel.currentModel != null)
            {
                this.IniciaCollection();
            }


        }

        private void IniciaCollection()
        {
            this.objViewModel.currentModel.lProdutos_Conversao.CollectionCarregada();
            this.objViewModel.currentModel.lProdutos_Conversao.CollectionChanged += this.lProdutos_Conversao_CollectionChanged;            
        }

        void lProdutos_Conversao_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (ConversaoModel item in e.NewItems)
                {
                    item.idDeUnidadeMedida = this.objViewModel.currentModel.idUnidadeMedidaEstoque ?? 0;
                }
        }

        private void metodoGetModel(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentModel
                = this.objService.GetObject(id: this.objViewModel.currentID);
        }

        public void BuildConversaoDetail()
        {
            if (this.lUnidadesMedida.Count(i => i.idUnidadeMedida == this.objViewModel.currentConversao.idParaUnidadeMedida)
                 == 0)
            {
                Unidade_medidaModel um = this.objUnidade_MedidaService.GetObject(id: this.objViewModel.currentConversao.idParaUnidadeMedida);

                if (um != null)
                    this.lUnidadesMedida.Add(item: um);
            }

            if(this.lUnidadesMedida.Count(i => i.idUnidadeMedida == this.objViewModel.currentConversao.idDeUnidadeMedida)
                == 0)
            {
                Unidade_medidaModel um = this.objUnidade_MedidaService.GetObject(id: this.objViewModel.currentConversao.idDeUnidadeMedida);

                if (um != null)
                    this.lUnidadesMedida.Add(item: um);
            }

            Unidade_medidaModel umOrigem = this.lUnidadesMedida.FirstOrDefault(i => i.idUnidadeMedida == this.objViewModel.currentConversao.idDeUnidadeMedida);

            Unidade_medidaModel umPara = this.lUnidadesMedida.FirstOrDefault(i => i.idUnidadeMedida == this.objViewModel.currentConversao.idParaUnidadeMedida);

            this.objViewModel.conversaoDetail = string.Format(format: "Um(a) {1} de {0} é equivalente à {2} {3}s de {0}",
                args: new object[] { 
                    this.objViewModel.currentModel.xComercial,
                    umPara != null ? umPara.xUnidadeMedida : string.Empty,
                    string.Format(format: "{0:G29}", 
                    arg0: (this.objViewModel.currentConversao.nFator + (this.objViewModel.currentConversao.nQuantidadeAdicional ?? 0))),
                    umOrigem != null ? umOrigem.xUnidadeMedida : string.Empty
                });
        }

        #endregion


    }
}
