using System;
using System.Collections;
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

        #region TextBox's Property
        [Category("HLP.Owner")]
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(HlpTextBox), new PropertyMetadata(string.Empty));

        [Category("HLP.Owner")]
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }
        // Using a DependencyProperty as the backing store for IsReadOnly.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(HlpTextBox), new PropertyMetadata(false));


        [Category("HLP.Owner")]
        public bool isFindFolder
        {
            get { return (bool)GetValue(isFindFolderProperty); }
            set { SetValue(isFindFolderProperty, value); }
        }
        // Using a DependencyProperty as the backing store for isFindFolder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isFindFolderProperty =
            DependencyProperty.Register("isFindFolder", typeof(bool), typeof(HlpTextBox), new PropertyMetadata(false, new PropertyChangedCallback(OnChangedisisFindFolder)));
        public static void OnChangedisisFindFolder(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                HlpTextBox comp = d as HlpTextBox;
                if (e.NewValue != null)
                {
                    bool bValor = (bool)e.NewValue;
                    Button btn = (Button)comp.txtControle.Template.FindName("btn", comp.txtControle);
                    if (bValor)
                        btn.Visibility = Visibility.Visible;
                    else if (comp.isFindFiles == false)
                        btn.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Category("HLP.Owner")]
        public bool isFindFiles
        {
            get { return (bool)GetValue(isFindFilesProperty); }
            set { SetValue(isFindFilesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for isFindFiles.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isFindFilesProperty =
            DependencyProperty.Register("isFindFiles", typeof(bool), typeof(HlpTextBox), new PropertyMetadata(false, new PropertyChangedCallback(OnChangedisFindFiles)));


        public static void OnChangedisFindFiles(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                HlpTextBox comp = d as HlpTextBox;
                if (e.NewValue != null)
                {
                    bool bValor = (bool)e.NewValue;
                    Button btn = (Button)comp.txtControle.Template.FindName("btn", comp.txtControle);
                    if (bValor)
                        btn.Visibility = Visibility.Visible;
                    else if (comp.isFindFolder == false)
                        btn.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Visibility VisibilityLabel
        {
            get { return (Visibility)GetValue(VisibilityLabelProperty); }
            set { SetValue(VisibilityLabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VisibilityLabel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VisibilityLabelProperty =
            DependencyProperty.Register("VisibilityLabel", typeof(Visibility), typeof(HlpTextBox), new PropertyMetadata(Visibility.Visible));

        #endregion
    }

}
