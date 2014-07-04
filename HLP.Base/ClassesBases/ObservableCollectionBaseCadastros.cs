using HLP.Base.EnumsBases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Base.ClassesBases
{
    public class ObservableCollectionBaseCadastros<T> : ObservableCollection<T>
    {
        public List<int> idExcluidos;
        public string xCampoId;

        public ObservableCollectionBaseCadastros(StCollection stCollection = StCollection._default)
        {
            this.idExcluidos = new List<int>();
            this.CollectionChanged += ObservableCollectionBaseCadastros_CollectionChanged;

            if (stCollection == StCollection.enderecos)
                this.CollectionChanged += ObservableCollection_CollectionChangedEnderecos;
        }

        public ObservableCollectionBaseCadastros(IList<T> list, StCollection stCollection = StCollection._default)
            : base(list)
        {
            this.idExcluidos = new List<int>();
            this.CollectionChanged += ObservableCollectionBaseCadastros_CollectionChanged;

            if (stCollection == StCollection.enderecos)
                this.CollectionChanged += ObservableCollection_CollectionChangedEnderecos;
        }

        public void ObservableCollectionBaseCadastros_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    {
                        foreach (var item in e.NewItems)
                        {
                            if ((statusModel)item.GetType().GetProperty("status").GetValue(item) == statusModel.nenhum)
                                item.GetType().GetProperty("status").SetValue(obj: item, value: statusModel.criado);
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    {
                        object pk;
                        foreach (var item in e.OldItems)
                        {
                            foreach (var p in item.GetType().GetProperties())
                            {
                                pk = p.GetCustomAttributes(true).FirstOrDefault(i => i.GetType() == typeof(PrimaryKey));

                                if (pk != null)
                                {
                                    if (((PrimaryKey)pk).isPrimary)
                                    {
                                        int? value = (int?)(p.GetValue(obj: item));
                                        if (value != null)
                                            idExcluidos.Add(item: (int)value);
                                        break;
                                        //idExcluidos.Add(item: (int)item.GetType().GetProperty(name: xCampoId).GetValue(obj: item));
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
        }

        public void ObservableCollection_CollectionChangedEnderecos(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (this.Count == 1)
            {
                if (e.NewItems != null)
                    foreach (var item in e.NewItems)
                    {
                        item.GetType().GetProperty(name: "stPrincipal").SetValue(obj: item, value: (byte)1);
                    }
            }
        }

        public void CollectionCarregada(StCollection stCollection = StCollection._default)
        {
            if (stCollection == StCollection.enderecos)
                this.CollectionChanged += ObservableCollection_CollectionChangedEnderecos;

            this.RemoveItensExcluidos();
            foreach (var item in this.Items)
            {
                item.GetType().GetProperty("status").SetValue(item, statusModel.nenhum);
            }
        }

        private void RemoveItensExcluidos()
        {
            if (this.Items.Count(i => (statusModel)i.GetType().GetProperty("status").GetValue(obj: i)
                == statusModel.excluido) == 0)
                return;

            this.Items.Remove(this.Items.FirstOrDefault(
                i => (statusModel)i.GetType().GetProperty("status").GetValue(obj: i)
                == statusModel.excluido));

            this.RemoveItensExcluidos();
        }

        protected override void ClearItems()
        {
            if (idExcluidos == null)
                idExcluidos = new List<int>();
            object pk;
            foreach (var item in this)
            {
                foreach (var p in item.GetType().GetProperties())
                {
                    pk = p.GetCustomAttributes(true).FirstOrDefault(i => i.GetType() == typeof(PrimaryKey));

                    if (pk != null)
                    {
                        if (((PrimaryKey)pk).isPrimary)
                        {
                            int? value = (int?)(p.GetValue(obj: item));
                            if (value != null)
                                idExcluidos.Add(item: (int)value);
                            break;
                            //idExcluidos.Add(item: (int)item.GetType().GetProperty(name: xCampoId).GetValue(obj: item));
                        }
                    }
                }
            }
            base.ClearItems();
        }

    }

    public enum StCollection
    {
        _default,
        enderecos
    }
}
