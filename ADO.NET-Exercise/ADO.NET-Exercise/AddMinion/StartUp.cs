using System;
using System.Data.SqlClient;
using System.Linq;
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

            string villainInfo = Console.ReadLine()!
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)[1];

            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            sqlConnection.Open();

            string result = AddMinions(sqlConnection);
            Console.WriteLine(result);
            
            sqlConnection.Close();

        }

        private static string AddMinions(SqlConnection sqlConnection)
        {

        }
    }
}
