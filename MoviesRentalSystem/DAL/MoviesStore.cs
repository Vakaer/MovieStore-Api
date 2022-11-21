using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DAL
{
    public class MoviesStore
    {
        private SqlConnection sqlConnection = null;
        private readonly string connectionString = @"Server=DESKTOP-3DC7SVB;Database=MoviesStore;Integrated Security=True;";
        
        int GenreId = 1;
        int ReleaseYearId = 1;
        int DirectorId = 1;
        
        int ProducerID = 1;
        int LanguageID = 1;



       



        //Sql query to insert into movies
        string sql = "INSERT INTO dbo.Movies(movieName,genreId,releaseYearId,directorId,rentalCost,producerId,languageId) " +
        "VALUES(@name,@genreID,@releaseYear,@directorID,@rentalCost,@producerID,@langaugeID)";



        public void CreateConnection()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }
        public void AddMovie(string movieName, int rentalCost)
        {
            
            
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
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
    }
}