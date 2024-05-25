using Hexa.DAL.Entities;

namespace Hexa.UI.Areas.admin.ModelViews
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
    }
}
