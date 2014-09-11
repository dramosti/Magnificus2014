using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Base.ClassesBases
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SkipValidation : System.Attribute
    {
        public TypeSkipValidation skip { get; set; }

        public SkipValidation(TypeSkipValidation skip)
        {
            this.skip = skip;
        }
    }

    public enum TypeSkipValidation
    {
        all,
        onlyDataGrid
    }
}
