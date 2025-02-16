using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OnlineClothingStoreAPI.Models;
using System.Data;

namespace OnlineClothingStoreAPI.Data
{
    public class OrderRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public OrderRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ConnectionString");
        }

        [HttpGet]
        public List<OrderModel> SelectAll()
        {
            var orders = new List<OrderModel>();
            //Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Order_SelectAll";

            SqlDataReader reader = objCmd.ExecuteReader();

            while (reader.Read())
            {
                OrderModel order = new OrderModel();
                order.OrderID = Convert.ToInt32(reader["OrderID"]);
                order.ProductID = Convert.ToInt32(reader["ProductID"]);
                order.ProductName = Convert.ToString(reader["ProductName"]);
                order.UserID = Convert.ToInt32(reader["UserID"]);
                order.UserName = Convert.ToString(reader["UserName"]);
                order.Quantity = Convert.ToInt32(reader["Quantity"]);
                order.TotalAmount = Convert.ToDecimal(reader["TotalAmount"]);

                orders.Add(order);
            }

            conn.Close();

            return orders;
        }

        [HttpGet("{id}")]
        public OrderModel SelectByPK(int OrderID)
        {
            OrderModel order = new OrderModel();
            //Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Order_GetByID";
            objCmd.Parameters.AddWithValue("@OrderID", OrderID);

            SqlDataReader reader = objCmd.ExecuteReader();

            while (reader.Read())
            {
                order.OrderID = Convert.ToInt32(reader["OrderID"]);
                order.ProductID = Convert.ToInt32(reader["ProductID"]);
                order.UserID = Convert.ToInt32(reader["UserID"]);
                order.Quantity = Convert.ToInt32(reader["Quantity"]);
                order.TotalAmount = Convert.ToDecimal(reader["TotalAmount"]);
            }

            conn.Close();

            return order;
        }

        [HttpPost]
        public bool Insert(OrderModel order)
        {
            //Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Order_Insert";

            objCmd.Parameters.AddWithValue("@ProductID", order.ProductID);
            objCmd.Parameters.AddWithValue("@UserID", order.UserID);
            objCmd.Parameters.AddWithValue("@Quantity", order.Quantity);
            objCmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);

            var rowsAffected = objCmd.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }

        [HttpPut("{id}")]
        public bool Update(OrderModel order)
        {
            //Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Order_Update";

            objCmd.Parameters.AddWithValue("@OrderID", order.OrderID);
            objCmd.Parameters.AddWithValue("@ProductID", order.ProductID);
            objCmd.Parameters.AddWithValue("@UserID", order.UserID);
            objCmd.Parameters.AddWithValue("@Quantity", order.Quantity);
            objCmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);

            var rowsAffected = objCmd.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }

        [HttpDelete]
        public bool Delete(int OrderID)
        {
            //Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Order_Delete";

            objCmd.Parameters.AddWithValue("@OrderID", OrderID);

            var rowsAffected = objCmd.ExecuteNonQuery();
            conn.Close();

            return rowsAffected > 0;
        }

        [HttpGet("{UserID}")]
        public List<OrderModel> SelectByUserID(int UserID)
        {
            var orders = new List<OrderModel>();
            //Prepare a connection
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            //Prepare a Command
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Order_SelectByUserID";

            objCmd.Parameters.AddWithValue("@UserID", UserID);

            SqlDataReader reader = objCmd.ExecuteReader();

            while (reader.Read())
            {
                OrderModel order = new OrderModel();
                order.OrderID = Convert.ToInt32(reader["OrderID"]);
                order.ProductID = Convert.ToInt32(reader["ProductID"]);
                order.ProductName = Convert.ToString(reader["ProductName"]);
                order.ImgUrl = Convert.ToString(reader["ImgUrl"]);
                order.UserID = Convert.ToInt32(reader["UserID"]);
                order.UserName = Convert.ToString(reader["UserName"]);
                order.Quantity = Convert.ToInt32(reader["Quantity"]);
                order.TotalAmount = Convert.ToDecimal(reader["TotalAmount"]);

                orders.Add(order);
            }

            conn.Close();

            return orders;
        }
    }
}
