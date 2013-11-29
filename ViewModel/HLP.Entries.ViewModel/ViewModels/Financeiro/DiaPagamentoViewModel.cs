using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Financeiro;

namespace HLP.Entries.ViewModel.ViewModels.Financeiro
{
    public class DiaPagamentoViewModel : ViewModelBase
    {
        public DiaPagamentoViewModel() 
        {
            
        }
        
        private Dia_pagamentoModel _currentModel;

        public Dia_pagamentoModel currentModel
        {
            get { return _currentModel; }
            set
            {
                _currentModel = value;
                base.NotifyPropertyChanged(propertyName: "currentModel");
            }
        }
        

    }
}
