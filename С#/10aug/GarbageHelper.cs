public class GarbageHelper
{
    public void MakeGarbage(int maxGarbage)
    {
        //for ( int i = 0; i < 1000; i++ ) 
        //{
        //    var p = new Person();
        //}
        Version vt;

        for (int i = 0; i < maxGarbage; i++)
        {
            vt = new Version();
        }
    }

    private class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

    }
}
