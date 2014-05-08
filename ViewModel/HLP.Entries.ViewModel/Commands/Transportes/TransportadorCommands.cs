﻿using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Transportes;
using HLP.Entries.ViewModel.ViewModels.Transportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HLP.Base.EnumsBases;
using HLP.Entries.Services.Transportes;
using HLP.Components.Model.Models;
using System.ServiceModel;
using HLP.Comum.ViewModel.ViewModel;

namespace HLP.Entries.ViewModel.Commands.Transportes
{
    public class TransportadorCommands
    {
        TransportadorViewModel objViewModel;
        TransportadoraService objService;

        public TransportadorCommands(TransportadorViewModel objViewModel)
        {
            this.objViewModel = objViewModel;

            this.objService = new TransportadoraService();

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

            objViewModel.bWorkerNovo.DoWork += bwNovo_DoWork;
            objViewModel.bWorkerNovo.RunWorkerCompleted += bwNovo_RunWorkerCompleted;

            objViewModel.bWorkerAlterar.DoWork += bwAlterar_DoWork;
            objViewModel.bWorkerAlterar.RunWorkerCompleted += bwAlterar_RunWorkerCompleted;

            objViewModel.bWorkerCopy.DoWork += bwCopy_DoWork;
            objViewModel.bWorkerCopy.RunWorkerCompleted += bwCopy_RunWorkerCompleted;

            objViewModel.bWorkerPesquisa.DoWork += new DoWorkEventHandler(this.metodoGetModel);
        }


        #region Implementação Commands

