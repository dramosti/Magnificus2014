using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Comum.Model.Models;
using HLP.Comum.Services;
using HLP.Comum.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLP.Comum.ViewModel.Commands
{
    public class SelectConnectionCommand
    {
        SelectConnectionViewModel ViewModel;
        SelectConnectionService servico;

        public SelectConnectionCommand(SelectConnectionViewModel ViewModel)
        {
            this.ViewModel = ViewModel;
            servico = new SelectConnectionService();

            if (System.IO.File.Exists(Pastas.Path_BasesConfiguradas))
            {
                MagnificusBaseConfiguration objResult = servico.GetBaseConfiguration();
                if (objResult != null)
                {
                    this.ViewModel.conexoes = new System.Collections.ObjectModel.ObservableCollection<ConnectionConfigModel>(objResult.conexoes);
                }
            }
            this.ViewModel.ConcluirCommand = new RelayCommand(execute: i => this.ConcluirSelect(i),
            canExecute: i => CanConcluirSelect());
            this.ViewModel.fecharCommand = new RelayCommand(execute: i => this.Fechar(i),
          canExecute: i => true);
        }

        public void ConcluirSelect(object win)
        {
            try
            {
                Sistema.SetAppSettings("urlWebService", ViewModel.currentModel.urlWebService);                
                Sistema.SalvaEndPoint(ViewModel.currentModel.urlWebService);
                Sistema.AddConnection(ViewModel.currentModel.ConnectionStringCompleted);

                this.ViewModel.bProssegue = true;
                Window objWin = win as Window;
                objWin.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CanConcluirSelect()
        {
            if (ViewModel.currentModel != null)
                return true;
            else
                return false;
        }


        public void Fechar(object win)
        {
            this.ViewModel.bProssegue = false;
            Window objWin = win as Window;
            objWin.Close();
        }




    }
}
