using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface ISite_enderecoRepository
    {
        void Save(Site_enderecoModel objSite_Endereco);
        void Delete(int site_idEndereco);
        void DeletePorSite(int idSite);
        void Copy(Site_enderecoModel objSite_Endereco);
        Site_enderecoModel GetSite_Endereco(int idEndereco);
        List<Site_enderecoModel> GetAllSite_Endereco(int idSite);
    }
}
