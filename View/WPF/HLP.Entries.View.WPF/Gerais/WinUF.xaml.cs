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
using HLP.Entries.ViewModel.ViewModels;
using HLP.Entries.View.WPF.UIUtilities;
using HLP.Comum.View.Formularios;
using System.Collections;

namespace HLP.Entries.View.WPF.Gerais
{
    /// <summary>
    /// Interaction logic for WinUF.xaml
    /// </summary>
    public partial class WinUF : WindowsBase
    {
        public UFViewModel ViewModel
        {
            get { return this.DataContext as UFViewModel; }
            set { this.DataContext = value; }
        }

        public WinUF()
        {
            InitializeComponent();
            try
            {
                this.ViewModel = new UFViewModel();
            }
            catch (Exception)
            {
                throw;
            }
            List<TabItem> lTabs = GetLogicalChildCollection<TabItem>(this);
            List<Control> lControls = new List<Control>();
            if (lTabs.Count > 0)
                foreach (TabItem item in lTabs)
                {
                    lControls.AddRange(GetLogicalChildCollection<Control>(item));
                }
            else
            {
                lControls.AddRange(GetLogicalChildCollection<Control>(this));
            }


            lControls = lControls.Where(c => c.GetType().BaseType == typeof(HLP.Comum.View.Components.BaseControl)).ToList();

            lControls.LastOrDefault().LostFocus += controles_LostFocus;

            
        }
        
        void controles_LostFocus(object sender, RoutedEventArgs e)
        {
            (this.Content as Panel).Focus();            
            this.SecondComponentFocus(this.Content as Panel);
        
        }
        #region TESTES
        public void SecondComponentFocus(System.Windows.Controls.Panel _panel)
        {
            _panel.Focus();
            
            _panel.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
            System.Windows.Controls.Control ctr = (System.Windows.Controls.Control)Keyboard.FocusedElement;
            while (ctr.GetType() != typeof(System.Windows.Controls.TextBox))
            {
                ctr.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                ctr = (System.Windows.Controls.Control)Keyboard.FocusedElement;
                if (ctr.GetType() == typeof(System.Windows.Controls.ComboBox))
                    break;
            }
            if (ctr.GetType() == typeof(System.Windows.Controls.TextBox))
                ctr.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }
        public void FirstComponentFocus(Panel _panel)
        {
            _panel.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
            System.Windows.Controls.Control ctr = (System.Windows.Controls.Control)Keyboard.FocusedElement;
            while (ctr.GetType() != typeof(System.Windows.Controls.TextBox))
            {
                ctr.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                ctr = (System.Windows.Controls.Control)Keyboard.FocusedElement;
                if (ctr.GetType() == typeof(System.Windows.Controls.ComboBox))
                    break;
            }
        }
        public static List<T> GetLogicalChildCollection<T>(object parent) where T : DependencyObject
        {
            List<T> logicalCollection = new List<T>();
            GetLogicalChildCollection(parent as DependencyObject, logicalCollection);
            return logicalCollection;
        }
        private static void GetLogicalChildCollection<T>(DependencyObject parent, List<T> logicalCollection) where T : DependencyObject
        {
            IEnumerable children = LogicalTreeHelper.GetChildren(parent);
            foreach (object child in children)
            {
                if (child is DependencyObject)
                {
                    DependencyObject depChild = child as DependencyObject;
                    if (child is T)
                    {
                        logicalCollection.Add(child as T);
                    }
                    GetLogicalChildCollection(depChild, logicalCollection);
                }
            }
        }
        #endregion

        private void HlpPesquisa_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //this.SecondComponentFocus(this.Content as Panel);
        }

        private void HlpPesquisa_KeyDown(object sender, KeyEventArgs e)
        {

        }



    }
}
