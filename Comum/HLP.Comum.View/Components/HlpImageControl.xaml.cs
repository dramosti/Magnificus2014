using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for HlpImageControl.xaml
    /// </summary>
    public partial class HlpImageControl : UserControl
    {
        public HlpImageControl()
        {
            InitializeComponent();
        }

        private string _xPathImg;

        public string xPathImg
        {
            get { return _xPathImg; }
            set
            {
                _xPathImg = value;

                if (File.Exists(path: value))
                {
                    byte[] b;
                    using (FileStream fs = File.OpenRead(path: value))
                    {
                        b = new byte[fs.Length];

                        fs.Read(b, 0, b.Length);
                    }

                    this.byteImg = b;
                }
            }
        }



        public byte[] byteImg
        {
            get { return (byte[])GetValue(byteImgProperty); }
            set { SetValue(byteImgProperty, value); }
        }

        // Using a DependencyProperty as the backing store for byteImg.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty byteImgProperty =
            DependencyProperty.Register("byteImg", typeof(byte[]), typeof(HlpImageControl), new PropertyMetadata(null));

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == true)
            {
                this.xPathImg = fd.FileName;
            }
        }



    }
}
