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
    /// Interaction logic for HlpUserControlBtnImage.xaml
    /// </summary>
    public partial class HlpUserControlBtnImage : UserControl
    {
        public HlpUserControlBtnImage()
        {
            InitializeComponent();
        }



        public string xPathCaminho
        {
            get { return (string)GetValue(xPathCaminhoProperty); }
            set { SetValue(xPathCaminhoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for xPathCaminho.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty xPathCaminhoProperty =
            DependencyProperty.Register("xPathCaminho", typeof(string), typeof(HlpUserControlBtnImage), new PropertyMetadata(string.Empty));

        public byte[] byteImage
        {
            get { return (byte[])GetValue(byteImageProperty); }
            set { SetValue(byteImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for byteImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty byteImageProperty =
            DependencyProperty.Register("byteImage", typeof(byte[]), typeof(HlpUserControlBtnImage), new PropertyMetadata(null));

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HlpImageControl wd = new HlpImageControl();

            if (this.xPathCaminho != "")
                wd.xPathImg = this.xPathCaminho;
            else
                wd.byteImg = this.byteImage;

            if (wd.ShowDialog() == true)
            {
                this.xPathCaminho = wd.xPathImg;
                this.byteImage = wd.byteImg;
            }
        }
    }
}
