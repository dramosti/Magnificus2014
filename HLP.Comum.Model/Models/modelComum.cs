using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Models
{
    public class modelComum : modelBase
    {
        public modelComum()
        {
        }

        
        private ObservableCollectionBaseCadastros<DocumentosModel> _lDocumentos;

        public ObservableCollectionBaseCadastros<DocumentosModel> lDocumentos
        {
            get { return _lDocumentos; }
            set
            {
                _lDocumentos = value;
                base.NotifyPropertyChanged(propertyName: "lDocumentos");
            }
        }
        

        public modelComum(string xTabela)
            : base(xTabela: xTabela)
        {
        }

        protected override void NotifyPropertyChanged(string propertyName)
        {
            base.NotifyPropertyChanged(propertyName);
        }
    }
}
