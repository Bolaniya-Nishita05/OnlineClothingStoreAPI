using OnlineClothingStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace OnlineClothingStoreAPI.Data
{
    public class BrandRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public BrandRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ConnectionString");
        }

        [HttpGet]
        public List<BrandModel> SelectAll()
        {
            var brands = new List<BrandModel>();
            //PrePare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Brand_SelectAll";

            SqlDataReader reader = objCmd.ExecuteReader();

            while (reader.Read())
            {
                BrandModel brand = new BrandModel();
                brand.BrandId = Convert.ToInt32(reader["BrandID"]);
                brand.BrandName = Convert.ToString(reader["BrandName"]);
                brand.Description = Convert.ToString(reader["Description"]);

                brands.Add(brand);
            }

            return brands;
        }

        [HttpGet("{id}")]
        public BrandModel SelectByPK(int BrandID)
        {
            BrandModel brand = new BrandModel();
            //PrePare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Brand_GetByID";
            objCmd.Parameters.AddWithValue("@BrandID", BrandID);

            SqlDataReader reader = objCmd.ExecuteReader();

            while (reader.Read())
            {
                brand.BrandId = Convert.ToInt32(reader["BrandID"]);
                brand.BrandName = Convert.ToString(reader["BrandName"]);
                brand.Description = Convert.ToString(reader["Description"]);
            }

            conn.Close();

            return brand;
        }

        [HttpPost]
        public bool Insert(BrandModel brand)
        {
            //PrePare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Brand_Insert";

            objCmd.Parameters.AddWithValue("@BrandName", brand.BrandName);
            objCmd.Parameters.AddWithValue("@Description", brand.Description);

            var rowsAffected = objCmd.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }

        [HttpPut("{id}")]
        public bool Update(BrandModel brand)
        {
            //PrePare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Brand_Update";

            objCmd.Parameters.AddWithValue("@BrandID", brand.BrandId);
            objCmd.Parameters.AddWithValue("@BrandName", brand.BrandName);
            objCmd.Parameters.AddWithValue("@Description", brand.Description);

            var rowsAffected = objCmd.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }

        [HttpDelete]
        public bool Delete(int BrandID)
        {
            //PrePare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Brand_Delete";

            objCmd.Parameters.AddWithValue("@BrandID", BrandID);

            var rowsAffected = objCmd.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }
    }
}
