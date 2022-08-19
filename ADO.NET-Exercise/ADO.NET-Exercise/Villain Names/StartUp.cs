using System;
using System.Data.SqlClient;
using System.Text;

namespace Villain_Names
{
    public class StartUp
    {
        static void Main()
        {
            int villainId = int.Parse(Console.ReadLine());

            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);

            sqlConnection.Open();

            string result = GetVillainsWithMinions(sqlConnection,villainId);
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

        private static string GetVillainsWithMinions(SqlConnection sqlConnection,int villainId)
        {
            StringBuilder output = new StringBuilder();

            string villainNameQuery = @"SELECT [Name]
                                          FROM [Villains]
                                         WHERE [Id] = @VillainId";

            SqlCommand getVillainNameCommand = new SqlCommand(villainNameQuery,sqlConnection);

            getVillainNameCommand.Parameters.AddWithValue(@"VillainId", villainId);

            string villainName = (string)getVillainNameCommand.ExecuteScalar();
            if (villainName == null)
            {
                return $"No villain with ID {villainId} exists in the database.";
            }

            output.AppendLine($"Villain: {villainName}");

            string minionsQuery = @"SELECT [m].[Name],
                                           [m].[Age]
                                      FROM [MinionsVillains]
                                        AS [mv]
                                 LEFT JOIN [Minions] AS [m] ON [m].[Id] =[mv].[MinionId]
                                     WHERE [mv].[VillainId] = @VillainId
                                  ORDER BY [m].[Name]";

            SqlCommand getMinionsCommand = new SqlCommand(minionsQuery, sqlConnection);
            getMinionsCommand.Parameters.AddWithValue("@VillainId", villainId);

            using SqlDataReader minionsReader = getMinionsCommand.ExecuteReader();

            if (!minionsReader.HasRows)
            {
                output.AppendLine($"(no minions)");
            }
            else
            {
                int rowNum = 1;

                while (minionsReader.Read())
                {
                    output.AppendLine($"{rowNum}. {minionsReader["Name"]} {minionsReader["Age"]}");
                    rowNum++;
                }
            }

            return output.ToString().Trim();

        }
    }
}
