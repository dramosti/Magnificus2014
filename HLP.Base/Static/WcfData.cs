using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Base.Static
{
    public class WcfData
    {
        private static string _xIpServidor;

        public static string xIpServidor
        {
            get { return "192.168.9.100"; }
            set { _xIpServidor = value; }
        }

        private static string _xEnderWeb;

        public static string xEnderWeb
        {
            get { return "http://hlpsistemas.no-ip.org:8081/wcf/"; }
            set { _xEnderWeb = value; }
        }

        private static string _xNameConnection = "dbPrincipal";

        public static string xNameConnection
        {
            get { return _xNameConnection; }
            set { _xNameConnection = value; }
        }
        

    }
}
