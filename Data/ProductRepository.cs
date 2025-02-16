using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OnlineClothingStoreAPI.Models;
using System.Data;

namespace OnlineClothingStoreAPI.Data
{
    public class ProductRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ConnectionString");
        }

        [HttpGet]
        public List<ProductModel> SelectAll()
        {
            var products = new List<ProductModel>();
            //Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Product_SelectAll";

            SqlDataReader reader = objCmd.ExecuteReader();

            while (reader.Read())
            {
                ProductModel product = new ProductModel();
                product.ProductID = Convert.ToInt32(reader["ProductID"]);
                product.ProductName = Convert.ToString(reader["ProductName"]);
                product.Description = Convert.ToString(reader["Description"]);
                product.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                product.CategoryName = Convert.ToString(reader["CategoryName"]);
                product.BrandID = Convert.ToInt32(reader["BrandID"]);
                product.BrandName = Convert.ToString(reader["BrandName"]);
                product.Price = Convert.ToDecimal(reader["Price"]);
                product.StockQuantity = Convert.ToInt32(reader["StockQuantity"]);
                product.Size = reader["Size"] != DBNull.Value ? Convert.ToString(reader["Size"]) : "";
                product.Color = Convert.ToString(reader["Color"]);
                product.ImgUrl = Convert.ToString(reader["ImgUrl"]);
                product.IsActive = Convert.ToInt32(reader["IsActive"]);

                products.Add(product);
            }

            conn.Close();

            return products;
        }

        [HttpGet("{id}")]
        public ProductModel SelectByPK(int ProductID)
        {
            ProductModel product = new ProductModel();
            //Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Product_GetByID";
            objCmd.Parameters.AddWithValue("@ProductID", ProductID);

            SqlDataReader reader = objCmd.ExecuteReader();

            while (reader.Read())
            {
                product.ProductID = Convert.ToInt32(reader["ProductID"]);
                product.ProductName = Convert.ToString(reader["ProductName"]);
                product.Description = Convert.ToString(reader["Description"]);
                product.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                product.CategoryName = Convert.ToString(reader["CategoryName"]);
                product.BrandName = Convert.ToString(reader["BrandName"]);
                product.BrandID = Convert.ToInt32(reader["BrandID"]);
                product.Price = Convert.ToDecimal(reader["Price"]);
                product.StockQuantity = Convert.ToInt32(reader["StockQuantity"]);
                product.Size = Convert.ToString(reader["Size"]);
                product.Color = Convert.ToString(reader["Color"]);
                product.ImgUrl = Convert.ToString(reader["ImgUrl"]);
                product.IsActive = Convert.ToInt32(reader["IsActive"]);
            }

            conn.Close();

            return product;
        }

        [HttpPost]
        public bool Insert(ProductModel product)
        {
            //Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Product_Insert";

            objCmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            objCmd.Parameters.AddWithValue("@Description", product.Description);
            objCmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);
            objCmd.Parameters.AddWithValue("@BrandID", product.BrandID);
            objCmd.Parameters.AddWithValue("@Price", product.Price);
            objCmd.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
            objCmd.Parameters.AddWithValue("@Size", product.Size);
            objCmd.Parameters.AddWithValue("@Color", product.Color);
            objCmd.Parameters.AddWithValue("@ImgUrl", product.ImgUrl);

            var rowsAffected = objCmd.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }

        [HttpPut("{id}")]
        public bool Update(ProductModel product)
        {
            //Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Product_Update";

            objCmd.Parameters.AddWithValue("@ProductID", product.ProductID);
            objCmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            objCmd.Parameters.AddWithValue("@Description", product.Description);
            objCmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);
            objCmd.Parameters.AddWithValue("@BrandID", product.BrandID);
            objCmd.Parameters.AddWithValue("@Price", product.Price);
            objCmd.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
            objCmd.Parameters.AddWithValue("@Size", product.Size);
            objCmd.Parameters.AddWithValue("@Color", product.Color);
            objCmd.Parameters.AddWithValue("@ImgUrl", product.ImgUrl);
            objCmd.Parameters.AddWithValue("@IsActive", product.IsActive);

            var rowsAffected = objCmd.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }

        [HttpDelete]
        public bool Delete(int ProductID)
        {
            //Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Product_Delete";

            objCmd.Parameters.AddWithValue("@ProductID", ProductID);

            var rowsAffected = objCmd.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }

        [HttpGet("{CategoryID}")]
        public List<ProductModel> SelectByCategoryID(int CategoryID)
        {
            var products = new List<ProductModel>();
            //Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Product_SelectByCategoryID";
            objCmd.Parameters.AddWithValue("@CategoryID", CategoryID);

            SqlDataReader reader = objCmd.ExecuteReader();

            while (reader.Read())
            {
                ProductModel product = new ProductModel();
                product.ProductID = Convert.ToInt32(reader["ProductID"]);
                product.ProductName = Convert.ToString(reader["ProductName"]);
                product.Description = Convert.ToString(reader["Description"]);
                product.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                product.CategoryName = Convert.ToString(reader["CategoryName"]);
                product.BrandID = Convert.ToInt32(reader["BrandID"]);
                product.BrandName = Convert.ToString(reader["BrandName"]);
                product.Price = Convert.ToDecimal(reader["Price"]);
                product.StockQuantity = Convert.ToInt32(reader["StockQuantity"]);
                product.Size = Convert.ToString(reader["Size"]);
                product.Color = Convert.ToString(reader["Color"]);
                product.ImgUrl = Convert.ToString(reader["ImgUrl"]);
                product.IsActive = Convert.ToInt32(reader["IsActive"]);

                products.Add(product);
            }

            conn.Close();

            return products;
        }

        [HttpGet("{BrandID}")]
        public List<ProductModel> SelectByBrandID(int BrandID)
        {
            var products = new List<ProductModel>();
            //Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Product_SelectByBrandID";
            objCmd.Parameters.AddWithValue("@BrandID", BrandID);

            SqlDataReader reader = objCmd.ExecuteReader();

            while (reader.Read())
            {
                ProductModel product = new ProductModel();
                product.ProductID = Convert.ToInt32(reader["ProductID"]);
                product.ProductName = Convert.ToString(reader["ProductName"]);
                product.Description = Convert.ToString(reader["Description"]);
                product.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                product.CategoryName = Convert.ToString(reader["CategoryName"]);
                product.BrandID = Convert.ToInt32(reader["BrandID"]);
                product.BrandName = Convert.ToString(reader["BrandName"]);
                product.Price = Convert.ToDecimal(reader["Price"]);
                product.StockQuantity = Convert.ToInt32(reader["StockQuantity"]);
                product.Size = Convert.ToString(reader["Size"]);
                product.Color = Convert.ToString(reader["Color"]);
                product.ImgUrl = Convert.ToString(reader["ImgUrl"]);
                product.IsActive = Convert.ToInt32(reader["IsActive"]);

                products.Add(product);
            }

            conn.Close();

            return products;
        }

        [HttpGet]
        public IEnumerable<CategoryDropDownModel> GetCategories()
        {
            var categories = new List<CategoryDropDownModel>();

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Category_DropDown";

            SqlDataReader reader = objCmd.ExecuteReader();

            while (reader.Read())
            {
                categories.Add(
                    new CategoryDropDownModel
                    {
                        CategoryId = Convert.ToInt32(reader["CategoryId"]),
                        CategoryName = reader["CategoryName"].ToString()
                    }
                );
            }

            return categories;
        }

        [HttpGet]
        public IEnumerable<BrandDropDownModel> GetBrands()
        {
            var brands = new List<BrandDropDownModel>();

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Brand_DropDown";

            SqlDataReader reader = objCmd.ExecuteReader();

            while (reader.Read())
            {
                brands.Add(
                    new BrandDropDownModel
                    {
                        BrandId = Convert.ToInt32(reader["BrandId"]),
                        BrandName = reader["BrandName"].ToString()
                    }
                );
            }

            return brands;
        }
    }
}
