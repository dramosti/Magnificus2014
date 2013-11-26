﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceEmpresa" in both code and config file together.
    [ServiceContract]
    public interface IserviceEmpresa
    {
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.EmpresaModel GetObject(int idEmpresa);

        [OperationContract]
        int Save(HLP.Entries.Model.Models.Gerais.EmpresaModel objEmpresa);

        [OperationContract]
        bool Delete(int idEmpresa);

        [OperationContract]
        int copyEmpresa(HLP.Entries.Model.Models.Gerais.EmpresaModel objEmpresa);
    }
}
