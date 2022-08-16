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

            //If we are here,the above query has ended!
            string infoQuery = @"SELECT [FirstName],[LastName],[JobTitle] FROM [Employees]";

            SqlCommand infoCommand = new SqlCommand(infoQuery, sqlConnection);
            using SqlDataReader employeeReader = infoCommand.ExecuteReader();
            int rowNum = 1; 

            while (employeeReader.Read())
            {
                string firstName = (string)employeeReader["FirstName"];
                string lastName = (string)employeeReader["LastName"];
                string jobTitle = (string)employeeReader["JobTitle"];

                Console.WriteLine($"##{rowNum++}. {firstName} {lastName} - {jobTitle}");
               
            }
            
            //Close the connection
            employeeReader.Close();
            sqlConnection.Close();


            //Just for debugging
            Console.WriteLine("Connection completed!");
            Console.WriteLine("Press any key to continue!");


        }
    }
}
