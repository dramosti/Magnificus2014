using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.RecursosHumanos;
using HLP.Entries.ViewModel.Commands.RecursosHumanos;

namespace HLP.Entries.ViewModel.ViewModels.RecursosHumanos
{
    public class CorrigirUltimoPontoViewModel : ViewModelBase<CorrigeUltimoPontoModel>
    {
        public CorrigirUltimoPontoCommand command;

        public ICommand CorrigirCommand { get; set; }
        public ICommand SelectTodosCommand { get; set; }

        public int idFuncionario { get; set; }
        public DateTime dtMes { get; set; }

        public CorrigirUltimoPontoViewModel(DateTime dtMes, int idFuncionario)
        {
            this.dtMes = dtMes;
            this.idFuncionario = idFuncionario;
            command = new CorrigirUltimoPontoCommand(this);
            this.bWorkerPesquisa.RunWorkerAsync();
        }


        private ObservableCollection<CorrigeUltimoPontoModel> _ldia = new ObservableCollection<CorrigeUltimoPontoModel>();
        public ObservableCollection<CorrigeUltimoPontoModel> ldia
        {
            get { return _ldia; }
            set { _ldia = value; base.NotifyPropertyChanged("ldia"); }
        }

        private bool _bSelectAll;
        public bool bSelectAll
        {
            get { return _bSelectAll; }
            set { _bSelectAll = value; base.NotifyPropertyChanged("bSelectAll"); }
        }

        public Action actionAtualizaWindowPrincipal;

      
        
        


    }
}
