using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands.Gerais;
using System.Windows.Controls;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class CalendarioDetalheViewModel : ViewModelBase<CalendarioGeraDetalhesModel>
    {
        public CalendarioDetalheViewModel()
        {
            this.currentModel = new CalendarioGeraDetalhesModel();
            commands = new CalendarioDetalheCommand(objViewModel: this);
        }

        #region Icommands
        public ICommand commandGerarDetalhamento { get; set; }

        public ICommand addDateCommand { get; set; }
        #endregion

     

        CalendarioDetalheCommand commands;
        private ObservableCollectionBaseCadastros<Calendario_DetalheModel> _lCalendarioDetalhes;
        public ObservableCollectionBaseCadastros<Calendario_DetalheModel> lCalendarioDetalhes
        {
            get { return _lCalendarioDetalhes; }
            set
            {
                _lCalendarioDetalhes = value;
                base.NotifyPropertyChanged(propertyName: "lCalendarioDetalhes");
            }
        }
        public Dictionary<TimeSpan, TimeSpan> GeraIntervalos()
        {
            try
            {
                Dictionary<TimeSpan, TimeSpan> Intervalos = new Dictionary<TimeSpan, TimeSpan>();
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
        public bool VerificaDiaExcluidoProgramacao(DateTime day)
        {
            try
            {
                bool ret = true;
                foreach (DateTime diaExcluido in this.currentModel.lDiasSemProgramacao)
                {
                    if (day.Date.Day == diaExcluido.Day && day.Date.Month == diaExcluido.Month)
                    {
                        ret = false;
                        break;
                    }
                }
                return ret;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void MontaHorario(Dictionary<TimeSpan, TimeSpan> Intervalos, DateTime day, TimeSpan HoraInicial, TimeSpan HoraFinal)
        {
            try
            {
                Calendario_DetalheModel detalhe = new Calendario_DetalheModel();

                detalhe.dCalendario = day.Date;
                detalhe.tHoraInicio = HoraInicial;

                if (Intervalos.Count() > 0)
                {
                    foreach (KeyValuePair<TimeSpan, TimeSpan> inter in Intervalos.OrderBy(C => C.Key))
                    {


                        if (inter.Key < HoraFinal)
                        {
                            detalhe.tHoraTermino = new TimeSpan(inter.Key.Hours, inter.Key.Minutes, inter.Key.Seconds);
                            lCalendarioDetalhes.Add(detalhe);

                            if (inter.Value < HoraFinal)
                            {
                                detalhe = new Calendario_DetalheModel();
                                detalhe.dCalendario = day.Date;
                                detalhe.tHoraInicio = new TimeSpan(inter.Value.Hours, inter.Value.Minutes, inter.Value.Seconds);
                            }
                        }
                        else
                        {
                            detalhe.tHoraTermino = new TimeSpan(HoraFinal.Hours, HoraFinal.Minutes, HoraFinal.Seconds);
                            lCalendarioDetalhes.Add(detalhe);
                        }
                    }
                    if (detalhe.tHoraTermino.Equals(new TimeSpan(0, 0, 0)))
                    {
                        detalhe.tHoraTermino = new TimeSpan(HoraFinal.Hours, HoraFinal.Minutes, HoraFinal.Seconds);
                        lCalendarioDetalhes.Add(detalhe);
                    }

                }
                else
                {
                    detalhe.tHoraTermino = new TimeSpan(HoraFinal.Hours, HoraFinal.Minutes, HoraFinal.Seconds);
                    lCalendarioDetalhes.Add(detalhe);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                if (this.currentModel.lDiasSemProgramacao.Count() > 0)
                    this.currentModel.lDiasSemProgramacao.Remove((DateTime)(sender as ListBox).SelectedItem);
            }
        }


    }
}
