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
using HLP.Base.Modules;
using HLP.Base.Static;
using HLP.Entries.Services.Gerais;
using System.Collections.ObjectModel;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class CalendarioCommand
    {
        CalendarioViewModel objViewModel;
        CalendarioService service = new CalendarioService();
        public CalendarioCommand(CalendarioViewModel objViewModel)
        {

            this.objViewModel = objViewModel;

            this.objViewModel.commandDeletar = new RelayCommand(paramExec => Delete(),
                    paramCanExec => objViewModel.deletarBaseCommand.CanExecute(null));

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
            //gerarDetalhamentoCommand

            this.objViewModel.gerarDetalhamentoCommand = new RelayCommand(execute: exec => this.GeraDetalhamento(),
                 canExecute: can => true);
            this.objViewModel.gerarByCalendarioBaseCommand = new RelayCommand(execute: exec => this.GerarDetalhamentoByCalendarBase(),
                canExecute: can => this.CanGerarDetalhamentoByCalendarBase());

            objViewModel.bWorkerSave.DoWork += bwSalvar_DoWork;
            objViewModel.bWorkerSave.RunWorkerCompleted += bwSalvar_RunWorkerCompleted;

            objViewModel.bWorkerNovo.DoWork += bwNovo_DoWork;
            objViewModel.bWorkerNovo.RunWorkerCompleted += bwNovo_RunWorkerCompleted;

            objViewModel.bWorkerAlterar.DoWork += bwAlterar_DoWork;
            objViewModel.bWorkerAlterar.RunWorkerCompleted += bwAlterar_RunWorkerCompleted;

            objViewModel.bWorkerCopy.DoWork += bwCopy_DoWork;
            objViewModel.bWorkerCopy.RunWorkerCompleted += bwCopy_RunWorkerCompleted;

            objViewModel.bWorkerPesquisa.DoWork += new DoWorkEventHandler(this.GetCalendario);
            objViewModel.bWorkerPesquisa.RunWorkerCompleted += bw_RunWorkerCompleted;
        }




        #region Implementação Commands

        public void GerarDetalhamentoByCalendarBase()
        {
            CalendarioModel objBase = service.GetObject((int)objViewModel.currentModel.idCalendarioBase);
            foreach (var item in objBase.lCalendario_DetalheModel)
            {
                item.idCalendarioDetalhe = null;
                item.status = statusModel.criado;
            }
            objViewModel.currentModel.lCalendario_DetalheModel = objBase.lCalendario_DetalheModel;
        }

        public bool CanGerarDetalhamentoByCalendarBase()
        {
            bool breturn = false;
            if (objViewModel.currentModel != null)
                if (objViewModel.currentModel.idCalendarioBase != null)
                    if (objViewModel.currentModel.idCalendarioBase > 0)
                        breturn = true;
            return breturn;
        }

        public void GeraDetalhamento()
        {
            Window win = GerenciadorModulo.Instancia.CarregaForm("WinCalendarioDetalhe", Base.InterfacesBases.TipoExibeForm.Modal);
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.ShowDialog();
            var dados = win.GetPropertyValue("ViewModel").GetPropertyValue("lCalendarioDetalhes");
            if (dados != null)
            {
                if (objViewModel.currentModel.lCalendario_DetalheModel.Count() > 0)
                {
                    List<Calendario_DetalheModel> lExcluir = new List<Calendario_DetalheModel>();
                    if (MessageBox.Show("Calendário já possui lançamento." + Environment.NewLine + "Deseja excluir? "
                        , "A V I S O"
                        , MessageBoxButton.YesNo
                        , MessageBoxImage.Question) == MessageBoxResult.No)
                    {
                        foreach (var item in ((ObservableCollectionBaseCadastros<Calendario_DetalheModel>)dados).Select(c => c.dCalendario).Distinct())
                            lExcluir.AddRange(objViewModel.currentModel.lCalendario_DetalheModel.Where(c => c.dCalendario == item).ToList());

                        foreach (var removeItem in lExcluir)
                            objViewModel.currentModel.lCalendario_DetalheModel.Remove(removeItem);

                        foreach (var itemAdd in (ObservableCollectionBaseCadastros<Calendario_DetalheModel>)dados)
                        {
                            objViewModel.currentModel.lCalendario_DetalheModel.Add(item: itemAdd);
                        }
                        List<int> lExcluidos = objViewModel.currentModel.lCalendario_DetalheModel.idExcluidos;
                        objViewModel.currentModel.lCalendario_DetalheModel =
                            new ObservableCollectionBaseCadastros<Calendario_DetalheModel>(objViewModel.currentModel.lCalendario_DetalheModel.OrderBy(c => c.dCalendario).ToList());
                        objViewModel.currentModel.lCalendario_DetalheModel.idExcluidos.AddRange(lExcluir.Where(c => c.idCalendarioDetalhe != null).Select(c => (int)c.idCalendarioDetalhe).ToList());
                        foreach (int i in lExcluidos)
                        {
                            if (!objViewModel.currentModel.lCalendario_DetalheModel.idExcluidos.Contains(i))
                                objViewModel.currentModel.lCalendario_DetalheModel.idExcluidos.Add(i);
                        }
                    }
                    else
                    {
                        foreach (var item in objViewModel.currentModel.lCalendario_DetalheModel.Where(c => c.idCalendarioDetalhe != null))
                            lExcluir.Add(item);
                        objViewModel.currentModel.lCalendario_DetalheModel = (ObservableCollectionBaseCadastros<Calendario_DetalheModel>)dados;
                        if (lExcluir.Count() > 0)
                            objViewModel.currentModel.lCalendario_DetalheModel.idExcluidos = lExcluir.Select(c => (int)c.idCalendarioDetalhe).ToList();

                    }
                }
                else
                    objViewModel.currentModel.lCalendario_DetalheModel = (ObservableCollectionBaseCadastros<Calendario_DetalheModel>)dados;
            }
        }

        public void Save(object _panel)
        {
            try
            {
                foreach (int id in this.objViewModel.currentModel.lCalendario_DetalheModel.idExcluidos)
                {
                    this.objViewModel.currentModel.lCalendario_DetalheModel.Add(
                        new Calendario_DetalheModel
                        {
                            idCalendarioDetalhe = id,
                            status = statusModel.excluido
                        });
                }
                objViewModel.SetFocusFirstTab(_panel as Panel);
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
                this.objViewModel.currentModel = service.SaveObject(objViewModel.currentModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            e.Result = e.Argument;
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
                    this.objViewModel.salvarBaseCommand.Execute(parameter: null);
                    object w = objViewModel.GetParentWindow(e.Result);

                    if (w != null)
                        if (w.GetType() == typeof(HLP.Comum.View.Formularios.HlpPesquisaInsert))
                        {
                            (w as HLP.Comum.View.Formularios.HlpPesquisaInsert).idSalvo = this.objViewModel.currentID;
                            (w as HLP.Comum.View.Formularios.HlpPesquisaInsert).DialogResult = true;
                            (w as HLP.Comum.View.Formularios.HlpPesquisaInsert).Close();
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
            if (objViewModel.currentModel == null && objDependency == null)
                return false;

            return (this.objViewModel.salvarBaseCommand.CanExecute(parameter: null)
                && this.objViewModel.IsValid(objDependency as Panel));
        }

        public void Copy()
        {
            try
            {
                this.objViewModel.currentModel = this.service.CopyObject(this.objViewModel.currentModel);
                this.objViewModel.copyBaseCommand.Execute(null);
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
                    this.objViewModel.currentModel = e.Result as CalendarioModel;
                    this.objViewModel.copyBaseCommand.Execute(null);
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
                e.Result =
                    this.service.CopyObject(obj: this.objViewModel.currentModel);
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

        public void Delete()
        {
            int iExcluir = 0;

            try
            {
                if (MessageBox.Show(messageBoxText: "Deseja excluir o cadastro?",
                    caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
                {
                    if (service.DeleteObject(this.objViewModel.currentModel))
                    {
                        MessageBox.Show(messageBoxText: "Cadastro excluido com sucesso!", caption: "Ok",
                            button: MessageBoxButton.OK, icon: MessageBoxImage.Information);
                        iExcluir = (int)this.objViewModel.currentModel.idCalendario;
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
                if (this.objViewModel.currentModel == null)
                {
                    this.objViewModel.deletarBaseCommand.Execute(parameter: iExcluir);
                    this.PesquisarRegistro();
                }
            }
        }

        private void Novo(object _panel)
        {
            this.objViewModel.currentModel = new CalendarioModel();
            this.objViewModel.novoBaseCommand.Execute(parameter: _panel);
            this.objViewModel.bWorkerNovo.RunWorkerAsync(argument: _panel);
        }

        void bwNovo_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            e.Result = e.Argument;
        }
        void bwNovo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            objViewModel.FocusToComponente(e.Result as Panel, HLP.Base.Static.Util.focoComponente.Segundo);
        }
        private bool NovoCanExecute()
        {
            return this.objViewModel.novoBaseCommand.CanExecute(parameter: null);
        }

        private void Alterar(object _panel)
        {
            this.objViewModel.alterarBaseCommand.Execute(parameter: _panel);
            this.objViewModel.bWorkerAlterar.RunWorkerAsync(argument: _panel);
        }

        void bwAlterar_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            e.Result = e.Argument;
        }
        void bwAlterar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            objViewModel.FocusToComponente(e.Result as Panel, HLP.Base.Static.Util.focoComponente.Segundo);
        }

        private bool AlterarCanExecute()
        {
            return this.objViewModel.alterarBaseCommand.CanExecute(parameter: null);
        }

        private void Cancelar()
        {
            if (MessageBox.Show(messageBoxText: "Deseja realmente cancelar a transação?", caption: "Cancelar?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question) == MessageBoxResult.No) return;
            this.PesquisarRegistro();
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
            this.objViewModel.bWorkerPesquisa.RunWorkerAsync();
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
            if (this.objViewModel.currentModel == null)
                this.objViewModel.currentModel = new CalendarioModel();
            this.objViewModel.currentModel.lCalendario_DetalheModel.CollectionCarregada();
        }

        private void GetCalendario(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentModel = service.GetObject(this.objViewModel.currentID);
        }
        #endregion


    }
}
