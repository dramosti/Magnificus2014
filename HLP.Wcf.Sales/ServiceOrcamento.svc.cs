using HLP.Comum.Resources.RecursosBases;
using HLP.Comum.Resources.Util;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceOrcamento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceOrcamento.svc or ServiceOrcamento.svc.cs at the Solution Explorer and start debugging.
    public class ServiceOrcamento : IServiceOrcamento
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

        public ServiceOrcamento()
        {

            try
            {
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
                                this.IOrcamento_Item_ImpostosRepository.Save(objOrcamento_Item_Impostos: item.orcamento_Item_Impostos.FirstOrDefault());
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.IOrcamento_Item_ImpostosRepository.Delete(idOrcamentoTotalizadorImpostos: (int)item.orcamento_Item_Impostos.FirstOrDefault().idOrcamentoTotalizadorImpostos);
                                this.orcamento_itemRepository.Delete(idOrcamentoItem: (int)item.idOrcamentoItem);
                            }
                            break;
                    }
                }

                this.orcamento_retTranspRepository.Save(objOrcamento_retTransp: objModel.orcamento_retTransp);
                this.orcamento_Total_ImpostosRepository.Save(objOrcamento_Total_Impostos: objModel.orcamento_Total_Impostos);

                this.orcamento_ideRepository.CommitTransaction();
                return objModel;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                this.orcamento_ideRepository.RollackTransaction();
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Sales.Model.Models.Comercial.Orcamento_ideModel GetObjeto(int idObjeto, int idEmpresa)
        {
            try
            {
                HLP.Comum.Infrastructure.Static.CompanyData.idEmpresa = idEmpresa;

                HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objOrcamento =
                    this.orcamento_ideRepository.GetOrcamento_ide(idOrcamento: idObjeto);

                objOrcamento.lOrcamento_Itens = new Comum.Model.Models.ObservableCollectionBaseCadastros<HLP.Sales.Model.Models.Comercial.Orcamento_ItemModel>(
                    list: this.orcamento_itemRepository.GetAllOrcamento_Item(idOrcamento: (int)objOrcamento.idOrcamento));

                foreach (HLP.Sales.Model.Models.Comercial.Orcamento_ItemModel item in objOrcamento.lOrcamento_Itens)
                {
                    item.orcamento_Item_Impostos.Add(item:
                        this.IOrcamento_Item_ImpostosRepository.GetOrcamento_Item_ImpostosByItem(
                        idOrcamento_Item: (int)item.idOrcamentoItem));
                }

                objOrcamento.orcamento_retTransp = this.orcamento_retTranspRepository.GetOrcamento_retTranspByIdOrcamento(idOrcamento: (int)objOrcamento.idOrcamento);

                objOrcamento.orcamento_Total_Impostos = this.orcamento_Total_ImpostosRepository.GetOrcamento_Total_ImpostosByIdOrcamento(idOrcamento: (int)objOrcamento.idOrcamento);

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
                foreach (HLP.Sales.Model.Models.Comercial.Orcamento_ItemModel item in objModel.lOrcamento_Itens)
                {
                    this.IOrcamento_Item_ImpostosRepository.Delete(idOrcamentoTotalizadorImpostos: (int)item.orcamento_Item_Impostos.FirstOrDefault().idOrcamentoTotalizadorImpostos);
                    this.orcamento_itemRepository.Delete(idOrcamentoItem: (int)item.idOrcamentoItem);
                }

                this.orcamento_Total_ImpostosRepository.Delete(idOrcamentoTotalImpostos: (int)objModel.orcamento_Total_Impostos.idOrcamentoTotalImpostos);
                this.orcamento_retTranspRepository.Delete(idRetTransp: (int)objModel.orcamento_retTransp.idRetTransp);
                this.orcamento_ideRepository.Delete(idOrcamento: (int)objModel.idOrcamento);

                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int Copy(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel)
        {

            try
            {
                this.orcamento_ideRepository.BeginTransaction();

                objModel.idOrcamento = this.orcamento_ideRepository.Copy(idOrcamento: (int)objModel.idOrcamento);

                foreach (HLP.Sales.Model.Models.Comercial.Orcamento_ItemModel item in objModel.lOrcamento_Itens)
                {
                    item.idOrcamentoItem = this.orcamento_itemRepository.Copy(idOrcamentoItem: (int)item.idOrcamentoItem, idOrcamento: (int)objModel.idOrcamento);
                    this.IOrcamento_Item_ImpostosRepository.Copy(idOrcamentoTotalizadorImpostos: (int)item.orcamento_Item_Impostos.FirstOrDefault().idOrcamentoTotalizadorImpostos,
                        idOrcamentoItem: (int)item.idOrcamentoItem);
                }

                this.orcamento_retTranspRepository.Copy(idRetTransp: (int)objModel.orcamento_retTransp.idRetTransp);
                this.orcamento_Total_ImpostosRepository.Copy(idOrcamentoTotalImpostos: (int)objModel.orcamento_Total_Impostos.idOrcamentoTotalImpostos);

                this.orcamento_ideRepository.CommitTransaction();

                return (int)objModel.idOrcamento;
            }
            catch (Exception ex)
            {
                this.orcamento_ideRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
