using HLP.Base.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_SelectConnectionConfig" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_SelectConnectionConfig.svc or wcf_SelectConnectionConfig.svc.cs at the Solution Explorer and start debugging.
    public class wcf_SelectConnectionConfig : Iwcf_SelectConnectionConfig
    {
        public Comum.Model.Models.MagnificusBaseConfiguration GetBaseConfiguration()
        {

            try
            {
                HLP.Comum.Model.Models.MagnificusBaseConfiguration objResult = new Comum.Model.Models.MagnificusBaseConfiguration();
                if (System.IO.File.Exists(Pastas.Path_BasesConfiguradas))
                {
                    objResult = SerializeClassToXml.DeserializeClasse<HLP.Comum.Model.Models.MagnificusBaseConfiguration>(Pastas.Path_BasesConfiguradas);
                }
                return objResult;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
