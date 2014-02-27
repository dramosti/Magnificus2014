using HLP.Comum.ViewModel.ViewModels.Commands.Components;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HLP.Comum.View.Components
{
    /// <summary>
    /// Interaction logic for HlpNavigationPanel.xaml
    /// </summary>
    public partial class HlpNavigationPanel : UserControl
    {
        public HlpNavigationPanel()
        {
            InitializeComponent();

        }

        public List<int> lIdsHierarquia
        {
            set
            {
                StackPanel stkPanel = new StackPanel();
                stkPanel.Orientation = Orientation.Horizontal;
                HlpButtonNavigation btn;

                foreach (int item in ((List<int>)value))
                {
                    btn = new HlpButtonNavigation();
                    btn.xContentBtn = item.ToString();
                    stkPanel.Children.Add(element: btn);
                }

                this.ctrlHierarquia.Content = stkPanel;
            }
        }



    }
}
