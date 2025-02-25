namespace OnlineClothingStoreAPI.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public int BrandID { get; set; }
        public string? BrandName { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string ImgUrl { get; set; }
        public int IsActive { get; set; }
    }

}
