using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Models.RecursosHumanos;
using HLP.Entries.Services.Gerais;
using HLP.Entries.Services.RecursosHumanos;
using HLP.Entries.ViewModel.ViewModels.RecursosHumanos;

namespace HLP.Entries.ViewModel.Commands.RecursosHumanos
{

    public class CorrigirUltimoPontoCommand
    {
        public CorrigirUltimoPontoViewModel ViewModel { get; set; }
        FuncionarioPontoService servicoFuncPonto;
        FuncionarioService servicoFuncionario;
        CalendarioService serviceCalendario;


        public CorrigirUltimoPontoCommand(CorrigirUltimoPontoViewModel ViewModel)
        {
            this.ViewModel = ViewModel;
            servicoFuncPonto = new FuncionarioPontoService();
            servicoFuncionario = new FuncionarioService();
            serviceCalendario = new CalendarioService();
            this.ViewModel.bWorkerPesquisa.DoWork += bWorkerPesquisa_DoWork;
            this.ViewModel.bWorkerPesquisa.RunWorkerCompleted += bWorkerPesquisa_RunWorkerCompleted;
            this.ViewModel.SelectTodosCommand = new RelayCommand(execute: paramExec => this.SelectTodos(),
              canExecute: paramCan => this.CanAcoes());

            this.ViewModel.CorrigirCommand = new RelayCommand(execute: paramExec => this.SalvarAlteracoes(paramExec),
              canExecute: paramCan => this.CanSalvarAlteracoes());

        }

        void bWorkerPesquisa_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                throw e.Error;
            }
            else
            {
                if (e.Result != null)
                    this.ViewModel.ldia = new System.Collections.ObjectModel.ObservableCollection<CorrigeUltimoPontoModel>(list:
                        e.Result as List<CorrigeUltimoPontoModel>);
            }
        }

        void SalvarAlteracoes(object win)
        {
            if (MessageHlp.Show(StMessage.stYesNo, "Deseja realmente corrigir as saídas selecionadas ?") == MessageBoxResult.Yes)
            {
                List<Funcionario_Controle_Horas_PontoModel> lpontos = new List<Funcionario_Controle_Horas_PontoModel>();
                foreach (var item in this.ViewModel.ldia.Where(c => c.bSeleciona))
                {
                    item.ponto.hAlteradaUsuario = item.horaAlterada;
                    lpontos.Add(item.ponto);
                }
                if (lpontos.Count > 0)
                {
                    this.servicoFuncPonto.Salvar(this.ViewModel.ldia.FirstOrDefault().ponto.idFuncionario, lpontos);
                    MessageHlp.Show(StMessage.stAlert, "Registros alterados com sucesso!");
                    this.ViewModel.actionAtualizaWindowPrincipal.Invoke();
                    (win as Window).Close();

                }
            }
        }

        bool CanSalvarAlteracoes()
        {
            return this.ViewModel.ldia.Where(c => c.bSeleciona).Count() > 0;
        }



        private void SelectTodos()
        {
            foreach (var item in this.ViewModel.ldia)
            {
                item.bSeleciona = this.ViewModel.bSelectAll;
            }
        }

        public bool CanAcoes()
        {
            return this.ViewModel.ldia.Count() > 0;
        }


        void bWorkerPesquisa_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                FuncionarioModel objFunc = servicoFuncionario.GetObject(ViewModel.idFuncionario, false);
                List<CorrigeUltimoPontoModel> lCorrecoes = new List<CorrigeUltimoPontoModel>();
                if (objFunc.idCalendario != null)
                {
                    CalendarioModel objCalendarioModel = serviceCalendario.GetObject((int)objFunc.idCalendario, false);

                    int iDaysMonth = System.DateTime.DaysInMonth(ViewModel.dtMes.Year, ViewModel.dtMes.Month);
                    this.ViewModel.ldia = new System.Collections.ObjectModel.ObservableCollection<CorrigeUltimoPontoModel>();
                    CorrigeUltimoPontoModel obj;
                    for (int i = 1; i <= iDaysMonth; i++)
                    {
                        obj = new CorrigeUltimoPontoModel();
                        obj.dia = new DateTime(ViewModel.dtMes.Year, ViewModel.dtMes.Month, i);
                        if (obj.dia.DayOfWeek != DayOfWeek.Saturday && obj.dia.DayOfWeek != DayOfWeek.Sunday)
                        {
                            obj.ponto = servicoFuncPonto.GetLastFuncionario_Controle_Horas_PontoDia(ViewModel.idFuncionario, obj.dia);

                            if (obj.dia.DayOfWeek == DayOfWeek.Friday)
                            {
                                obj.horaAlterada = objCalendarioModel.tHoraFinalSex;
                            }
                            else
                            {
                                obj.horaAlterada = objCalendarioModel.tHoraFinalSegQui;
                            }
                            if (obj.ponto != null)
                            {

                                if (obj.ponto.hAlteradaUsuario == new TimeSpan()
                                    || obj.ponto.hAlteradaUsuario == null)
                                {
                                    lCorrecoes.Add(item: obj);
                                    if (obj.ponto.hRelogioPonto > obj.horaAlterada)
                                        obj.bSeleciona = true;

                                }
                            }
                        }
                    }
                }

                e.Result = lCorrecoes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
