using HLP.Base.ClassesBases;
using HLP.Comum.Services;
using HLP.SQLAnalyse.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.SQLAnalyse.ViewModel.Commands
{
    public class AnalyzeCommand
    {
        ConnectionConfigService servicoFindConexao;

        public AnalyzeViewModel ViewModel { get; set; }

        public AnalyzeCommand(AnalyzeViewModel ViewModel)
        {
            this.ViewModel = ViewModel;

            this.ViewModel.AddCommand = new RelayCommand(execute: i => this.AddConexao(),
             canExecute: i => CanTesteAndADD());
            this.ViewModel.TestarCommand = new RelayCommand(execute: i => this.TestConnection(),
            canExecute: i => CanTesteAndADD());
            //this.ViewModel.ProsseguirCommand
            
            this.ViewModel.bWorkerPesquisa.DoWork += bWorkerPesquisa_DoWork;
            this.ViewModel.bWorkerPesquisa.RunWorkerAsync();
        }

        private void bWorkerPesquisa_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                DataTable dt = servicoFindConexao.GetServer();
                if (dt != null)
                {
                    this.ViewModel.servers = new System.Collections.ObjectModel.ObservableCollection<string>(dt.AsEnumerable().Select(c => c["ServerName"].ToString()).ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        public void TestConnection()
        {
            try
            {
                if (String.IsNullOrEmpty(this.ViewModel.currentConexao.xBaseDados))
                {
                    MessageHlp.Show( StMessage.stAlert, "Banco de Dados não foi selecionado");
                }
                if (servicoFindConexao.TestConnection(this.ViewModel.currentConexao.ConnectionStringCompleted))
                {
                    MessageHlp.Show(StMessage.stAlert, "Teste de conexão realizado com sucesso!");
                }
                else
                {
                    MessageHlp.Show(StMessage.stAlert, "Teste de Conexão não obteve êxito!");
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public void AddConexao()
        {
            this.ViewModel.currentModel.conexoes.Add(this.ViewModel.currentConexao);
            this.ViewModel.currentConexao = new Comum.Model.Models.ConnectionConfigModel();
        }
        bool CanTesteAndADD()
        {
            if (this.ViewModel.currentConexao.ConnectionStringCompleted != ""
                && !(string.IsNullOrEmpty(this.ViewModel.currentConexao.xBaseDados)))
                return true;
            else
                return false;
        }
    }
}
