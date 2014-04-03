using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Entries.Model.Models;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands;
using HLP.Base.ClassesBases;
using HLP.Entries.ViewModel.Commands.Gerais;

namespace HLP.Entries.ViewModel.ViewModels
{
    public class RegiaoViewModel : ViewModelBase<RegiaoModel>
    {       

        public ICommand commandTeste { get; set; }

        RegiaoCommands objRegiaoCommands = null;
        

        private ObservableCollection<RegiaoModel> _lRegiao;

        public ObservableCollection<RegiaoModel> lRegiao
        {
            get { return _lRegiao; }
            set { _lRegiao = value; base.NotifyPropertyChanged("lRegiao"); }
        }

        public RegiaoViewModel()
            : base()
        {
            objRegiaoCommands = new RegiaoCommands(objRegiaoViewModel: this);
            objRegiaoCommands.GetAll();
        }

        public ObservableCollection<RegiaoModel> GetAll()
        {
            objRegiaoCommands.GetAll();
            return this.lRegiao;
        }


    }



}
