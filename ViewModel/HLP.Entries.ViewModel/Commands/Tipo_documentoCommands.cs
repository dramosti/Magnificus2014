using HLP.Comum.ViewModel.Commands;
using HLP.Dependencies;
using HLP.Entries.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using HLP.Entries.Model.Repository.Interfaces.Fiscal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Fiscal;

namespace HLP.Entries.ViewModel.Commands
{
    public class Tipo_documentoCommands
    {
        private Tipo_documentoService.IserviceTipo_documentoClient servicoTipoDocumento = new Tipo_documentoService.IserviceTipo_documentoClient();

        Tipo_documentoViewModel objViewModel;
        public Tipo_documentoCommands(Tipo_documentoViewModel vViewModel)
        {          

            this.objViewModel = vViewModel;

            this.objViewModel.commandDeletar = new RelayCommand(paramExec => Delete(this.objViewModel.currentTipo_documento),
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

        public async void Save()
        {
            try
            {
                await this.servicoTipoDocumento.SaveAsync(documento: this.objViewModel.currentTipo_documento);
                this.objViewModel.commandSalvarBase.Execute(parameter: null);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private bool SaveCanExecute(object bValido)
        {
            if (this.objViewModel.currentTipo_documento == null)
                return false;
            return this.objViewModel.commandSalvarBase.CanExecute(parameter: null);
        }

        public async void Delete(object objTipo_documento)
        {
            await this.servicoTipoDocumento.DeleteAsync(idTipoDocumento: Convert.ToInt32(value: (objTipo_documento as Tipo_documentoModel)
                .idTipoDocumento));
            this.objViewModel.commandDeletarBase.Execute(parameter: null);
        }
        private bool DeleteCanExecute()
        {
            return this.objViewModel.commandDeletarBase.CanExecute(parameter: null);
        }

        private void Novo()
        {
            this.objViewModel.currentTipo_documento = new Tipo_documentoModel();
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

        #endregion


    }
}
