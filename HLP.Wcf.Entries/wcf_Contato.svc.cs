using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Base.Static;
using HLP.Components.Model.Models;
using HLP.Components.Model.Repository.Interfaces;
using HLP.Dependencies;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Contato" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Contato.svc or wcf_Contato.svc.cs at the Solution Explorer and start debugging.
    public class wcf_Contato : Iwcf_Contato
    {
        [Inject]
        public IContatoRepository iContatoRepository { get; set; }
        [Inject]
        public IContato_EnderecoRepository iContato_EnderecoRepository { get; set; }

        public wcf_Contato()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public ContatoModel Save(ContatoModel objContato)
        {
            try
            {
                iContatoRepository.BeginTransaction();
                iContatoRepository.Save(objContato);
                foreach (var item in objContato.lContato_EnderecoModel)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idContato = (int)objContato.idContato;
                                iContato_EnderecoRepository.Save(item);
                            }
                            break;
                        case statusModel.excluido:
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

        public ContatoModel Copy(ContatoModel objContato)
        {
            try
            {
                iContatoRepository.BeginTransaction();
                iContatoRepository.Copy(objContato.idContato ?? 0);

                foreach (var item in objContato.lContato_EnderecoModel)
                {
                    item.idContato = (int)objContato.idContato;
                    item.idEndereco = null;
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

        public ContatoModel GetObject(int idContato)
        {
            try
            {

                ContatoModel objReturn = iContatoRepository.GetContato(idContato);
                if (objReturn != null)
                {
                    objReturn.lContato_EnderecoModel = new ObservableCollectionBaseCadastros<Contato_EnderecoModel>(iContato_EnderecoRepository.GetAllContato_Endereco(idContato));
                }
                return objReturn;


            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public List<ContatoModel> GetContato_ByClienteFornec(int idContato)
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
