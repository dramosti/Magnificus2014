using HLP.Comum.Services;
using HLP.Comum.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.ViewModel.Commands
{
    public class ConnectionConfigCommand
    {
        public ConnectionConfigViewModel viewModel { get; set; }
        ConnectionConfigService servico;
        public ConnectionConfigCommand(ConnectionConfigViewModel viewModel)
        {
            this.viewModel = viewModel;
            this.viewModel.currentModel = new Model.Models.ConnectionConfigModel();
            servico = new ConnectionConfigService();
            this.viewModel.bWorkerPesquisa.DoWork += bWorkerPesquisa_DoWork;
            this.viewModel.bWorkerPesquisa.RunWorkerAsync();
        }

        private void bWorkerPesquisa_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                DataTable dt = servico.GetServer();
                if (dt != null)
                {
                    this.viewModel.servers = new System.Collections.ObjectModel.ObservableCollection<string>(dt.AsEnumerable().Select(c => c["ServerName"].ToString()).ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CarregaBases()
        {
            try
            {
                DataSet ds = servico.GetDatabases(this.viewModel.currentModel.ConnectionString);

                if (ds.Tables.Count > 0)
                {
                    this.viewModel.bases = new System.Collections.ObjectModel.ObservableCollection<string>(ds.Tables[0].AsEnumerable().Select(c => c["name"].ToString()).ToList());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }



    }
}
