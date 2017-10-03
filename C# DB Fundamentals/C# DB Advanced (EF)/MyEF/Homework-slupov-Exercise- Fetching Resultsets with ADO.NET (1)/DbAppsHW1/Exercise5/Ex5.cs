using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Ex5
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(
                "Server=.;Database=MinionsDB; Integrated Security=true;MultipleActiveResultSets=true");

            Console.WriteLine("Enter country name: ");
            string countryName = Console.ReadLine();

            connection.Open();
            using (connection)
            {
                SqlCommand uppercaseCountryTowns = new SqlCommand(@"UPDATE Towns
                            SET Name = UPPER(Name)
                            WHERE CountryName = @countryName", connection);

                SqlCommand getCountryNames = new SqlCommand(@"SELECT CountryName FROM Towns", connection);
                SqlDataReader getCountryNamesReader = getCountryNames.ExecuteReader();

                uppercaseCountryTowns.Parameters.AddWithValue("@countryName", countryName);

                uppercaseCountryTowns.ExecuteNonQuery();

                bool countryExists = false;
                while (getCountryNamesReader.Read())
                {
                    if (getCountryNamesReader[0] == System.DBNull.Value)
                    {
                        continue; 
                    }
                    if ((string) getCountryNamesReader[0] == countryName)
                    {
                        countryExists = true;
                    }
                }

                Console.WriteLine(countryExists ? "Towns uppercased successfully!" : "No such country exists.");
            }

            connection.Close();
        }
    }
}