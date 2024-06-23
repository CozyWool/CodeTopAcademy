
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCollectionWpfApp;
public class DataSource
{
    private readonly ICollection<Student> studentCollection =
        new ObservableCollection<Student>();

    public IEnumerable<Student> StudentCollection => studentCollection;

    public void AddValueToStudentCollection(Student student)
    {
        studentCollection.Add(student);
    }
}
