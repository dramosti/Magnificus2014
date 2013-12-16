using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HLP.Comum.Modules;
using HLP.Comum.ViewModel.Commands;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using HLP.Comum.Infrastructure.Static;
using HLP.Comum.Model.Models;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class CalendarioCommand
    {
        CalendarioViewModel objViewModel;
        CalendarioService.IserviceCalendarioClient servico = new CalendarioService.IserviceCalendarioClient();
        public CalendarioCommand(CalendarioViewModel objViewModel)
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
            //gerarDetalhamentoCommand

            this.objViewModel.gerarDetalhamentoCommand = new RelayCommand(execute: exec => this.GeraDetalhamento(),
                 canExecute: can => true);

        }

        #region Implementação Commands

        public void GeraDetalhamento()
        {
            Window win = GerenciadorModulo.Instancia.CarregaForm("WinCalendarioDetalhe", Comum.Modules.Interface.TipoExibeForm.Modal);
            win.ShowDialog();
            var dados = win.GetPropertyValue("lCalendarioDetalhes");
            if (dados != null)
                objViewModel.currentModel.lCalendario_DetalheModel = (ObservableCollectionBaseCadastros<Calendario_DetalheModel>)dados;
        }


        public async void Save()
        {
            try
            {
                foreach (int id in this.objViewModel.currentModel.lCalendario_DetalheModel.idExcluidos)
                {
                    this.objViewModel.currentModel.lCalendario_DetalheModel.Add(
                        new Calendario_DetalheModel
                        {
                            idCalendarioDetalhe = id,
                            status = Comum.Resources.RecursosBases.statusModel.excluido
                        });
                }
                this.objViewModel.currentModel =
                    await servico.SaveAsync(objViewModel.currentModel);
                this.objViewModel.salvarBaseCommand.Execute(parameter: null);
                this.Inicia_Collections();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private bool SaveCanExecute(object objDependency)
        {
            if (objViewModel.currentModel == null && objDependency == null)
                return false;

            return (this.objViewModel.salvarBaseCommand.CanExecute(parameter: null)
                && this.objViewModel.IsValid(objDependency as Panel));
        }

        public async void Copy()
        {
            try
            {
                this.objViewModel.currentModel = await this.servico.CopyAsync(this.objViewModel.currentModel);
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

        public async void Delete()
        {
            try
            {
                if (MessageBox.Show(messageBoxText: "Deseja excluir o cadastro?",
                    caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
                {
                    if (await servico.DeleteAsync(this.objViewModel.currentModel))
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
            this.objViewModel.currentModel = new CalendarioModel();
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


        public void ExecPesquisa()
        {
            this.objViewModel.pesquisarBaseCommand.Execute(null);
            this.PesquisarRegistro();
        }


        private void PesquisarRegistro()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(this.GetEmpresasBackground);
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.Inicia_Collections();
            }
            catch (Exception ex)
            {
                throw ex;
            }

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

        private void Inicia_Collections()
        {
            this.objViewModel.currentModel.lCalendario_DetalheModel.CollectionCarregada();
        }

        private void GetEmpresasBackground(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentModel = servico.GetObjeto(this.objViewModel.currentID);
        }
        #endregion


    }
}
