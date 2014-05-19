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
    public class HlpMessageYesNoCommands
    {
        HlpMessageYesNoViewModel objViewModel;

        public HlpMessageYesNoCommands(HlpMessageYesNoViewModel objViewModel)
        {
            this.objViewModel = objViewModel;

            this.objViewModel.commYes = new RelayCommand(execute: execute => YesExecute(o: execute), canExecute: canExecute => true);
            this.objViewModel.commNo = new RelayCommand(execute: execute => NoExecute(o: execute), canExecute: canExecute => true);
        }

        private void YesExecute(object o)
        {
            (o as Window).DialogResult = true;
            (o as Window).Close();
        }

        private void NoExecute(object o)
        {
            (o as Window).DialogResult = false;
            (o as Window).Close();
        }
    }
}
