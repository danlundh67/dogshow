using System;
using System.Drawing.Printing;
using MySql.Data.MySqlClient;
class Program
{
    static void Main()
    {
        //Password=your_password;
        string connectionString = "Server=127.0.0.1;Database=dogshow;User ID=root;";
        string qnr="";
        // Create an instance of DatabaseManager
        DatabaseManager databaseManager = new DatabaseManager(connectionString);

        Console.WriteLine("Which query do you want to run ?");
        Console.WriteLine("1. get all dogs, their owners, and breed");
        Console.WriteLine("2. Get contents of a table");
        Console.WriteLine("3. Search a owners dogs");
        Console.WriteLine("4. Add to a table");
        qnr=Console.ReadLine()+"";
        // Use the Connect method to establish the connection
        using (MySqlConnection connection = databaseManager.Connect())
        {
            try
            {
                Console.WriteLine("Connection successful!");
                if (qnr=="1") 
                {
                    // Example queries ( gets the dogs and their owners and breed )
                    
                    databaseManager.ExecuteQuery(connection);
                }
                else if (qnr=="2")
                {
                    List<string> tables = new List<string>();
                    Console.WriteLine("Which  table do you want to view?");
                    tables=databaseManager.listtables(connection);
                    string selecedtable = Console.ReadLine() +"";
                    string query = "SELECT * FROM " + selecedtable +";";
                    databaseManager.gettable(connection,query);
                }
                else if (qnr=="3")
                {
                    Console.WriteLine("Which exhibitor do you want to search for? :");
                    string owner=Console.ReadLine()+"";
                    databaseManager.FindmyDogs(connection,owner);

                }
                else if (qnr=="4")
                {
                    
                }
                //databaseManager.ExecuteQuery(connection, "SELECT * FROM exibitor;");

                // Continue executing more queries or performing other operations using the same connection

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}