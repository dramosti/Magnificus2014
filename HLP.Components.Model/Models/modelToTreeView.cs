using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace HLP.Components.Model.Models
{
    public class modelToTreeView
    {
        public int id { get; set; }
        public string xDisplay { get; set; }
        public List<modelToTreeView> lFilhos = new List<modelToTreeView>();
        public string xNameImage { get; set; }
        private BitmapImage image;
        private StackPanel panel;
        private Image img;
        private TextBlock txt;

        public void MontaHierarquia(modelToTreeView m, TreeViewItem tvi)
        {
            if (m != null)
            {

                Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    m.panel = new StackPanel();
                    m.panel.Orientation = Orientation.Horizontal;
                    if (m.xNameImage != "")
                    {
                        string sPath = System.AppDomain.CurrentDomain.BaseDirectory + @"Icones\" + m.xNameImage + ".png";
                        if (File.Exists(path: sPath))
                        {
                            m.image = new BitmapImage(new Uri(sPath));
                        }
                    }
                    m.img = new Image();
                    m.img.Source = m.image;
                    m.img.Width = 16;
                    m.img.Height = 16;
                    m.img.Margin = new Thickness(0, 0, 10, 0);
                    m.txt = new TextBlock();
                    m.txt.Text = m.id + ". " + m.xDisplay.ToUpper();
                    m.panel.Children.Add(m.img);
                    m.panel.Children.Add(m.txt);
                    tvi.Header = m.panel;
                    tvi.IsExpanded = true;
                }));

                TreeViewItem i = null;

                foreach (modelToTreeView item in m.lFilhos)
                {
                    Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        i = new TreeViewItem();
                        item.panel = new StackPanel();
                        item.panel.Orientation = Orientation.Horizontal;
                        if (item.xNameImage != "")
                        {
                            string sPath = System.AppDomain.CurrentDomain.BaseDirectory + @"Icones\" + item.xNameImage + ".png";
                            if (File.Exists(path: sPath))
                            {
                                item.image = new BitmapImage(new Uri(sPath));
                            }
                        }
                        item.img = new Image();
                        item.img.Source = item.image;
                        item.img.Width = 16;
                        item.img.Height = 16;
                        item.img.Margin = new Thickness(0, 0, 10, 0);
                        item.txt = new TextBlock();
                        item.txt.Text = item.id + ". " + item.xDisplay.ToUpper();
                        item.panel.Children.Add(item.img);
                        item.panel.Children.Add(item.txt);
                        i.Header = item.panel;
                        i.IsExpanded = true;

                        tvi.Items.Add(newItem: i);

                        if (item.lFilhos != null)
                            if (item.lFilhos.Count > 0)
                                this.MontaHierarquia(m: item,
                                    tvi: i);
                    }));
                }


            }
        }
    }
}
