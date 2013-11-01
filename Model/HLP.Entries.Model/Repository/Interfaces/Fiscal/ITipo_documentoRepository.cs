using HLP.Entries.Model.Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Fiscal
{
    public interface ITipo_documentoRepository
    {
        Tipo_documentoModel GetDocumento(int idTipoDocumento);
        void Save(Tipo_documentoModel documento);
        void Delete(int idTipoDocumento);
        void Begin();
        void Commit();
        void RollBack();
        int Copy(int idTipoDocumento);
        List<Tipo_documentoModel> GetTipo_documentoAll();
    }
}
