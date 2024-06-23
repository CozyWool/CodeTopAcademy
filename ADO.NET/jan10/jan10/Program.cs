using Npgsql;
using System.Configuration;

var connStr = "Host=localhost;Port=5432;Username=postgres;Password=d3k7f4l8b5r4;Database=jan08";
using var conn = new NpgsqlConnection(connStr);
conn.Open();

//var query = "SELECT id, name, age FROM students;\r\nSELECT id, name FROM subjects;";
//var cmd = new NpgsqlCommand(query, conn);

//var reader = cmd.ExecuteReader();

//do
//{
//    while (reader.Read())
//    {
//        Console.WriteLine($"{reader[0]}, {reader[1]}");
//    }    

//} while (reader.NextResult());

var name = "Qwerty";
var age = 42;
var query = "INSERT INTO students (name, age) " +
            "VALUES(@p1, @p2)";
var cmd = new NpgsqlCommand(query, conn);
var p1 = new NpgsqlParameter("@p1", name)
{
    DbType = System.Data.DbType.String
};
var p2 = new NpgsqlParameter("@p2", age)
{
    DbType = System.Data.DbType.Int32
};

cmd.Parameters.Add(p1);
cmd.Parameters.Add(p2);
