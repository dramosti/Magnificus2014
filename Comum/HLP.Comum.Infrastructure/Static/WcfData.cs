using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Infrastructure.Static
{
    public class WcfData
    {
        private static string _xIpServidor;

        public static string xIpServidor
        {
            get { return "192.168.9.33"; }
            set { _xIpServidor = value; }
        }

        private static string _xEnderLocal;

        public static string xEnderLocal
        {
            get { return "http://192.168.9.33:8080/wcf/"; }
            set { _xEnderLocal = value; }
        }

        private static string _xEnderWeb;

        public static string xEnderWeb
        {
            get { return "http://hlpsistemas.no-ip.org:8081/wcf/"; }
            set { _xEnderLocal = value; }
        }       

    }
}
