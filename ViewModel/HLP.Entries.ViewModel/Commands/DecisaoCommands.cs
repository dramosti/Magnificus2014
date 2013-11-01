using HLP.Comum.ViewModel.Commands;
using HLP.Dependencies;
using HLP.Entries.ViewModel.ViewModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Repository.Interfaces.Crm;
using HLP.Entries.Model.Models.Crm;

namespace HLP.Entries.ViewModel.Commands
{
    public class DecisaoCommands
    {
        [Inject]
        public IDecisaoRepository decisaoRepository { get; set; }

        DecisaoViewModel objViewModel;
        public DecisaoCommands(DecisaoViewModel vViewModel)
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);

            this.objViewModel = vViewModel;

            this.objViewModel.commandDeletar = new RelayCommand(paramExec => Delete(this.objViewModel.currentDecisao),
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
                decisaoRepository.Save(decisao: this.objViewModel.currentDecisao);
                this.objViewModel.commandSalvarBase.Execute(parameter: null);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private bool SaveCanExecute(object bValido)
        {
            if (this.objViewModel.currentDecisao == null)
                return false;

            return this.objViewModel.commandSalvarBase.CanExecute(parameter: null);
        }

        public void Delete(object objDecisao)
        {
            this.decisaoRepository.Delete(idDecisao: Convert.ToInt32((objDecisao as DecisaoModel).idDecisao));
            this.objViewModel.commandDeletarBase.Execute(parameter: null);
        }
        private bool DeleteCanExecute()
        {
            return this.objViewModel.commandDeletarBase.CanExecute(parameter: null);
        }

        private void Novo()
        {
            //this.objViewModel.currentDecisao = new DecisaoModel
            //{
            //    xDecisao = "",
            //    xDescricao = ""
            //};
            this.objViewModel.currentDecisao = new DecisaoModel();
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
        }
        private bool PesquisarCanExecute()
        {
            return this.objViewModel.commandPesquisarBase.CanExecute(parameter: null);
        }

        #endregion


    }
}
