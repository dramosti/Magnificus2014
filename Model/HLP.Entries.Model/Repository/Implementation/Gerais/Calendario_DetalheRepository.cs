using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;

namespace HLP.Entries.Model.Repository.Implementation.Gerais
{
    public class Calendario_DetalheRepository : ICalendario_DetalheRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Calendario_DetalheModel> regAcessor;

        public void Save(Calendario_DetalheModel objCalendario_Detalhe)
        {
            if (objCalendario_Detalhe.idCalendarioDetalhe == null)
            {
                objCalendario_Detalhe.idCalendarioDetalhe = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Calendario_Detalhe]",
                ParameterBase<Calendario_DetalheModel>.SetParameterValue(objCalendario_Detalhe));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
               "[dbo].[Proc_update_Calendario_Detalhe]",
                ParameterBase<Calendario_DetalheModel>.SetParameterValue(objCalendario_Detalhe));
            }
        }

        public void Delete(Calendario_DetalheModel objCalendario_Detalhe)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                 UndTrabalho.dbTransaction,
                "[dbo].[Proc_delete_Calendario_Detalhe]",
                  UserData.idUser,
                  objCalendario_Detalhe.idCalendarioDetalhe);
        }

        public void DeleteDetalhesByCalendario(int idCalendario)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                UndTrabalho.dbTransaction,
                System.Data.CommandType.Text,
              "DELETE Calendario_Detalhe WHERE idCalendario = " + idCalendario);
        }

        public void Copy(Calendario_DetalheModel objCalendario_Detalhe)
        {
            objCalendario_Detalhe.idCalendarioDetalhe = null;
            objCalendario_Detalhe.idCalendarioDetalhe = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Calendario_Detalhe]",
        ParameterBase<Calendario_DetalheModel>.SetParameterValue(objCalendario_Detalhe));
        }

        public Calendario_DetalheModel GetCalendario_Detalhe(int idCalendarioDetalhe)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Calendario_Detalhe]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idCalendarioDetalhe"),
                   MapBuilder<Calendario_DetalheModel>.MapAllProperties().DoNotMap(c=>c.status).Build());
            }
            return regAcessor.Execute(idCalendarioDetalhe).FirstOrDefault();
        }

        public List<Calendario_DetalheModel> GetAllCalendario_Detalhe(int idCalendario)
        {
            DataAccessor<Calendario_DetalheModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Calendario_Detalhe WHERE idCalendario = @idCalendario", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idCalendario"),
            MapBuilder<Calendario_DetalheModel>.MapAllProperties().DoNotMap(c => c.status).Build());

            return reg.Execute(idCalendario).ToList();
        }
    }
}
