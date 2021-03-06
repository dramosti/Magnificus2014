﻿using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.SQLAnalyse.Model
{
    public partial class TableModel : modelBase
    {
        public TableModel() { }

        private string _xTable;
        public string xTable
        {
            get { return _xTable; }
            set
            {
                _xTable = value;
                base.NotifyPropertyChanged(propertyName: "xTable");
            }
        }

        private List<FieldModel> _lField;
        public List<FieldModel> lField
        {
            get { return _lField; }
            set
            {
                _lField = value;
                base.NotifyPropertyChanged(propertyName: "lField");
            }
        }
        
        


    }
    public partial class TableModel
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
