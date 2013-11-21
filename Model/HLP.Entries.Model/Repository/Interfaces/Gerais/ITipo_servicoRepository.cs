using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Gerais;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface ITipo_servicoRepository
    {
        Tipo_servicoModel GetTipo(int idTipoServico);
        void Save(Tipo_servicoModel tipo);
        void Delete(int idTipoServico);
        int Copy(int idTipoServico);
    }
}
