using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    class Ex2
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection(
                "Server=.;Database=MinionsDB; Integrated Security=true");

            connection.Open();
            using (connection)
            {
                SqlCommand getVillainsNames = new SqlCommand(@"SELECT v.Name, COUNT(mv.MinionId) as [MinionCount]
                  FROM Villains as v
                  JOIN MinionsVillains as mv on v.Id = mv.VillainId
                  GROUP BY v.Name",connection);
                SqlDataReader villainsReader = getVillainsNames.ExecuteReader();
                Console.WriteLine(new string('-',15) + "-+-" + new string('-', 15));
                while (villainsReader.Read())
                {
                    Console.WriteLine($"{villainsReader[0],-15} | {villainsReader[1]}");
                }

            }
            connection.Close();

        }
    }
}
