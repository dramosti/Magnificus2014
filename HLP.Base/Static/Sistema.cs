using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using HLP.Report.View.WPF.DataSet;
using System.Xml;
using HLP.Base.ClassesBases;

namespace HLP.Base.Static
{
    public class Sistema
    {
        private static List<BasicModel> _lCidades;

        public static List<BasicModel> lCidades
        {
            get { return _lCidades; }
            set { _lCidades = value; }
        }


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

        public static Window GetOpenWindow(string xName = "")
        {
            Window wd = null;
            if (xName == "")
            {
                if (Application.Current != null)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
                    {
                        object mainDataContext = Application.Current.MainWindow.DataContext;

                        if (mainDataContext != null)
                        {
                            object manModel = mainDataContext.GetType().GetProperty(name: "winMan").GetValue(obj: mainDataContext);
                            if (manModel != null)
                            {
                                object objCurrentTab = manModel.GetType().GetProperty(name: "_currentTab").GetValue(obj: manModel);
                                if (objCurrentTab != null)
                                {
                                    wd = objCurrentTab.GetType().GetProperty(name: "_windows").GetValue(obj: objCurrentTab) as Window;
                                }
                            }
                        }
                    }));
                }
            }
            else
            {
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

        public static void SetAppSettings(string xKey, string xValue)
        {
            try
            {
                Configuration c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (c.AppSettings.Settings[xKey] != null)
                {
                    c.AppSettings.Settings[xKey].Value = xValue;
                }
                else
                {
                    c.AppSettings.Settings.Add(new KeyValueConfigurationElement(xKey, xValue));
                }
                c.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string GetAppSettings(string xKey)
        {
            try
            {
                Configuration c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (c.AppSettings.Settings[xKey] != null)
                {
                    return c.AppSettings.Settings[xKey].Value.ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Adiciona todas os bindings de wcf no config principal
        /// </summary>
        public static void SetAllConfigService()
        {
            List<BasicHttpBindingElement> lBindings = new List<BasicHttpBindingElement>();
            List<ChannelEndpointElement> lChannels = new List<ChannelEndpointElement>();
            Configuration localConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // local...
            ServiceModelSectionGroup serviceModeGroupLocal = ServiceModelSectionGroup.GetSectionGroup(config: localConfig);
            List<BasicHttpBindingElement> lBindingsLocalConfig = new List<BasicHttpBindingElement>();
            foreach (BasicHttpBindingElement item in serviceModeGroupLocal.Bindings.BasicHttpBinding.Bindings)
            {
                lBindingsLocalConfig.Add(item: item);
            }

            string[] arrayPaths = Directory.GetFiles(System.Windows.Forms.Application.StartupPath, "*.config", SearchOption.AllDirectories);
            ConfigXmlDocument configXml = new ConfigXmlDocument();
            XmlNodeList nodeList;
            List<BasicHttpBindingElement> lBindingsToAdd = new List<BasicHttpBindingElement>();
            List<ChannelEndpointElement> lChannelsToAdd = new List<ChannelEndpointElement>();
            XmlAttribute attName = null;
            foreach (string paths in arrayPaths)
            {
                if (paths != localConfig.FilePath)
                {
                    configXml.Load(filename: paths);
                    nodeList = configXml.SelectNodes(xpath: "/configuration/system.serviceModel/bindings/basicHttpBinding/binding");

                    foreach (XmlNode node in nodeList)
                    {
                        attName = node.Attributes[name: "name"];

                        if (attName != null)
                            lBindings.Add(item: new BasicHttpBindingElement
                            {
                                Name = attName.Value
                            });
                    }

                    nodeList = configXml.SelectNodes(xpath: "/configuration/system.serviceModel/client/endpoint");

                    foreach (XmlNode node in nodeList)
                    {
                        lChannels.Add(item: new ChannelEndpointElement
                        {
                            Address = new Uri(uriString: node.Attributes[name: "address"].Value),
                            Binding = node.Attributes[name: "binding"].Value,
                            BindingConfiguration = node.Attributes[name: "bindingConfiguration"].Value,
                            Contract = node.Attributes[name: "contract"].Value,
                            Name = node.Attributes[name: "name"].Value
                        });
                    }






                    List<string> lLocal = lBindingsLocalConfig.Select(c => c.Name).ToList();
                    List<string> lPath = lBindings.Select(c => c.Name).ToList();
                    List<string> ltoAdd = (from c in lPath
                                           where !lLocal.Contains(c)
                                           select c).ToList();

                    lBindingsToAdd.AddRange(lBindings.Where(c => ltoAdd.Contains(c.Name.ToString())).ToList());

                    List<ChannelEndpointElement> lChannelsLocalConfig = new List<ChannelEndpointElement>();
                    foreach (ChannelEndpointElement channels in serviceModeGroupLocal.Client.Endpoints)
                    {
                        lChannelsLocalConfig.Add(item: channels);
                    }
                    foreach (ChannelEndpointElement c in lChannels)
                    {
                        if (lChannelsLocalConfig.Count(i => i.Name == c.Name) == 0)
                            lChannelsToAdd.Add(item: c);
                    }
                }
            }


            try
            {
                lBindingsToAdd = lBindingsToAdd.Distinct().ToList();
                foreach (BasicHttpBindingElement i in lBindingsToAdd.Distinct())
                {
                    serviceModeGroupLocal.Bindings.BasicHttpBinding.Bindings.Add(element:
                        i);
                }

                foreach (ChannelEndpointElement c in lChannelsToAdd)
                {
                    serviceModeGroupLocal.Client.Endpoints.Add(element:
                        c);
                }

                localConfig.Save();
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

                if ((pr.Status == System.Net.NetworkInformation.IPStatus.Success))
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

        private static DataSetImgRport _dsImagemToReport;

        public static DataSet dsImagemToReport
        {
            get
            {
                if (Sistema._dsImagemToReport == null)
                {
                    object xPath = CompanyData.objEmpresaModel.GetPropertyValue("xLinkLogoEmpresa");
                    if (xPath != "")
                    {
                        if (File.Exists(xPath.ToString()))
                        {
                            Sistema._dsImagemToReport = new DataSetImgRport();
                            DataSetImgRport.ImagensRow row = Sistema._dsImagemToReport.Imagens.NewImagensRow();
                            FileStream fs = new FileStream(xPath.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            byte[] Image = new byte[fs.Length];
                            fs.Read(Image, 0, Convert.ToInt32(fs.Length));
                            fs.Close();
                            row.LogoEmpresa = Image;
                            row.idEmpresa = CompanyData.idEmpresa.ToString();
                            _dsImagemToReport.Imagens.AddImagensRow(row);
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
