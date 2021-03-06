﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.Comum.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ParameterOrder : System.Attribute
    {
        public int Order { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PrimaryKey : System.Attribute
    {
        public bool isPrimary { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DontMap : System.Attribute
    {
        public bool bDontMap { get; set; }
    }
}
