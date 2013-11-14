using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HLP.Comum.ViewModel.Commands;
using HLP.Dependencies;
using HLP.Entries.Model.Models;
using HLP.Entries.Model.Repository.Interfaces;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using HLP.Entries.ViewModel.ViewModels;

namespace HLP.Entries.ViewModel.Commands
{
    public class RegiaoCommands
    {
        public IRegiaoRepository iRegiaoRepository { get; set; }

        RegiaoViewModel objRegiaoViewModel;
        public RegiaoCommands(RegiaoViewModel objRegiaoViewModel)
        {
            this.objRegiaoViewModel = objRegiaoViewModel;

            this.objRegiaoViewModel.commandTeste = new RelayCommand(param => TESTE(), exec => true);
        }

        public void TESTE() 
        {
            MessageBox.Show("teste");
        }

        public void GetAll()
        {
            objRegiaoViewModel.lRegiao = iRegiaoRepository.GetAll();
        }
    }
}
