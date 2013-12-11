using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Parametros;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceEmpresaParametros" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceEmpresaParametros.svc or serviceEmpresaParametros.svc.cs at the Solution Explorer and start debugging.
    public class serviceEmpresaParametros : IserviceEmpresaParametros
    {
        [Inject]
        public IEmpresaRepository empresaRepository { get; set; }

        [Inject]
        public IParametro_ComercialRepository parametro_ComercialRepository { get; set; }

        [Inject]
        public IParametro_ComprasRepository parametro_ComprasRepository { get; set; }

        [Inject]
        public IParametro_CustosRepository parametro_CustosRepository { get; set; }

        [Inject]
        public IParametro_EstoqueRepository parametro_EstoqueRepository { get; set; }

        [Inject]
        public IParametro_FinanceiroRepository parametro_FinanceiroRepository { get; set; }

        [Inject]
        public IParametro_FiscalRepository parametro_FiscalRepository { get; set; }

        [Inject]
        public IParametro_Ordem_ProducaoRepository parametro_Ordem_ProducaoRepository { get; set; }

        public serviceEmpresaParametros()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.EmpresaModel getEmpresaParametros(int idEmpresa)
        {
            try
            {
                HLP.Entries.Model.Models.Gerais.EmpresaModel objEmpresa =
                    new HLP.Entries.Model.Models.Gerais.EmpresaModel();

                objEmpresa = this.empresaRepository.GetEmpresa(idEmpresa: idEmpresa);

                HLP.Entries.Model.Models.Gerais.EmpresaParametrosModel objEmpresaParametros = new
                 HLP.Entries.Model.Models.Gerais.EmpresaParametrosModel();

                objEmpresaParametros.ObjParametro_ComercialModel = parametro_ComercialRepository.GetParametro_Comercial(
                    idEmpresa: idEmpresa) ?? new HLP.Entries.Model.Models.Parametros.Parametro_ComercialModel();
                objEmpresaParametros.ObjParametro_ComprasModel = parametro_ComprasRepository.GetParametro_Compras(
                    idEmpresa: idEmpresa) ?? new HLP.Entries.Model.Models.Parametros.Parametro_ComprasModel();
                objEmpresaParametros.ObjParametro_CustosModel = parametro_CustosRepository.GetParametro_Custos(
                    idEmpresa: idEmpresa) ?? new HLP.Entries.Model.Models.Parametros.Parametro_CustosModel();
                objEmpresaParametros.ObjParametro_EstoqueModel = parametro_EstoqueRepository.GetParametro_Estoque(
                    idEmpresa: idEmpresa) ?? new HLP.Entries.Model.Models.Parametros.Parametro_EstoqueModel();
                objEmpresaParametros.ObjParametro_FinanceiroModel = parametro_FinanceiroRepository.GetParametro_Financeiro(
                    idEmpresa: idEmpresa) ?? new HLP.Entries.Model.Models.Parametros.Parametro_FinanceiroModel();
                objEmpresaParametros.ObjParametro_FiscalModel = parametro_FiscalRepository.GetParametro_Fiscal(
                    idEmpresa: idEmpresa) ?? new HLP.Entries.Model.Models.Parametros.Parametro_FiscalModel();
                objEmpresaParametros.ObjParametro_Ordem_ProducaoModel = parametro_Ordem_ProducaoRepository.GetParametro_Ordem_Producao(
                    idEmpresa: idEmpresa) ?? new HLP.Entries.Model.Models.Parametros.Parametro_Ordem_ProducaoModel();

                objEmpresaParametros.ObjParametro_ComercialModel.idEmpresa = objEmpresaParametros.ObjParametro_ComprasModel.idEmpresa =
                    objEmpresaParametros.ObjParametro_CustosModel.idEmpresa = objEmpresaParametros.ObjParametro_EstoqueModel.idEmpresa =
                    objEmpresaParametros.ObjParametro_FinanceiroModel.idEmpresa = objEmpresaParametros.ObjParametro_FiscalModel.idEmpresa =
                    objEmpresaParametros.ObjParametro_Ordem_ProducaoModel.idEmpresa = idEmpresa;

                objEmpresa.empresaParametros = objEmpresaParametros;

                return objEmpresa;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public void saveEmpresaParamestros(HLP.Entries.Model.Models.Gerais.EmpresaParametrosModel objEmpresaParametros)
        {
            try
            {
                this.parametro_ComercialRepository.Save(objParametro_Comercial: objEmpresaParametros.ObjParametro_ComercialModel);
                this.parametro_ComprasRepository.Save(objParametro_Compras: objEmpresaParametros.ObjParametro_ComprasModel);
                this.parametro_CustosRepository.Save(objParametro_Custos: objEmpresaParametros.ObjParametro_CustosModel);
                this.parametro_EstoqueRepository.Save(objParametro_Estoque: objEmpresaParametros.ObjParametro_EstoqueModel);
                this.parametro_FinanceiroRepository.Save(objParametro_Financeiro: objEmpresaParametros.ObjParametro_FinanceiroModel);
                this.parametro_FiscalRepository.Save(objParametro_Fiscal: objEmpresaParametros.ObjParametro_FiscalModel);
                this.parametro_Ordem_ProducaoRepository.Save(objParametro_Ordem_Producao: objEmpresaParametros.ObjParametro_Ordem_ProducaoModel);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
