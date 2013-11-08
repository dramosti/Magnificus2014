using HLP.Comum.Model.Models;
using HLP.Comum.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Resources.RecursosBases;

namespace HLP.Comum.ViewModel.Commands
{
    public class ViewModelBaseCommands
    {
        ViewModelBase viewModel;
        public OperacaoCadastro currentOp { get; set; }


        public ViewModelBaseCommands(ViewModelBase vViewModel)
        {
            this.viewModel = vViewModel;
            this.viewModel.novoBaseCommand = new RelayCommand(execute: pExec => this.novoBase(),
                canExecute: pCanExec => this.novoBaseCanExecute());
            this.viewModel.alterarBaseCommand = new RelayCommand(execute: pExec => this.alterarBase(),
                canExecute: pCanExec => this.alterarBaseCanExecute());
            this.viewModel.deletarBaseCommand = new RelayCommand(execute: pExec => this.delBase(),
                canExecute: pCanExec => this.delBaseCanExecute());
            this.viewModel.salvarBaseCommand = new RelayCommand(execute: pExec => this.salvarBase(),
                canExecute: pCanExec => this.salvarBaseCanExecute());
            this.viewModel.cancelarBaseCommand = new RelayCommand(execute: pExec => this.cancelarBase(),
                canExecute: pCanExec => this.cancelarBaseCanExecute());
            this.viewModel.pesquisarBaseCommand = new RelayCommand(execute: pExec => this.pesquisaBase(),
                canExecute: pCanExec => this.pesquisaBaseCanExecute());
            this.currentOp = OperacaoCadastro.livre;
        }

        #region Executes & CanExecutes
        private void novoBase()
        {
            this.currentOp = Resources.RecursosBases.OperacaoCadastro.criando;
            this.viewModel.bIsEnabled = true;
        }
        private bool novoBaseCanExecute()
        {
            return (this.currentOp == Resources.RecursosBases.OperacaoCadastro.livre
                || this.currentOp == Resources.RecursosBases.OperacaoCadastro.pesquisando);
        }

        private void alterarBase()
        {
            this.currentOp = Resources.RecursosBases.OperacaoCadastro.alterando;
            this.viewModel.bIsEnabled = true;
        }
        private bool alterarBaseCanExecute()
        {
            return this.currentOp == Resources.RecursosBases.OperacaoCadastro.pesquisando;
        }

        private void delBase()
        {
            this.currentOp = Resources.RecursosBases.OperacaoCadastro.livre;
        }
        private bool delBaseCanExecute()
        {
            return this.currentOp == Resources.RecursosBases.OperacaoCadastro.pesquisando;
        }

        private void salvarBase()
        {
            this.currentOp = Resources.RecursosBases.OperacaoCadastro.pesquisando;
            this.viewModel.bIsEnabled = false;
        }
        private bool salvarBaseCanExecute()
        {
            if (this.currentOp != Resources.RecursosBases.OperacaoCadastro.criando &&
                this.currentOp != Resources.RecursosBases.OperacaoCadastro.alterando)
                return false;
            else
                return true;
        }

        private void cancelarBase()
        {
            this.currentOp = Resources.RecursosBases.OperacaoCadastro.livre;
            this.viewModel.bIsEnabled = false;
        }
        private bool cancelarBaseCanExecute()
        {
            return (this.currentOp == Resources.RecursosBases.OperacaoCadastro.criando ||
                this.currentOp == Resources.RecursosBases.OperacaoCadastro.alterando);
        }

        private void pesquisaBase()
        {
            this.currentOp = OperacaoCadastro.pesquisando;
        }
        private bool pesquisaBaseCanExecute()
        {
            return this.currentOp == OperacaoCadastro.livre ||
                this.currentOp == OperacaoCadastro.pesquisando;
        }


        #endregion
    }
}
