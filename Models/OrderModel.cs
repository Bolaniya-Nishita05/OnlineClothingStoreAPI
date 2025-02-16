namespace OnlineClothingStoreAPI.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string? ProductName {  get; set; }
        public string? ImgUrl { get; set; }
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
    }

}
