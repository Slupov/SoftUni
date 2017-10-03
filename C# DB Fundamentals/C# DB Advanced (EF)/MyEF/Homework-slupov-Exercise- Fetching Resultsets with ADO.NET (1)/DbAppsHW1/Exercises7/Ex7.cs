using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises7
{
    class Ex7
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(
                "Server=.;Database=MinionsDB; Integrated Security=true;MultipleActiveResultSets=true");

            connection.Open();
            using (connection)
            {
                SqlCommand getMinionsNames = new SqlCommand(@"SELECT Name FROM Minions", connection);

                List<string> original = new List<string>();
                List<string> names = new List<string>();


                SqlDataReader getMinionsNamesReader = getMinionsNames.ExecuteReader();
                while (getMinionsNamesReader.Read())
                {
                    original.Add((string) getMinionsNamesReader[0]);
                }


                for (int i = 0; i <= original.Count / 2; i++)
                {
                    names.Add(original[i]);
                    names.Add(original[original.Count - 1 - i]);
                }

                for (int i = 0; i < original.Count; i++)
                {
                    Console.WriteLine($"{i+1,-2}. {original[i],-20} | {names[i],-20}");
                }
            }
        }

        public static void Swap(IList<string> list, int indexA, int indexB)
        {
            string tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
    }
}