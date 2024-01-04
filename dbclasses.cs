using System;
using MySql.Data.MySqlClient;

public class DatabaseManager
{
    private string _connectionString;

    public DatabaseManager(string connectionString)
    {
        _connectionString = connectionString;
    }

    public MySqlConnection Connect()
    {
        MySqlConnection connection = new MySqlConnection(_connectionString);
        connection.Open();
        return connection;
    }

    public void ExecuteQuery(MySqlConnection connection)
    {
        string query = "SELECT Exibitor.name, dogs.dogname, breed.breedname FROM Dogs ";
                    query += "INNER JOIN Exibitor ON dogs.ownerid = exibitor.exid ";
                    query += "INNER JOIN Breed ON dogs.breedid=breed.breedid;";
        Console.WriteLine($"Executing {query}");
        using (MySqlCommand cmd = new MySqlCommand(query, connection))
        {
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string cnv1 = reader["name"].ToString();
                    string cnv2= reader["dogname"].ToString();
                    string cnv3= reader["breedname"].ToString();
                    Console.WriteLine($"m {cnv1}  {cnv2}  {cnv3}");
                }
            }
        }
    }

    // INSERT INTO `contest` (`Cid`, `Arena`, `Year`) VALUES (NULL, 'Halmstad dogshow', '2023');

    public void AddtoTable(MySqlConnection connection)
    {
        Console.WriteLine("Which tabel do you want to add to?");
        string query="SHOW TABLES";
        using (MySqlCommand cmd = new MySqlCommand(query, connection))
        {
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {

            }

        }
        
    }



    public void FindmyDogs(MySqlConnection connection,string owner)
    {
        string query = "SELECT Exibitor.name, dogs.dogname, breed.breedname FROM Dogs ";
                    query += "INNER JOIN Exibitor ON dogs.ownerid = exibitor.exid ";
                    query += "INNER JOIN Breed ON dogs.breedid=breed.breedid WHERE ";
                    query += "exibitor.name=" + "\'" +owner+ "\'" +";";
        Console.WriteLine($"Executing {query}");
        using (MySqlCommand cmd = new MySqlCommand(query, connection))
        {
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string cnv1 = reader["name"].ToString();
                    string cnv2= reader["dogname"].ToString();
                    string cnv3= reader["breedname"].ToString();
                    Console.WriteLine($"m {cnv1}  {cnv2}  {cnv3}");
                }
            }
        }
    }

    public void gettable(MySqlConnection connection, string query)
    {
       
        using (MySqlCommand cmd = new MySqlCommand(query, connection))
        {
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    for (int i =0; i<reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }

    public List<string> listtables(MySqlConnection connection)
    {
        string query="SHOW TABLES;";
        List<string> tables = new List<string>();
        using (MySqlCommand cmd = new MySqlCommand(query, connection))
        {
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string cnv1 = reader[0].ToString();
                    Console.WriteLine($" {cnv1}");
                    tables.Add(cnv1);
                }
            }
        }
        return tables;
    }
}