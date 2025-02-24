namespace OnlineClothingStoreAPI.Models
{
    public class DashboardModel
    {
        public List<DashboardCountsModel> Counts { get; set; }
        public List<RecentOrderModel> RecentOrders { get; set; }
        public List<RecentProductModel> RecentProducts { get; set; }
        public List<TopUserModel> TopUsers { get; set; }
        public List<TopSellingProductModel> TopSellingProducts { get; set; }

    }
}
