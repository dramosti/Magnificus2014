using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Comum.Model.Models;
using HLP.Entries.Model.Models;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands;

namespace HLP.Entries.ViewModel.ViewModels
{
    public class UFViewModel : ModelBase
    {

        public ICommand commandSalvar { get; set; }
        public ICommand commandDeletar { get; set; }

        UFCommands objUFCommand;
                      
        public UFViewModel()
        {
            objUFCommand = new UFCommands(objViewModel: this);
        }

        private int _idUF;

        public int idUF
        {
            get { return _idUF; }
            set
            {
                _idUF = value;
                base.NotifyPropertyChanged("idUF");
                this.currentUF.idUF = value;
            }
        }

        private UFModel _currentUF;

        public UFModel currentUF
        {
            get
            {

                return (_currentUF == null ? this._currentUF = new UFModel() : this._currentUF);
            }
            set { _currentUF = value; base.NotifyPropertyChanged("currentUF"); }
        }




    }
}
