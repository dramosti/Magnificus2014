using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Entries.Services.Gerais;
using HLP.Comum.ViewModel.ViewModel;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class PlanoPagamentoCommand
    {
        PlanoPagamentoViewModel objViewModel;
        Plano_PagamentoService objService;

        public PlanoPagamentoCommand(PlanoPagamentoViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            objService = new Plano_PagamentoService();

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

            objViewModel.bWorkerCopy.DoWork += bwCopy_DoWork;
            objViewModel.bWorkerCopy.RunWorkerCompleted += bwCopy_RunWorkerCompleted;

            objViewModel.bWorkerPesquisa.DoWork += new DoWorkEventHandler(this.metodoGetModel);
            objViewModel.bWorkerPesquisa.RunWorkerCompleted += bw_RunWorkerCompleted;
        }



        #region Implementação Commands


        public void Save(object _panel)
        {
            try
            {
                if (this.objViewModel.currentModel.stAlocacao == (byte)0)
                {
                    if (this.objViewModel.currentModel.lPlano_pagamento_linhasModel.Count == 0)
                    {
                        MessageHlp.Show(stMessage: StMessage.stError, xMessageToUser: "Plano de pagamento é do tipo de alocação Especificado, é necessário no mínimo definir uma linha do plano de pagamento!");
                        return;
                    }
                    else if (this.objViewModel.currentModel.lPlano_pagamento_linhasModel.FirstOrDefault()
                        .stValorouPorcentagem == (byte)0)
                        if (this.objViewModel.currentModel.lPlano_pagamento_linhasModel.Sum(i => i.nValorouPorcentagem)
                            != 100)
                        {
                            MessageHlp.Show(stMessage: StMessage.stError,
                                xMessageToUser: "Soma de porcentagem deve ser igual a 100%");
                            return;
                        }
                }
                foreach (int id in this.objViewModel.currentModel.lPlano_pagamento_linhasModel.idExcluidos)
                {

                    this.objViewModel.currentModel.lPlano_pagamento_linhasModel.Add(
                        new Plano_pagamento_linhasModel
                        {
                            idLinhasPagamento = id,
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

                if (this.objViewModel.currentModel.lPlano_pagamento_linhasModel.Count(i => i.stValorouPorcentagem == (byte)0) > 0
                    && this.objViewModel.currentModel.lPlano_pagamento_linhasModel.Sum(
                        i => i.nValorouPorcentagem) < 100)
                {
                    Application.Current.Dispatcher.BeginInvoke((Action)(()
                =>
                    {
                        MessageHlp.Show(stMessage: StMessage.stAlert,
                            xMessageToUser: "Não é possível salvar registro, pois soma das porcentagens do plano de pagamento são inferiores a 100%");
                    }));
                }
                else
                {
                    if (objViewModel.message.Save())
                    {
                        this.objViewModel.currentModel = objService.SaveObject(obj: this.objViewModel.currentModel);
                        e.Result = e.Argument;
                    }
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
                        this.Inicia_Collections();
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
                    if (this.objService.DeleteObject(obj: this.objViewModel.currentModel))
                    {
                        objViewModel.message.Excluido();
                        iExcluir = this.objViewModel.currentModel.idPlanoPagamento ?? 0;
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
            this.objViewModel.currentModel = new Plano_pagamentoModel();
            this.objViewModel.novoBaseCommand.Execute(parameter: _panel);
            this.objViewModel.PlanoSort();
        }
        private bool NovoCanExecute()
        {
            return this.objViewModel.novoBaseCommand.CanExecute(parameter: null);
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
            catch (Exception)
            {

                throw;
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
            this.objViewModel.bWorkerPesquisa.RunWorkerAsync();
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    throw e.Error;
                }
                else
                {
                    if (this.objViewModel.currentModel != null)
                    {
                        this.Inicia_Collections();
                        this.objViewModel.PlanoSort();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void metodoGetModel(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentModel = this.objService.GetObject(id: this.objViewModel.currentID);
        }

        private void Inicia_Collections()
        {
            this.objViewModel.currentModel.lPlano_pagamento_linhasModel.CollectionCarregada();
        }

        #endregion


    }
}
