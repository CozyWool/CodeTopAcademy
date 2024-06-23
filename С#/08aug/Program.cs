using _08aug;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;
using JsonFormatting = Newtonsoft.Json.Formatting;

XmlSerialize();
JsonSerialize();


static void XmlSerialize()
{
    List<Person> people = new()
    {
        new Person(0,"John",30),
        new Person(10,"Alex",20)
    };
    Console.WriteLine("\nXml\n\nДо сериализации:");
    foreach (var person in people)
    {
        Console.WriteLine(person);
    }

    using var fs = new FileStream("XmlPerson.xml", FileMode.Create, FileAccess.Write);
    var xmlSerializer = new XmlSerializer(typeof(List<Person>));
    var xmlWrtier = XmlWriter.Create(fs, new XmlWriterSettings { Indent = false });
    Console.WriteLine("Форматировать xml? (Y/N)");
    var answer = char.Parse(Console.ReadLine()) == 'Y';
    if (answer)
    {
        xmlSerializer.Serialize(fs, people);
    }
    else
    {
        xmlSerializer.Serialize(xmlWrtier, people);
    }
    fs.Close();

    Console.WriteLine("\nДесериализация:");
    var fsRead = new FileStream("XmlPerson.xml", FileMode.Open, FileAccess.Read);
    var deserializedList = (List<Person>)xmlSerializer.Deserialize(fsRead);
    foreach (var person in deserializedList)
    {
        Console.WriteLine(person);
    }
}
static void JsonSerialize()
{
    List<Person> people = new()
    {
        new Person(0,"John",30),
        new Person(10,"Alex",20)
    };
    Console.WriteLine("\nJson\n\nДо сериализации:");
    foreach (var person in people)
    {
        Console.WriteLine(person);
    }

    Console.WriteLine("Форматировать json? (Y/N)");
    var answer = char.Parse(Console.ReadLine()) == 'Y';
    string json;
    if (answer)
    {
        json = JsonConvert.SerializeObject(people, JsonFormatting.Indented);
    }
    else
    {
        json = JsonConvert.SerializeObject(people, JsonFormatting.None);
    }
    Console.WriteLine($"Json string:\n{json}");
    Console.WriteLine("\nДесериализация:");

    var deserializedList = JsonConvert.DeserializeObject<List<Person>>(json);
    foreach (var person in deserializedList)
    {
        Console.WriteLine(person);
    }
}
