using System;
using System.Data.SqlClient;

namespace LiveDemo
{
    public class StartUp
    {
        static void Main()
        {
            
            //Created connection
            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            //Open connection
            sqlConnection.Open();
            //Connected
            string query = "SELECT COUNT(*) FROM [Employees]";

            //Then we create a query
            SqlCommand command = new SqlCommand(query, sqlConnection);


            //Just for debugging
            Console.WriteLine("Connection completed!");
            Console.WriteLine("Press any key to continue!");


        }
    }
}
