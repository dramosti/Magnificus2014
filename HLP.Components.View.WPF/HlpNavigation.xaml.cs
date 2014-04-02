using HLP.Base.ClassesBases;
using HLP.Components.Model.Models;
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

namespace HLP.Components.View.WPF
{
    /// <summary>
    /// Interaction logic for HlpNavigation.xaml
    /// </summary>
    public partial class HlpNavigation : UserControl
    {
        public ICommand btnAntComm { get; set; }

        public ICommand btnProxComm { get; set; }

        public HlpNavigation()
        {
            InitializeComponent();
            this.btnAntComm = new RelayCommand(execute: execut => this.AntExecute(), canExecute: canExec => this.AntCanExecute());
            this.btnProxComm = new RelayCommand(execute: execut => this.ProxExecute(), canExecute: canExec => this.ProxCanExecute());
            this.btnAnt.Command = this.btnAntComm;
            this.btnProx.Command = this.btnProxComm;
        }

        #region Commands

        private void AntExecute()
        {
            this.scroll.ScrollToHorizontalOffset(offset: this.scroll.HorizontalOffset - 74);
        }

        private bool AntCanExecute()
        {
            return (this.scroll.HorizontalOffset > 0);
        }

        private void ProxExecute()
        {
            this.scroll.ScrollToHorizontalOffset(offset: this.scroll.HorizontalOffset + 74);
        }

        private bool ProxCanExecute()
        {
            return (this.scroll.HorizontalOffset < this.scroll.ScrollableWidth);
        }

        #endregion

        public int selectedId
        {
            get { return (int)GetValue(selectedIdProperty); }
            set
            {
                SetValue(selectedIdProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for selectedId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectedIdProperty =
            DependencyProperty.Register("selectedId", typeof(int), typeof(HlpNavigation), new PropertyMetadata(0));


        public List<HlpButtonHierarquiaStruct> lIdsHierarquia
        {
            get { return (List<HlpButtonHierarquiaStruct>)GetValue(lIdsHierarquiaProperty); }
            set
            {
                SetValue(lIdsHierarquiaProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for lIdsHierarquia.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty lIdsHierarquiaProperty =
            DependencyProperty.Register("lIdsHierarquia", typeof(List<HlpButtonHierarquiaStruct>), typeof(HlpNavigation),
            new PropertyMetadata(new List<HlpButtonHierarquiaStruct>()));



        public ICommand commButton
        {
            get { return (ICommand)GetValue(commButtonProperty); }
            set { SetValue(commButtonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for commButton.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty commButtonProperty =
            DependencyProperty.Register("commButton", typeof(ICommand), typeof(HlpNavigation), new PropertyMetadata(null));
    }
}
