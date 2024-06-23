using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExamples;
public class DataSource
{
    private readonly ObservableCollection<Student> students = new ObservableCollection<Student>();
    public IEnumerable<Student> StudentsCollection => students;

    public Student CurrentStudent { get; set; }

    
    public void AddStudent(Student student)
    {
        students.Add(student);
    }
}
