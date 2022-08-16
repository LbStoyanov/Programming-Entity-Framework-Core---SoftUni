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



            //Just for debugging
            Console.WriteLine("Connection completed!");
            Console.WriteLine("Press any key to continue!");


        }
    }
}
