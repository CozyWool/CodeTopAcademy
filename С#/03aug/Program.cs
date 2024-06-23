using _03aug;
using System.Text;

var filePath = "test.dat";
//WriteBinaryExample(filePath);
//ReadBinaryExample(filePath);
//ReadPngExample();
//DirectoryExample();
//FileExample();
DirectoryExplorerExample();

static void WriteBinaryExample(string filePath)
{
    var fs = new FileStream(filePath, FileMode.Create);
    var bw = new BinaryWriter(fs, Encoding.Unicode);
    bw.Write(46);
    bw.Write(Math.PI);
    bw.Write("Hello world!");
    bw.Write(true);
    bw.Close();
}
static void ReadBinaryExample(string filePath)
{
    var fs = new FileStream(filePath, FileMode.Open);
    var bw = new BinaryReader(fs, Encoding.Unicode);
    var intValue = bw.ReadInt32();
    var doubleValue = bw.ReadDouble();
    var stringValue = bw.ReadString();
    var boolValue = bw.ReadBoolean();
    Console.WriteLine(intValue);
    Console.WriteLine(doubleValue);
    Console.WriteLine(stringValue);
    Console.WriteLine(boolValue);
}
static void ReadPngExample()
{
    var fileName = "test-picture.png";

    //var fs = new FileStream(fileName, FileMode.Open);
    //var br = new BinaryReader(fs);
    //fs.Seek(1, SeekOrigin.Begin);
    //var bytes = br.ReadBytes(3);
    //var pngText = Encoding.ASCII.GetString(bytes);
    //Console.WriteLine(pngText);
    //br.Close();

    //Ключевое слово using, можно использовать только для IDisposable
    using var fs = new FileStream(fileName, FileMode.Open);
    using var br = new BinaryReader(fs);
    fs.Seek(1, SeekOrigin.Begin);
    var bytes = br.ReadBytes(3);
    var pngText = Encoding.ASCII.GetString(bytes);
    Console.WriteLine(pngText);
    //br.Close(); Уже не нужно из-за using

    ////Развертка using
    //FileStream fs = null;
    //BinaryReader br = null;
    //try
    //{
    //    fs = new FileStream(fileName, FileMode.Open);
    //    br = new BinaryReader(fs);
    //    fs.Seek(1, SeekOrigin.Begin);
    //    var bytes = br.ReadBytes(3);
    //    var pngText = Encoding.ASCII.GetString(bytes);
    //    Console.WriteLine(pngText);
    //}
    //finally
    //{
    //    fs.Close();
    //    br.Close();
    //}
}
static void DirectoryExample()
{
    var directoryPath = @"D:\CodeITStep\С#\03aug\bin\Debug\net6.0";
    DirectoryInfo dir = Directory.CreateDirectory(Path.Combine(directoryPath, "DirectoryExample"));
}
static void FileExample()
{
    var directoryPath = @"D:\CodeITStep\С#\03aug\bin\Debug\net6.0";
    File.Create(Path.Combine(directoryPath, "DirectoryExample", "emptyFile.txt"));
}
static void DirectoryExplorerExample()
{
    var directoryPath = @"D:\CodeITStep\С#\03aug";
    DirectoryExplorer.Print(directoryPath);
}