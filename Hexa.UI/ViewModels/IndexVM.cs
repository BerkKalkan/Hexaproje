﻿using Hexa.DAL.Entities;

namespace Hexa.UI.ViewModels
{
    public class IndexVM
    {
        public IEnumerable<Slide> Slides { get; set; }

        public IEnumerable<Product> LatestProducts { get; set; }

        public IEnumerable<Product> SalesProduct { get; set; }
    }
}
