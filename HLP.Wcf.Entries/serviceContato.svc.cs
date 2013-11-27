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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceContato" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceContato.svc or serviceContato.svc.cs at the Solution Explorer and start debugging.
    public class serviceContato : IserviceContato
    {
        [Inject]
        public IContatoRepository iContatoRepository { get; set; }
        [Inject]
        public IContato_EnderecoRepository iContato_EnderecoRepository { get; set; }

        public serviceContato()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.ContatoModel Save(HLP.Entries.Model.Models.Gerais.ContatoModel objContato)
        {
            try
            {
                iContatoRepository.BeginTransaction();
                iContatoRepository.Save(objContato);
                foreach (var item in objContato.lContato_EnderecoModel)
                {
                    switch (item.status)
                    {
                        case HLP.Comum.Resources.RecursosBases.statusModel.criado:
                        case HLP.Comum.Resources.RecursosBases.statusModel.alterado:
                            {
                                iContato_EnderecoRepository.Save(item);                    
                            }
                            break;
                        case HLP.Comum.Resources.RecursosBases.statusModel.excluido:
                            {
                                iContato_EnderecoRepository.Delete((int)item.idEndereco);
                            }
                            break;
                    }
                }
                iContatoRepository.CommitTransaction();
                return objContato;
            }
            catch (Exception ex)
            {
                iContatoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(int idContato)
        {
            try
            {
                iContatoRepository.BeginTransaction();
                iContato_EnderecoRepository.DeleteEnderecosByContato(idContato);
                iContatoRepository.Delete(idContato);
                iContatoRepository.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                iContatoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        
        }

        public HLP.Entries.Model.Models.Gerais.ContatoModel Copy(HLP.Entries.Model.Models.Gerais.ContatoModel objContato)
        {
            try
            {
                iContatoRepository.BeginTransaction();
                iContatoRepository.Copy(objContato);

                foreach (var item in objContato.lContato_EnderecoModel)
                {
                    item.idContato = (int)objContato.idContato;
                    iContato_EnderecoRepository.Copy(item);
                }
                iContatoRepository.CommitTransaction();
               return objContato;

            }
            catch (Exception ex)
            {
                iContatoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        
        }

        public HLP.Entries.Model.Models.Gerais.ContatoModel GetObject(int idContato)
        {
            try
            {

                HLP.Entries.Model.Models.Gerais.ContatoModel objReturn = iContatoRepository.GetContato(idContato);
                if (objReturn != null)
                {
                    objReturn.lContato_EnderecoModel = new Comum.Model.Models.ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Contato_EnderecoModel>(iContato_EnderecoRepository.GetAllContato_Endereco(idContato));                    
                }
                return objReturn;


            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        
        }

        public List<HLP.Entries.Model.Models.Gerais.ContatoModel> GetContato_ByClienteFornec(int idContato)
        {
            try
            {
                return iContatoRepository.GetContato_ByClienteFornec(idContato);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        
        }





  
    }
}
