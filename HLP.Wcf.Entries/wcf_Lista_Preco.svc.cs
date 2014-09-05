using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Base.Static;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Lista_Preco" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Lista_Preco.svc or wcf_Lista_Preco.svc.cs at the Solution Explorer and start debugging.
    public class wcf_Lista_Preco : Iwcf_Lista_Preco
    {
        [Inject]
        public ILista_Preco_PaiRepository lista_Preco_PaiRepository { get; set; }

        [Inject]
        public ILista_precoRepository lista_PrecoRepository { get; set; }

        public wcf_Lista_Preco()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public List<HLP.Components.Model.Models.HlpButtonHierarquiaStruct> GetLista_PrecoHierarquia(int idListaPreco)
        {
            HLP.Entries.Model.Models.Comercial.Lista_Preco_PaiModel objLista_Preco_Pai
                = this.lista_Preco_PaiRepository.GetLista_Preco_Pai(idListaPrecoPai: idListaPreco);
            List<HLP.Components.Model.Models.HlpButtonHierarquiaStruct> lListHierarquia = new List<HLP.Components.Model.Models.HlpButtonHierarquiaStruct>();

            if (objLista_Preco_Pai != null)
            {
                lListHierarquia.Add(item:
                    new HLP.Components.Model.Models.HlpButtonHierarquiaStruct
                    {
                        xId = objLista_Preco_Pai.idListaPrecoPai.ToString(),
                        xOpcional = objLista_Preco_Pai.pPercentual.ToString()
                    });
            }
            while (true)
            {
                if (objLista_Preco_Pai == null)
                    break;
                if (objLista_Preco_Pai.idListaPrecoOrigem == null || objLista_Preco_Pai.idListaPrecoOrigem == 0)
                    break;

                objLista_Preco_Pai
                = this.lista_Preco_PaiRepository.GetLista_Preco_Pai(idListaPrecoPai: (int)objLista_Preco_Pai.idListaPrecoOrigem);

                lListHierarquia.Insert(item:
                    new HLP.Components.Model.Models.HlpButtonHierarquiaStruct
                    {
                        xId = objLista_Preco_Pai.idListaPrecoPai.ToString(),
                        xOpcional = objLista_Preco_Pai.pPercentual.ToString()
                    }, index: 0);
            }
            return lListHierarquia;
        }

        public HLP.Components.Model.Models.modelToTreeView GetSelectedLista_PrecoFullHierarquia(int idListaPreco)
        {

            HLP.Components.Model.Models.modelToTreeView node = new HLP.Components.Model.Models.modelToTreeView();

            HLP.Components.Model.Models.modelToTreeView nodeAux = null;

            HLP.Entries.Model.Models.Comercial.Lista_Preco_PaiModel objLista =
                this.lista_Preco_PaiRepository.GetLista_Preco_Pai(idListaPrecoPai: idListaPreco);

            node.id = objLista.idListaPrecoPai ?? 0;
            node.xDisplay = objLista.xLista;

            while (true)
            {
                if (objLista.idListaPrecoOrigem == null)
                    break;

                objLista = this.lista_Preco_PaiRepository.GetLista_Preco_Pai(idListaPrecoPai: objLista.idListaPrecoOrigem ?? 0);

                nodeAux = new HLP.Components.Model.Models.modelToTreeView
                {
                    id = objLista.idListaPrecoPai ?? 0,
                    xDisplay = objLista.xLista
                };

                nodeAux.lFilhos = new List<HLP.Components.Model.Models.modelToTreeView>();
                nodeAux.lFilhos.Add(
                    item: node);

                node = nodeAux;
            }

            if (nodeAux == null)
                nodeAux = node;

            node = nodeAux;

            while (nodeAux.lFilhos != null)
            {
                nodeAux = nodeAux.lFilhos.FirstOrDefault();

                if (nodeAux == null)
                    break;
            }


            if (nodeAux != null)
                this.MontaHierarquiaFilhos(item: nodeAux);

            return node;
        }

        void MontaHierarquiaFilhos(HLP.Components.Model.Models.modelToTreeView item)
        {
            List<HLP.Entries.Model.Models.Comercial.Lista_Preco_PaiModel> lListas = this.lista_Preco_PaiRepository.GetAllListaPrecoOrigem(
                idListaPrecoOrigem: item.id);

            if (lListas != null)
                foreach (var it in lListas)
                {
                    HLP.Components.Model.Models.modelToTreeView m = new HLP.Components.Model.Models.modelToTreeView
                        {
                            id = it.idListaPrecoPai ?? 0,
                            xDisplay = it.xLista
                        };

                    if (item.lFilhos == null)
                        item.lFilhos = new List<HLP.Components.Model.Models.modelToTreeView>();
                    item.lFilhos.Add(item: m);
                    this.MontaHierarquiaFilhos(item: m);
                }

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

                var lListaPrecoItens = this.lista_PrecoRepository.GetAllLista_preco(
                        idListaPrecoPai: idListaPrecoPai);

                if (lListaPrecoItens != null)
                    objListaPreco.lLista_preco = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Comercial.Lista_precoModel>
                        (list: lListaPrecoItens);
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
