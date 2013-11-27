﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Resources.RecursosBases;
using HLP.Comum.Infrastructure;

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
                                        idExcluidos.Add(item: (int)(p.GetValue(obj: item)));
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

        public void CollectionCarregada()
        {
            foreach (var item in this.Items)
            {
                item.GetType().GetProperty("status").SetValue(item, statusModel.nenhum);
            }
        }
    }
}
