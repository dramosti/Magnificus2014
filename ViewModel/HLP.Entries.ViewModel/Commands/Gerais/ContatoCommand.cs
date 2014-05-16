using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Components.Model.Models;
using HLP.Entries.Services.Comercial;
using HLP.Entries.Model.Models.Transportes;
using HLP.Entries.Services.Transportes;
using HLP.Entries.Services.Gerais;
using System.Collections.ObjectModel;
using HLP.Comum.ViewModel.ViewModel;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class ContatoCommand
    {
        ContatoViewModel objViewModel;
        ContatoService objService;

        public ContatoCommand(ContatoViewModel objViewModel)
        {

            this.objViewModel = objViewModel;
            objService = new ContatoService();

            this.objViewModel.commandDeletar = new RelayCommand(paramExec => Delete(),
                    paramCanExec => false);

            this.objViewModel.commandSalvar = new RelayCommand(paramExec => Save(_panel: paramExec),
                    paramCanExec => SaveCanExecute(paramCanExec));

            this.objViewModel.commandNovo = new RelayCommand(execute: paramExec => this.Novo(_panel: paramExec),
                   canExecute: paramCanExec => this.NovoCanExecute());

            this.objViewModel.commandAlterar = new RelayCommand(execute: paramExec => this.Alterar(_panel: paramExec),
                    canExecute: paramCanExec => this.AlterarCanExecute());

            this.objViewModel.commandCancelar = new RelayCommand(execute: paramExec => this.Cancelar(),
                    canExecute: paramCanExec => this.CancelarCanExecute());

            this.objViewModel.commandCopiar = new RelayCommand(execute: paramExec => this.Copy(),
            canExecute: paramCanExec => this.CopyCanExecute());

            this.objViewModel.commandPesquisar = new RelayCommand(execute: paramExec => this.ExecPesquisa(),
                        canExecute: paramCanExec => this.objViewModel.pesquisarBaseCommand.CanExecute(parameter: null));

            this.objViewModel.navegarCommand = new RelayCommand(execute: paramExec => this.Navegar(ContentBotao: paramExec),
                canExecute: paramCanExec => objViewModel.navegarBaseCommand.CanExecute(paramCanExec));

            objViewModel.bWorkerSave.DoWork += bwSalvar_DoWork;
            objViewModel.bWorkerSave.RunWorkerCompleted += bwSalvar_RunWorkerCompleted;

            objViewModel.bWorkerCopy.DoWork += bwCopy_DoWork;
            objViewModel.bWorkerCopy.RunWorkerCompleted += bwCopy_RunWorkerCompleted;

            objViewModel.bWorkerPesquisa.DoWork += new DoWorkEventHandler(this.metodoGetModel);
            objViewModel.bWorkerPesquisa.RunWorkerCompleted += bw_RunWorkerCompleted;
        }


        #region Implementação Commands

        public void Save(object _panel)
        {
            try
            {
                foreach (int id in this.objViewModel.currentModel.lContato_EnderecoModel.idExcluidos)
                {
                    this.objViewModel.currentModel.lContato_EnderecoModel.Add(
                        new Contato_EnderecoModel
                        {
                            idEndereco = id,
                            status = statusModel.excluido
                        });
                }
                this.objViewModel.bWorkerSave.RunWorkerAsync(argument: _panel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        void bwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (objViewModel.message.Save())
                {
                    this.objViewModel.currentModel = objService.SaveObject(obj: this.objViewModel.currentModel);
                    e.Result = e.Argument;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void bwSalvar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    throw new Exception(message: e.Error.Message);
                }
                else
                {
                    if (objViewModel.message.bSave)
                    {
                        this.objViewModel.salvarBaseCommand.Execute(parameter: null);

                        object w = objViewModel.GetParentWindow(e.Result);

                        if (w != null)
                        {
                            w.GetType().GetProperty(name: "idSalvo").SetValue(obj: w, value: this.objViewModel.currentID);
                            (w as Window).DialogResult = true;
                            (w as Window).Close();
                        }
                    }
                    this.Inicia_Collections();
                }
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

        public void Delete()
        {
            int iExcluir = 0;

            try
            {
                if (objViewModel.message.Excluir())
                {
                    if (this.objService.DeleteObject(id: this.objViewModel.currentModel.idContato ?? 0))
                    {
                        objViewModel.message.Excluido();
                        iExcluir = (int)this.objViewModel.currentModel.idContato;
                        this.objViewModel.currentModel = null;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    OperacoesDataBaseViewModel vm = new OperacoesDataBaseViewModel();
                    vm.ShowWinExclusionDenied(xMessage: ex.Message, xValor: this.objViewModel.currentID.ToString());
                }
                else
                    throw ex;
            }
            finally
            {
                if (this.objViewModel.currentModel == null)
                {
                    this.objViewModel.deletarBaseCommand.Execute(parameter: iExcluir);
                    this.PesquisarRegistro();
                }
            }
        }

        private void Novo(object _panel)
        {
            this.objViewModel.currentModel = new ContatoModel();
            this.objViewModel.novoBaseCommand.Execute(parameter: _panel);
        }

        private bool NovoCanExecute()
        {
            return false;
        }

        private void Alterar(object _panel)
        {
            this.objViewModel.alterarBaseCommand.Execute(parameter: _panel);
        }

        private bool AlterarCanExecute()
        {
            return this.objViewModel.alterarBaseCommand.CanExecute(parameter: null);
        }

        private void Cancelar()
        {
            if (objViewModel.message.Cancelar())
            {
                this.PesquisarRegistro();
                this.objViewModel.cancelarBaseCommand.Execute(parameter: null);
            }
        }
        private bool CancelarCanExecute()
        {
            return this.objViewModel.cancelarBaseCommand.CanExecute(parameter: null);
        }

        public void Copy()
        {
            try
            {
                this.objViewModel.bWorkerCopy.RunWorkerAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        void bwCopy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    throw new Exception(message: e.Error.Message);
                }
                else
                {
                    this.objViewModel.viewModelBaseCommands.SetFocusFirstControl();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void bwCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.objViewModel.copyBaseCommand.Execute(null);
            }
            catch (Exception)
            {

                throw;
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
            this.objViewModel.bWorkerPesquisa.RunWorkerAsync();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    throw new Exception(message: e.Error.Message);
                }
                else
                {
                    if (this.objViewModel.currentModel != null)
                    {
                        if ((this.objViewModel.currentModel.idContatoMotorista != null
                            && this.objViewModel.currentModel.idContatoMotorista != 0) ||
                            (this.objViewModel.currentModel.idContatoTransportador != null
                            && this.objViewModel.currentModel.idContatoTransportador != 0)
                            )
                        {
                            TransportadoraService tService = new TransportadoraService();
                            TransportadorModel t = null;

                            if (this.objViewModel.currentModel.idContatoMotorista != null
                            && this.objViewModel.currentModel.idContatoMotorista != 0)
                            {
                                t = tService.GetObject(id: this.objViewModel.currentModel.idContatoMotorista ?? 0);
                            }
                            else
                            {
                                t = tService.GetObject(id: this.objViewModel.currentModel.idContatoTransportador ?? 0);
                            }

                            if (t != null)
                            {
                                this.objViewModel.currentModel.idEmpresaContato = t.idTransportador ?? 0;
                                this.objViewModel.currentModel.xEmpresa = t.xNome;
                                this.objViewModel.currentModel.xTelefoneEmpresa = t.xTelefone1;

                                if (t.lTransportador_Endereco != null)
                                {
                                    EnderecoModel endereco = null;
                                    CidadeService objCidadeService = new CidadeService();

                                    if (this.objViewModel.currentModel.idContatoMotorista != null
                            && this.objViewModel.currentModel.idContatoMotorista != 0)
                                    {
                                        if (t.lTransportador_Motorista != null)
                                        {
                                            this.objViewModel.lContatos = new ObservableCollection<ContatoModel>
                                            (list: t.lTransportador_Motorista.ToList());
                                        }
                                    }
                                    else
                                    {
                                        if (t.lTransportador_Contato != null)
                                        {
                                            this.objViewModel.lContatos = new ObservableCollection<ContatoModel>
                                            (list: t.lTransportador_Contato.ToList());
                                        }
                                    }

                                    if (this.objViewModel.lContatos != null)
                                        this.objViewModel.lContatos.RemoveAt(
                                                index: this.objViewModel.lContatos.IndexOf(item: this.objViewModel.lContatos.FirstOrDefault(
                                                i => i.idContato == this.objViewModel.currentModel.idContato)));

                                    if (t.lTransportador_Endereco.Count(i => i.stPrincipal == 1) > 0)
                                    {
                                        endereco = t.lTransportador_Endereco.FirstOrDefault(i => i.stPrincipal == 1);
                                    }
                                    else
                                    {
                                        endereco = t.lTransportador_Endereco.FirstOrDefault();
                                    }
                                    if (endereco != null)
                                    {
                                        CidadeModel cid = objCidadeService.GetObject(
                                            id: endereco.idCidade ?? 0);

                                        this.objViewModel.currentModel.xEnderecoEmpresa = string.Format(format: "{0}, {1}, {2}",
                                            arg0: endereco.xEndereco, arg1: endereco.xBairro, arg2: cid != null ?
                                            cid.xCidade : "");
                                    }
                                }
                            }
                        }
                    }
                }

                this.Inicia_Collections();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void metodoGetModel(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentModel = this.objService.GetObject(id: this.objViewModel.currentID);
        }

        private void Inicia_Collections()
        {
            if (this.objViewModel.currentModel != null)
                this.objViewModel.currentModel.lContato_EnderecoModel.CollectionCarregada();
        }

        #endregion

    }
}
