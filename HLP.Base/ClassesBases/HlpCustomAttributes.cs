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
        public bool skip { get; set; }

        public SkipValidation(bool skip)
        {
            this.skip = skip;
        }
    }
}
