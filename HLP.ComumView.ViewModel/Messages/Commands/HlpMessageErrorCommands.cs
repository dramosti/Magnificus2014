using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.ComumView.ViewModel.ViewModel;
using HLP.ComumView.ViewModel.Messages.ViewModels;
using System.Windows;
using HLP.Base.ClassesBases;
using HLP.Base.Static;

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
            try
            {
                Clipboard.SetText(text: this.objViewModel.xErrorMessageToUser +
                Environment.NewLine + Environment.NewLine +
                this.objViewModel.xErrorMessageFramework);
            }
            catch (Exception)
            {
            }
            finally
            {
                Log.xPath = @"c:\logMagnificus\";
                Log.AddLog(xLog: this.objViewModel.xErrorMessageFramework);
            }

        }

        private void OkExecute(object o)
        {
            (o as Window).Close();
        }
    }
}
