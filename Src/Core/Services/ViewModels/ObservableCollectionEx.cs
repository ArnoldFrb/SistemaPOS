using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace SistemaPOS.Src.Core.Services.ViewModels
{
    public class ObservableCollectionEx<T> : ObservableCollection<T>
    {
        public ObservableCollectionEx() : base()
        {
        }

        public ObservableCollectionEx(IEnumerable<T> collection) : base(collection)
        {
        }

        public ObservableCollectionEx(List<T> list) : base(list)
        {
        }

        public void ReloadData(IEnumerable<T> collection)
        {
            ReloadData(
                innerList =>
                {
                    foreach (var item in collection)
                    {
                        innerList.Add(item);
                    }
                });
        }

        public void ReloadData(Action<IList<T>> innerListAction)
        {
            Items.Clear();

            innerListAction(Items);

            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
            OnPropertyChanged(new PropertyChangedEventArgs("Items[]"));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public void ReloadData(Func<IList<T>, Task> innerListAction)
        {
            Items.Clear();

            innerListAction(Items);

            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
            OnPropertyChanged(new PropertyChangedEventArgs("Items[]"));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
