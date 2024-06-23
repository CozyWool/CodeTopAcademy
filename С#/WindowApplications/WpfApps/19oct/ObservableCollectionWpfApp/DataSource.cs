using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableCollectionWpfApp;
public class DataSource
{
    private readonly ICollection<int> nonNotifiableCollection = 
        new List<int> { 1, 2, 3 };
    private readonly ICollection<int> notifiableCollection = 
        new ObservableCollection<int>(new[] { 1, 2, 3 });

    public IEnumerable<int> NonNotifiableCollection => nonNotifiableCollection;
    public IEnumerable<int> NotifiableCollection => notifiableCollection;

    public void AddValueToNonNotifiableCollection()
    {
        nonNotifiableCollection.Add(nonNotifiableCollection.Count + 1);
    }
    public void AddValueToNotifiableCollection()
    {
        notifiableCollection.Add(notifiableCollection.Count + 1);
    }
}
