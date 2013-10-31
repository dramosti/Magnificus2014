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
using Ninject;
using System.ComponentModel;

namespace HLP.Entries.ViewModel.Commands
{
    public class UFCommands
    {
        [Inject]
        public IUFRepository iUFRepository { get; set; }

        UFViewModel objViewModel;

        public UFCommands(UFViewModel objViewModel)
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);

            this.objViewModel = objViewModel;

            this.objViewModel.commandDeletar = new RelayCommand(paramExec => Delete(this.objViewModel.currentUF),
                paramCanExec => DeleteCanExecute());

            this.objViewModel.commandSalvar = new RelayCommand(paramExec => Save(),
                paramCanExec => SaveCanExecute(paramCanExec));

            this.objViewModel.commandNovo = new RelayCommand(execute: paramExec => this.Novo(),
               canExecute: paramCanExec => this.NovoCanExecute());

            this.objViewModel.commandAlterar = new RelayCommand(execute: paramExec => this.Alterar(),
                canExecute: paramCanExec => this.AlterarCanExecute());

            this.objViewModel.commandCancelar = new RelayCommand(execute: paramExec => this.Cancelar(),
                canExecute: paramCanExec => this.CancelarCanExecute());

            this.objViewModel.commandPesquisar = new RelayCommand(execute: paramExec => this.Pesquisar(param: paramExec),
                canExecute: paramCanExec => this.PesquisarCanExecute());
        }


        #region Implementação Commands

        public void Save()
        {
            try
            {
                iUFRepository.Save(objViewModel.currentUF);
                this.objViewModel.commandSalvarBase.Execute(parameter: null);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private bool SaveCanExecute(object bValido)
        {
            if (objViewModel.currentUF == null)
                return false;

            return (objViewModel.currentUF.IsValid &&
                this.objViewModel.commandSalvarBase.CanExecute(parameter: null));
        }

        public void Delete(object objUFModel)
        {
            iUFRepository.Delete(Convert.ToInt32((objUFModel as UFModel).idUF));
            this.objViewModel.commandDeletarBase.Execute(parameter: null);
        }
        private bool DeleteCanExecute()
        {
            return this.objViewModel.commandDeletarBase.CanExecute(parameter: null);
        }

        private void Novo()
        {
            this.objViewModel.currentUF = new UFModel
            {
                xSiglaUf = "",
                xUf = ""
            };
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
            this.objViewModel.commandCancelarBase.Execute(parameter: null);
        }
        private bool CancelarCanExecute()
        {
            return this.objViewModel.commandCancelarBase.CanExecute(parameter: null);
        }


        private void Pesquisar(object param)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(this.GetWorkOrdersBackground);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.GetWorkOrdersBackgroundComplete);

            if (param != null)
                bw.RunWorkerAsync(argument: param);
        }

        private bool PesquisarCanExecute()
        {
            return this.objViewModel.commandPesquisarBase.CanExecute(parameter: null);
        }

        private void GetWorkOrdersBackground(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentUF = iUFRepository.GetUF(idUF: Convert.ToInt32(e.Argument));
        }

        private void GetWorkOrdersBackgroundComplete(
          object sender,
          RunWorkerCompletedEventArgs e)
        {
            this.objViewModel.commandPesquisarBase.Execute(parameter: null);
        }

        #endregion

    }
}
