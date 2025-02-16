namespace OnlineClothingStoreAPI.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }

    public class CategoryDropDownModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
