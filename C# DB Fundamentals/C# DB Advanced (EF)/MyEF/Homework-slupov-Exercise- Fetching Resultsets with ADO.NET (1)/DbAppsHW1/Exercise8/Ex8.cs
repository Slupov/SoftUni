using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise8
{
    class Ex8
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(
                "Server=.;Database=MinionsDB; Integrated Security=true;MultipleActiveResultSets=true");

            Console.WriteLine("Enter the ids with seperated by spaces");
            int[] ids = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

            string dbIdSet = "(" + string.Join(",", ids) + ")";
            string query = @"UPDATE Minions
                SET Name = CONCAT(UPPER(LEFT(Name,1)),SUBSTRING(Name,2,LEN(Name)-1))
                WHERE Id IN " + dbIdSet +
                           @"UPDATE Minions
                SET Age = Age + 1
                WHERE Id IN " + dbIdSet;
                
            connection.Open();
            using (connection)
            {
                SqlCommand increaseAgeAndUppercaseNameCommand = new SqlCommand(query,connection);
                increaseAgeAndUppercaseNameCommand.ExecuteNonQuery();

                SqlCommand getAllMinions = new SqlCommand(@"SELECT Name, Age
FROM Minions",connection);
                SqlDataReader reader = getAllMinions.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " " +  reader[1]);
                }

            }
            connection.Close();
        }
    }
}