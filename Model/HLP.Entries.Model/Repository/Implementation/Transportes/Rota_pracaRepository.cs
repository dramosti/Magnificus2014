﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Transportes;
using HLP.Entries.Model.Repository.Interfaces.Transportes;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using HLP.Base.ClassesBases;
using HLP.Base.Static;

namespace HLP.Entries.Model.Repository.Implementation.Transportes
{
    public class Rota_pracaRepository : IRota_pracaRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Rota_pracaModel> regAcessor;

        public void Save(Rota_pracaModel objRota_Praca)
        {

            if (objRota_Praca.idRotaPraca == null)
            {
                objRota_Praca.idRotaPraca = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Rota_Praca]",
                ParameterBase<Rota_pracaModel>.SetParameterValue(objRota_Praca));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
                    "[dbo].[Proc_update_Rota_Praca]",
                    ParameterBase<Rota_pracaModel>.SetParameterValue(objRota_Praca));

            }
        }
              
        public void Delete(Rota_pracaModel objRota_Praca)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_delete_Rota_Praca]",
                UndTrabalho.dbTransaction,
                  UserData.idUser,
                  objRota_Praca.idRotaPraca);
        }

        public void DeletePracasByRota(int idRota)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                UndTrabalho.dbTransaction,
                System.Data.CommandType.Text,
              "DELETE Rota_Praca WHERE idRota = " + idRota);
        }

        public void Copy(Rota_pracaModel objRota_Praca)
        {
            objRota_Praca.idRotaPraca = null;
            objRota_Praca.idRotaPraca = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Rota_Praca]",
        ParameterBase<Rota_pracaModel>.SetParameterValue(objRota_Praca));
        }

        public Rota_pracaModel GetRota_Praca(int idRotaPraca)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Rota_Praca]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idRotaPraca"),
                   MapBuilder<Rota_pracaModel>.MapAllProperties().DoNotMap(c => c.status).Build());
            }
            return regAcessor.Execute(idRotaPraca).FirstOrDefault();
        }

        public List<Rota_pracaModel> GetAllRota_Praca(int idRota)
        {
            DataAccessor<Rota_pracaModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Rota_Praca WHERE idRota = @idRota", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idRota"),
            MapBuilder<Rota_pracaModel>.MapAllProperties().DoNotMap(c=>c.status).Build());

            return reg.Execute(idRota).ToList();
        }
    }
}
