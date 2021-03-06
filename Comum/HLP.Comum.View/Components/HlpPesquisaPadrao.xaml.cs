﻿using HLP.Components.Model.Models;
using HLP.Components.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for HlpPesquisaPadrao.xaml
    /// </summary>
    public partial class HlpPesquisaPadrao : UserControl
    {

        public HlpPesquisaPadraoViewModel ViewModel
        {
            get { return this.DataContext as HlpPesquisaPadraoViewModel; }
            set { this.DataContext = value; }
        }

        System.Windows.Forms.Timer timerFocus;
        public HlpPesquisaPadrao()
        {
            InitializeComponent();
        }

        #region Property
        [Category("HLP.Owner")]
        public string NameView
        {
            get { return (string)GetValue(NameViewProperty); }
            set
            {
                SetValue(NameViewProperty, value);
                if (value != string.Empty)
                    this.ViewModel = new HlpPesquisaPadraoViewModel(value);
            }
        }

        [Category("HLP.Owner")]
        public string NameWindowCadastro
        {
            get { return (string)GetValue(NameWindowCadastroProperty); }
            set { SetValue(NameWindowCadastroProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NameWindowCadastro.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameWindowCadastroProperty =
            DependencyProperty.Register("NameWindowCadastro", typeof(string), typeof(HlpPesquisaPadrao), new PropertyMetadata(String.Empty));



        // Using a DependencyProperty as the backing store for NameView.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameViewProperty =
            DependencyProperty.Register("NameView", typeof(string), typeof(HlpPesquisaPadrao), new PropertyMetadata(string.Empty));

        [Browsable(false)]
        [Category("HLP.Owner")]
        public List<int> lResult
        {
            get { return (List<int>)GetValue(lResultProperty); }
            set { SetValue(lResultProperty, value); }
        }
        // Using a DependencyProperty as the backing store for lResult.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty lResultProperty =
            DependencyProperty.Register("lResult", typeof(List<int>), typeof(HlpPesquisaPadrao), new PropertyMetadata(new List<int>()));


        #endregion

        #region Events
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (NameView != string.Empty)
                this.ViewModel = new HlpPesquisaPadraoViewModel(NameView);

            timerFocus = new System.Windows.Forms.Timer();
            timerFocus.Interval = 10;
            timerFocus.Tick += timerFocus_Tick;
            timerFocus.Start();
            //clCampos.Width = 150;
            //clOperador.Width = 150;
            //cleou.Width = 150;
        }
        void timerFocus_Tick(object sender, EventArgs e)
        {
            while (dgvFilter.Items.Count > 0)
            {
                Keyboard.Focus(dgvFilter);
                FocusCellInicial(dgvFilter);
                timerFocus.Stop();
                break;
            }
        }
        private void DataGridCell_GotFocus(object sender, RoutedEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            if (cell != null && !cell.IsEditing && !cell.IsReadOnly)
            {
                if (!cell.IsFocused)
                {
                    cell.Focus();
                }
                DataGrid dataGrid = FindVisualParent<DataGrid>(cell);
                if (dataGrid != null)
                {
                    if (dataGrid.SelectionUnit != DataGridSelectionUnit.FullRow)
                    {
                        if (!cell.IsSelected)
                        {
                            cell.IsSelected = true;
                            cell.IsEditing = true;
                        }

                    }
                    else
                    {
                        DataGridRow row = FindVisualParent<DataGridRow>(cell);
                        if (row != null && !row.IsSelected)
                        {
                            row.IsSelected = true;
                        }
                    }
                }
            }
        }
        private void dgvResult_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    SelectAndFinish();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (e.Key == Key.RightCtrl || e.Key == Key.LeftCtrl)
            {
                try
                {
                    this.dgvFilter.Focus();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        private void dgvResult_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (dgvResult.SelectedItems.Count == 1)
                {
                    SelectAndFinish();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Methods
        public static DataGridCell GetCell(DataGrid dataGrid, DataGridRow rowContainer, int column)
        {
            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
                if (presenter == null)
                {
                    /* if the row has been virtualized away, call its ApplyTemplate() method
                     * to build its visual tree in order for the DataGridCellsPresenter
                     * and the DataGridCells to be created */
                    rowContainer.ApplyTemplate();
                    presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
                }
                if (presenter != null)
                {
                    DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
                    if (cell == null)
                    {
                        /* bring the column into view
                         * in case it has been virtualized away */
                        dataGrid.ScrollIntoView(rowContainer, dataGrid.Columns[column]);
                        cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
                    }
                    return cell;
                }
            }
            return null;
        }
        public static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
        static T FindVisualParent<T>(UIElement element) where T : UIElement
        {
            UIElement parent = element;
            while (parent != null)
            {
                T correctlyTyped = parent as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }

                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }
            return null;
        }
        private void SelectAndFinish()
        {
            lResult = (from c in dgvResult.SelectedItems.Cast<DataRowView>()
                       select (int)c.Row["ID"]).ToList<int>();
            this.Visibility = System.Windows.Visibility.Collapsed;
        }
        private void FocusCellInicial(DataGrid dgv)
        {
            DataGridRow row = dgv.ItemContainerGenerator.ContainerFromIndex(0) as DataGridRow;
            if (row != null)
            {
                DataGridCell cell = GetCell(dgv, row, 2);
                if (cell != null)
                {
                    cell.Focus();
                }
            }
        }
        #endregion

        private void dgvResult_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.ViewModel.bIniciaFocusFirstRow)
            {
                SelectRowByIndex(sender as DataGrid, 0);
                FocusCellInicial(sender as DataGrid);
                this.ViewModel.bIniciaFocusFirstRow = false;
            }
        }

        public static void SelectRowByIndex(DataGrid dataGrid, int rowIndex)
        {
            if (!dataGrid.SelectionUnit.Equals(DataGridSelectionUnit.FullRow))
                throw new ArgumentException("The SelectionUnit of the DataGrid must be set to FullRow.");

            //if (rowIndex < 0 || rowIndex > (dataGrid.Items.Count - 1))
            //    throw new ArgumentException(string.Format("{0} is an invalid row index.", rowIndex));

            if ((int)dataGrid.Items.Count > (int)0)
            {
                if (dataGrid.SelectedItems.Count > 0)
                {
                    dataGrid.SelectedItems.Clear();
                }

                /* set the SelectedItem property */
                object item = dataGrid.Items[rowIndex]; // = Product X
                dataGrid.SelectedItem = item;

                DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
                if (row == null)
                {
                    /* bring the data item (Product object) into view
                     * in case it has been virtualized away */
                    dataGrid.ScrollIntoView(item);
                    row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
                }
            }
        }

        private void columnHeader_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                if (this.ViewModel.lFiltros == null)
                    this.ViewModel.lFiltros = new List<PesquisaPadraoModel>();

                var columnHeader = sender as DataGridColumnHeader;
                var column = dgvResult.Columns[columnHeader.DisplayIndex];
                var Path = (column as DataGridBoundColumn).Binding.GetType().GetProperty(name: "Path").GetValue(obj: (column as DataGridBoundColumn).Binding);

                this.ViewModel.lFiltros.Add(item:
                    this.ViewModel.lFilers.FirstOrDefault(i => i.COLUMN_NAME == (Path as PropertyPath).Path));
            }
        }

        private void winPesquisaPadrao_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
            {
                if (this.ViewModel.lFiltros != null)
                    if (this.ViewModel.lFiltros.Count > 0)
                    {
                        HlpPesquisaFiltrada frm = new HlpPesquisaFiltrada();
                        frm.ViewModel.lFiltros = new System.Collections.ObjectModel.ObservableCollection<PesquisaPadraoModel>(
                            collection: this.ViewModel.lFiltros);

                        frm.Height = 110 + (frm.ViewModel.lFiltros.Count * 30);

                        if (frm.ShowDialog() == true)
                        {
                            this.ViewModel.lFiltroAtivo = frm.ViewModel.lFiltros.ToList();
                            this.ViewModel.campoSelecionado = frm.ViewModel.campoSelecionado;
                            this.ViewModel.stOrdenacao = frm.ViewModel.stOrdenacao;

                            this.ViewModel.commandPesquisaFiltrada.Execute(parameter: this.dgvResult);
                        }
                        this.ViewModel.lFiltros = new List<PesquisaPadraoModel>();
                    }
            }
        }

    }
}
