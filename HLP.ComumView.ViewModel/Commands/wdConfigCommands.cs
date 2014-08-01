using HLP.ComumView.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using HLP.Base.Static;
using System.Windows.Controls;
using HLP.Base.ClassesBases;
using System.Windows;

namespace HLP.ComumView.ViewModel.Commands
{
    public class wdConfigCommands
    {
        wdConfigViewModel objViewModel;

        public wdConfigCommands(wdConfigViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            this.objViewModel.okCommand = new RelayCommand(execute: ex => this.okExecute(objDependency: ex)
                , canExecute: canEx => this.okCanExecute(objDependency: canEx));
        }

        private void okExecute(object objDependency)
        {
            Configuration c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (string.IsNullOrEmpty(value: Sistema.GetConnectionStrings(xKey: "dbPrincipal")))
                c.ConnectionStrings.ConnectionStrings.
                    Add(settings: new ConnectionStringSettings(name: "dbPrincipal", connectionString: this.objViewModel.currentModel.xBaseDados));

            if (string.IsNullOrEmpty(value: Sistema.GetAppSettings(xKey: "urlWebService")))
                c.AppSettings.Settings.Add(key: "urlWebService", value: this.objViewModel.currentModel.xUriWcf);

            c.Save();

            ((objDependency as Grid).Parent as Window).Close();
        }

        private bool okCanExecute(object objDependency)
        {
            return this.objViewModel.IsValid(objDependency as Panel);
        }
    }
}
