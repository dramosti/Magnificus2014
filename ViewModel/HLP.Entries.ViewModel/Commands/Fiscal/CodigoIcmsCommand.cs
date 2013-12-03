using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Fiscal;
using HLP.Entries.ViewModel.ViewModels.Fiscal;

namespace HLP.Entries.ViewModel.Commands.Fiscal
{
    public class CodigoIcmsCommand
    {
        CodigoIcmsViewModel objViewModel;
        CodigoIcmsService.IserviceCodigoIcmsClient servico = new CodigoIcmsService.IserviceCodigoIcmsClient();

        public CodigoIcmsCommand(CodigoIcmsViewModel objViewModel)
        {

        }


        //#region Implementação Commands

        //public async void Save()
        //{
        //    try
        //    {
        //        foreach (int id in this.objViewModel.currentModel.lCodigo_IcmsModel.idExcluidos)
        //        {
        //            this.objViewModel.currentModel.lCodigo_IcmsModel.Add(
        //                new Codigo_IcmsModel
        //                {
        //                    idCodigoIcms = id,
        //                    status = Comum.Resources.RecursosBases.statusModel.excluido
        //                });
        //        }
        //        this.objViewModel.currentModel =
        //            await servico.SaveAsync(objViewModel.currentModel);
        //        this.objViewModel.salvarBaseCommand.Execute(parameter: null);
        //        this.Inicia_Collections();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        //private bool SaveCanExecute(object objDependency)
        //{
        //    if (objViewModel.currentModel == null && objDependency == null)
        //        return false;

        //    return (this.objViewModel.salvarBaseCommand.CanExecute(parameter: null)
        //        && this.objViewModel.IsValid(objDependency as Panel));
        //}

        //public async void Copy()
        //{
        //    try
        //    {
        //        this.objViewModel.currentModel = await this.servico.copyEmpresaAsync(objEmpresa:
        //            this.objViewModel.currentModel);
        //        this.objViewModel.copyBaseCommand.Execute(null);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //public bool CopyCanExecute()
        //{
        //    return this.objViewModel.copyBaseCommand.CanExecute(null);
        //}

        //public async void Delete(object objUFModel)
        //{
        //    try
        //    {
        //        if (MessageBox.Show(messageBoxText: "Deseja excluir o cadastro?",
        //            caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
        //            == MessageBoxResult.Yes)
        //        {
        //            if (await servico.DeleteAsync(idEmpresa: (int)this.objViewModel.currentModel.idEmpresa))
        //            {
        //                MessageBox.Show(messageBoxText: "Cadastro excluido com sucesso!", caption: "Ok",
        //                    button: MessageBoxButton.OK, icon: MessageBoxImage.Information);
        //                this.objViewModel.currentModel = null;
        //            }
        //            else
        //            {
        //                MessageBox.Show(messageBoxText: "Não foi possível excluir o cadastro!", caption: "Falha",
        //                    button: MessageBoxButton.OK, icon: MessageBoxImage.Exclamation);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        this.objViewModel.deletarBaseCommand.Execute(parameter: null);
        //    }
        //}
        //private bool DeleteCanExecute()
        //{
        //    if (objViewModel.currentModel == null)
        //        return false;

        //    return this.objViewModel.deletarBaseCommand.CanExecute(parameter: null);
        //}

        //private void Novo()
        //{
        //    this.objViewModel.currentModel = new EmpresaModel();
        //    this.objViewModel.novoBaseCommand.Execute(parameter: null);
        //}
        //private bool NovoCanExecute()
        //{
        //    return this.objViewModel.novoBaseCommand.CanExecute(parameter: null);
        //}

        //private void Alterar()
        //{
        //    this.objViewModel.alterarBaseCommand.Execute(parameter: null);
        //}
        //private bool AlterarCanExecute()
        //{
        //    return this.objViewModel.alterarBaseCommand.CanExecute(parameter: null);
        //}

        //private void Cancelar()
        //{
        //    this.objViewModel.currentModel = null;
        //    this.objViewModel.cancelarBaseCommand.Execute(parameter: null);
        //}
        //private bool CancelarCanExecute()
        //{
        //    return this.objViewModel.cancelarBaseCommand.CanExecute(parameter: null);
        //}


        //public void ExecPesquisa()
        //{
        //    this.objViewModel.pesquisarBaseCommand.Execute(null);
        //    this.PesquisarRegistro();
        //}


        //private void PesquisarRegistro()
        //{
        //    BackgroundWorker bw = new BackgroundWorker();
        //    bw.DoWork += new DoWorkEventHandler(this.GetEmpresasBackground);
        //    bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        //    bw.RunWorkerAsync();
        //}

        //void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    try
        //    {
        //        this.Inicia_Collections();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        //public void Navegar(object ContentBotao)
        //{
        //    try
        //    {
        //        objViewModel.navegarBaseCommand.Execute(ContentBotao);
        //        this.PesquisarRegistro();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private void Inicia_Collections()
        //{
        //    this.objViewModel.currentModel.lEmpresa_endereco.CollectionCarregada();
        //}

        //private void GetEmpresasBackground(object sender, DoWorkEventArgs e)
        //{
        //    this.objViewModel.currentModel = servico.getEmpresa(idEmpresa: this.objViewModel.currentID);
        //}
        //#endregion


    }
}
