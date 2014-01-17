using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Models
{
    public partial class loginModel : modelBase
    {
        public loginModel()
        {
        }

        public int idEmpresa { get; set; }
        public string xId { get; set; }
        public string xPassword { get; set; }
    }

    public partial class loginModel
    {
        public override string this[string columnName]
        {
            get
            {
                return null;
            }
        }
    }
}
