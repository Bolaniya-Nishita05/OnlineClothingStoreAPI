using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OnlineClothingStoreAPI.Models;
using System.Data;

namespace OnlineClothingStoreAPI.Data
{
    public class FavouriteRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public FavouriteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ConnectionString");
        }

        [HttpGet]
        public List<FavouriteModel> SelectAll()
        {
            var favourites = new List<FavouriteModel>();
            //PrePare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Favourite_SelectAll";

            SqlDataReader reader = objCmd.ExecuteReader();

            while (reader.Read())
            {
                FavouriteModel favourite = new FavouriteModel();
                favourite.FavouriteID = Convert.ToInt32(reader["FavouriteID"]);
                favourite.ProductID = Convert.ToInt32(reader["ProductID"]);
                favourite.ProductName = Convert.ToString(reader["ProductName"]);
                favourite.ImgUrl = Convert.ToString(reader["ImgUrl"]);
                favourite.UserID = Convert.ToInt32(reader["UserID"]);
                favourite.UserName = Convert.ToString(reader["UserName"]);

                favourites.Add(favourite);
            }

            return favourites;
        }

        [HttpPost]
        public bool Insert(FavouriteModel favourite)
        {
            //PrePare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Favourite_Insert";

            objCmd.Parameters.AddWithValue("@ProductID", favourite.ProductID);
            objCmd.Parameters.AddWithValue("@UserID", favourite.UserID);

            var rowsAffected = objCmd.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }

        [HttpDelete]
        public bool Delete(int FavouriteID)
        {
            //PrePare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Favourite_Delete";

            objCmd.Parameters.AddWithValue("@FavouriteID", FavouriteID);

            var rowsAffected = objCmd.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }

        [HttpGet("{UserID}")]
        public List<FavouriteModel> SelectByUserID(int UserID)
        {
            var favourites = new List<FavouriteModel>();
            //Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Favourite_SelectByUserID";

            objCmd.Parameters.AddWithValue("@UserID", UserID);

            SqlDataReader reader = objCmd.ExecuteReader();

            while (reader.Read())
            {
                FavouriteModel favourite = new FavouriteModel();
                favourite.FavouriteID = Convert.ToInt32(reader["FavouriteID"]);
                favourite.ProductID = Convert.ToInt32(reader["ProductID"]);
                favourite.ProductName = Convert.ToString(reader["ProductName"]);
                favourite.ImgUrl = Convert.ToString(reader["ImgUrl"]);

                favourites.Add(favourite);
            }

            conn.Close();

            return favourites;
        }
    }
}
