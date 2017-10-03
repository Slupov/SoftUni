using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise9
{
    class Ex9
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(
               "Server=.;Database=MinionsDB; Integrated Security=true;MultipleActiveResultSets=true");
            Console.WriteLine("Type the id of the minion you want to make older:");
            int id = int.Parse(Console.ReadLine());

            connection.Open();
            using (connection)
            {
                SqlCommand ageMinion = new SqlCommand("EXEC usp_GetOlder " + id, connection);
                ageMinion.ExecuteNonQuery();

                SqlCommand getMinion = new SqlCommand("SELECT TOP(1) Name,Age FROM Minions WHERE Id = " + id, connection);
                SqlDataReader reader = getMinion.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " " + reader[1]);
                }

            }
            connection.Close();
        }
    }
}
