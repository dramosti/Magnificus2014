using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Parametros;
using HLP.Entries.Model.Repository.Interfaces.Parametros;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Parametros
{
    public class Parametro_Cartao_PontoRepository : IParametro_Cartao_PontoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Parametro_Cartao_PontoModel> regParametro_Cartao_PontoAccessor;
        private DataAccessor<Parametro_Cartao_PontoModel> regAllParametro_Cartao_PontoAccessor;

        public void Save(Parametro_Cartao_PontoModel objParametro_Cartao_Ponto)
        {
            objParametro_Cartao_Ponto.idParametroCartaoPonto = (int)UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_Parametro_Cartao_Ponto",
            ParameterBase<Parametro_Cartao_PontoModel>.SetParameterValue(objParametro_Cartao_Ponto));
        }

        public void Delete(int idParametroCartaoPonto)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_Parametro_Cartao_Ponto",
                 UserData.idUser,
                 idParametroCartaoPonto);
        }

        public int Copy(int idParametroCartaoPonto)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                      "dbo.Proc_copy_Parametro_Cartao_Ponto",
                       idParametroCartaoPonto);
        }

        public Parametro_Cartao_PontoModel GetParametro_Cartao_Ponto(int idEmpresa)
        {
            if (regParametro_Cartao_PontoAccessor == null)
            {
                regParametro_Cartao_PontoAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Parametro_Cartao_Ponto" +
                " where idEmpresa = " + idEmpresa,
                                MapBuilder<Parametro_Cartao_PontoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }

            return regParametro_Cartao_PontoAccessor.Execute().FirstOrDefault();
        }

        public List<Parametro_Cartao_PontoModel> GetAllParametro_Cartao_Ponto()
        {
            if (regAllParametro_Cartao_PontoAccessor == null)
            {
                regAllParametro_Cartao_PontoAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Parametro_Cartao_Ponto",
                                MapBuilder<Parametro_Cartao_PontoModel>.MapAllProperties().Build());
            }
            return regAllParametro_Cartao_PontoAccessor.Execute().ToList();
        }

    }
}
