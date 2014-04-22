using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Comercial;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Conversao" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Conversao.svc or wcf_Conversao.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Conversao : Iwcf_Conversao
    {
        [Inject]
        public IConversaoRepository conversaoRepository { get; set; }

        [Inject]
        public IProdutoRepository produtoRepository { get; set; }

        public wcf_Conversao()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public ProdutoModel GetObject(int id)
        {
            try
            {
                ProdutoModel objProduto =
                    produtoRepository.GetProduto(idProduto: id);

                if (objProduto != null)
                    objProduto.lProdutos_Conversao = new ObservableCollectionBaseCadastros<ConversaoModel>
                        (list: conversaoRepository.GetAll(idProduto: id));

                return objProduto;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public ObservableCollectionBaseCadastros<ConversaoModel> SaveObject(ProdutoModel obj)
        {
            try
            {
                this.conversaoRepository.BeginTransaction();
                foreach (HLP.Entries.Model.Models.Gerais.ConversaoModel item in obj.lProdutos_Conversao)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idProduto = (int)obj.idProduto;
                                this.conversaoRepository.Save(conversao: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.conversaoRepository.Delete(idConversao: (int)item.idConversao);
                            }
                            break;
                    }
                }
                this.conversaoRepository.CommitTransaction();

                return obj.lProdutos_Conversao;
            }
            catch (Exception ex)
            {
                this.conversaoRepository.RollbackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool DeleteObject(int id)
        {
            try
            {
                this.conversaoRepository.DeletePorProduto(idProduto: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
        
}
