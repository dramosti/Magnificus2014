using System.Collections.Generic;
using System.Data;
using HLP.Entries.Model.Models.Crm;

namespace HLP.Entries.Model.Repository.Interfaces.Crm
{
    public interface IUFRepository
    {
        List<UFModel> GetAll();
        UFModel GetUF(int idUF);
        DataTable GetAlltoComboBox();
        void Save(UFModel uf);
        void Delete(int idUF);
        bool IsNew(string xSiglaUf);
        int Copy(int idUF);
    }
}
