using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
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
                #region App.config.exe
                System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Add an Application Setting.

                if (config.ConnectionStrings.ConnectionStrings[WcfData.xNameConnection] != null)
                    config.ConnectionStrings.ConnectionStrings[WcfData.xNameConnection].ConnectionString = @stringConnection;
                else
                    config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(WcfData.xNameConnection,
                        @stringConnection, "System.Data.SqlClient"));

                // Save the configuration file.
                config.Save(ConfigurationSaveMode.Modified, false);
                #endregion


                //#region App.Config

                //string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                //string userFilePath = Path.Combine(localAppData, "HLP");

                //if (!Directory.Exists(userFilePath))
                //{
                //    Directory.CreateDirectory(userFilePath);
                //}

                //string sourceFilePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "App.config");
                //string destFilePath = Path.Combine(userFilePath, "App.config");

                //if (!File.Exists(destFilePath))
                //{
                //    File.Copy(sourceFilePath, destFilePath);
                //}

                //Configuration configUser = ConfigurationManager.OpenMappedExeConfiguration(
                //    new ExeConfigurationFileMap { ExeConfigFilename = sourceFilePath }, ConfigurationUserLevel.None);

                //// Add an Application Setting.
                //configUser.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(WcfData.xNameConnection,
                //    @stringConnection));

                //// Save the configuration file.
                //configUser.Save(ConfigurationSaveMode.Modified, false);
                //#endregion

                // Force a reload of a changed section.
                ConfigurationManager.RefreshSection("appSettings");

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

        public static bool SalvaTamanhoMensagensWcf()
        {
            Configuration c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            bool bModificado = false;

            int iTamanho = 2147483647;

            ServiceModelSectionGroup serviceModeGroup = ServiceModelSectionGroup.GetSectionGroup(c);

            foreach (BasicHttpBindingElement item in serviceModeGroup.Bindings.BasicHttpBinding.Bindings
                )
            {
                if (item.MaxReceivedMessageSize != iTamanho)
                {
                    item.MaxReceivedMessageSize = iTamanho;
                    bModificado = true;
                }
                if (item.ReaderQuotas.MaxDepth != iTamanho)
                {
                    item.ReaderQuotas.MaxDepth = iTamanho;
                    bModificado = true;
                }
                if (item.ReaderQuotas.MaxStringContentLength != iTamanho)
                {
                    item.ReaderQuotas.MaxStringContentLength = iTamanho;
                    bModificado = true;
                }
                if (item.ReaderQuotas.MaxArrayLength != iTamanho)
                {
                    item.ReaderQuotas.MaxArrayLength = iTamanho;
                    bModificado = true;
                }
                if (item.ReaderQuotas.MaxBytesPerRead != iTamanho)
                {
                    item.ReaderQuotas.MaxBytesPerRead = iTamanho;
                    bModificado = true;
                }
                if (item.ReaderQuotas.MaxNameTableCharCount != iTamanho)
                {
                    item.ReaderQuotas.MaxNameTableCharCount = iTamanho;
                    bModificado = true;
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
        public static StConnection EmRedeLocal()
        {
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pr;

            try
            {
                pr = p.Send(WcfData.xIpServidor);

                if (pr.Status == System.Net.NetworkInformation.IPStatus.Success)
                    Sistema.bOnline = StConnection.OnlineNetwork;
                else
                    Sistema.bOnline = StConnection.OnlineWeb;
                return Sistema.bOnline;
            }
            catch (Exception)
            {
                return StConnection.Offline;
            }
        }

        public static Type GetTypeByReflection(string xNamespace, string xType)
        {
            Type t = null;

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            if (assemblies != null)
            {
                Assembly selectedAssembly = assemblies.ToList().FirstOrDefault(
                    i => i.ManifestModule.Name.StartsWith(value: xNamespace));

                if (selectedAssembly != null)
                    t = selectedAssembly.GetTypes().FirstOrDefault(i => i.Name == xType);
            }

            return t;
        }

        public static object ExecuteMethodByReflection(string xNamespace, string xType, string xMethod, object[] parameters)
        {
            Type t = GetTypeByReflection(xNamespace: xNamespace, xType: xType);

            if (t != null)
            {
                MethodInfo method = t.GetMethod(name: xMethod);

                if (method != null)
                    return method.Invoke(obj: t, parameters: parameters);
            }

            return null;
        }

        private static DataSet.DataSetImgRport _dsImagemToReport;

        public static DataSet.DataSetImgRport dsImagemToReport
        {
            get
            {
                if (Sistema._dsImagemToReport == null)
                {
                    object xPath = CompanyData.objEmpresaModel.GetPropertyValue("xLinkPastas");
                    if (xPath != null)
                    {
                        if (File.Exists(xPath.ToString()))
                        {
                            Sistema._dsImagemToReport = new DataSet.DataSetImgRport();
                            DataSet.DataSetImgRport.ImagensRow row = Sistema._dsImagemToReport.Imagens.NewImagensRow();
                            row.LogoEmpresa = Util.ImagemParaByte(xPath.ToString());
                        }

                    }
                }
                return Sistema._dsImagemToReport;
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
