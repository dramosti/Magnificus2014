using System;
using System.Collections.Generic;
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

        private CalendarioDetalheModel _currentModel;

        public CalendarioDetalheModel currentModel
        {
            get { return _currentModel; }
            set
            {
                _currentModel = value;
                base.NotifyPropertyChanged(propertyName: "currentModel");
            }
        }




        private bool ValidaIntervalosDia()
        {
            try
            {
                bool ret = true;
                //if (dgvIntervalo.RowCount > 1)
                //{
                //    DateTime Inicio;
                //    DateTime Fim;
                //    for (int i = 0; i < dgvIntervalo.RowCount - 1; i++)
                //    {
                //        if (dgvIntervalo.Rows[i].Cells["Inicio"].Value != null)
                //        {
                //            Inicio = Convert.ToDateTime(dgvIntervalo.Rows[i].Cells["Inicio"].Value);
                //        }
                //        else
                //        {
                //            ret = false;
                //            break;
                //        }
                //        if (dgvIntervalo.Rows[i].Cells["Fim"].Value != null)
                //        {
                //            Fim = Convert.ToDateTime(dgvIntervalo.Rows[i].Cells["Fim"].Value);
                //        }
                //        else
                //        {
                //            ret = false;
                //            break;
                //        }
                //        if (Inicio >= Fim)
                //        {
                //            ret = false;
                //            break;
                //        }

                //    }
                //    if (!ret)
                //    {
                //        KryptonMessageBox.Show("Intervalo(s) do dia Inválido(s)", "A V I S O", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    return ret;
                //}
                //else
                //{
                    return ret;
                //}
            }
            catch (Exception ex)
            {
                //new HLPexception(ex);
                return false;
            }
        }
    }
}
