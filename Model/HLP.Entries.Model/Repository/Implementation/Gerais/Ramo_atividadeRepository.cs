using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Gerais
{
    public class Ramo_atividadeRepository : IRamo_atividadeRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Ramo_atividadeModel> regMoedaAccessor;

        public Ramo_atividadeModel GetRamo(int idRamoAtividade)
        {
            if (regMoedaAccessor == null)
            {
                regMoedaAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_ramo_atividade",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idRamoAtividade"),
                                  MapBuilder<Ramo_atividadeModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }


            return regMoedaAccessor.Execute(idRamoAtividade).FirstOrDefault();
        }

        public void Save(Ramo_atividadeModel ramo)
        {
            if (ramo.idRamoAtividade == null)
            {
                int idRamoAtividade = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
             "[dbo].[Proc_save_ramo_atividade]",
            ParameterBase<Ramo_atividadeModel>.SetParameterValue(ramo));

                ramo.idRamoAtividade = idRamoAtividade;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
             "[dbo].[Proc_update_Ramo_atividade]",
            ParameterBase<Ramo_atividadeModel>.SetParameterValue(ramo));
            }

        }

        public void Delete(int idRamoAtividade)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                   "dbo.Proc_delete_ramo_atividade",
                    UserData.idUser,
                    idRamoAtividade);
        }


        public int Copy(int idRamoAtividade)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                        "dbo.Proc_copy_ramo_atividade",
                         idRamoAtividade);
        }
    }
}
