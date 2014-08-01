using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Models
{
    [DataContract]
    public partial class DocumentosModel : modelBase
    {        

        public DocumentosModel()
            : base(xTabela: "Documentos")
        {
        }

        private int _idDocumento;
        [ParameterOrder(Order = 1)]
        [DataMember]
        public int idDocumento
        {
            get { return _idDocumento; }
            set
            {
                _idDocumento = value;
                base.NotifyPropertyChanged(propertyName: "idDocumento");
            }
        }
        private string _xDocumento;
        [ParameterOrder(Order = 2)]
        [DataMember]
        public string xDocumento
        {
            get { return _xDocumento; }
            set
            {
                _xDocumento = value;
                base.NotifyPropertyChanged(propertyName: "xDocumento");
            }
        }
        private string _xPath;
        [ParameterOrder(Order = 3)]
        [DataMember]
        public string xPath
        {
            get { return _xPath; }
            set
            {
                _xPath = value;

                if (File.Exists(path: value))
                {
                    FileInfo fi = new FileInfo(fileName: value);
                    this.xExtensao = fi.Extension;
                }

                base.NotifyPropertyChanged(propertyName: "xPath");
            }
        }
        private string _xNameTable;
        [ParameterOrder(Order = 4)]
        [DataMember]
        public string xNameTable
        {
            get { return _xNameTable; }
            set
            {
                _xNameTable = value;
                base.NotifyPropertyChanged(propertyName: "xNameTable");
            }
        }
        private int _idPk;
        [ParameterOrder(Order = 5)]
        [DataMember]
        public int idPk
        {
            get { return _idPk; }
            set
            {
                _idPk = value;
                base.NotifyPropertyChanged(propertyName: "idPk");
            }
        }
        private int _idEmpresa;
        [ParameterOrder(Order = 6)]
        [DataMember]
        public int idEmpresa
        {
            get { return _idEmpresa; }
            set
            {
                _idEmpresa = value;
                base.NotifyPropertyChanged(propertyName: "idEmpresa");
            }
        }
        private string _xExtensao;
        [ParameterOrder(Order = 7)]
        [DataMember]
        public string xExtensao
        {
            get { return _xExtensao; }
            set
            {
                _xExtensao = value;
                base.NotifyPropertyChanged(propertyName: "xExtensao");
            }
        }
    }

    public partial class DocumentosModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }
}
