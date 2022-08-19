using System;
using System.Data.SqlClient;
using System.Text;

namespace Villain_Names
{
    public class StartUp
    {
        static void Main()
        {
            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);

            sqlConnection.Open();

            string result = GetVillainsNamesWithMinionsCount(sqlConnection);
            Console.WriteLine(result);

            sqlConnection.Close();
        }

        
        private static string GetVillainsNamesWithMinionsCount(SqlConnection sqlConnection)
        {
            StringBuilder output = new StringBuilder();
            string query = @"SELECT 
	                            [v].[Name],
	                            COUNT([mv].[MinionId])
	                            AS [MinionsCount]
                                FROM [Villains]
                                  AS [v]
                                LEFT JOIN[MinionsVillains] AS[mv] ON v.[Id] = mv.[VillainId]
                                GROUP BY [v].Name
                                HAVING COUNT([mv].[MinionId]) > 3
                                ORDER BY [MinionsCount]";

            SqlCommand command = new SqlCommand(query,sqlConnection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                output.AppendLine($"{reader["Name"]} - {reader["MinionsCount"]}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
