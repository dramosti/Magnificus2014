using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceConversao" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceConversao.svc or serviceConversao.svc.cs at the Solution Explorer and start debugging.
    public class serviceConversao : IserviceConversao
    {
        [Inject]
        public IConversaoRepository conversaoRepository { get; set; }

        [Inject]
        public IProdutoRepository produtoRepository { get; set; }

        public serviceConversao()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Comercial.ProdutoModel getlConversao(int idProduto)
        {
            try
            {
                HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto =
                    produtoRepository.GetProduto(idProduto: idProduto);

                if (objProduto != null)
                    objProduto.lProdutos_Conversao = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.ConversaoModel>
                        (list: conversaoRepository.GetAll(idProduto: idProduto));

                return objProduto;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.ConversaoModel> savelConversao(HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto)
        {
            try
            {
                this.conversaoRepository.BeginTransaction();
                foreach (HLP.Entries.Model.Models.Gerais.ConversaoModel item in objProduto.lProdutos_Conversao)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idProduto = (int)objProduto.idProduto;
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

                return objProduto.lProdutos_Conversao;
            }
            catch (Exception ex)
            {
                this.conversaoRepository.RollbackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool dellConversao(int idProduto)
        {
            try
            {
                this.conversaoRepository.DeletePorProduto(idProduto: idProduto);
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
