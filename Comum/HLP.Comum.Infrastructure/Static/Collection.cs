using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HLP.Comum.Infrastructure.Static
{
    public static class Collection
    {
        public static ImageList LIST_IMAGELIST_TREEVIEW;
        public static List<OrdemModulo> LIST_ORDEM_MODULOS;
    }

    public struct OrdemModulo
    {
        public string nome { get; set; }
        public string arquivo { get; set; }
        public int ordem { get; set; }
    }
}
