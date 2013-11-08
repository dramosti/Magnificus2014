using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.ViewModel.Commands;
using HLP.Dependencies;
using HLP.Entries.Model.Models;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using HLP.Entries.ViewModel.ViewModels;
using System.ComponentModel;

namespace HLP.Entries.ViewModel.Commands
{
    public class UFCommands
    {
        UFViewModel objViewModel;

        ufService.IserviceUfClient servicoUf = new ufService.IserviceUfClient();

        public UFCommands(UFViewModel objViewModel)
        {

            this.objViewModel = objViewModel;

            this.objViewModel.commandDeletar = new RelayCommand(paramExec => Delete(this.objViewModel.currentModel),
                    paramCanExec => DeleteCanExecute());

            this.objViewModel.commandSalvar = new RelayCommand(paramExec => Save(),
                    paramCanExec => SaveCanExecute(paramCanExec));

            this.objViewModel.commandNovo = new RelayCommand(execute: paramExec => this.Novo(),
                   canExecute: paramCanExec => this.NovoCanExecute());

            this.objViewModel.commandAlterar = new RelayCommand(execute: paramExec => this.Alterar(),
                    canExecute: paramCanExec => this.AlterarCanExecute());

            this.objViewModel.commandCancelar = new RelayCommand(execute: paramExec => this.Cancelar(),
                    canExecute: paramCanExec => this.CancelarCanExecute());

            //this.objViewModel.commandPesquisar = new RelayCommand(execute: paramExec => this.Pesquisar(param: paramExec),
            //        canExecute: paramCanExec => this.PesquisarCanExecute());

        }


        #region Implementação Commands

        public async void Save()
        {
            try
            {
                this.objViewModel.currentModel.idUF = await this.servicoUf.saveUfAsync(objModel: this.objViewModel.currentModel);
                this.objViewModel.commandSalvarBase.Execute(parameter: null);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private bool SaveCanExecute(object bValido)
        {
            if (objViewModel.currentModel == null)
                return false;

            return (objViewModel.currentModel.IsValid &&
                this.objViewModel.commandSalvarBase.CanExecute(parameter: null));
        }

        public void Delete(object objUFModel)
        {
            this.servicoUf.deleteUfAsync(idUf: (int)this.objViewModel.currentModel.idUF);
            this.objViewModel.commandDeletarBase.Execute(parameter: null);
        }
        private bool DeleteCanExecute()
        {
            if (objViewModel.currentModel == null)
                return false;

            return this.objViewModel.commandDeletarBase.CanExecute(parameter: null);
        }

        private void Novo()
        {
            this.objViewModel.currentModel = new UFModel();
            this.objViewModel.commandNovoBase.Execute(parameter: null);
        }
        private bool NovoCanExecute()
        {
            return this.objViewModel.commandNovoBase.CanExecute(parameter: null);
        }

        private void Alterar()
        {
            this.objViewModel.commandAlterarBase.Execute(parameter: null);
        }
        private bool AlterarCanExecute()
        {
            return this.objViewModel.commandAlterarBase.CanExecute(parameter: null);
        }

        private void Cancelar()
        {
            this.objViewModel.currentModel = new UFModel();
            this.objViewModel.commandCancelarBase.Execute(parameter: null);
        }
        private bool CancelarCanExecute()
        {
            return this.objViewModel.commandCancelarBase.CanExecute(parameter: null);
        }

        public void Pesquisar(object param)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(this.GetUFBackground);

            if (param != null)
                bw.RunWorkerAsync(argument: param);
        }

        private async void GetUFBackground(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentModel = await servicoUf.getUfAsync(idUf: Convert.ToInt32(e.Argument));
        }       

        #endregion

        #region Chamada de métodos assyncronos

        //private async Task<UFModel> getUfAsync(int idUf)
        //{
        //    return await servicoUf.getUfAsync(idUf: idUf);
        //}

        #endregion
    }
}
