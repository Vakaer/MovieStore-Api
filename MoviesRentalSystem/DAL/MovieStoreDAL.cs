using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRentalSystem.DAL
{
    public class MovieStoreDAL
    {
        public string _connectionString;
        public MovieStoreDAL()
        {

        }
        public void Init (IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }
       

        public SqlConnection getConnectionString()
        {
            return new SqlConnection(_connectionString.ToString());
        }

        public void CreateConnection()
        {

            SqlConnection conn = getConnectionString();
            conn.Open();

        }
        //public void CreateCommand(string queryString,
        //string connectionString)
        //{
        //    using (SqlConnection connection = new SqlConnection(
        //               connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(queryString, connection);
        //        command.Connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //}

    }
}
