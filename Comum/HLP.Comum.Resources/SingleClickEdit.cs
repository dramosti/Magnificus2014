using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HLP.Comum.Resources
{
    public class SingleClickEdit
    {
        public SingleClickEdit() { }

        private void DataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                DataGrid dgv = sender as DataGrid;
                if (dgv.CurrentCell.Column != null)
                    if (dgv.CurrentCell.Column.GetType() == typeof(DataGridComboBoxColumn))
                        dgv.BeginEdit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
