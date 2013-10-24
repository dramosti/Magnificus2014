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
        }


        #region Implementação Commands

        public void Save()
        {
            try
            {
                iUFRepository.Save(objViewModel.currentUF);
                this.objViewModel.currentOp = Comum.View.ClassesBases.OperacaoCadastro.pesquisando;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private bool SaveCanExecute(object bValido)
        {
            if (this.objViewModel.currentOp != Comum.View.ClassesBases.OperacaoCadastro.criando &&
                this.objViewModel.currentOp != Comum.View.ClassesBases.OperacaoCadastro.alterando)
                return false;

            return objViewModel.currentUF.IsValid;
        }

        public void Delete(object objUFModel)
        {
            iUFRepository.Delete(Convert.ToInt32((objUFModel as UFModel).idUF));
        }
        private bool DeleteCanExecute()
        {
            return this.objViewModel.currentOp == Comum.View.ClassesBases.OperacaoCadastro.pesquisando;
        }

        private void Novo()
        {
            this.objViewModel.currentUF = new UFModel
            {
                xSiglaUf = "",
                xUf = ""
            };
            this.objViewModel.currentOp = Comum.View.ClassesBases.OperacaoCadastro.criando;
        }
        private bool NovoCanExecute()
        {
            return (this.objViewModel.currentOp == Comum.View.ClassesBases.OperacaoCadastro.livre
                || this.objViewModel.currentOp == Comum.View.ClassesBases.OperacaoCadastro.pesquisando);
        }

        private void Alterar()
        {
            this.objViewModel.currentOp = Comum.View.ClassesBases.OperacaoCadastro.alterando;
        }
        private bool AlterarCanExecute()
        {
            return this.objViewModel.currentOp == Comum.View.ClassesBases.OperacaoCadastro.pesquisando;
        }


        private void Cancelar()
        {
            this.objViewModel.currentOp = Comum.View.ClassesBases.OperacaoCadastro.livre;
        }

        private bool CancelarCanExecute()
        {
            return (this.objViewModel.currentOp == Comum.View.ClassesBases.OperacaoCadastro.criando ||
                this.objViewModel.currentOp == Comum.View.ClassesBases.OperacaoCadastro.alterando);
        }


        #endregion

    }
}
