using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Villain_Names;

namespace AddMinion
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            //Task:Add Minion.
            //Write a program that reads information about a minion and its villain and adds it to the database.
            //In case the town of the minion is not in the database, insert it as well.
            //In case the villain is not present in the database, add him too with a default evilness factor of "evil".
            //Finally set the new minion to be a servant of the villain. Print appropriate messages after each operation.
            string[] minionInfo = Console.ReadLine()!
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)[1]
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            string villainName = Console.ReadLine()!
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)[1];
            

            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            sqlConnection.Open();

            string result = AddMinions(sqlConnection,minionInfo,villainName);
            Console.WriteLine(result);
            
            sqlConnection.Close();

        }

        private static string AddMinions(SqlConnection sqlConnection, string[] minionInfo,string villainName)
        {
            StringBuilder output = new StringBuilder();
            
            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string minionTown = minionInfo[2];

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                int townId = GetTownId(sqlConnection, sqlTransaction, output, minionTown);
                int villainId = GetVillainId(sqlConnection, sqlTransaction, output, villainName);

                
            }
            catch (Exception exception)
            {
                sqlTransaction.Rollback();
                return exception.Message;
            }

            return output.ToString().TrimEnd();
        }

        private static int GetVillainId(SqlConnection sqlConnection, SqlTransaction sqlTransaction, StringBuilder output, string villainName)
        {
            string villainIdQuery = @"SELECT [Id]
                                            FROM [Villains]
                                           WHERE [Name] = @VillainName";

            SqlCommand villainIdCommand = new SqlCommand(villainIdQuery, sqlConnection, sqlTransaction);

            villainIdCommand.Parameters.AddWithValue("@VillainName", villainName);

            object villainIdObj = villainIdCommand.ExecuteScalar();

            if (villainIdObj == null)
            {
                string evilnessFactorQuery = @"INSERT INTO [Villains]([Name], [EvilnessFactorId]) 
                                                 VALUES ('@evilnessFactor',4)";

                SqlCommand addEvilnessFactor = new SqlCommand(evilnessFactorQuery, sqlConnection, sqlTransaction);

                addEvilnessFactor.Parameters.AddWithValue("@VillainName", villainName);
                addEvilnessFactor.ExecuteNonQuery();
                output.AppendLine($"Villain {villainName} was added to the database.");

                villainIdObj = villainIdCommand.ExecuteScalar();
            }

            return (int)villainIdObj;
        }

        private static int GetTownId(SqlConnection sqlConnection, SqlTransaction sqlTransaction, StringBuilder output,
            string townName)
        {
            
            string townNameQuery = @"SELECT [Id]
                                       FROM [Towns]
                                      WHERE [Name] = @TownName";

            SqlCommand townIdCommand = new SqlCommand(townNameQuery, sqlConnection, sqlTransaction);
            townIdCommand.Parameters.AddWithValue("@TownName", townName);

            object townIdObj = townIdCommand.ExecuteScalar();

            if (townIdObj == null)
            {
                string addTownQuery = @"INSERT INTO [Towns]([Name]) 
                                                 VALUES ('@TownName')";

                SqlCommand addTownCommand = new SqlCommand(addTownQuery, sqlConnection, sqlTransaction);
                addTownCommand.Parameters.AddWithValue("@TownName", townName);
                addTownCommand.ExecuteNonQuery();
                output.AppendLine($"Town {townName} was added to the database.");

                townIdObj = townIdCommand.ExecuteScalar();
            }



            return (int)townIdObj;
        }
    }
}
