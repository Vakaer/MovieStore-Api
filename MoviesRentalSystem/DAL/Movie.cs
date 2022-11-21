using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRentalSystem.DAL
{
    public class Movie
    {

        int GenreId = 1;
        int ReleaseYearId = 1;
        int DirectorId = 1;

        int ProducerID = 1;
        int LanguageID = 1;
        private readonly string connectionString = @"Server=DESKTOP-3DC7SVB;Database=MoviesStore;Integrated Security=True;";
        
        
            
        
        
       
      
        //Sql query to insert into movies
        string insertMoviewQuery = "INSERT INTO dbo.Movies(movieName,genreId,releaseYearId,directorId,rentalCost,producerId,languageId) " +
        "VALUES(@name,@genreID,@releaseYear,@directorID,@rentalCost,@producerID,@langaugeID)";
        string retrievDataQuery = "SELECT * FROM Movies";
        string deleteDataQuery = "DELETE FROM Movies WHERE ID=@id;";

        public void AddMovie(string movieName, int rentalCost)
        {
            
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("Connection built successfully");
            using (SqlCommand cmd = new SqlCommand(insertMoviewQuery, sqlConnection))
            {
                cmd.Parameters.Add("@name", SqlDbType.Char, 30).Value = movieName;
                cmd.Parameters.Add("@genreID", SqlDbType.Int).Value = GenreId;
                cmd.Parameters.Add("@releaseYear", SqlDbType.Int).Value = ReleaseYearId;
                cmd.Parameters.Add("@directorID", SqlDbType.Int).Value = DirectorId;
                cmd.Parameters.Add("@rentalCost", SqlDbType.Int).Value = rentalCost;
                cmd.Parameters.Add("@producerID", SqlDbType.Int).Value = ProducerID;
                cmd.Parameters.Add("@langaugeID", SqlDbType.Int).Value = LanguageID;
                cmd.CommandType = CommandType.Text;
                
                cmd.ExecuteNonQuery();
            }
        }

        public void RetrieveMovies()
        {
            
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("Connection built successfully");
            try
            {
                using (SqlCommand cmd = new SqlCommand(retrievDataQuery, sqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("---Row---");
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write("item: ");
                                Console.WriteLine(reader.GetValue(i));
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(ConnectionState.Open != ConnectionState.Closed)
                {
                    sqlConnection.Close();
                }
            }

            
        }
        public void deleteMovie(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("Connection built successfully");
            try
            {
                using(SqlCommand cmd = new SqlCommand(deleteDataQuery, sqlConnection))
                {
                    cmd.Parameters.Add("@id",SqlDbType.Int).Value = id;
                    cmd.ExecuteNonQuery();
                }
            }catch(Exception e)
            {
                Console.WriteLine("Error message is "+e.Message);
            }
            finally
            {
                if (ConnectionState.Open != ConnectionState.Closed)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
