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
using HLP.Comum.ViewModel.Commands;

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
            set
            {
                SetValue(TextProperty, value);
            }
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
            DependencyProperty.Register("isFindFolder", typeof(bool), typeof(HlpTextBox), new PropertyMetadata(false));

        [Category("HLP.Owner")]
        public bool isFindFiles
        {
            get { return (bool)GetValue(isFindFilesProperty); }
            set { SetValue(isFindFilesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for isFindFiles.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isFindFilesProperty =
            DependencyProperty.Register("isFindFiles", typeof(bool), typeof(HlpTextBox), new PropertyMetadata(false));

        public Visibility VisibilityLabel
        {
            get { return (Visibility)GetValue(VisibilityLabelProperty); }
            set { SetValue(VisibilityLabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VisibilityLabel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VisibilityLabelProperty =
            DependencyProperty.Register("VisibilityLabel", typeof(Visibility), typeof(HlpTextBox), new PropertyMetadata(Visibility.Visible));

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbd { get; set; }
        private System.Windows.Forms.OpenFileDialog ofd { get; set; }

        public void Find()
        {
            try
            {
                if (this.isFindFolder)
                {
                    if (fbd == null)
                    {
                        fbd = new System.Windows.Forms.FolderBrowserDialog();
                        fbd.Description = "Localizar diretório";
                    }
                    if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Text = fbd.SelectedPath;
                    }
                }
                else if (this.isFindFiles)
                {
                    if (ofd == null)
                    {
                        ofd = new System.Windows.Forms.OpenFileDialog();
                        ofd.Title = "Localizar arquivos";
                        ofd.FileName = "Magníficus";
                        ofd.Multiselect = false;
                    }
                    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Text = ofd.FileName;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void componente_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.isFindFolder || this.isFindFiles)
            {
                this.btn.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Find();
        }

        public event TextChangedEventHandler UCTextChanged;

        private void txtControle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (UCTextChanged != null)
            {
                UCTextChanged(sender: this, e: e);
            }
        }
    }

}
