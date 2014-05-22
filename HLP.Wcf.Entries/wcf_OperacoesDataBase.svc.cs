using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Comum.Model.Models;
using HLP.Comum.Model.Repository.Interfaces;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Components;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_OperacoesDataBase" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_OperacoesDataBase.svc or wcf_OperacoesDataBase.svc.cs at the Solution Explorer and start debugging.
    public class wcf_OperacoesDataBase : Iwcf_OperacoesDataBase
    {
        [Inject]
        public IOperacoesDataBaseRepository operacoesDataBaseRepos { get; set; }

        [Inject]
        public IHlpPesquisaPadraoRepository hlpPesquisaPadraoRepository { get; set; }

        public wcf_OperacoesDataBase()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public List<RecordsSqlModel> GetRecordsFKUsed(string xTabela, string xCampo, string valor, int idEmpresa)
        {
            List<PesquisaPadraoModelContract> lCampos = this.hlpPesquisaPadraoRepository.getCamposSqlNotNull(
                xTabela: xTabela);

            string xDisplay = "";
            string xId = "";

            foreach (var item in lCampos)
            {
                if (item.DATA_TYPE == "PK")
                    xId += item.COLUMN_NAME;

                if (item.COLUMN_NAME.StartsWith(value: "x"))
                {
                    if (xDisplay == "")
                    {
                        xDisplay += item.COLUMN_NAME;
                    }
                    else
                    {
                        xDisplay += "+' - ', " + item.COLUMN_NAME;
                        break;
                    }

                }
            }


            try
            {
                string xWhere = string.Format(format: "where {0} = {1}", arg0: xCampo, arg1: valor);

                if (this.operacoesDataBaseRepos.FieldExist(xTable: xTabela, xCampo: "idEmpresa"))
                {
                    xWhere += string.Format(format: " and idEmpresa = {0}", arg0: idEmpresa);
                }


                string xSelect = string.Format(format:
                    "select {0} from {1} {2}", arg0: string.Format(format: "{0} as id, CONCAT({1}) as display", arg0: xId, arg1: xDisplay), arg1: xTabela, arg2: xWhere);

                return this.operacoesDataBaseRepos.GetRegistros(xQuery: xSelect);
            }
            catch (Exception)
            {
                return new List<RecordsSqlModel>();
            }

        }

        public int GetRecord(string nameView, string xCampo, string xValue, int idEmpresa = 0)
        {
            return operacoesDataBaseRepos.GetRecord(nameView: nameView, xCampo: xCampo,
                xValue: xValue, idEmpresa: idEmpresa);
        }
    }
}
