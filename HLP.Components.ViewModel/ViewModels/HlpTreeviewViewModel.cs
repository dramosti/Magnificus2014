using HLP.Components.Model.Models;
using HLP.Components.ViewModel.Commands;
using HLP.Comum.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace HLP.Components.ViewModel.ViewModels
{
    public class HlpTreeviewViewModel : viewModelComum<TreeViewItem>
    {
        HlpTreeviewCommands comm;
        public Func<List<modelToTreeView>> fGetHierarquia { get; set; }
        BackgroundWorker bw;

        private string _selectedValue;

        public string selectedValue
        {
            get { return _selectedValue; }
            set { _selectedValue = value; }
        }


        private object _contentHierarquia;

        public object contentHierarquia
        {
            get { return _contentHierarquia; }
            set
            {
                _contentHierarquia = value;
                base.NotifyPropertyChanged(propertyName: "contentHierarquia");
            }
        }


        public HlpTreeviewViewModel()
        {
            comm = new HlpTreeviewCommands(objViewModel: this);
            this.bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                throw new Exception(message: e.Error.Message);
            }
            else
            {
                TreeViewItem tviFirstNode = new TreeViewItem();
                this.BuildHieraquia(_Nodes: e.Result as List<modelToTreeView>, tvi: tviFirstNode);

                TreeView tv = new TreeView();
                tv.Items.Add(newItem: tviFirstNode);

                this.SelectNode(nodes: tv.Items);

                this.contentHierarquia = tv;
            }
        }

        private void SelectNode(ItemCollection nodes)
        {
            if (nodes == null)
                return;

            foreach (TreeViewItem n in nodes)
            {
                if ((n.Tag == null ? string.Empty : n.Tag).ToString() == this.selectedValue)
                {
                    n.IsSelected = true;
                    this.ExpandNode(nd: n);
                    return;
                }
                else
                    this.SelectNode(nodes: n.Items);
            }
        }

        private void ExpandNode(TreeViewItem nd)
        {
            if (nd.Parent.GetType() == typeof(TreeView))
            {
                nd.IsExpanded = true;
                return;
            }
            else
            {
                nd.IsExpanded = true;
                this.ExpandNode(nd: nd.Parent as TreeViewItem);
            }
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            List<modelToTreeView> vNodes = fGetHierarquia.Invoke();
            e.Result = vNodes;
        }

        public void GetHierarquia()
        {
            this.bw.RunWorkerAsync();
        }

        public void BuildHieraquia(List<modelToTreeView> _Nodes, TreeViewItem tvi)
        {
            TreeViewItem currentTreeViewItem;
            StackPanel stk = null;
            TextBlock txt = null;
            BitmapImage img = null;
            Image ndImg = null;

            if (_Nodes != null)
                foreach (modelToTreeView n in _Nodes)
                {
                    if (n != null)
                    {
                        stk = new StackPanel();
                        stk.Orientation = Orientation.Horizontal;

                        if (!string.IsNullOrEmpty(value: n.xNameImage))
                        {
                            if (File.Exists(path: n.xNameImage))
                                img = new BitmapImage(uriSource: new Uri(uriString: n.xNameImage));
                        }
                        ndImg = new Image();
                        ndImg.Source = img;
                        ndImg.Width = ndImg.Height = 16;
                        stk.Children.Add(element: ndImg);

                        txt = new TextBlock();
                        txt.Text = string.Format(format: "{0} - {1}", arg0: n.xIdAlternativo, arg1: n.xDisplay);
                        stk.Children.Add(element: txt);

                        currentTreeViewItem = new TreeViewItem();
                        currentTreeViewItem.Header = stk;
                        currentTreeViewItem.Tag = n.xIdAlternativo;
                        tvi.Items.Add(newItem: currentTreeViewItem);
                        if (n.lFilhos.Count > 0)
                            BuildHieraquia(_Nodes: n.lFilhos, tvi: currentTreeViewItem);
                    }
                }
        }

        public void ClearHierarquia()
        {
            this.contentHierarquia = null;
        }
    }
}
