namespace OnlineClothingStoreAPI.Models
{
    public class FavouriteModel
    {
        public int FavouriteID { get; set; }
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ImgUrl { get; set; }
        public int UserID { get; set; }
        public string? UserName { get; set; }
    }
}
