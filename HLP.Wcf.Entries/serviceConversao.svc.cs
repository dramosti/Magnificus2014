using HLP.Comum.Resources.Util;
using HLP.Dependencies;
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

        public serviceConversao()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public IEnumerable<HLP.Entries.Model.Models.Gerais.ConversaoModel> getlConversao(int idProduto)
        {
            try
            {
                return this.conversaoRepository.GetAll(idProduto: idProduto);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public void savelConversao(Comum.Model.Models.ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.ConversaoModel> lConversao)
        {

            try
            {
                foreach (HLP.Entries.Model.Models.Gerais.ConversaoModel item in lConversao)
                {
                    switch (item.status)
                    {
                        case HLP.Comum.Resources.RecursosBases.statusModel.criado:
                        case HLP.Comum.Resources.RecursosBases.statusModel.alterado:
                            {
                                this.conversaoRepository.Save(conversao: item);
                            }
                            break;
                        case HLP.Comum.Resources.RecursosBases.statusModel.excluido:
                            {
                                this.conversaoRepository.Delete(idConversao: (int)item.idConversao);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
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
