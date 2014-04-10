using HLP.Base.ClassesBases;
using HLP.Base.Modules;
using HLP.Entries.ViewModel.Services.Gerais;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HLP.Base.Static;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class HlpCalendarioPontoCommand
    {
        FuncionarioPontoService servico;
        public HlpCalendarioPontoViewModel objViewModel { get; set; }

        public HlpCalendarioPontoCommand(HlpCalendarioPontoViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            servico = new FuncionarioPontoService();
            this.objViewModel.LancamentoManualCommand = new RelayCommand(execute: paramExec => this.LoadLancamentoManual(),
                 canExecute: paramCanExec => CanLancamentoManual());
        }
        public void CarregaDados()
        {
            try
            {
                objViewModel.styleDSR = objViewModel.resource["ListBox_Calendario_Ponto_Padrao"] as Style;
                // verifica se tem calendario no dia.
                objViewModel.isDSR = servico.ExisteCalendarioDia(objViewModel.idFuncionario, Convert.ToDateTime(objViewModel.dataPonto));
                    //servico.GetHorasAtrabalhadarDia(objViewModel.idFuncionario, Convert.ToDateTime(objViewModel.dataPonto)).Count() == 0;

                List<HLP.Entries.Model.Models.Gerais.Funcionario_Controle_Horas_PontoModel> lReturn = servico.GetAllFuncionario_Controle_Horas_Ponto(objViewModel.idFuncionario, Convert.ToDateTime(objViewModel.dataPonto));
                if (lReturn.Count == 0)
                    this.objViewModel.stDia = HlpCalendarioPontoViewModel.StatusDia.EMBRANCO;
                else if (lReturn.Where(c => c.stFalta == 1).Count() == lReturn.Count())
                    this.objViewModel.stDia = HlpCalendarioPontoViewModel.StatusDia.FALTOU;
                else if (lReturn.Where(c => c.stFeriasAbono == 1).Count() == lReturn.Count())
                    this.objViewModel.stDia = HlpCalendarioPontoViewModel.StatusDia.ABONO;
                else
                    this.objViewModel.stDia = HlpCalendarioPontoViewModel.StatusDia.NORMAL;


                if (this.objViewModel.stDia == HlpCalendarioPontoViewModel.StatusDia.EMBRANCO && objViewModel.isDSR)
                {
                    this.objViewModel.stDia = HlpCalendarioPontoViewModel.StatusDia.DSR;
                }

                if (objViewModel.idFuncionario != 0 && objViewModel.dataPonto != "")
                    this.objViewModel.lPonto = new System.Collections.ObjectModel.ObservableCollection<Model.Models.Gerais.EspelhoPontoModel>(servico.GetHorasTrabalhadasDia
                       (
                       idFuncionario: objViewModel.idFuncionario,
                       dtDia: Convert.ToDateTime(objViewModel.dataPonto)
                       ));
                else
                    objViewModel.lPonto = new System.Collections.ObjectModel.ObservableCollection<Model.Models.Gerais.EspelhoPontoModel>();
            }
            catch (Exception)
            {
            }
        }
        public bool CanLancamentoManual()
        {
            bool breturn = false;

            if (objViewModel.idFuncionario != 0 && objViewModel.dataPonto != null && objViewModel._bMesFechado == false)
            {
                breturn = true;
            }
            return breturn;
        }
        public void LoadLancamentoManual()
        {
            try
            {
                Window win = GerenciadorModulo.Instancia.CarregaForm("WinLancamentoManualPonto", Base.InterfacesBases.TipoExibeForm.Modal);
                Type tp = win.GetType();
                MethodInfo method = tp.GetMethod("SetDataContext");
                method.Invoke(win, new object[] { objViewModel.idFuncionario, Convert.ToDateTime(objViewModel.dataPonto) });
                win.ShowDialog();
                if (((bool)win.GetPropertyValue("bAlterou")))
                {
                    this.objViewModel.actionAtualizaWindowPrincipal.Invoke();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



    }
}
