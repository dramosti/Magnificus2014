using HLP.Base.Static;
using HLP.Comum.ViewModel.ViewModel;
using HLP.ComumView.Model.Model;
using HLP.ComumView.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.ComumView.ViewModel.ViewModel
{
    public class wdConfigViewModel : viewModelComum<configuracaoModel>
    {
        public ICommand okCommand { get; set; }
        wdConfigCommands comm;

        public wdConfigViewModel()
        {
            this.currentModel = new configuracaoModel
            {
                xUriWcf = Sistema.GetAppSettings("urlWebService"),
                xBaseDados = Sistema.GetConnectionStrings(xKey: "dbPrincipal")
            };

            comm = new wdConfigCommands(objViewModel: this);
        }
    }
}
