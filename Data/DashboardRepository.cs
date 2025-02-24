using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OnlineClothingStoreAPI.Models;
using System.Data;

namespace OnlineClothingStoreAPI.Data
{
    public class DashboardRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DashboardRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ConnectionString");
        }

        [HttpGet]
        public DashboardModel SelectAll()
        {
            var dashboardData = new DashboardModel
            {
                Counts = new List<DashboardCountsModel>(),
                RecentOrders = new List<RecentOrderModel>(),
                RecentProducts = new List<RecentProductModel>(),
                TopUsers = new List<TopUserModel>(),
                TopSellingProducts = new List<TopSellingProductModel>()
            };

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("usp_GetDashboardData", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // Fetch counts
                            while (reader.Read())
                            {
                                dashboardData.Counts.Add(new DashboardCountsModel
                                {
                                    Metric = reader["Metric"].ToString(),
                                    Value = Convert.ToInt32(reader["Value"])
                                });
                            }

                            // Fetch recent orders
                            if (reader.NextResult())
                            {
                                while (reader.Read())
                                {
                                    dashboardData.RecentOrders.Add(new RecentOrderModel
                                    {
                                        OrderID = Convert.ToInt32(reader["OrderID"]),
                                        UserName = reader["UserName"].ToString(),
                                        ProductName = Convert.ToString(reader["ProductName"]),
                                        TotalAmount = Convert.ToDecimal(reader["TotalAmount"])
                                    });
                                }
                            }

                            // Fetch recent products
                            if (reader.NextResult())
                            {
                                while (reader.Read())
                                {
                                    dashboardData.RecentProducts.Add(new RecentProductModel
                                    {
                                        ProductID = Convert.ToInt32(reader["ProductID"]),
                                        ProductName = reader["ProductName"].ToString(),
                                        Price = Convert.ToDecimal(reader["Price"]),
                                        StockQuantity = Convert.ToInt32(reader["StockQuantity"])
                                    });
                                }
                            }

                            // Fetch top customers
                            if (reader.NextResult())
                            {
                                while (reader.Read())
                                {
                                    dashboardData.TopUsers.Add(new TopUserModel
                                    {
                                        UserName = reader["UserName"].ToString(),
                                        TotalOrders = Convert.ToInt32(reader["TotalOrders"]),
                                        Email = reader["Email"].ToString()
                                    });
                                }
                            }

                            // Fetch top selling products
                            if (reader.NextResult())
                            {
                                while (reader.Read())
                                {
                                    dashboardData.TopSellingProducts.Add(new TopSellingProductModel
                                    {
                                        ProductName = reader["ProductName"].ToString(),
                                        TotalSoldQuantity = Convert.ToInt32(reader["TotalSoldQuantity"])
                                    });
                                }
                            }
                        }
                    }
                }
            }

            //dashboardData.NavigationLinks = new List<QuickLinksModel> {
            //    new QuickLinksModel {ActionMethodName = "Index", ControllerName="Dashboard", LinkName="Dashboard" },
            //    new QuickLinksModel {ActionMethodName = "Index", ControllerName="Country", LinkName="Country" },
            //    new QuickLinksModel {ActionMethodName = "Index", ControllerName="State", LinkName="State" },
            //    new QuickLinksModel {ActionMethodName = "Index", ControllerName="City", LinkName="City" }
            //};

            //var model = new DashboardModel
            //{
            //    Counts = dashboardData.Counts,
            //    RecentOrders = dashboardData.RecentOrders,
            //    RecentProducts = dashboardData.RecentProducts,
            //    TopUsers = dashboardData.TopUsers,
            //    TopSellingProducts = dashboardData.TopSellingProducts,
            //    NavigationLinks = dashboardData.NavigationLinks
            //};

            return dashboardData;
        }
    }
}
