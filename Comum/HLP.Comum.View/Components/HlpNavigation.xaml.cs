using HLP.Comum.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for HlpNavigation.xaml
    /// </summary>
    public partial class HlpNavigation : UserControl
    {
        public HlpNavigation()
        {
            InitializeComponent();
            //this.ViewModel = new HlpNavigationViewModel();
        }



        public List<int> lIdsHierarquia
        {
            get { return (List<int>)GetValue(lIdsHierarquiaProperty); }
            set
            {
                SetValue(lIdsHierarquiaProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for lIdsHierarquia.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty lIdsHierarquiaProperty =
            DependencyProperty.Register("lIdsHierarquia", typeof(List<int>), typeof(HlpNavigation), new PropertyMetadata(new List<int>()));



        public HlpNavigationViewModel ViewModel
        {
            get
            {
                return this.DataContext as HlpNavigationViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }

    public class HlpNavigationViewModel : INotifyPropertyChanged
    {
        public HlpNavigationViewModel()
        {
        }

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
