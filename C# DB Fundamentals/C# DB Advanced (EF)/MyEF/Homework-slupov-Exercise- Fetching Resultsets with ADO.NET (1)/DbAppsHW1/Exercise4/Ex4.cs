using System;
using System.Data.SqlClient;

namespace Exercise4
{
    class Ex4
    {
        static void Main()
        {
            Console.WriteLine("Enter minion name: ");
            string minionName = Console.ReadLine();

            Console.WriteLine("Enter minion age: ");
            int minionAge = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter minion town: ");
            string townName = Console.ReadLine();

            Console.WriteLine("Enter villain name: ");
            string villainName = Console.ReadLine();

            SqlConnection connection = new SqlConnection(
                "Server=.;Database=MinionsDB; Integrated Security=true;MultipleActiveResultSets=true");

            connection.Open();
            using (connection)
            {
                try
                {
                    insertTown(connection, townName);
                    insertMinion(connection, minionName, minionAge, townName);
                    insertVillain(connection, villainName);
                    insertMinionVillain(connection, villainName, minionName);
                }
                catch (Exception)
                {
                    Console.WriteLine("There was an error creating this minion.Please try again");
                    throw;
                }
               

            }
            connection.Close();

        }

        static void insertMinionVillain(SqlConnection connection,string villainName, string minionName)
        {
            int villainId = 0;
            int minionId = 0;

            SqlCommand getVillainId = new SqlCommand(@"SELECT TOP(1) Id FROM VILLAINS WHERE Name = @villainName", connection);
            getVillainId.Parameters.AddWithValue("@villainName", villainName);
            villainId = (int) getVillainId.ExecuteScalar();

            SqlCommand getMinionId = new SqlCommand(@"SELECT TOP(1) Id FROM Minions WHERE Name = @minionName ORDER BY Id DESC", connection);
            getMinionId.Parameters.AddWithValue("@minionName", minionName);
            minionId = (int)getMinionId.ExecuteScalar();


            SqlCommand addMinionVillain =
                new SqlCommand(@"INSERT INTO MinionsVillains (VillainId,MinionId) VALUES (@VillainId,@MinionId)", connection);
            addMinionVillain.Parameters.AddWithValue("@VillainId", villainId);
            addMinionVillain.Parameters.AddWithValue("@MinionId", minionId);

            addMinionVillain.ExecuteNonQuery();
            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");

        }
        static void insertMinion(SqlConnection connection, string minionName, int minionAge, string townName)
        {
            SqlCommand addMinionCommand =
                new SqlCommand(@"INSERT INTO Minions (Name,Age,TownId) VALUES (@MinionName,@MinionAge,@TownId)",connection);

            addMinionCommand.Parameters.AddWithValue("@MinionName", minionName);
            addMinionCommand.Parameters.AddWithValue("@MinionAge", minionAge);
      
 
            addMinionCommand.Parameters.AddWithValue("@TownId", getTownIdByName(connection,townName));

            addMinionCommand.ExecuteNonQuery();
        }
        static void insertTown(SqlConnection connection,string townName)
        {
            SqlCommand getTownCommand = new SqlCommand(@"SELECT *
                            FROM Towns
                            WHERE Name = @TownName", connection);

            SqlCommand insertTownCommand = new SqlCommand(@"INSERT INTO TOWNS (Name) VALUES (@TownName)", connection);

            getTownCommand.Parameters.AddWithValue("@TownName", townName);
            insertTownCommand.Parameters.AddWithValue("@TownName", townName);

            SqlDataReader getTownReader = getTownCommand.ExecuteReader();

            if (!getTownReader.HasRows)
            {
                insertTownCommand.ExecuteNonQuery();
                Console.WriteLine($"Town {townName} was added to the database.");
            }
        }

        static void insertVillain(SqlConnection connection, string villainName)
        {
            SqlCommand getVillainCommand = new SqlCommand(@"SELECT *
                            FROM Villains
                            WHERE Name = @VillainName", connection);

            SqlCommand insertVillainCommand = new SqlCommand(@"INSERT INTO Villains (Name,EvilnessFactor) VALUES (@VillainName,'evil')", connection);

            getVillainCommand.Parameters.AddWithValue("@VillainName", villainName);
            insertVillainCommand.Parameters.AddWithValue("@VillainName", villainName);

            SqlDataReader getVillainReader = getVillainCommand.ExecuteReader();

            if (!getVillainReader.HasRows)
            {
                insertVillainCommand.ExecuteNonQuery();
                Console.WriteLine($"Villain {villainName} was added to the database.");

            }
        }

        static int getTownIdByName(SqlConnection connection, string townName)
        {
            SqlCommand getIdCommand = new SqlCommand("SELECT TOP(1) Id FROM TOWNS WHERE Name = @TownName",connection);
            getIdCommand.Parameters.AddWithValue("@TownName", townName);

            int id = (int)getIdCommand.ExecuteScalar();

            return id;

        }

    }
}