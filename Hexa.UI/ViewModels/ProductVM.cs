﻿using Hexa.DAL.Entities;

namespace Hexa.UI.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<Product> RelatedProducts { get; set; }
    }
}
