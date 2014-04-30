using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HLP.Base.EnumsBases;
using HLP.Entries.Services.RecursosHumanos;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class Funcionario_Controle_Horas_PontoCommand
    {
        public Funcionario_Controle_Horas_PontoViewModel objViewModel { get; set; }
        FuncionarioPontoService servico;

        public Funcionario_Controle_Horas_PontoCommand(Funcionario_Controle_Horas_PontoViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            servico = new FuncionarioPontoService();
            this.CarregarDados();
            objViewModel.commandSalvar = new RelayCommand(execute: paramExec => this.Salvar(win: paramExec),
                 canExecute: paramCanExec => true);
            objViewModel.commandCancelar = new RelayCommand(execute: paramExec => this.Cancelar(win: paramExec),
                canExecute: paramCanExec => true);

            objViewModel.commandSalvar = new RelayCommand(execute: paramExec => this.Salvar(win: paramExec),
                canExecute: paramCanExec => true);

            objViewModel.commandFaltou = new RelayCommand(execute: paramExec => this.CarregaFalta(paramExec),
                 canExecute: paramCanExec => this.CanCarregaFalta());

            objViewModel.commandFeriasAbono = new RelayCommand(execute: paramExec => this.CarregaAbono(paramExec),
                 canExecute: paramCanExec => this.CanCarregaAbono());
        }

        public void Cancelar(object win) 
        {
            ((Window)win).Close();
        }

        public void Salvar(object win)
        {
            try
            {
                foreach (int id in this.objViewModel.lPonto.idExcluidos)
                {
                    this.objViewModel.lPonto.Add(
                        new Funcionario_Controle_Horas_PontoModel
                        {
                            idFuncionarioControleHorasPonto = id,
                            status = statusModel.excluido
                        });
                }
                foreach (var item in this.objViewModel.lPonto)
                    item.dRelogioPonto = this.objViewModel.data;


                List<Funcionario_Controle_Horas_PontoModel> lreturn = servico.Salvar(objViewModel.idFuncionario, new List<Funcionario_Controle_Horas_PontoModel>(objViewModel.lPonto));
                this.objViewModel.lPonto = null;
                this.objViewModel.lPonto = new ObservableCollectionBaseCadastros<Funcionario_Controle_Horas_PontoModel>(lreturn);
                this.objViewModel.bAlterou = true;
                ((Window)win).Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void CarregarDados()
        {
            try
            {
                List<Funcionario_Controle_Horas_PontoModel> result = servico.GetAllFuncionario_Controle_Horas_Ponto(objViewModel.idFuncionario, objViewModel.data);
                if (result != null)
                {
                    objViewModel.lPonto = new ObservableCollectionBaseCadastros<Funcionario_Controle_Horas_PontoModel>(result);

                    if (objViewModel.lPonto.Count > 0)
                    {
                        if (objViewModel.lPonto.Where(c => c.stFeriasAbono == (byte)1).Count() == objViewModel.lPonto.Count())
                        {
                            objViewModel.bAbono = true;
                        }
                        if (objViewModel.lPonto.Where(c => c.stFalta == (byte)1).Count() == objViewModel.lPonto.Count())
                        {
                            objViewModel.bFaltou = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        void CarregaFalta(object bChecked)
        {
            if ((bool)bChecked)
                this.CarregarLista(tipo.FALTOU);
            else
                this.objViewModel.lPonto.Clear();
        }

        bool CanCarregaFalta()
        {
            if (objViewModel.bAbono)
                return false;
            else
                return true;
        }

        void CarregaAbono(object bChecked)
        {
            if ((bool)bChecked)
                this.CarregarLista(tipo.ABONO);
            else
                this.objViewModel.lPonto.Clear();
        }

        bool CanCarregaAbono()
        {
            if (objViewModel.bFaltou)
                return false;
            else
                return true;
        }


        void CarregarLista(tipo stTipo)
        {
            objViewModel.lPonto.Clear();
            int iCount = 1;
            List<Calendario_DetalheModel> lReturn = servico.GetHorasAtrabalhadarDia(objViewModel.idFuncionario, objViewModel.data);
            if (lReturn.Count > 0)
            {
                foreach (var item in lReturn)
                {
                    if (item.tHoraInicio != null)
                    {
                        objViewModel.lPonto.Add(new Funcionario_Controle_Horas_PontoModel
                        {
                            dRelogioPonto = objViewModel.data,
                            hRelogioPonto = item.tHoraInicio,
                            idFuncionario = objViewModel.idFuncionario,
                            idSequenciaInterna = iCount,
                            stFeriasAbono = (stTipo == tipo.ABONO) ? (byte)1 : (byte)0,
                            stFalta = (stTipo == tipo.FALTOU) ? (byte)1 : (byte)0,
                            xJustificativa = (stTipo == tipo.ABONO) ? "ABONO / FÉRIAS" : "FALTA"
                        });
                        iCount++;
                    }
                    if (item.tHoraTermino != null)
                    {
                        objViewModel.lPonto.Add(new Funcionario_Controle_Horas_PontoModel
                        {
                            dRelogioPonto = objViewModel.data,
                            hRelogioPonto = item.tHoraTermino,
                            idFuncionario = objViewModel.idFuncionario,
                            idSequenciaInterna = iCount,
                            stFeriasAbono = (stTipo == tipo.ABONO) ? (byte)1 : (byte)0,
                            stFalta = (stTipo == tipo.FALTOU) ? (byte)1 : (byte)0,
                            xJustificativa = (stTipo == tipo.ABONO) ? "ABONO / FÉRIAS" : "FALTA"
                        });
                        iCount++;
                    }
                }
            }
            else
            {
                MessageBox.Show("Não há calendário para esse dia", "AVISO");
                if (stTipo == tipo.ABONO)
                    objViewModel.bAbono = false;
                else
                    objViewModel.bFaltou = false;
            }
        }


        private enum tipo { ABONO, FALTOU };


    }
}
