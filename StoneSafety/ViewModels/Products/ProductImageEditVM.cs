﻿namespace StoneSafety.ViewModels.Products
{
    public class ProductImageEditVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
