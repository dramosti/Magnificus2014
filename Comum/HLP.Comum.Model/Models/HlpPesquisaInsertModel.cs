using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Models
{
    public class HlpPesquisaInsertModel: modelBase
    {
        private object _objDataContext;

        public object objDataContext
        {
            get { return _objDataContext; }
            set
            {
                _objDataContext = value;
                base.NotifyPropertyChanged(propertyName: "objDataContext");
            }
        }
        
        private object _objContent;

        public object objContent
        {
            get { return _objContent; }
            set
            {
                _objContent = value;
                base.NotifyPropertyChanged(propertyName: "objContent");
            }
        }
        
    }
}
