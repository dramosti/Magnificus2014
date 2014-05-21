using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands.Gerais;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class CalendarioViewModel : ViewModelBase<CalendarioModel>
    {
        #region Icommands
        public ICommand commandSalvar { get; set; }
        public ICommand commandDeletar { get; set; }
        public ICommand commandNovo { get; set; }
        public ICommand commandAlterar { get; set; }
        public ICommand commandCancelar { get; set; }
        public ICommand commandCopiar { get; set; }
        public ICommand commandPesquisar { get; set; }
        public ICommand navegarCommand { get; set; }

        public ICommand gerarByCalendarioBaseCommand { get; set; }
        public ICommand commandGerarDetalhamento { get; set; }
        public ICommand addDateCommand { get; set; }

        #endregion

        public CalendarioViewModel()
        {
            //this.currentModel = new CalendarioModel();
            commands = new CalendarioCommand(objViewModel: this);
        }

        CalendarioCommand commands;
        #region Properties
        
        private ObservableCollection<DateTime> _lDiasSemProgramacao = new ObservableCollection<DateTime>();
        public ObservableCollection<DateTime> lDiasSemProgramacao
        {
            get { return _lDiasSemProgramacao; }
            set
            {
                _lDiasSemProgramacao = value;
                base.NotifyPropertyChanged(propertyName: "lDiasSemProgramacao");
            }
        }

        
        private DateTime? _diaSemProgramacao = null ;
        public DateTime? diaSemProgramacao
        {
            get { return _diaSemProgramacao; }
            set
            {
                _diaSemProgramacao = value;
                base.NotifyPropertyChanged(propertyName: "diaSemProgramacao");
            }
        }
        

        #endregion

        public Dictionary<TimeSpan, TimeSpan> GeraIntervalos()
        {
            try
            {
                Dictionary<TimeSpan, TimeSpan> Intervalos = new Dictionary<TimeSpan, TimeSpan>();
                foreach (var item in currentModel.lCalendario_IntervaloModel)
                {
                    Intervalos.Add(item.tInicio, item.tFinal);
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
                foreach (DateTime diaExcluido in this.lDiasSemProgramacao)
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

        public ObservableCollection<Calendario_DetalheModel> MontaHorario(Dictionary<TimeSpan, TimeSpan> Intervalos, DateTime day, TimeSpan HoraInicial, TimeSpan HoraFinal)
        {
            try
            {
                ObservableCollection<Calendario_DetalheModel> lReturn = new ObservableCollection<Calendario_DetalheModel>();
                Calendario_DetalheModel detalhe = new Calendario_DetalheModel();
                detalhe.status = Base.EnumsBases.statusModel.criado;
                detalhe.dCalendario = day.Date;
                detalhe.tHoraInicio = HoraInicial;

                if (Intervalos.Count() > 0)
                {
                    foreach (KeyValuePair<TimeSpan, TimeSpan> inter in Intervalos.OrderBy(C => C.Key))
                    {
                        if (inter.Key < HoraFinal)
                        {
                            detalhe.tHoraTermino = new TimeSpan(inter.Key.Hours, inter.Key.Minutes, inter.Key.Seconds);
                            lReturn.Add(detalhe);

                            if (inter.Value < HoraFinal)
                            {
                                detalhe = new Calendario_DetalheModel();
                                detalhe.status = Base.EnumsBases.statusModel.criado;
                                detalhe.dCalendario = day.Date;
                                detalhe.tHoraInicio = new TimeSpan(inter.Value.Hours, inter.Value.Minutes, inter.Value.Seconds);
                            }
                        }
                        else
                        {
                            detalhe.tHoraTermino = new TimeSpan(HoraFinal.Hours, HoraFinal.Minutes, HoraFinal.Seconds);
                            lReturn.Add(detalhe);
                        }
                    }
                    if (detalhe.tHoraTermino.Equals(new TimeSpan(0, 0, 0)))
                    {
                        detalhe.tHoraTermino = new TimeSpan(HoraFinal.Hours, HoraFinal.Minutes, HoraFinal.Seconds);
                        lReturn.Add(detalhe);
                    }
                }
                else
                {
                    detalhe.tHoraTermino = new TimeSpan(HoraFinal.Hours, HoraFinal.Minutes, HoraFinal.Seconds);
                    lReturn.Add(detalhe);
                }
                return lReturn;
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
                if (this.lDiasSemProgramacao.Count() > 0)
                    this.lDiasSemProgramacao.Remove((DateTime)(sender as ListBox).SelectedItem);
            }
        }

    }
}
