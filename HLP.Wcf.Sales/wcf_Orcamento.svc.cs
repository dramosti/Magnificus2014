using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Sales.Model.Repository.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Sales
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Orcamento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Orcamento.svc or wcf_Orcamento.svc.cs at the Solution Explorer and start debugging.
    public class wcf_Orcamento : Iwcf_Orcamento
    {
        [Inject]
        public IOrcamento_ideRepository orcamento_ideRepository { get; set; }

        [Inject]
        public IOrcamento_Item_ImpostosRepository IOrcamento_Item_ImpostosRepository { get; set; }

        [Inject]
        public IOrcamento_ItemRepository orcamento_itemRepository { get; set; }

        [Inject]
        public IOrcamento_retTranspRepository orcamento_retTranspRepository { get; set; }

        [Inject]
        public IOrcamento_Total_ImpostosRepository orcamento_Total_ImpostosRepository { get; set; }

        [Inject]
        public IOrcamento_Item_RepresentantesRepository orcamento_Item_RepresentantesRepository { get; set; }

        public wcf_Orcamento()
        {
            try
            {
                Sistema.stSender = TipoSender.WCF;
                Log.xPath = @"C:\inetpub\wwwroot\log";
                IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
                kernel.Settings.ActivationCacheDisabled = false;
                kernel.Inject(this);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public HLP.Sales.Model.Models.Comercial.Orcamento_ideModel Save(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel)
        {
            try
            {
                this.orcamento_ideRepository.BeginTransaction();
                this.orcamento_ideRepository.Save(objOrcamento_ide: objModel);

                foreach (HLP.Sales.Model.Models.Comercial.Orcamento_ItemModel item in objModel.lOrcamento_Itens)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idOrcamento = (int)objModel.idOrcamento;
                                this.orcamento_itemRepository.Save(objOrcamento_Item: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.orcamento_itemRepository.Delete(idOrcamentoItem: (int)item.idOrcamentoItem);
                            }
                            break;
                    }

                    switch (item.objImposto.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.objImposto.idOrcamentoItem = (int)item.idOrcamentoItem;
                                this.IOrcamento_Item_ImpostosRepository.Save(objOrcamento_Item_Impostos: item.objImposto);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.IOrcamento_Item_ImpostosRepository.DeleteByIdOrcamento(idOrcamentoItem: (int)item.idOrcamentoItem);
                            }
                            break;
                    }

                    foreach (var itemRepresentantes in item.lOrcamentoItemsRepresentantes)
                    {
                        switch (itemRepresentantes.status)
                        {
                            case statusModel.criado:
                            case statusModel.alterado:
                                {
                                    itemRepresentantes.idOrcamentoItem = item.idOrcamentoItem;
                                    orcamento_Item_RepresentantesRepository.Save(objOrcamento_Item_Representantes:
                                        itemRepresentantes);
                                }
                                break;
                            case statusModel.excluido:
                                {
                                    orcamento_Item_RepresentantesRepository.Delete(idOrcamentoItemRepresentate: itemRepresentantes
                                        .idOrcamentoItemRepresentate ?? 0);
                                }
                                break;
                        }
                    }
                }
                if (objModel.orcamento_retTransp != null)
                {
                    objModel.orcamento_retTransp.idOrcamento = (int)objModel.idOrcamento;
                    this.orcamento_retTranspRepository.Save(objOrcamento_retTransp: objModel.orcamento_retTransp);
                }
                if (objModel.orcamento_Total_Impostos != null)
                {
                    objModel.orcamento_Total_Impostos.idOrcamento = (int)objModel.idOrcamento;
                    this.orcamento_Total_ImpostosRepository.Save(objOrcamento_Total_Impostos: objModel.orcamento_Total_Impostos);
                }
                this.orcamento_ideRepository.CommitTransaction();
                return objModel;
            }
            catch (Exception ex)
            {
                this.orcamento_ideRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Sales.Model.Models.Comercial.Orcamento_ideModel GetObjeto(int idObjeto, int idEmpresa)
        {
            try
            {
                CompanyData.idEmpresa = idEmpresa;

                HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objOrcamento =
                    this.orcamento_ideRepository.GetOrcamento_ide(idOrcamento: idObjeto);
                if (objOrcamento != null)
                {
                    objOrcamento.lOrcamento_Itens = new ObservableCollectionBaseCadastros<HLP.Sales.Model.Models.Comercial.Orcamento_ItemModel>(
                        list: this.orcamento_itemRepository.GetAllOrcamento_Item(idOrcamento: (int)objOrcamento.idOrcamento));

                    foreach (var item in objOrcamento.lOrcamento_Itens)
                    {
                        item.objImposto =
                            this.IOrcamento_Item_ImpostosRepository.GetOrcamento_Item_ImpostosByItem(idOrcamento_Item: item.idOrcamentoItem ?? 0);
                        if (item.objImposto != null)
                        {
                            item.objImposto.stOrcamentoImpostos = item.stOrcamentoItem;
                        }

                        item.lOrcamentoItemsRepresentantes = new ObservableCollectionBaseCadastros<HLP.Sales.Model.Models.Comercial.Orcamento_Item_RepresentantesModel>(list:
                            this.orcamento_Item_RepresentantesRepository.GetOrcamento_Item_Representantes_ByIdOrcamentoItem(idOrcamentoItem: item.idOrcamentoItem ?? 0));
                    }

                    objOrcamento.orcamento_retTransp = this.orcamento_retTranspRepository.GetOrcamento_retTranspByIdOrcamento(idOrcamento: (int)objOrcamento.idOrcamento);

                    objOrcamento.orcamento_Total_Impostos = this.orcamento_Total_ImpostosRepository.GetOrcamento_Total_ImpostosByIdOrcamento(idOrcamento: (int)objOrcamento.idOrcamento);
                }
                return objOrcamento;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw;
            }
        }

        public bool Delete(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel)
        {
            try
            {
                this.orcamento_ideRepository.BeginTransaction();
                foreach (HLP.Sales.Model.Models.Comercial.Orcamento_ItemModel item in objModel.lOrcamento_Itens)
                {
                    if (item.objImposto != null)
                        this.IOrcamento_Item_ImpostosRepository.Delete(idOrcamentoTotalizadorImpostos: item.objImposto.idOrcamentoTotalizadorImpostos ?? 0);

                    this.orcamento_itemRepository.Delete(idOrcamentoItem: (int)item.idOrcamentoItem);
                }

                this.orcamento_Total_ImpostosRepository.Delete(idOrcamentoTotalImpostos: (int)objModel.orcamento_Total_Impostos.idOrcamentoTotalImpostos);
                this.orcamento_retTranspRepository.Delete(idRetTransp: (int)objModel.orcamento_retTransp.idRetTransp);
                this.orcamento_ideRepository.Delete(idOrcamento: (int)objModel.idOrcamento);
                this.orcamento_ideRepository.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                this.orcamento_ideRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Sales.Model.Models.Comercial.Orcamento_ideModel Copy(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel)
        {

            try
            {
                this.orcamento_ideRepository.BeginTransaction();

                objModel.idOrcamento = this.orcamento_ideRepository.Copy(idOrcamento: (int)objModel.idOrcamento);

                foreach (HLP.Sales.Model.Models.Comercial.Orcamento_ItemModel item in objModel.lOrcamento_Itens)
                {
                    item.idOrcamentoItem = this.orcamento_itemRepository.Copy(idOrcamentoItem: (int)item.idOrcamentoItem, idOrcamento: (int)objModel.idOrcamento);
                    item.objImposto.idOrcamentoTotalizadorImpostos =
                        this.IOrcamento_Item_ImpostosRepository.Copy(idOrcamentoTotalizadorImpostos: (int)item.objImposto.idOrcamentoTotalizadorImpostos,
                        idOrcamentoItem: (int)item.idOrcamentoItem);
                }

                this.orcamento_retTranspRepository.Copy(idRetTransp: (int)objModel.orcamento_retTransp.idRetTransp);
                this.orcamento_Total_ImpostosRepository.Copy(idOrcamentoTotalImpostos: (int)objModel.orcamento_Total_Impostos.idOrcamentoTotalImpostos);

                this.orcamento_ideRepository.CommitTransaction();

                return objModel;
            }
            catch (Exception ex)
            {
                this.orcamento_ideRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Sales.Model.Models.Comercial.Orcamento_ideModel GerarVersao(
            HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel)
        {

            try
            {
                this.orcamento_ideRepository.BeginTransaction();
                objModel.idOrcamentoOrigem = objModel.idOrcamento;
                objModel.idOrcamento = null;

                this.orcamento_ideRepository.Save(objOrcamento_ide: objModel);

                foreach (var item in objModel.lOrcamento_Itens)
                {
                    item.idOrcamentoItem = null;
                    item.idOrcamento = objModel.idOrcamento ?? 0;
                    this.orcamento_itemRepository.Save(objOrcamento_Item: item);
                    item.objImposto.idOrcamentoTotalizadorImpostos = null;
                    item.objImposto.idOrcamentoItem = item.idOrcamentoItem ?? 0;
                    this.IOrcamento_Item_ImpostosRepository.Save(objOrcamento_Item_Impostos: item.objImposto);


                    foreach (var itemRepresentante in item.lOrcamentoItemsRepresentantes)
                    {
                        itemRepresentante.idOrcamentoItemRepresentate = null;
                        itemRepresentante.idOrcamentoItem = item.idOrcamentoItem;
                        this.orcamento_Item_RepresentantesRepository.Save(objOrcamento_Item_Representantes: itemRepresentante);
                    }
                }

                objModel.orcamento_retTransp.idRetTransp = null;
                objModel.orcamento_retTransp.idOrcamento = objModel.idOrcamento ?? 0;
                this.orcamento_retTranspRepository.Save(objOrcamento_retTransp: objModel.orcamento_retTransp);

                objModel.orcamento_Total_Impostos.idOrcamentoTotalImpostos = null;
                objModel.orcamento_Total_Impostos.idOrcamento = objModel.idOrcamento ?? 0;
                this.orcamento_Total_ImpostosRepository.Save(objModel.orcamento_Total_Impostos);
                this.orcamento_ideRepository.CommitTransaction();
                return objModel;
            }
            catch (Exception ex)
            {
                this.orcamento_ideRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public List<int> GetListaVersoes(int idOrcamento)
        {
            List<int> lItens = new List<int>();

            lItens.Add(item: idOrcamento);

            int i = idOrcamento;
            do
            {
                i = this.orcamento_ideRepository.GetIdOrcamentoPai(idOrcamento: i);
                if (i != 0)
                    lItens.Insert(index: 0, item: i);
            } while (i != 0);

            i = idOrcamento;
            do
            {
                i = this.orcamento_ideRepository.GetIdOrcamentoFilho(idOrcamentoOrigem: i);
                if (i != 0)
                    lItens.Add(item: i);
            } while (i != 0);

            return lItens;
        }

        public bool PossuiFilho(int idOrcamento)
        {

            try
            {
                return this.orcamento_ideRepository.GetIdOrcamentoFilho(idOrcamentoOrigem: idOrcamento) > 0;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
