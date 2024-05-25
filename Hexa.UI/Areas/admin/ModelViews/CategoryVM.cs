using Hexa.DAL.Entities;

namespace Hexa.UI.Areas.admin.ModelViews
{
    public class CategoryVM
    {
        public Category Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
