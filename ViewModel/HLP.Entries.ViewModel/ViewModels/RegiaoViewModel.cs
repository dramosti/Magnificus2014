﻿using System;
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
    public class RegiaoViewModel : ModelBase
    {
       public ICommand commandTeste {get;set;}

        RegiaoCommands objRegiaoCommands = null;

        private ObservableCollection<RegiaoModel> _lRegiao;

        public ObservableCollection<RegiaoModel> lRegiao
        {
            get { return _lRegiao; }
            set { _lRegiao = value; base.NotifyPropertyChanged("lRegiao"); }
        }

        public RegiaoViewModel()
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
