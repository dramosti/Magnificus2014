using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Ninject;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceFamiliaProduto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceFamiliaProduto.svc or serviceFamiliaProduto.svc.cs at the Solution Explorer and start debugging.
    public class serviceFamiliaProduto : IserviceFamiliaProduto
    {
        [Inject]
        public IFamilia_ProdutoRepository iFamilia_ProdutoRepository { get; set; }
        [Inject]
        public IFamilia_Produto_ClassesRepository iFamilia_Produto_ClassesRepository { get; set; }

        public serviceFamiliaProduto()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.Familia_produtoModel GetObject(int idFamiliaProduto)
        {

            try
            {
                HLP.Entries.Model.Models.Gerais.Familia_produtoModel objFamiliaProd = iFamilia_ProdutoRepository.GetFamilia_produto(idFamiliaProduto);
                if (objFamiliaProd != null)
                {
                    objFamiliaProd.lFamilia_Produto_ClassesModel = new Comum.Model.Models.ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Familia_Produto_ClassesModel>(iFamilia_Produto_ClassesRepository.GetAllFamilia_Produto_Classes(idFamiliaProduto));
                }
                return objFamiliaProd;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }


        }

        public void Save(HLP.Entries.Model.Models.Gerais.Familia_produtoModel familia_produto)
        {
            try
            {
                iFamilia_ProdutoRepository.BeginTransaction();

                iFamilia_ProdutoRepository.Save(familia_produto);

                foreach (var item in familia_produto.lFamilia_Produto_ClassesModel)
                {
                    switch (item.status)
                    {
                        case HLP.Comum.Resources.RecursosBases.statusModel.criado:
                        case HLP.Comum.Resources.RecursosBases.statusModel.alterado:
                            {
                                iFamilia_Produto_ClassesRepository.Save(item);
                            }
                            break;
                        case HLP.Comum.Resources.RecursosBases.statusModel.excluido:
                            {
                                iFamilia_Produto_ClassesRepository.Delete((int)item.idFamilia_Produto_Classes);
                            }
                            break;
                    }
                }
                iFamilia_ProdutoRepository.CommitTransaction();
            }
            catch (Exception ex)
            {
                iFamilia_ProdutoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(int idFamiliaProduto)
        {
            try
            {
                iFamilia_ProdutoRepository.BeginTransaction();
                iFamilia_Produto_ClassesRepository.DeleteFamiliasPorFamilia(idFamiliaProduto);
                iFamilia_ProdutoRepository.Delete(idFamiliaProduto);
                iFamilia_ProdutoRepository.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                iFamilia_ProdutoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int Copy(HLP.Entries.Model.Models.Gerais.Familia_produtoModel familia_produto)
        {
            try
            {
                iFamilia_ProdutoRepository.BeginTransaction();
                familia_produto.idFamiliaProduto = iFamilia_ProdutoRepository.Copy(familia_produto);

                foreach (var item in familia_produto.lFamilia_Produto_ClassesModel)
                {
                    item.idFamiliaProduto = (int)familia_produto.idFamiliaProduto;
                    iFamilia_Produto_ClassesRepository.Copy(item);
                }
                iFamilia_ProdutoRepository.CommitTransaction();
                return (int)familia_produto.idFamiliaProduto;
            }
            catch (Exception ex)
            {
                iFamilia_ProdutoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
