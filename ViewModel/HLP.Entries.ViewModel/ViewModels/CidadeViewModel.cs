using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Model.Models;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands;
using System.Windows.Input;
using HLP.Comum.ViewModel.ViewModels;

namespace HLP.Entries.ViewModel.ViewModels
{
    public class CidadeViewModel : ViewModelBase
    {

        #region ICommands
        public ICommand commandNovo { get; set; }
        #endregion

        private ObservableCollection<CidadeModel> _lCidade;

        public ObservableCollection<CidadeModel> lCidade
        {
            get { return _lCidade; }
            set
            {
                _lCidade = value;
                base.NotifyPropertyChanged("lCidade");
            }
        }

        private CidadeModel currentCidade;

        public CidadeModel _currentCidade
        {
            get
            {
                return this.currentCidade == null ?
                    this.currentCidade = new CidadeModel() : this.currentCidade;
            }
            set
            {
                currentCidade = value;
                base.NotifyPropertyChanged(propertyName: "_currentCidade");
            }
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
