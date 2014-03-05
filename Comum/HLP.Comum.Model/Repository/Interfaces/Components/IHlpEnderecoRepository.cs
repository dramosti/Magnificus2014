using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Repository.Interfaces.Components
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
