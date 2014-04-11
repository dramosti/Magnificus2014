using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Models
{
    public class RecordsSqlModel: modelBase
    {        
        private int _id;

        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                base.NotifyPropertyChanged(propertyName: "id");
            }
        }

        private string _display;

        public string display
        {
            get { return _display; }
            set
            {
                _display = value;
                base.NotifyPropertyChanged(propertyName: "display");
            }
        }
    }
}
