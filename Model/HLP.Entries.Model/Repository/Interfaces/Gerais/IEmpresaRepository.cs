using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IEmpresaRepository
    {
        void Save(EmpresaModel objEmpresa);
        void Delete(int idEmpresa);
        int Copy(EmpresaModel objModel);
        EmpresaModel GetEmpresa(int idEmpresa);
        List<EmpresaModel> GetAllEmpresa();
        void BeginTransaction();
        void CommitTransaction();
        void RollackTransaction();
    }
}
