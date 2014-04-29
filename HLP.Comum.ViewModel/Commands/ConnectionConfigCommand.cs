using HLP.Base.ClassesBases;
using HLP.Comum.Services;
using HLP.Comum.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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


            this.viewModel.TestarCommand = new RelayCommand(execute: i => this.TestConnection(),
                canExecute: i => this.viewModel.currentModel.ConnectionStringCompleted != "");

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
                if (this.viewModel.currentModel.ConnectionString != "")
                {
                    DataSet ds = servico.GetDatabases(this.viewModel.currentModel.ConnectionString);

                    if (ds.Tables.Count > 0)
                    {
                        this.viewModel.bases = new System.Collections.ObjectModel.ObservableCollection<string>(ds.Tables[0].AsEnumerable().Select(c => c["name"].ToString()).ToList());
                    }
                    else
                    {
                        this.viewModel.bases = new System.Collections.ObjectModel.ObservableCollection<string>();
                    }
                }
                else
                {
                    this.viewModel.bases = new System.Collections.ObjectModel.ObservableCollection<string>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public void TestConnection()
        {
            try
            {
                if (String.IsNullOrEmpty(this.viewModel.currentModel.xBaseDados))
                {
                    MessageBox.Show("Banco de Dados não foi selecionado", "A V I S O", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (servico.TestConnection(this.viewModel.currentModel.ConnectionStringCompleted))
                {
                    MessageBox.Show("Teste de conexão realizado com sucesso!", "A V I S O", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Teste de Conexão não obteve êxito!", "A V I S O", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


    }
}
