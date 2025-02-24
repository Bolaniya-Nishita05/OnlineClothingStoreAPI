namespace OnlineClothingStoreAPI.Models
{
    public class RecentOrderModel
    {
        public int OrderID { get; set; }
        public string UserName { get; set; }
        public string ProductName { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
