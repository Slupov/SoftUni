using System;
using System.Data.SqlClient;

namespace Exercise3
{
    class Ex3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter villain id: ");
            int villainId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(
                "Server=.;Database=MinionsDB; Integrated Security=true");

            connection.Open();
            using (connection)
            {
                string query = $@"SELECT v.Name as [VillainName],
                        m.Name as [MinionName],
                        m.Age as [MinionAge]
                        FROM Villains as v
                        JOIN MinionsVillains as mv on v.Id = mv.VillainId
                        JOIN Minions as m on m.Id = mv.MinionId
                        WHERE v.Id = {villainId}";

                SqlCommand getVillainInfoCommand = new SqlCommand(query, connection);
                SqlDataReader villainReader = getVillainInfoCommand.ExecuteReader();

                int row = 0;

                while (villainReader.Read())
                {
                    if (row == 0)
                    {
                        Console.WriteLine("Villain: " + villainReader[0]);
                        row++;
                        Console.WriteLine($"{row}. {villainReader[1]} {villainReader[2]}");
                        continue;
                    }
                    else
                    {
                        row++;
                        Console.WriteLine($"{row}. {villainReader[1]} {villainReader[2]}");
                        
                    }
                    
                }
            }
        }
    }
}

