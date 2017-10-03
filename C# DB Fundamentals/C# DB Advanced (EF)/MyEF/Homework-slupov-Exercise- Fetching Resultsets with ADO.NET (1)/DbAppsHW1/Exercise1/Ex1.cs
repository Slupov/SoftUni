using System;
using System.Data.SqlClient;
using System.IO;

namespace DbAppsHW1
{
    class Ex1
    {
        public static void Main()
        {

            SqlConnection connection = new SqlConnection(
                "Server=.;Integrated Security=true");

            connection.Open();

            using (connection)
            {
                try
                {
                    string sqlCreateDB = "CREATE DATABASE MinionsDB";
                    SqlCommand createDbCommand = new SqlCommand(sqlCreateDB, connection);
                    createDbCommand.ExecuteNonQuery();

                    Console.WriteLine("DATABASE CREATED");

                }
                catch (Exception)
                {
                    Console.WriteLine("DATABASE ALREADY EXISTS");
                }

            }
            connection.Close();

            SqlConnection connection2 = new SqlConnection(
                "Server=.;Integrated Security=true");

            connection2.Open();

            using (connection2)
            {
                string query = File.ReadAllText("../../InitialSetup.sql");
                try
                {
                    SqlCommand createTablesCommand = new SqlCommand(query, connection2);
                    createTablesCommand.ExecuteNonQuery();

                    Console.WriteLine("Tables created!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Tables already exist!");
                }
                
            }
            connection2.Close();
        }

    }
}
