using HLP.Comum.Model.Models;
using HLP.Comum.Resources.RecursosBases;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceLista_Preco" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceLista_Preco.svc or serviceLista_Preco.svc.cs at the Solution Explorer and start debugging.
    public class serviceLista_Preco : IserviceLista_Preco
    {
        [Inject]
        public ILista_Preco_PaiRepository lista_Preco_PaiRepository { get; set; }

        [Inject]
        public ILista_precoRepository lista_PrecoRepository { get; set; }

        public serviceLista_Preco()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }



        public HLP.Entries.Model.Models.Comercial.Lista_Preco_PaiModel getLista_Preco(int idListaPrecoPai)
        {

            try
            {
                HLP.Entries.Model.Models.Comercial.Lista_Preco_PaiModel objListaPreco
                    = this.lista_Preco_PaiRepository.GetLista_Preco_Pai(idListaPrecoPai: idListaPrecoPai);

                if (objListaPreco == null)
                {
                    return null;
                }

                objListaPreco.lLista_preco = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Comercial.Lista_precoModel>
                    (list: this.lista_PrecoRepository.GetAllLista_preco(
                        idListaPrecoPai: idListaPrecoPai));
                return objListaPreco;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public List<HLP.Entries.Model.Models.Comercial.Lista_precoModel> GetItensListaPreco(int idListaPrecoPai)
        {
            try
            {
                return this.lista_PrecoRepository.GetAllLista_preco(idListaPrecoPai:
                    idListaPrecoPai);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public HLP.Entries.Model.Models.Comercial.Lista_Preco_PaiModel saveLista_Preco(HLP.Entries.Model.Models.Comercial.Lista_Preco_PaiModel objListaPreco)
        {

            try
            {
                this.lista_Preco_PaiRepository.BeginTransaction();
                this.lista_Preco_PaiRepository.Save(
                    objLista_Preco_Pai: objListaPreco);


                foreach (HLP.Entries.Model.Models.Comercial.Lista_precoModel item in objListaPreco.lLista_preco)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idListaPrecoPai = objListaPreco.idListaPrecoPai;
                                this.lista_PrecoRepository.Save(
                                    objLista_preco: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.lista_PrecoRepository.Delete(idListaPreco:
                                    (int)item.idListaPreco);
                            }
                            break;
                    }
                }                

                this.lista_Preco_PaiRepository.CommitTransaction();

                while (objListaPreco.lLista_preco.Count(i => i.status == statusModel.excluido) > 0)
                {
                    objListaPreco.lLista_preco.RemoveAt(index: objListaPreco.lLista_preco.IndexOf(item:
                        objListaPreco.lLista_preco.FirstOrDefault(i => i.status == statusModel.excluido)));
                }

                return objListaPreco;
            }
            catch (Exception ex)
            {
                this.lista_Preco_PaiRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool deleteLista_Preco(int idListaPrecoPai)
        {
            try
            {
                this.lista_Preco_PaiRepository.BeginTransaction();
                this.lista_PrecoRepository.DeletePorListaPrecoPai(
                    idListaPrecoPai: idListaPrecoPai);
                this.lista_Preco_PaiRepository.Delete(
                    idListaPrecoPai: idListaPrecoPai);
                this.lista_Preco_PaiRepository.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                this.lista_Preco_PaiRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Comercial.Lista_Preco_PaiModel copyLista_Preco(HLP.Entries.Model.Models.Comercial.Lista_Preco_PaiModel objListaPreco)
        {

            try
            {
                this.lista_Preco_PaiRepository.BeginTransaction();
                this.lista_Preco_PaiRepository.Copy(objLista_Preco_Pai:
                    objListaPreco);


                foreach (HLP.Entries.Model.Models.Comercial.Lista_precoModel item in objListaPreco.lLista_preco)
                {
                    item.idListaPreco = null;
                    item.idListaPrecoPai = objListaPreco.idListaPrecoPai;
                    this.lista_PrecoRepository.Copy(
                        objLista_preco: item);
                }
                this.lista_Preco_PaiRepository.CommitTransaction();
                return objListaPreco;
            }
            catch (Exception ex)
            {
                this.lista_Preco_PaiRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public List<int> GetAllIdsListaPreco()
        {
            return this.lista_Preco_PaiRepository.GetAllIdListaPreco();
        }

        public int GetIdListaPreferencial()
        {
            return this.lista_Preco_PaiRepository.GetIdListaPreferencial();
        }
    }
}
