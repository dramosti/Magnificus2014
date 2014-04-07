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
                            //objViewModel.currentModel.SabadoInicial = new TimeSpan(
                            //                    objViewModel.currentModel.SabadoInicial.Hours,
                            //                    objViewModel.currentModel.SabadoInicial.Minutes,
                            //                    objViewModel.currentModel.SabadoInicial.Seconds);

                            objViewModel.MontaHorario(Intervalos, day, objViewModel.currentModel.SabadoInicial, objViewModel.currentModel.SabadoFinal);
                        }
                        else if (day.DayOfWeek == DayOfWeek.Friday)
                        {
                            objViewModel.MontaHorario(Intervalos, day, objViewModel.currentModel.SextaInicial, objViewModel.currentModel.SextaFinal);
                        }
                        else if (day.DayOfWeek == DayOfWeek.Sunday && objViewModel.currentModel.bConsideraDomingo)
                        {
                            objViewModel.MontaHorario(Intervalos, day, objViewModel.currentModel.DomingoInicial, objViewModel.currentModel.DomingoFinal);
                        }
                        else if (day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday)
                        {
                            //objViewModel.currentModel.SegQuiInicial = new TimeSpan(
                            //                        objViewModel.currentModel.SegQuiInicial.Hours,
                            //                        objViewModel.currentModel.SegQuiInicial.Minutes,
                            //                        objViewModel.currentModel.SegQuiInicial.Seconds);


                            //objViewModel.currentModel.SegQuiFinal = new TimeSpan(
                            //                        objViewModel.currentModel.SegQuiFinal.Hours,
                            //                        objViewModel.currentModel.SegQuiFinal.Minutes,
                            //                        objViewModel.currentModel.SegQuiFinal.Seconds);

                            objViewModel.MontaHorario(Intervalos, day, objViewModel.currentModel.SegQuiInicial, objViewModel.currentModel.SegQuiFinal);
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
