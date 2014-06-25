using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Fiscal
{
    public partial class Situacao_tributaria_icmsModel : modelComum
    {
        public Situacao_tributaria_icmsModel()
            : base(xTabela: "Situacao_tributaria_icms")
        {
        }


        private int? _idCSTICms;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idCSTICms
        {
            get { return _idCSTICms; }
            set
            {
                _idCSTICms = value;
                base.NotifyPropertyChanged(propertyName: "idCSTICms");
            }
        }

        [ParameterOrder(Order = 2)]
        public string cCSTIcms { get; set; }
        [ParameterOrder(Order = 3)]
        public string xCSTIcms { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stSimplesNacional { get; set; }
    }

    public partial class Situacao_tributaria_icmsModel
    {
        public override string this[string columnName]
        {
            get
            {
                string sReturn = base[columnName];

                if (sReturn == null)
                {
                    if (columnName.Equals("cCSTIcms"))
                    {
                        if (this.cCSTIcms != "")
                        {
                            int ivalue;
                            int.TryParse(this.cCSTIcms, out ivalue);
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
