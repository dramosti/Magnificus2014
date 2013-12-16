using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands.Gerais;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class CalendarioDetalheViewModel : ViewModelBase
    {
        public CalendarioDetalheViewModel()
        {
            commands = new CalendarioDetalheCommand(objViewModel: this);
            
        }

        #region Icommands
        public ICommand commandGerarDetalhamento { get; set; }
        #endregion

        CalendarioDetalheCommand commands;

        private CalendarioGeraDetalhesModel _currentModel;

        public CalendarioGeraDetalhesModel currentModel
        {
            get { return _currentModel; }
            set
            {
                _currentModel = value;
                base.NotifyPropertyChanged(propertyName: "currentModel");
            }
        }


        
        private ObservableCollection<Calendario_DetalheModel> _lCalendarioDetalhes;

        public ObservableCollection<Calendario_DetalheModel> lCalendarioDetalhes
        {
            get { return _lCalendarioDetalhes; }
            set
            {
                _lCalendarioDetalhes = value;
                base.NotifyPropertyChanged(propertyName: "lCalendarioDetalhes");
            }
        }




        public Dictionary<DateTime, DateTime> GeraIntervalos()
        {
            try
            {
                Dictionary<DateTime, DateTime> Intervalos = new Dictionary<DateTime, DateTime>();
                foreach (var item in currentModel.lDetalhes)
                {
                    Intervalos.Add(item.horaInicial, item.horaFinal);
                }
                return Intervalos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool VerificaDiaExcluidoProgramacao(DateTime day, List<string> DiasSemProgramacao)
        {
            try
            {
                bool ret = true;
                foreach (string diasExcluidos in DiasSemProgramacao)
                {
                    if (diasExcluidos != "")
                    {
                        int dia = Convert.ToInt32(diasExcluidos.Split('/')[0]);
                        int mes = Convert.ToInt32(diasExcluidos.Split('/')[1]);

                        if (day.Date.Day == dia && day.Date.Month == mes)
                        {
                            ret = false;
                            break;
                        }
                    }
                }
                return ret;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void MontaHorario(Dictionary<DateTime, DateTime> Intervalos, DateTime day, DateTime HoraInicial, DateTime HoraFinal)
        {
            try
            {
                Calendario_DetalheModel detalhe = new Calendario_DetalheModel();

                detalhe.dCalendario = day.Date;
                detalhe.dHoraInicio = HoraInicial;

                if (Intervalos.Count() > 0)
                {
                    foreach (KeyValuePair<DateTime, DateTime> inter in Intervalos.OrderBy(C => C.Key))
                    {


                        if (inter.Key.TimeOfDay < HoraFinal.TimeOfDay)
                        {
                            detalhe.dHoraTermino = new DateTime(detalhe.dCalendario.Year, detalhe.dCalendario.Month, detalhe.dCalendario.Day, inter.Key.Hour, inter.Key.Minute, inter.Key.Second);
                            lCalendarioDetalhes.Add(detalhe);

                            if (inter.Value.TimeOfDay < HoraFinal.TimeOfDay)
                            {
                                detalhe = new Calendario_DetalheModel();
                                detalhe.dCalendario = day.Date;
                                detalhe.dHoraInicio = new DateTime(detalhe.dCalendario.Year, detalhe.dCalendario.Month, detalhe.dCalendario.Day, inter.Value.Hour, inter.Value.Minute, inter.Value.Second);
                            }
                        }
                        else
                        {
                            detalhe.dHoraTermino = new DateTime(detalhe.dCalendario.Year, detalhe.dCalendario.Month, detalhe.dCalendario.Day, HoraFinal.Hour, HoraFinal.Minute, HoraFinal.Second);
                            lCalendarioDetalhes.Add(detalhe);
                        }
                    }
                    if (detalhe.dHoraTermino.TimeOfDay.Equals(new TimeSpan(0, 0, 0)))
                    {
                        detalhe.dHoraTermino = new DateTime(detalhe.dCalendario.Year, detalhe.dCalendario.Month, detalhe.dCalendario.Day, HoraFinal.Hour, HoraFinal.Minute, HoraFinal.Second);
                        lCalendarioDetalhes.Add(detalhe);
                    }

                }
                else
                {
                    detalhe.dHoraTermino = new DateTime(detalhe.dCalendario.Year, detalhe.dCalendario.Month, detalhe.dCalendario.Day, HoraFinal.Hour, HoraFinal.Minute, HoraFinal.Second);
                    lCalendarioDetalhes.Add(detalhe);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        
    }
}
