using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CrystalDecisions.CrystalReports.Engine;

namespace HLP.Comum.View.WPF
{
    /// <summary>
    /// Interaction logic for WinPreviewReport.xaml
    /// </summary>
    public partial class WinPreviewReport : Window
    {
        public WinPreviewReport()
        {
            InitializeComponent();
            reportViewer.Owner = this;
        }


        public ReportDocument rpt
        {
            set
            {
                this.reportViewer.ViewerCore.ReportSource = value;
                this.reportViewer.ViewerCore.RefreshReport();
            }
        }



    }
}
