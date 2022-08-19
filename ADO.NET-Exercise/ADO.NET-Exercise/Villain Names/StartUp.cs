using System;
using System.Data.SqlClient;

namespace Villain_Names
{
    public class StartUp
    {
        static void Main()
        {
            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);

            sqlConnection.Open();

            Console.WriteLine("Connected successfully");

            sqlConnection.Close();
        }
    }
}
