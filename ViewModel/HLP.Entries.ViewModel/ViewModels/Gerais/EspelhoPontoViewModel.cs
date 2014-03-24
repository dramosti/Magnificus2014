using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands.Gerais;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class EspelhoPontoViewModel : ViewModelBase<EspelhoPontoModel>
    {

        EspelhoPontoCommand command;


        public EspelhoPontoViewModel( int idFuncionario, DateTime dataPonto) 
        {
            command = new EspelhoPontoCommand(objViwModel: this);
        }


        private ObservableCollection<EspelhoPontoModel> _lPonto;

        public ObservableCollection<EspelhoPontoModel> lPonto
        {
            get { return _lPonto; }
            set { _lPonto = value; base.NotifyPropertyChanged("lPonto"); }
        }
        
    }
}
