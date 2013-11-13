using HLP.Entries.Model.Models.RecursosHumanos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.RecursosHumanos
{
    public interface IDepartamentoRepository
    {
        DepartamentoModel GetDepartamento(int idDepartamento);
        void Save(DepartamentoModel departamento);
        void Delete(int idDepartamento);
        int Copy(int idDepartamento);
        List<DepartamentoModel> GetBySetor(int idSetor);
    }
}
