using HLP.Comum.Model.Models;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels
{
    public class FuncionarioViewModel : ViewModelBase
    {
        #region Icommands
        public ICommand commandSalvar { get; set; }
        public ICommand commandDeletar { get; set; }
        public ICommand commandNovo { get; set; }
        public ICommand commandAlterar { get; set; }
        public ICommand commandCancelar { get; set; }
        public ICommand commandCopiar { get; set; }
        public ICommand commandPesquisar { get; set; }
        public ICommand navegarCommand { get; set; }
        #endregion

        #region Listas de Campos Not Null
        campoSqlModel[] lCamposSqlModelAcesso;
        campoSqlModel[] lCamposSqlModelFuncionario_Arquivo;
        campoSqlModel[] lCamposSqlModelFuncionario_Certificacao;
        campoSqlModel[] lCamposSqlModelFuncionario_Comissao_Produto;
        campoSqlModel[] lCamposSqlModelFuncionario_Endereco;
        campoSqlModel[] lCamposSqlModelFuncionario_Margem_Lucro_Comissao;
        #endregion

        FuncionarioViewModel()
            : base(xTabela: "Funcionario")
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerAsync();
        }

        FuncionarioModel _currentModel;

        public FuncionarioModel currentModel
        {
            get { return _currentModel; }
            set
            {
                _currentModel = value;
                base.NotifyPropertyChanged(propertyName: "currentModel");
            }
        }

        async void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            lCamposSqlModelAcesso = await base.taskGetCamposNotNull(xTabela: "Acesso");
            lCamposSqlModelFuncionario_Arquivo = await base.taskGetCamposNotNull(
                xTabela: "Funcionario_Arquivo");
            lCamposSqlModelFuncionario_Certificacao = await base.taskGetCamposNotNull(xTabela: "Funcionario_Certificacao");
            lCamposSqlModelFuncionario_Comissao_Produto = await base.taskGetCamposNotNull(xTabela: "Funcionario_Comissao_Produto");
            lCamposSqlModelFuncionario_Endereco = await base.taskGetCamposNotNull(xTabela: "Funcionario_Endereco");
            lCamposSqlModelFuncionario_Margem_Lucro_Comissao = await base.taskGetCamposNotNull(xTabela: "Funcionario_Margem_Lucro_Comissao");
        }
    }
}
