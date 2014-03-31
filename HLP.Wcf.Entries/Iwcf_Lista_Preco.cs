using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Lista_Preco" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Lista_Preco
    {
        [OperationContract]
        List<HLP.Comum.Resources.RecursosBases.HlpButtonHierarquiaStruct> GetLista_PrecoHierarquia(int idListaPreco);

        [OperationContract]
        HLP.Comum.Resources.Models.modelToTreeView GetSelectedLista_PrecoFullHierarquia(int idListaPreco);

        [OperationContract]
        HLP.Entries.Model.Models.Comercial.Lista_Preco_PaiModel getLista_Preco(int idListaPrecoPai);

        [OperationContract]
        List<HLP.Entries.Model.Models.Comercial.Lista_precoModel> GetItensListaPreco(int idListaPrecoPai);

        [OperationContract]
        HLP.Entries.Model.Models.Comercial.Lista_Preco_PaiModel saveLista_Preco(HLP.Entries.Model.Models.Comercial.Lista_Preco_PaiModel objListaPreco);

        [OperationContract]
        bool deleteLista_Preco(int idListaPrecoPai);

        [OperationContract]
        HLP.Entries.Model.Models.Comercial.Lista_Preco_PaiModel copyLista_Preco(HLP.Entries.Model.Models.Comercial.Lista_Preco_PaiModel objListaPreco);

        [OperationContract]
        List<int> GetAllIdsListaPreco();

        [OperationContract]
        int GetIdListaPreferencial();

    }
}
