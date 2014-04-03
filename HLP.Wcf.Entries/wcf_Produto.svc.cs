using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Produto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Produto.svc or wcf_Produto.svc.cs at the Solution Explorer and start debugging.
    public class wcf_Produto : Iwcf_Produto
    {
        [Inject]
        public IProdutoRepository produtoRepository { get; set; }

        [Inject]
        public IProduto_RevisaoRepository produto_RevisaoRepository { get; set; }

        [Inject]
        public IProduto_Fornecedor_HomologadoRepository produto_Fornecedor_HomologadoRepository { get; set; }

        public wcf_Produto()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Comercial.ProdutoModel GetObjeto(int idProduto)
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

        public HLP.Entries.Model.Models.Comercial.ProdutoModel Save(HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto)
        {

            try
            {
                this.produtoRepository.BeginTransaction();

                this.produtoRepository.Save(produto: objProduto);


                foreach (HLP.Entries.Model.Models.Comercial.Produto_Fornecedor_HomologadoModel item in objProduto.lProduto_Fornecedor_Homologado)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idProduto = (int)objProduto.idProduto;
                                this.produto_Fornecedor_HomologadoRepository.Save(
                                    produtoFornHom: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.produto_Fornecedor_HomologadoRepository.Delete(
                                    idProdutoFornecedorHomologado: (int)item.idProdutoFornecedorHomologado);
                            }
                            break;
                    }
                }


                foreach (HLP.Entries.Model.Models.Comercial.Produto_RevisaoModel item in objProduto.lProduto_Revisao)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idProduto = (int)objProduto.idProduto;
                                this.produto_RevisaoRepository.Save(
                                    produtoRevisao: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.produto_RevisaoRepository.Delete(idProdutoRevisao: (int)item.idProdutoRevisao);
                            }
                            break;
                    }
                }
                produtoRepository.CommitTransaction();
                return objProduto;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                produtoRepository.RollackTransaction();
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Comercial.ProdutoModel Copy(HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto)
        {

            try
            {
                this.produtoRepository.BeginTransaction();
                this.produtoRepository.Copy(produto: objProduto);

                foreach (HLP.Entries.Model.Models.Comercial.Produto_RevisaoModel item in objProduto.lProduto_Revisao)
                {
                    item.idProduto = (int)objProduto.idProduto;
                    this.produto_RevisaoRepository.Copy(produtoRevisao: item);
                }

                foreach (HLP.Entries.Model.Models.Comercial.Produto_Fornecedor_HomologadoModel item in objProduto.lProduto_Fornecedor_Homologado)
                {
                    item.idProduto = (int)objProduto.idProduto;
                    this.produto_Fornecedor_HomologadoRepository.Copy(produtoFornHom: item);
                }
                this.produtoRepository.CommitTransaction();
                return objProduto;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                this.produtoRepository.RollackTransaction();
                throw new FaultException(reason: ex.Message);
            }
        }

        public List<HLP.Entries.Model.Models.Comercial.ProdutoModel> getAll()
        {

            try
            {
                return this.produtoRepository.GetAll();
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(int idProduto)
        {

            try
            {
                this.produtoRepository.BeginTransaction();
                this.produto_Fornecedor_HomologadoRepository.DeletePorProduto(
                    idProduto: idProduto);
                this.produto_RevisaoRepository.DeletePorProduto(
                    idProduto: idProduto);
                this.produtoRepository.Delete(idProduto: idProduto);
                this.produtoRepository.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                this.produtoRepository.RollackTransaction();
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool PrecoCustoManual(int idProduto)
        {
            try
            {
                return (byte?)this.produtoRepository.GetStCustoProduto(idProduto: idProduto) == (byte)1;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public decimal GetValorCompraProduto(int idProduto)
        {

            try
            {
                return this.produtoRepository.GetValorCompraProduto(idProduto: idProduto) ?? decimal.Zero;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
