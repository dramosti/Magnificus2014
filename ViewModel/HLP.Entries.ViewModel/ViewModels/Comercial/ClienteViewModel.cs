using HLP.Base.ClassesBases;
using HLP.Comum.ViewModel.ViewModel;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels.Comercial
{
    public class ClienteViewModel : viewModelComum<Cliente_fornecedorModel>
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
        ClienteCommands comm;

        public ClienteViewModel()
        {
            comm = new ClienteCommands(
                objViewModel: this);
        }

        public bool RotaPossuiListaPrecoPai(int idRota)
        {
            bool bResult = this.comm.RotaPossuiListaPrecoPai(idRota: idRota);

            if (bResult)
            {
                MessageHlp.Show(stMessage: StMessage.stAlert, xMessageToUser: "Rota possui uma lista de preço já informada. Cadastro do cliente perderá a referência a lista informada!");
            }

            return bResult;
        }

        public int GetIdSiteByDeposito(int idDeposito)
        {
            return comm.GetIdSiteByDeposito(idDeposito: idDeposito);
        }

        public Condicao_pagamentoModel getCondicaoPagamentoByCliente(int idCondicaoPagamento)
        {
            return comm.getCondicaoPagamentoByCliente(idCondicaoPagamento: idCondicaoPagamento);
        }

        public int? GetIdListaPrecoPaiRota(int idRota)
        {
            return comm.GetIdListaPrecoPaiRota(idRota: idRota);
        }
    }
}
