using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Resources.RecursosBases;

namespace HLP.Comum.Model.Models
{
    public class ObservableCollectionBaseCadastros<T> : ObservableCollection<T>
    {
        public List<int> idExcluidos;
        public string xCampoId;

        public ObservableCollectionBaseCadastros()
        {
            this.idExcluidos = new List<int>();
            this.CollectionChanged += ObservableCollectionBaseCadastros_CollectionChanged;
        }

        public ObservableCollectionBaseCadastros(IList<T> list)
            : base(list)
        {
            this.idExcluidos = new List<int>();
            this.CollectionChanged += ObservableCollectionBaseCadastros_CollectionChanged;
        }

        void ObservableCollectionBaseCadastros_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
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
                        foreach (var item in e.OldItems)
                        {
                            idExcluidos.Add(item: (int)item.GetType().GetProperty(name: xCampoId).GetValue(obj: item));
                        }
                    }
                    break;
            }
        }
    }
}