        public void Save(object _panel)
        {
            try
            {
                foreach (int item in this.objViewModel.currentModel.lTransportador_Endereco.idExcluidos)
                {
                    this.objViewModel.currentModel.lTransportador_Endereco.Add(item:
                        new EnderecoModel
                        {
                            idEndereco = item,
                            status = statusModel.excluido
                        });
                }

                foreach (int item in this.objViewModel.currentModel.lTransportador_Motorista.idExcluidos)
                {
                    this.objViewModel.currentModel.lTransportador_Motorista.Add(item:
                        new ContatoModel
                        {
                            idContato = item,
                            status = statusModel.excluido
                        });
                }

                foreach (int item in this.objViewModel.currentModel.lTransportador_Veiculos.idExcluidos)
                {
                    this.objViewModel.currentModel.lTransportador_Veiculos.Add(item:
                        new Transportador_VeiculosModel
                        {
                            idTransportadorVeiculo = item,
                            status = statusModel.excluido
                        });
                }

                foreach (int id in this.objViewModel.currentModel.lTransportador_Contato.idExcluidos)
                {
                    this.objViewModel.currentModel.lTransportador_Contato.Add(item:
                        new Components.Model.Models.ContatoModel
                        {
                            idContato = id,
                            status = statusModel.excluido
                        });
                }

                objViewModel.SetFocusFirstTab(_panel as Panel);
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
                this.objViewModel.currentModel = this.objService.SaveObject(obj:
                    this.objViewModel.currentModel);
                e.Result = e.Argument;
            }
            catch (FaultException fEx)
            {
                if (fEx.Code.Name == "sql221")
                    throw new Exception(message: fEx.Message);
            }
            catch (Exception)
            {

                throw;
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
                    this.objViewModel.salvarBaseCommand.Execute(parameter: null);
                    object w = objViewModel.GetParentWindow(e.Result);

                    while (this.objViewModel.currentModel.lTransportador_Contato.Count(
                        i => i.status == statusModel.excluido) > 0)
                    {
                        this.objViewModel.currentModel.lTransportador_Contato.Remove(
                            item: this.objViewModel.currentModel.lTransportador_Contato.FirstOrDefault(i => i.status == statusModel.excluido));
                    }

                    while (this.objViewModel.currentModel.lTransportador_Endereco.Count(
                        i => i.status == statusModel.excluido) > 0)
                    {
                        this.objViewModel.currentModel.lTransportador_Endereco.Remove(
                            item: this.objViewModel.currentModel.lTransportador_Endereco.FirstOrDefault(i => i.status == statusModel.excluido));
                    }

                    while (this.objViewModel.currentModel.lTransportador_Motorista.Count(
                        i => i.status == statusModel.excluido) > 0)
                    {
                        this.objViewModel.currentModel.lTransportador_Motorista.Remove(
                            item: this.objViewModel.currentModel.lTransportador_Motorista.FirstOrDefault(i => i.status == statusModel.excluido));
                    }

                    while (this.objViewModel.currentModel.lTransportador_Veiculos.Count(
                        i => i.status == statusModel.excluido) > 0)
                    {
                        this.objViewModel.currentModel.lTransportador_Veiculos.Remove(
                            item: this.objViewModel.currentModel.lTransportador_Veiculos.FirstOrDefault(i => i.status == statusModel.excluido));
                    }

                    if (w != null)
                        if (w.GetType() == typeof(HLP.Comum.View.Formularios.HlpPesquisaInsert))
                        {
                            (w as HLP.Comum.View.Formularios.HlpPesquisaInsert).idSalvo = this.objViewModel.currentID;
                            (w as HLP.Comum.View.Formularios.HlpPesquisaInsert).DialogResult = true;
                            (w as HLP.Comum.View.Formularios.HlpPesquisaInsert).Close();
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
                if (MessageBox.Show(messageBoxText: "Deseja excluir o cadastro?",
                    caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
                {
                    if (this.objService.DeleteObject(id: (int)this.objViewModel.currentModel.idTransportador))
                    {
                        MessageBox.Show(messageBoxText: "Cadastro excluido com sucesso!", caption: "Ok",
                            button: MessageBoxButton.OK, icon: MessageBoxImage.Information);
                        iExcluir = (int)this.objViewModel.currentModel.idTransportador;
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
            this.objViewModel.currentModel = new TransportadorModel();
            this.objViewModel.novoBaseCommand.Execute(parameter: _panel);
            this.objViewModel.bWorkerNovo.RunWorkerAsync(argument: _panel);
        }

        void bwNovo_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(millisecondsTimeout: 100);
            e.Result = e.Argument;
        }
        void bwNovo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            objViewModel.FocusToComponente(e.Result as Panel, HLP.Base.Static.Util.focoComponente.Segundo);
        }
        private bool NovoCanExecute()
        {
            return this.objViewModel.novoBaseCommand.CanExecute(parameter: null);
        }
        private void Alterar(object _panel)
        {
            this.objViewModel.alterarBaseCommand.Execute(parameter: _panel);
            this.objViewModel.bWorkerAlterar.RunWorkerAsync(argument: _panel);
        }

        void bwAlterar_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            e.Result = e.Argument;
        }
        void bwAlterar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            objViewModel.FocusToComponente(e.Result as Panel, HLP.Base.Static.Util.focoComponente.Segundo);
        }
        private bool AlterarCanExecute()
        {
            return this.objViewModel.alterarBaseCommand.CanExecute(parameter: null);
        }

        private void Cancelar()
        {
            if (MessageBox.Show(messageBoxText: "Deseja realmente cancelar a transação?", caption: "Cancelar?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question) == MessageBoxResult.No) return;
            //this.objViewModel.currentModel = null;
            this.PesquisarRegistro();
            this.objViewModel.cancelarBaseCommand.Execute(parameter: null);
        }
        private bool CancelarCanExecute()
        {
            return this.objViewModel.cancelarBaseCommand.CanExecute(parameter: null);
        }

        public void Copy()
        {
            try
            {
                this.objViewModel.currentModel = this.objService.CopyObject(obj: this.objViewModel.currentModel);
                this.objViewModel.copyBaseCommand.Execute(null);
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
                    this.objViewModel.currentModel = e.Result as TransportadorModel;
                    this.objViewModel.copyBaseCommand.Execute(null);
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
                e.Result =
                    this.objService.CopyObject(obj: this.objViewModel.currentModel);
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

        private void metodoGetModel(object sender, DoWorkEventArgs e)
        {
            if (this.objViewModel.currentID != 0)
                this.objViewModel.currentModel = this.objService.GetObject(id:
                    this.objViewModel.currentID);
            else
            {
                this.objViewModel.currentModel = null;
            }
        }
        #endregion


    }
}
