using HLP.Comum.ViewModel.Commands;
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

namespace HLP.Entries.ViewModel.Commands.Transportes
{
    public class TransportadorCommands
    {
        TransportadorViewModel objViewModel;
        transportadorService.IserviceTransportadorClient servico = new transportadorService.IserviceTransportadorClient();
        public TransportadorCommands(TransportadorViewModel objViewModel)
        {
            this.objViewModel = objViewModel;

            this.objViewModel.commandDeletar = new RelayCommand(paramExec => Delete(),
                    paramCanExec => DeleteCanExecute());

            this.objViewModel.commandSalvar = new RelayCommand(paramExec => Save(),
                    paramCanExec => SaveCanExecute(paramCanExec));

            this.objViewModel.commandNovo = new RelayCommand(execute: paramExec => this.Novo(),
                   canExecute: paramCanExec => this.NovoCanExecute());

            this.objViewModel.commandAlterar = new RelayCommand(execute: paramExec => this.Alterar(),
                    canExecute: paramCanExec => this.AlterarCanExecute());

            this.objViewModel.commandCancelar = new RelayCommand(execute: paramExec => this.Cancelar(),
                    canExecute: paramCanExec => this.CancelarCanExecute());

            this.objViewModel.commandCopiar = new RelayCommand(execute: paramExec => this.Copy(),
            canExecute: paramCanExec => this.CopyCanExecute());

            this.objViewModel.commandPesquisar = new RelayCommand(execute: paramExec => this.ExecPesquisa(),
                        canExecute: paramCanExec => true);

            this.objViewModel.navegarCommand = new RelayCommand(execute: paramExec => this.Navegar(ContentBotao: paramExec),
                canExecute: paramCanExec => objViewModel.navegarBaseCommand.CanExecute(paramCanExec));
        }


        #region Implementação Commands

        public async void Save()
        {
            try
            {
                foreach (int item in this.objViewModel.currentModel.lTransportador_Endereco.idExcluidos)
                {
                    this.objViewModel.currentModel.lTransportador_Endereco.Add(item:
                        new Transportador_EnderecoModel
                        {
                            idEndereco = item,
                            status = Comum.Resources.RecursosBases.statusModel.excluido
                        });
                }

                foreach (int item in this.objViewModel.currentModel.lTransportador_Motorista.idExcluidos)
                {
                    this.objViewModel.currentModel.lTransportador_Motorista.Add(item:
                        new Transportador_MotoristaModel
                        {
                            idTransportdorMotorista = item,
                            status = Comum.Resources.RecursosBases.statusModel.excluido
                        });
                }

                foreach (int item in this.objViewModel.currentModel.lTransportador_Veiculos.idExcluidos)
                {
                    this.objViewModel.currentModel.lTransportador_Veiculos.Add(item:
                        new Transportador_VeiculosModel
                        {
                            idTransportadorVeiculo = item,
                            status = Comum.Resources.RecursosBases.statusModel.excluido
                        });
                }

                foreach (int item in objViewModel.currentModel.lTransportador_Contato.idExcluidos)
                {
                    this.objViewModel.currentModel.lTransportador_Contato.Add(item:
                        new Transportador_ContatoModel
                        {
                            idTransportdorContato = item,
                            status = Comum.Resources.RecursosBases.statusModel.excluido
                        });
                }

                this.objViewModel.currentModel.idTransportador = await this.servico.saveTransportadorAsync(objTransportador:
                    this.objViewModel.currentModel);
                this.objViewModel.salvarBaseCommand.Execute(parameter: null);
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

        public async void Delete()
        {
            try
            {
                if (MessageBox.Show(messageBoxText: "Deseja excluir o cadastro?",
                    caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
                {
                    if (await this.servico.delTransportadorAsync(idTransportador: (int)this.objViewModel.currentModel.idTransportador))
                    {
                        MessageBox.Show(messageBoxText: "Cadastro excluido com sucesso!", caption: "Ok",
                            button: MessageBoxButton.OK, icon: MessageBoxImage.Information);
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
                this.objViewModel.deletarBaseCommand.Execute(parameter: null);
            }
        }

        private bool DeleteCanExecute()
        {
            if (objViewModel.currentModel == null)
                return false;

            return this.objViewModel.deletarBaseCommand.CanExecute(parameter: null);
        }

        private void Novo()
        {
            this.objViewModel.currentModel = new TransportadorModel();
            this.objViewModel.novoBaseCommand.Execute(parameter: null);
        }
        private bool NovoCanExecute()
        {
            return this.objViewModel.novoBaseCommand.CanExecute(parameter: null);
        }

        private void Alterar()
        {
            this.objViewModel.alterarBaseCommand.Execute(parameter: null);
        }
        private bool AlterarCanExecute()
        {
            return this.objViewModel.alterarBaseCommand.CanExecute(parameter: null);
        }

        private void Cancelar()
        {
            this.objViewModel.currentModel = null;
            this.objViewModel.cancelarBaseCommand.Execute(parameter: null);
        }
        private bool CancelarCanExecute()
        {
            return this.objViewModel.cancelarBaseCommand.CanExecute(parameter: null);
        }

        public async void Copy()
        {
            try
            {
                this.objViewModel.currentModel.idTransportador = await this.servico.copyTransportadorAsync(
                    idTransportador: (int)this.objViewModel.currentModel.idTransportador);
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
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(this.metodoGetModel);
            bw.RunWorkerAsync();

        }

        private async void metodoGetModel(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentModel = await this.servico.getTransportadorAsync(idTransportador:
                this.objViewModel.currentID);
        }
        #endregion


    }
}
