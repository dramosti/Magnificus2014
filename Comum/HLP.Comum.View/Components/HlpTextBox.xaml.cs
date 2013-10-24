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

        #region Caption
        public string Caption
        {
            get { return GetValue(CaptionProperty).ToString(); }
            set { SetValue(CaptionProperty, value); }
        }

        public static readonly DependencyProperty CaptionProperty =
              DependencyProperty.Register("Caption", typeof(string), typeof(HlpTextBox),
              new PropertyMetadata(string.Empty, OnCaptionPropertyChanged));

        private static void OnCaptionPropertyChanged(DependencyObject dependencyObject,
               DependencyPropertyChangedEventArgs e)
        {
            HlpTextBox comp = dependencyObject as HlpTextBox;
            comp.OnPropertyChanged("Caption");
            comp.OnCaptionPropertyChanged(e);
        }
        private void OnCaptionPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            lblCaption.Content = Caption;

        }



        #endregion

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
            txtHlp.OnPropertyChanged("Texto");
            txtHlp.OnTextoPropertyChanged(e);
        }
        private void OnTextoPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            txtControle.Text = Texto.Trim().PadLeft(MarginLeftLabel, ' ');
        }
        #endregion

        #region MarginLeftLabel

        public int MarginLeftLabel
        {
            get { return (int)GetValue(MarginLeftLabelProperty); }
            set { SetValue(MarginLeftLabelProperty, (value)); }
        }

        // Using a DependencyProperty as the backing store for MarginLeftLabel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MarginLeftLabelProperty =
            DependencyProperty.Register("MarginLeftLabel", typeof(int), typeof(HlpTextBox), new PropertyMetadata(new int(), OnMarginLeftLabelPropertyChanged));

        private static void OnMarginLeftLabelPropertyChanged(DependencyObject dependecyObject, DependencyPropertyChangedEventArgs e)
        {
            HlpTextBox comp = dependecyObject as HlpTextBox;
            comp.OnPropertyChanged("MarginLeftLabel");
            comp.OnMarginLeftLabelPropertyChanged(e);

        }

        private void OnMarginLeftLabelPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            lblCaption.Content = (lblCaption.Content ?? "").ToString().Trim().PadLeft(MarginLeftLabel, ' ');
        }




        #endregion

        #endregion
    }

}
