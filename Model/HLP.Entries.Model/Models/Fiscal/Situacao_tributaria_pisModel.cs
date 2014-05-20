using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Fiscal
{
    public partial class Situacao_tributaria_pisModel : modelBase
    {
        public Situacao_tributaria_pisModel() : base("Situacao_tributaria_pis") { }

        private int? _idCSTPis;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idCSTPis
        {
            get { return _idCSTPis; }
            set
            {
                _idCSTPis = value;
                base.NotifyPropertyChanged(propertyName: "idCSTPis");
            }
        }

        [ParameterOrder(Order = 2)]
        public string cCSTPis { get; set; }
        [ParameterOrder(Order = 3)]
        public string xCSTPis { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stSimplesNacional { get; set; }
    }

    public partial class Situacao_tributaria_pisModel
    {
        public override string this[string columnName]
        {
            get
            {
                string sReturn = base[columnName];

                if (sReturn == null)
                {
                    if (columnName.Equals("cCSTPis"))
                    {
                        if (this.cCSTPis != "")
                        {
                            int ivalue;
                            int.TryParse(this.cCSTPis, out ivalue);
                            if (ivalue == 0)
                            {
                                return "Código numérico inválido";
                            }
                        }
                    }
                }
                return sReturn;
            }
        }
    }
}
