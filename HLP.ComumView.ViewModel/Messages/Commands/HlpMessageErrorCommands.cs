using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.ComumView.ViewModel.ViewModel;
using HLP.ComumView.ViewModel.Messages.ViewModels;
using System.Windows;
using HLP.Base.ClassesBases;

namespace HLP.ComumView.ViewModel.Messages.Commands
{
    public class HlpMessageErrorCommands
    {
        HlpMessageErrorViewModel objViewModel;
        public HlpMessageErrorCommands(HlpMessageErrorViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            this.objViewModel.commCopy = new RelayCommand(execute: e => this.CopyExecute());
            this.objViewModel.commOk = new RelayCommand(execute: execute => this.OkExecute(o: execute),
                canExecute: canExecute => true);
        }

        private void CopyExecute()
        {
            Clipboard.SetText(text: this.objViewModel.xErrorMessageToUser +
                Environment.NewLine + Environment.NewLine +
                this.objViewModel.xErrorMessageFramework);
        }

        private void OkExecute(object o)
        {
            (o as Window).Close();
        }
    }
}
