using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.ComumView.Model.Model
{
    public class MenuItemModel
    {
        public string xName { get; set; }
        public string xHeader { get; set; }
        public List<MenuItemModel> lItens { get; set; }
    }
}
