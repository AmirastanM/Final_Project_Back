namespace StoneSafety.ViewModels.Products
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public int Rating { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int? SubSubCategoryId { get; set; }
        public string SubSubCategoryName { get; set; }
    }

}



