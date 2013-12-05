﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceFamiliaProduto" in both code and config file together.
    [ServiceContract]
    public interface IserviceFamiliaProduto
    {
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.Familia_produtoModel GetObject(int idFamiliaProduto);

        [OperationContract]
        HLP.Entries.Model.Models.Gerais.Familia_produtoModel Save(HLP.Entries.Model.Models.Gerais.Familia_produtoModel familia_produto);

        [OperationContract]
        bool Delete(int idFamiliaProduto);

        [OperationContract]
        HLP.Entries.Model.Models.Gerais.Familia_produtoModel Copy(HLP.Entries.Model.Models.Gerais.Familia_produtoModel familia_produto);


    }
}
