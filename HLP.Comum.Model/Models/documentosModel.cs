using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Models
{
    public partial class DocumentosModel : modelComum
    {
        public DocumentosModel()
            : base(xTabela: "Documentos")
        {
        }

        private int _idDocumento;
        [ParameterOrder(Order = 1)]
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
        public string xPath
        {
            get { return _xPath; }
            set
            {
                _xPath = value;
                base.NotifyPropertyChanged(propertyName: "xPath");
            }
        }
        private string _xNameTable;
        [ParameterOrder(Order = 4)]
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
