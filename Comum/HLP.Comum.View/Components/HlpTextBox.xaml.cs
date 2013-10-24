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
    /// Interaction logic for MyUserControl.xaml
    /// </summary>
    public partial class HlpTextBox : BaseControl
    {
        public HlpTextBox()
        {
            InitializeComponent();
        }

        #region Properties

      

        #region Texto

        public string Texto
        {
            get { return GetValue(TextoProperty).ToString(); }
            set { SetValue(TextoProperty, value); }
        }


        public static readonly DependencyProperty TextoProperty =
            DependencyProperty.Register("Texto", typeof(string), typeof(HlpTextBox),
            new PropertyMetadata(string.Empty, OnTextoPropertyChanged));


        private static void OnTextoPropertyChanged(DependencyObject dependencyObject,
               DependencyPropertyChangedEventArgs e)
        {
            HlpTextBox txtHlp = dependencyObject as HlpTextBox;
            //txtHlp.OnPropertyChanged("Texto");
            txtHlp.OnTextoPropertyChanged(e);
        }
        private void OnTextoPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            txtControle.Text = Texto.Trim().PadLeft(MarginLeftLabel, ' ');
        }
        #endregion

      
        #endregion
    }

}
