using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Base.ClassesBases
{
    public class MyObservableCollection<T> : ObservableCollection<T>
    {
        public MyObservableCollection()
            : base()
        {

        }

        public MyObservableCollection(List<T> list)
            : base(list)
        {

        }

        public MyObservableCollection(IEnumerable<T> collection)
            : base(collection)
        {

        }

        private System.ComponentModel.ICollectionView GetDefaultView()
        {
            return System.Windows.Data.CollectionViewSource.GetDefaultView(this);
        }

        public int CurrentPosition
        {
            get
            {
                return GetDefaultView().CurrentPosition;
            }
        }

        public void MoveFirst()
        {
            GetDefaultView().MoveCurrentToFirst();
        }

        public void MovePrevious()
        {
            GetDefaultView().MoveCurrentToPrevious();
        }

        public void MoveNext()
        {
            GetDefaultView().MoveCurrentToNext();
        }

        public void MoveLast()
        {
            GetDefaultView().MoveCurrentToLast();
        }

        public int CurrentValue
        {
            get { return ((IEnumerable<int>)GetDefaultView().SourceCollection).ToList()[CurrentPosition]; }
        }


    }

}
