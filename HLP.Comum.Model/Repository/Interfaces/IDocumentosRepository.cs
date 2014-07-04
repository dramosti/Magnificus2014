using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Repository.Interfaces
{
    public interface IDocumentosRepository
    {
        void Save(DocumentosModel objDocumentos);
        void Delete(int idDocumento);
        int Copy(int idDocumento);
        DocumentosModel GetDocumentos(int idDocumento);
        List<DocumentosModel> GetAllDocumentosByPk(string xTabela, int idPk);
        void DeleteByPk(string xNameTabela, int idPk);
    }
}
