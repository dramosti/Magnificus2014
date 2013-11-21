using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HLP.Entries.ViewModel.ViewModels.Comercial;
using HLP.Entries.ViewModel.ViewModels;
using System.Windows.Controls;
using System.ComponentModel;

namespace HLP.Entries.ViewModel.Commands.Comercial
{
    public class Tipo_ProdutoCommands
    {
        Tipo_ProdutoViewModel objViewModel;

        private TipoProdutoService.IserviceTipoProdutoClient servicoProduto = new TipoProdutoService.IserviceTipoProdutoClient();

        public Tipo_ProdutoCommands(Tipo_ProdutoViewModel _objViewModel)
        {
            this.objViewModel = _objViewModel;
        }


        #region Implementação Commands

        public async void Save()
        {
            try
            {
                //TODO: método de serviço para salvar
                await servicoProduto.SaveAsync(objViewModel.currentModel);
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
                        //if (await this.servicoProduto.DeleteAsync((int)this.objViewModel.currentModel.idTipoProduto))
                        {
                            MessageBox.Show(messageBoxText: "Cadastro excluido com sucesso!", caption: "Ok",
                                button: MessageBoxButton.OK, icon: MessageBoxImage.Information);
                            this.objViewModel.currentModel = null;
                        }
                        //else
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
            //TODO: instanciar novo objeto
            this.objViewModel.novoBaseCommand.Execute(parameter: null);
        }
        private bool NovoCanExecute()
        {
            return this.objViewModel.novoBaseCommand.CanExecute(parameter: null);
        }

        private void Alterar()
        {
            this.objViewModel.alterarBaseCommand.Execute(parameter: null);
            //this.objViewModel.currentModel.lcamposSqlNotNull = this.objViewModel.lCampos.ToList();
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
                //TODO: Implementar serviço de copy
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
              //this.objViewModel.currentModel = await //TODO: método de serviço para pesquisar
          }
        #endregion





    }
}
