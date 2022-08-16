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


            //Then we create a query
            string query = "SELECT COUNT(*) AS [EmployeeCount] FROM [Employees]";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            //Execute command
            int employeeCount = (int)command.ExecuteScalar();
            Console.WriteLine(employeeCount);
            Console.WriteLine("----------------------------------------");


            //Just for debugging
            Console.WriteLine("Connection completed!");
            Console.WriteLine("Press any key to continue!");


        }
    }
}
