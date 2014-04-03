using HLP.Components.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Components.Model.Repository.Interfaces
{
    public interface IHlpEnderecoRepository
    {
        void Save(EnderecoModel objEnderecoModel);
        void Delete(EnderecoModel objEnderecoModel);
        void Delete(int idFK, string sNameFK);
        void Copy(EnderecoModel objEnderecoModel);
        EnderecoModel GetObjeto(int idEndereco);
        List<EnderecoModel> GetAllObjetos(int idPK, string sPK);

    }
}
