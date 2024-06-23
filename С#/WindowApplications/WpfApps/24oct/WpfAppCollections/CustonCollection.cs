using System.Collections.Generic;
using System.Collections.Specialized;

namespace WpfAppCollections;
public class CustonCollection<T> : INotifyCollectionChanged
    where T : class
{
    private readonly List<T> _items = new List<T>();

    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    public void Add(T item)
    { 
        _items.Add(item);
        CollectionChanged?.Invoke(
            this, 
            new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
    }

    public void Remove(T item)
    {
        _items.Remove(item);
        CollectionChanged?.Invoke(
            this,
            new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));

    }
}
