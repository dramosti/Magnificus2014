using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using HLP.Base.Static;

namespace HLP.ComumView.Model.Model
{
    public class WinManModel : modelBase
    {
        private BitmapImage _iconConexao;
        public BitmapImage iconConexao
        {
            get { return _iconConexao; }
            set { _iconConexao = value; base.NotifyPropertyChanged("iconConexao"); }
        }

        private string _sToolTipConexao;
        public string sToolTipConexao
        {
            get { return _sToolTipConexao; }
            set { _sToolTipConexao = value; base.NotifyPropertyChanged("sToolTipConexao"); }
        }

        private ObservableCollection<TabPagesAtivasModel> lTabPagesAtivas;
        public ObservableCollection<TabPagesAtivasModel> _lTabPagesAtivas
        {
            get { return lTabPagesAtivas; }
            set
            {
                lTabPagesAtivas = value;
                base.NotifyPropertyChanged(propertyName: "_lTabPagesAtivas");
            }
        }

        private ObservableCollection<windowsModel> lWindows;
        public ObservableCollection<windowsModel> _lWindows
        {
            get { return lWindows; }
            set
            {
                lWindows = value;
                base.NotifyPropertyChanged(propertyName: "_lWindows");
            }
        }

        private TabPagesAtivasModel currentTab;
        public TabPagesAtivasModel _currentTab
        {
            get { return currentTab; }
            set
            {
                currentTab = value;
                this.NotifyPropertyChanged(propertyName: "_currentTab");
                try
                {
                    if (currentTab != null)
                        try
                        { currentTab._currentDataContext.SetPropertyValue("NameView", currentTab._windows.GetPropertyValue("NameView").ToString()); }
                        catch (Exception) { }
                }
                catch (Exception) { throw; }
            }
        }

        private Visibility _vToolBar = Visibility.Collapsed;

        public Visibility vToolBar
        {
            get { return _vToolBar; }
            set { _vToolBar = value; base.NotifyPropertyChanged("vToolBar"); }
        }

        private double _iHeightToolBar = 0;

        public double iHeightToolBar
        {
            get { return _iHeightToolBar; }
            set { _iHeightToolBar = value; base.NotifyPropertyChanged("iHeightToolBar"); }
        }
    }

}
