using System.Text;
using System.Text.RegularExpressions;

using StreamReader sr = new("TestProgram.txt");
using StreamWriter sw = new("NewTestProgram.txt");
List<string> lines = new List<string>();

while (!sr.EndOfStream)
{
    string line = sr.ReadLine();
    line = line.Replace("public", "private");
    line = Regex.Replace(line, @"\s+", " ");

    var sb = new StringBuilder();
    foreach(var word in line.Split(' '))
    {
        sb.Append($"{(word.Length > 2 ? word.ToUpper() : word)} ");
    }
    line = sb.ToString().TrimEnd();


    //line = string.Join(" ",line.Split(" ").Where(s => s.Length > 2).Select(s => s.ToUpper()));
    lines.Add(line);
    Console.WriteLine(line);
}
lines.Reverse();
foreach (string line in lines)
{
    sw.WriteLine(line);
}