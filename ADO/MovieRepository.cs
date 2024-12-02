using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ADO
{
    public class MovieRepository
    {
        private readonly string _connectionString;

        public MovieRepository(string connectionString)
        {
            _connectionString = DatabaseConfig.GetConnectionString();
        }

        public List<string> GetMoviesByActor(Actor actor)
        {
            List<string> movies = new List<string>();
            string query = @"
            SELECT f.title
            FROM film f
            INNER JOIN film_actor fa ON f.film_id = fa.film_id
            INNER JOIN actor a ON a.actor_id = fa.actor_id
            WHERE a.first_name = @FirstName AND a.last_name = @LastName";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@FirstName", actor.FirstName);
                    command.Parameters.AddWithValue("@LastName", actor.LastName);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                movies.Add(reader["title"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid databasanslutning: {ex.Message}");
            }

            return movies;
        }
       
    }
    }
