using HLP.Comum.Model.Models;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Comercial;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceProduto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceProduto.svc or serviceProduto.svc.cs at the Solution Explorer and start debugging.
    public class serviceProduto : IserviceProduto
    {
        [Inject]
        public IProdutoRepository produtoRepository { get; set; }

        [Inject]
        public IProduto_RevisaoRepository produto_RevisaoRepository { get; set; }

        [Inject]
        public IProduto_Fornecedor_HomologadoRepository produto_Fornecedor_HomologadoRepository { get; set; }

        public serviceProduto()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Comercial.ProdutoModel getProduto(int idProduto)
        {
            try
            {
                HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto =
                    this.produtoRepository.GetProduto(idProduto: idProduto);

                objProduto.lProduto_Fornecedor_Homologado =
                    new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Comercial.Produto_Fornecedor_HomologadoModel>(
                        list: this.produto_Fornecedor_HomologadoRepository.GetAllProdForncHom(
                        idProduto: idProduto));

                objProduto.lProduto_Revisao =
                    new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Comercial.Produto_RevisaoModel>(
                        list: this.produto_RevisaoRepository.GetAllProdutoRevisao(
                        idProduto: idProduto));

                return objProduto;

            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int saveProduto(HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto)
        {

            try
            {
                this.produtoRepository.BeginTransaction();

                this.produtoRepository.Save(produto: objProduto);

                return (int)objProduto.idProduto;

            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool deleteProduto(int idProduto)
        {
            throw new NotImplementedException();
        }

        public int copyProduto(HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto)
        {
            throw new NotImplementedException();
        }
    }
}
