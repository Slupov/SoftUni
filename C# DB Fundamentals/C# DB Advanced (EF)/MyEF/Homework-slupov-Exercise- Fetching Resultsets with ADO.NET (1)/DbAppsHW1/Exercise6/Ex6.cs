using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    class Ex6
    {
        static void Main()
        {
            Console.WriteLine("Enter id of a villian you want to delete: ");
            int villainId = int.Parse(Console.ReadLine());
            SqlConnection connection = new SqlConnection(
                "Server=.;Database=MinionsDB; Integrated Security=true;MultipleActiveResultSets=true");

            connection.Open();
            using (connection)
            {
                SqlCommand releaseDependencies =
                    new SqlCommand(@"DELETE FROM MinionsVillains WHERE VillainId = " + villainId, connection);

                int releasedMinions = releaseDependencies.ExecuteNonQuery();
                string villainName = "";

                SqlCommand getDeletedVillainName =
                    new SqlCommand(@"SELECT TOP(1)  Name FROM Villains WHERE Id = " + villainId, connection);
                SqlDataReader reader = getDeletedVillainName.ExecuteReader();

                while (reader.Read())
                {
                    villainName = (string) reader[0];
                }

                if (villainName == "")
                {
                    Console.WriteLine("No such villain was found");
                }
                else
                {
                    SqlCommand deleteVillain =
                        new SqlCommand(@"DELETE FROM Villains WHERE Id = " + villainId, connection);
                    deleteVillain.ExecuteNonQuery();

                    Console.WriteLine(villainName + " was deleted");
                    Console.WriteLine(releasedMinions + " minions released");
                }
            }
            connection.Close();
        }
    }
}