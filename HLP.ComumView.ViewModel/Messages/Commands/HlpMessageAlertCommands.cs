using HLP.Base.ClassesBases;
using HLP.ComumView.ViewModel.Messages.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLP.ComumView.ViewModel.Messages.Commands
{
    public class HlpMessageAlertCommands
    {
        HlpMessageAlertViewModel objViewModel;

        public HlpMessageAlertCommands(HlpMessageAlertViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            this.objViewModel.commOk = new RelayCommand(execute: execute => this.OkExecute(o: execute),
                canExecute: canExecute => true);
        }

        private void OkExecute(object o)
        {
            (o as Window).Close();
        }
    }
}
