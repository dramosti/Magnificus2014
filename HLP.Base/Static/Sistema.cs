using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace HLP.Base.Static
{
    public class Sistema
    {
        public static ContatoStatic contatoStatico = new ContatoStatic();
        public static TipoSender stSender = TipoSender.Sistema;
        public struct ContatoStatic
        {
            public string nmTable { get; set; }
            public string fkTableReferencia { get; set; }
            public int idFkReferencia { get; set; }
            public int idFkContato { get; set; }
        }
        public static List<System.Configuration.KeyValueConfigurationElement> lSettings { get; set; }

        public static StConnection bOnline { get; set; }

        public static Window GetOpenWindow(string xName)
        {

            Window wd = null;
            if (Application.Current != null)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
                {
                    foreach (Window item in Application.Current.Windows)
                    {
                        if (item.Name == xName)
                            wd = item;
                    }
                }));
            }
            return wd;
        }

        public static void AddConnection(string stringConnection)
        {
            try
            {
                Configuration c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                c.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings
                {
                    ConnectionString = stringConnection
                });
                c.Save();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public static bool SalvaEndPoint(string xUri)
        {
            Configuration c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ServiceModelSectionGroup serviceModeGroup = ServiceModelSectionGroup.GetSectionGroup(c);
            string xNomeServico;
            Uri _uri;
            bool bModificado = false;

            foreach (ChannelEndpointElement item in serviceModeGroup.Client.Endpoints)
            {
                xNomeServico = item.Address.ToString().Split('/').ToList().Last();
                _uri = new Uri(xUri + xNomeServico);
                if (_uri != item.Address)
                {
                    bModificado = true;
                    item.Address = _uri;
                }
            }
            try
            {
                if (bModificado)
                    c.Save();

                return bModificado;
            }
            catch (Exception)
            {

                throw;
            }
        }



    }

    public enum StConnection
    {
        OnlineNetwork,
        OnlineWeb,
        Offline
    }

    public enum TipoSender
    {
        WCF,
        Sistema
    }
}
