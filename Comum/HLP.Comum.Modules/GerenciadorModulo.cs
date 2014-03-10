using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows;
using HLP.Comum.Modules.Infrastructure;
using HLP.Comum.Modules.Interface;
using HLP.Comum.Infrastructure.Static;

namespace HLP.Comum.Modules
{
    public class GerenciadorModulo
    {

        #region [Singleton]
        private static volatile GerenciadorModulo instance;
        private static object syncRoot = new Object();
        private GerenciadorModulo() { }
        public static GerenciadorModulo Instancia
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new GerenciadorModulo();
                    }
                }

                return instance;
            }
        }
        #endregion

        #region [Propriedades]

        public string CaminhoConfiguracoes { get; private set; }

        public List<Modulo> Modulos { get; private set; }

        #endregion


        public void InicializaSistema()
        {
            inicializaModulos();
        }

        public Window CarregaForm(string nome, TipoExibeForm exibeForm)
        {
            Window form = null;
            try
            {
                if (form == null)
                {
                    form = Contexto.GetServico<Window>(nome.Replace(" ", ""));
                    if (form != null)
                    {
                        form.Name = nome;
                    }
                }
                return form;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        #region [Métodos privados]



        private void inicializaModulos()
        {
            carregaModulos();

            for (int i = 0; i < Collection.LIST_ORDEM_MODULOS.Count; i++)
            {
                Modulo m = this.Modulos.FirstOrDefault(M => M.NomeModulo == Collection.LIST_ORDEM_MODULOS[i].nome);
                if (m != null)
                {
                    m.InicializarModulo();
                }
            }
        }

        private void carregaModulos()
        {
            this.CaminhoConfiguracoes = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "configuracoes\\Modulos");



            this.Modulos = (from modulo in System.IO.Directory.EnumerateFiles(this.CaminhoConfiguracoes, "*.modulo")
                            select new Modulo(modulo)).ToList();

            XmlDocument xarquivo = new XmlDocument();
            xarquivo.Load(this.CaminhoConfiguracoes + "\\Modulos.xml");
            XmlNodeList xmlListaModulos = xarquivo.GetElementsByTagName("modulo");
            Collection.LIST_ORDEM_MODULOS = new List<OrdemModulo>();
            foreach (XmlNode item in xmlListaModulos)
            {
                Collection.LIST_ORDEM_MODULOS.Add(new OrdemModulo { nome = item.Attributes["nome"].Value, arquivo = item.Attributes["arquivo"].Value, ordem = Convert.ToInt16(item.Attributes["ordem"].Value) });
            }
            Collection.LIST_ORDEM_MODULOS = Collection.LIST_ORDEM_MODULOS.OrderBy(L => L.ordem).ToList();
        }

        void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e.Exception != null)
            {
                MessageBox.Show("Ocorreu um erro não tratado, favor entrar em contato com o Suporte tecnico.", "Informacao", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public static class Collection
        {
            public static List<OrdemModulo> LIST_ORDEM_MODULOS;
        }

        public struct OrdemModulo
        {
            public string nome { get; set; }
            public string arquivo { get; set; }
            public int ordem { get; set; }
        }


        #endregion


    }
}
