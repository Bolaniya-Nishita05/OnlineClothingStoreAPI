using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OnlineClothingStoreAPI.Models;
using System.Data;

namespace OnlineClothingStoreAPI.Data
{
    public class CategoryRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CategoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ConnectionString");
        }

        [HttpGet]
        public List<CategoryModel> SelectAll()
        {
            var categories = new List<CategoryModel>();
            //PrePare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Category_SelectAll";

            SqlDataReader reader = objCmd.ExecuteReader();

            while (reader.Read())
            {
                CategoryModel category = new CategoryModel();
                category.CategoryId = Convert.ToInt32(reader["CategoryID"]);
                category.CategoryName = Convert.ToString(reader["CategoryName"]);
                category.Description = Convert.ToString(reader["Description"]);

                categories.Add(category);
            }

            return categories;
        }

        [HttpGet("{id}")]
        public CategoryModel SelectByPK(int CategoryID)
        {
            CategoryModel category = new CategoryModel();
            //PrePare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Category_GetByID";
            objCmd.Parameters.AddWithValue("@CategoryID", CategoryID);

            SqlDataReader reader = objCmd.ExecuteReader();

            while (reader.Read())
            {
                category.CategoryId = Convert.ToInt32(reader["CategoryID"]);
                category.CategoryName = Convert.ToString(reader["CategoryName"]);
                category.Description = Convert.ToString(reader["Description"]);
            }

            conn.Close();

            return category;
        }

        [HttpPost]
        public bool Insert(CategoryModel category)
        {
            //PrePare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Category_Insert";

            objCmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            objCmd.Parameters.AddWithValue("@Description", category.Description);

            var rowsAffected = objCmd.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }

        [HttpPut("{id}")]
        public bool Update(CategoryModel category)
        {
            //PrePare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Category_Update";

            objCmd.Parameters.AddWithValue("@CategoryID", category.CategoryId);
            objCmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            objCmd.Parameters.AddWithValue("@Description", category.Description);

            var rowsAffected = objCmd.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }

        [HttpDelete]
        public bool Delete(int CategoryID)
        {
            //PrePare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Category_Delete";

            objCmd.Parameters.AddWithValue("@CategoryID", CategoryID);

            var rowsAffected = objCmd.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }
    }
}
