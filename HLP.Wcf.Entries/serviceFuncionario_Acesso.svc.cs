using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceFuncionario_Acesso" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceFuncionario_Acesso.svc or serviceFuncionario_Acesso.svc.cs at the Solution Explorer and start debugging.
    public class serviceFuncionario_Acesso : IserviceFuncionario_Acesso
    {
        [Inject]
        public IAcessoRepository acessoRepository { get; set; }

        [Inject]
        public IFuncionarioRepository funcionarioRepository { get; set; }

        public serviceFuncionario_Acesso()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public int Save(HLP.Entries.Model.Models.Gerais.FuncionarioModel objModel)
        {

            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Gerais.FuncionarioModel GetObjeto(int idObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
