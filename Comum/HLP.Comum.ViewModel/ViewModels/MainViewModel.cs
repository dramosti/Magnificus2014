using HLP.Comum.Model.Models;
using HLP.Comum.Modules;
using HLP.Comum.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Forms;
using HLP.Comum.Infrastructure.Static;
using System.IO;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace HLP.Comum.ViewModel.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Assinatura de comandos
        public ICommand AddWindowCommand { get; set; }
        public ICommand DelWindowCommand { get; set; }
        public ICommand pesquisarBaseCommand { get; set; }



        #endregion

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

        public MainViewModel()
        {
            MainCommands objCommands = new MainCommands(objTabPagesAtivasViewModel: this);
            this._lTabPagesAtivas = new ObservableCollection<TabPagesAtivasModel>();
            this._lWindows = new ObservableCollection<windowsModel>();
            windowsModel objWindow;

            foreach (var item in Modulo.lobjectModulo)
            {
                foreach (var win in item.lFormularios)
                {
                    objWindow = new windowsModel();
                    objWindow.xName = win.xId;
                    objWindow.xHeader = win.xName.Replace('_', ' ');
                    this.lWindows.Add(item: objWindow);
                }
            }

            this.lMenu = new List<MenuItemModel>();
            string s;
            bool v = true;
            string header;
            int count = 0;
            try
            {
                foreach (var item in Modulo.lobjectModulo)
                {
                    foreach (var win in item.lFormularios)
                    {
                        List<string> lSeparadores = win.xType.ToString().Split(',')[0].Split('.').ToList();
                        header = win.xName;
                        v = true;
                        s = lSeparadores.FirstOrDefault(i => i.ToString() == "HLP");
                        if (s != null)
                            lSeparadores.RemoveAt(lSeparadores.IndexOf(s));
                        else
                            v = false;

                        s = lSeparadores.FirstOrDefault(i => i.ToString() == "View");
                        if (s != null)
                            lSeparadores.RemoveAt(lSeparadores.IndexOf(s));
                        else
                            v = false;

                        s = lSeparadores.FirstOrDefault(i => i.ToString() == "WPF");
                        if (s != null)
                            lSeparadores.RemoveAt(lSeparadores.IndexOf(s));
                        else
                            v = false;

                        if (v)
                        {
                            this.currentMenu = this.lMenu;
                            count = 0;
                            foreach (string menuItem in lSeparadores)
                            {
                                count++;
                                AddMenuItem(xNome: menuItem, xHeader: header, bLast: count < lSeparadores.Count ? false : true);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


        }



        #region Criação de Menu

        private List<MenuItemModel> currentMenu;

        private List<MenuItemModel> _lMenus;

        public List<MenuItemModel> lMenu
        {
            get { return _lMenus; }
            set { _lMenus = value; }
        }

        private void AddMenuItem(string xNome, string xHeader, bool bLast)
        {
            if (currentMenu.Count(i => i.xName == xNome) < 1)
            {
                this.currentMenu.Add(item:
                    new MenuItemModel
                    {
                        xHeader = bLast ? xHeader : xNome,
                        xName = xNome,
                        lItens = new List<MenuItemModel>()
                    });
            }

            this.currentMenu = this.currentMenu.FirstOrDefault(i => i.xName == xNome).lItens;
        }

        public void CarregaMenu(System.Windows.Controls.Menu m)
        {
            try
            {
                this.AddMenusItens(lMenuItens: this.lMenu, menuItem: m.Items);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void AddMenusItens(List<MenuItemModel> lMenuItens, ItemCollection menuItem)
        {
            foreach (MenuItemModel it in lMenuItens)
            {
                System.Windows.Controls.MenuItem mi = new System.Windows.Controls.MenuItem();

                if (File.Exists(path: System.AppDomain.CurrentDomain.BaseDirectory + @"Icones\" + it.xName + ".png"))
                {
                    mi.Icon = 
                    new System.Windows.Controls.Image
                    {
                        Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + @"Icones\" + it.xName + ".png"))
                    };
                    //Bitmap bmp = (Bitmap)System.Drawing.Image.FromFile(filename: System.AppDomain.CurrentDomain.BaseDirectory + @"Icones\" + it.xName + ".png");
                    //Icon ic = Icon.FromHandle(bmp.GetHicon());
                    //mi.Icon = ic;
                }


                mi.Header = it.xHeader;
                mi.Command = this.AddWindowCommand;
                mi.CommandParameter = it.xName;
                menuItem.Add(newItem: mi);
                if (it.lItens.Count > 0)
                    AddMenusItens(lMenuItens: it.lItens, menuItem: mi.Items);
            }
        }

        #endregion

        private string getHeaderWindow(string xNomeForm)
        {
            Window w;
            try
            {
                w = GerenciadorModulo.Instancia.CarregaForm(nome: xNomeForm.ToString(),
                exibeForm: Modules.Interface.TipoExibeForm.Modal);
                return w != null ? w.Title : xNomeForm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                w = null;
            }
        }
    }
}
