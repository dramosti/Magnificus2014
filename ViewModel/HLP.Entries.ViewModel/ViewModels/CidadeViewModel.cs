using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Model.Models;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands;

namespace HLP.Entries.ViewModel.ViewModels
{
    public class CidadeViewModel : ModelBase
    {

        private ObservableCollection<CidadeModel> _lCidade;

        public ObservableCollection<CidadeModel> lCidade
        {
            get { return _lCidade; }
            set { _lCidade = value; base.NotifyPropertyChanged("lCidade"); }
        }

        public CidadeCommands objCidadeCommands;

        public CidadeViewModel()
        {
            objCidadeCommands = new CidadeCommands(objCidadeViewModel: this);            
        }

        public void GetCidadeByUf(int iidUF)  
        {
            objCidadeCommands.GetCidadeByUf(idUF: iidUF);
        }

        




    }
}
