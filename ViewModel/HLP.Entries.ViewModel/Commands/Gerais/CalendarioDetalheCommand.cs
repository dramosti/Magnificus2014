using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using HLP.Base.ClassesBases;

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
               exec => GeraGradeHoraria(o: exec),
               can => CanExecute(o: can));

            this.objViewModel.addDateCommand = new RelayCommand(
              exec => AddDateSemProgramacaoToList(),
              can => CanAddDateSemProgramacaoToList());


        }

        public void AddDateSemProgramacaoToList()
        {
            if (objViewModel.currentModel.lDiasSemProgramacao.Where(c => c.Date == ((DateTime)objViewModel.currentModel.diaSemProgramacao).Date).Count() == 0)
            {
                objViewModel.currentModel.lDiasSemProgramacao.Add((DateTime)objViewModel.currentModel.diaSemProgramacao);
                objViewModel.currentModel.diaSemProgramacao = null;
            }
            else
                System.Windows.MessageBox.Show("Data já inserida na listagem abaixo!", "A V I S O");
        }

        public bool CanAddDateSemProgramacaoToList()
        {
            if (objViewModel.currentModel.diaSemProgramacao != null)
                return true;
            else return false;
        }


        private void GeraGradeHoraria(object o)
        {
            try
            {
                objViewModel.lCalendarioDetalhes = new ObservableCollectionBaseCadastros<Calendario_DetalheModel>();
                Dictionary<TimeSpan, TimeSpan> Intervalos = objViewModel.GeraIntervalos();


                DateTimeEnumerator dateTimeRange = new DateTimeEnumerator(objViewModel.currentModel.dtInicial, objViewModel.currentModel.dtFinal);
                foreach (DateTime day in dateTimeRange)
                {
                    if (objViewModel.VerificaDiaExcluidoProgramacao(day))
                    {
                        if (day.DayOfWeek == DayOfWeek.Saturday && objViewModel.currentModel.bConsideraSabado)
                        {
                            objViewModel.currentModel.SabadoInicial = new DateTime(day.Year, day.Month, day.Day,
                                                objViewModel.currentModel.SabadoInicial.Hour,
                                                objViewModel.currentModel.SabadoInicial.Minute,
                                                objViewModel.currentModel.SabadoInicial.Second);

                            objViewModel.MontaHorario(Intervalos, day, objViewModel.currentModel.SabadoInicial.TimeOfDay, objViewModel.currentModel.SabadoFinal.TimeOfDay);
                        }
                        else if (day.DayOfWeek == DayOfWeek.Friday)
                        {

                        }
                        else if (day.DayOfWeek == DayOfWeek.Sunday && objViewModel.currentModel.bConsideraDomingo)
                        {
                            objViewModel.MontaHorario(Intervalos, day, objViewModel.currentModel.DomingoInicial.TimeOfDay, objViewModel.currentModel.DomingoFinal.TimeOfDay);
                        }
                        else if (day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday)
                        {
                            objViewModel.currentModel.SegSexInicial = new DateTime(day.Year, day.Month, day.Day,
                                                    objViewModel.currentModel.SegSexInicial.Hour,
                                                    objViewModel.currentModel.SegSexInicial.Minute,
                                                    objViewModel.currentModel.SegSexInicial.Second);


                            objViewModel.currentModel.SegSexFinal = new DateTime(day.Year, day.Month, day.Day, objViewModel.currentModel.SegSexFinal.Hour, objViewModel.currentModel.SegSexFinal.Minute, objViewModel.currentModel.SegSexFinal.Second);
                            objViewModel.MontaHorario(Intervalos, day, objViewModel.currentModel.SegSexInicial.TimeOfDay, objViewModel.currentModel.SegSexFinal.TimeOfDay);
                        }


                    }
                }

                objViewModel.FechaForm(((UserControl)o).Parent);
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
