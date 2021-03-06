﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure.Static;
using HLP.Comum.Modules.Infrastructure;
using HLP.Comum.Modules.Interface;

namespace HLP.Comum.Modules
{
    public class Modulo : IModulo
    {
        // private bool _bCarregaComponentes = true; ** variável privada não utilizada no sistema

        public Modulo(string arquivoConfiguracao)
        {
            this.ArquivoConfiguracao = arquivoConfiguracao;
            this.NomeModulo = System.IO.Path.GetFileNameWithoutExtension(arquivoConfiguracao);
        }
        public Modulo()
        { }

        #region [Propriedades]

        public string NomeModulo { get; private set; }
        public string ArquivoConfiguracao { get; private set; }
        /// <summary>
        /// Objeto de configuração do modulo que contem informações dos Formularios.
        /// </summary>
        public ObjectsModule objectModulo { get; set; }

        public static List<ObjectsModule> lobjectModulo = new List<ObjectsModule>();

        //public IFormModulo FormModulo { get; private set; }

        #endregion

        #region [Métodos]

        #region [Métodos públicos]

        public void InicializarModulo()
        {
            try
            {
                Contexto.CarregaConfiguracao(this.NomeModulo, this.ArquivoConfiguracao);

                objectModulo = SerializeClassToXml.DeserializeClasse<ObjectsModule>(ArquivoConfiguracao);

                List<string> lresult = Sistema.lSettings.Select(s => s.Key.ToString()).ToList();

                objectModulo.lFormularios = (from c in objectModulo.lFormularios
                                             where (!lresult.Contains(c.xId.ToString()))
                                             select c).ToList();

                lobjectModulo.Add(objectModulo);
            }
            catch (Exception ex)
            {
                new Exception(this.NomeModulo + " - " + this.ArquivoConfiguracao + " - " + ex.Message);
            }
        }
        public void DescarregarModulo()
        {
            throw new NotImplementedException();
        }

        #endregion
        #endregion


    }



    [Serializable]
    [System.Xml.Serialization.XmlRootAttribute("objects", Namespace = "http://www.springframework.net", IsNullable = false)]
    //[System.Xml.Serialization.XmlRoot("objects")]
    public class ObjectsModule
    {
        public ObjectsModule()
        {
            lFormularios = new List<objectForm>();
        }

        [System.Xml.Serialization.XmlElement("object")]
        public List<objectForm> lFormularios { get; set; }
    }

    [System.Xml.Serialization.XmlRoot("object")]
    public class objectForm
    {
        [System.Xml.Serialization.XmlAttribute("id")]
        public string xId { get; set; }

        private string _xName;

        [System.Xml.Serialization.XmlAttribute("name")]
        public string xName
        {
            get { return _xName; }
            set { _xName = Util.ToUpperFirstLetter(value.Replace("_", " ")); ; }
        }

        [System.Xml.Serialization.XmlAttribute("singleton")]
        public string stSingleton { get; set; }

        [System.Xml.Serialization.XmlAttribute("scope")]
        public string xScope { get; set; }

        [System.Xml.Serialization.XmlAttribute("type")]
        public string xType { get; set; }
    }


}
