﻿using HLP.Comum.Model.Models;
using HLP.Comum.ViewModel.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Comum.ViewModel.ViewModels
{
    public class HlpPesquisaInsertViewModel : ViewModelBase<HlpPesquisaInsertModel>
    {

        public ICommand salvarCommand { get; set; }

        public HlpPesquisaInsertViewModel()
        {
            HlpPesquisaInsertCommands comm = new HlpPesquisaInsertCommands(objViewModel: this);            
        }


    }
}
