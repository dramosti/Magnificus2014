using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using HLP.Comum.Model.Models;
using HLP.Comum.ViewModel.Commands;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.ViewModels.Gerais;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class CalendarioDetalheCommand
    {

        CalendarioDetalheViewModel objViewModel;

        public CalendarioDetalheCommand(CalendarioDetalheViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            this.objViewModel.currentModel = new Model.Models.Gerais.CalendarioGeraDetalhesModel();

            this.objViewModel.commandGerarDetalhamento = new RelayCommand(
               exec => GeraGradeHoraria(),
               can => CanExecute(o: can));
        }



        private void GeraGradeHoraria()
        {
            try
            {
                objViewModel.lCalendarioDetalhes = new System.Collections.ObjectModel.ObservableCollection<Model.Models.Gerais.Calendario_DetalheModel>();
                List<string> DiasSemProgramacao = objViewModel.currentModel.diaSemProgramacao.Split(',').ToList();
                Dictionary<DateTime, DateTime> Intervalos = objViewModel.GeraIntervalos();


                DateTimeEnumerator dateTimeRange = new DateTimeEnumerator(objViewModel.currentModel.dtInicial, objViewModel.currentModel.dtFinal);
                foreach (DateTime day in dateTimeRange)
                {
                    if (objViewModel.VerificaDiaExcluidoProgramacao(day, DiasSemProgramacao))
                    {
                        if (day.DayOfWeek == DayOfWeek.Saturday && objViewModel.currentModel.bConsideraSabado)
                        {
                            objViewModel.currentModel.SabadoInicial = new DateTime(day.Year, day.Month, day.Day,
                                                objViewModel.currentModel.SabadoInicial.Hour,
                                                objViewModel.currentModel.SabadoInicial.Minute,
                                                objViewModel.currentModel.SabadoInicial.Second);

                            objViewModel.MontaHorario(Intervalos, day, objViewModel.currentModel.SabadoInicial, objViewModel.currentModel.SabadoFinal);
                        }
                        else if (day.DayOfWeek == DayOfWeek.Sunday && objViewModel.currentModel.bConsideraDomingo)
                        {
                            objViewModel.MontaHorario(Intervalos, day, objViewModel.currentModel.DomingoInicial, objViewModel.currentModel.DomingoFinal);
                        }
                        else if (day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday)
                        {
                            objViewModel.currentModel.SegSexInicial = new DateTime(day.Year, day.Month, day.Day,
                                                    objViewModel.currentModel.SegSexInicial.Hour,
                                                    objViewModel.currentModel.SegSexInicial.Minute,
                                                    objViewModel.currentModel.SegSexInicial.Second);


                            objViewModel.currentModel.SegSexFinal = new DateTime(day.Year, day.Month, day.Day, objViewModel.currentModel.SegSexFinal.Hour, objViewModel.currentModel.SegSexFinal.Minute, objViewModel.currentModel.SegSexFinal.Second);
                            objViewModel.MontaHorario(Intervalos, day, objViewModel.currentModel.SegSexInicial, objViewModel.currentModel.SegSexFinal);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CanExecute(object o)
        {

            return !Validation.GetHasError((UserControl)o);

        }

    }
}
