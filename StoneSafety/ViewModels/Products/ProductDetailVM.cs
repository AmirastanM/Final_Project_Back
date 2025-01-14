﻿using StoneSafety.Models;

namespace StoneSafety.ViewModels.Products
{
    public class ProductDetailVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }
        public bool IsMain { get; set; }
        public int Rating { get; set; }

        public string SubCategoryName { get; set; }

        public string SubSubCategoryName { get; set; } 

        public string CreatedDate { get; set; }

        public string UpdatedDate { get; set; }
        public IEnumerable<string> Images { get; set; }
      

    }

   
}
