using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Fiscal;

namespace HLP.Entries.Model.Repository.Interfaces.Fiscal
{
    public interface ITipo_documento_oper_validaRepository
    {
        List<Tipo_documento_oper_validaModel> GetAll(int idTipoDocumento);
        void Save(Tipo_documento_oper_validaModel documentoOper);
        void Delete(int idTipoDocumentoOperValida);
        void DeleteOperValidaByTipoDocumento(int idTipoDocumento);
        int Copy(int idTipoDocumentoOperValida);
    }
}
