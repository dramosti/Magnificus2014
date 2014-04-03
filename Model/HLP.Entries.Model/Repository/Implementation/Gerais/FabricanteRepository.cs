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
    public class FabricanteRepository : IFabricanteRepository
    {

        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<FabricanteModel> regFabricanteAccessor;

        public FabricanteModel GetFabricante(int idFabricante)
        {
            if (regFabricanteAccessor == null)
            {
                regFabricanteAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_fabricante",
                                    new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idFabricante"),
                                    MapBuilder<FabricanteModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regFabricanteAccessor.Execute(idFabricante).FirstOrDefault();
        }

        public void Save(FabricanteModel fabricante)
        {
            if (fabricante.idFabricante == null)
            {
                int idFabricante = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                  "dbo.Proc_save_fabricante",
                 ParameterBase<FabricanteModel>.SetParameterValue(fabricante));

                fabricante.idFabricante = idFabricante;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                  "[dbo].[Proc_update_Fabricante]",
                 ParameterBase<FabricanteModel>.SetParameterValue(fabricante));
            }
        }

        public void Delete(int idFabricante)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                        "dbo.Proc_delete_fabricante",
                         UserData.idUser,
                         idFabricante);
        }

        public int Copy(int idFabricante)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                        "dbo.Proc_copy_fabricante",
                         idFabricante);
        }
    }
}
