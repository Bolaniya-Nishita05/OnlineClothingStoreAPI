using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OnlineClothingStoreAPI.Models;
using System.Data;

namespace OnlineClothingStoreAPI.Data
{
    public class UserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ConnectionString");
        }

        [HttpGet]
        public List<UserModel> SelectAll()
        {
            var users = new List<UserModel>();

            // Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            // Prepare a command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_SelectAll";

            SqlDataReader reader = objCmd.ExecuteReader();

            while (reader.Read())
            {
                UserModel user = new UserModel();
                user.UserID = Convert.ToInt32(reader["UserID"]);
                user.UserName = Convert.ToString(reader["UserName"]);
                user.Email = Convert.ToString(reader["Email"]);
                user.Password = Convert.ToString(reader["Password"]);
                user.ContactNo = Convert.ToString(reader["ContactNo"]);

                users.Add(user);
            }

            conn.Close();

            return users;
        }

        [HttpGet("{id}")]
        public UserModel SelectByPK(int UserID)
        {
            UserModel user = new UserModel();

            // Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            // Prepare a command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_GetByID";
            objCmd.Parameters.AddWithValue("@UserID", UserID);

            SqlDataReader reader = objCmd.ExecuteReader();

            while (reader.Read())
            {
                user.UserID = Convert.ToInt32(reader["UserID"]);
                user.UserName = Convert.ToString(reader["UserName"]);
                user.Email = Convert.ToString(reader["Email"]);
                user.Password = Convert.ToString(reader["Password"]);
                user.ContactNo = Convert.ToString(reader["ContactNo"]);
            }

            conn.Close();

            return user;
        }

        [HttpPost]
        public bool Insert(UserModel user)
        {
            // Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            // Prepare a command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_Insert";

            objCmd.Parameters.AddWithValue("@UserName", user.UserName);
            objCmd.Parameters.AddWithValue("@Email", user.Email);
            objCmd.Parameters.AddWithValue("@Password", user.Password);
            objCmd.Parameters.AddWithValue("@ContactNo", user.ContactNo);

            var rowsAffected = objCmd.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }

        [HttpPut("{id}")]
        public bool Update(UserModel user)
        {
            // Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            // Prepare a command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_Update";

            objCmd.Parameters.AddWithValue("@UserID", user.UserID);
            objCmd.Parameters.AddWithValue("@UserName", user.UserName);
            objCmd.Parameters.AddWithValue("@Email", user.Email);
            objCmd.Parameters.AddWithValue("@Password", user.Password);
            objCmd.Parameters.AddWithValue("@ContactNo", user.ContactNo);

            var rowsAffected = objCmd.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }

        [HttpDelete("{id}")]
        public bool Delete(int UserID)
        {
            // Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            // Prepare a command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_Delete";

            objCmd.Parameters.AddWithValue("@UserID", UserID);

            var rowsAffected = objCmd.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }
    }
}
