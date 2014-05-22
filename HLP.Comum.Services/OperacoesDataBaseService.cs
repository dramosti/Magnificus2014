using HLP.Base.EnumsBases;
using HLP.Base.Static;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Services
{
    public class OperacoesDataBaseService
    {
        HLP.Wcf.Entries.wcf_OperacoesDataBase serviceNetwork;
        wcf_OperacoesDataBase.Iwcf_OperacoesDataBaseClient serviceWeb;

        public OperacoesDataBaseService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new Wcf.Entries.wcf_OperacoesDataBase();
                    }
                    break;
                case StConnection.OnlineWeb:
                    {
                        serviceWeb = new wcf_OperacoesDataBase.Iwcf_OperacoesDataBaseClient();
                    }
                    break;
                case StConnection.Offline:
                default:
                    {
                    } break;
            }
        }

        public List<RecordsSqlModel> GetRecordsFKUsed(string xMessage, string xValor)
        {
            string xTabela = xMessage.Split(
                    separator: new string[] { "table" }
                    , options: StringSplitOptions.None)[1].ToString()
                    .Split(separator: '"')[1].ToString().Split('"')[0].ToString();
            string xCampo = xMessage.Split(separator: new string[] { "column" }, options: StringSplitOptions.None)[1].ToString().Split(separator: '\'')[1];

            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.GetRecordsFKUsed(xTabela: xTabela.Replace(oldValue: "dbo.", newValue: ""), xCampo: xCampo, valor: xValor, idEmpresa: CompanyData.idEmpresa);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.GetRecordsFKUsed(xTabela: xTabela, xCampo: xCampo, valor: xValor, idEmpresa: CompanyData.idEmpresa);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }

        public int GetIdRecordToQuickSearch(string xNameTable, string xCampo, string xValue, stFilterQuickSearch stFilterQS, int idEmpresa = 0)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.GetRecord(
                            xNameTable: xNameTable, xCampo: xCampo, xValue: xValue, idEmpresa: idEmpresa, stFilterQS: stFilterQS);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.GetRecord(
                            xNameTable: xNameTable, xCampo: xCampo, xValue: xValue, idEmpresa: idEmpresa, stFilterQS: stFilterQS);
                    }
                case StConnection.Offline:
                default:
                    {
                        return 0;
                    }
            }
        }
    }
}
