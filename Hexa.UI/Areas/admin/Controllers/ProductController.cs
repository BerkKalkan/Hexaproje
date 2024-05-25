using Hexa.BL.Repositories;
using Hexa.DAL.Entities;
using Hexa.UI.Areas.admin.ModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hexa.UI.Areas.admin.Controllers
{
    [Area("Admin"), Authorize]
    public class ProductController : Controller
    {
        IRepository<Product> repoProduct;
        IRepository<Brand> repoBrand;
        IRepository<Category> repoCategory;

        public ProductController(IRepository<Product> _repoProduct, IRepository<Brand> _repoBrand, IRepository<Category> _repoCategory)
        {
            repoProduct = _repoProduct;
            repoBrand = _repoBrand;
            repoCategory = _repoCategory;
        }

        public IActionResult Index()
        {
            return View(repoProduct.GetAll().OrderBy(x => x.DisplayIndex));
        }

        public IActionResult New()
        {
            ProductVM productVM = new ProductVM
            {
                Product = new Product(),
                Brands = repoBrand.GetAll().OrderBy(x => x.Name),
                Categories = repoCategory.GetAll(x => x.ParentID != null).OrderBy(x => x.Name)
            };
            return View(productVM);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(ProductVM model)
        {
            if (ModelState.IsValid) // gelen model doğrulanmışsa
            {
                repoProduct.Add(model.Product);
                return RedirectToAction("Index");
            }

            else return RedirectToAction("New");
        }

        public IActionResult Edit(int id)
        {
            Product product = repoProduct.GetBy(x => x.ID == id);
            ProductVM productVM = new ProductVM()
            {
                Product = product,
                Brands = repoBrand.GetAll().OrderBy(x => x.Name),
                Categories = repoCategory.GetAll(x => x.ParentID != null).OrderBy(x => x.Name)
            };
            if (product != null) return View(productVM);
            else return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductVM model)
        {
            if (ModelState.IsValid) // gelen model doğrulanmışsa
            {

                repoProduct.Update(model.Product);
                return RedirectToAction("Index");
            }

            else return RedirectToAction("New");
        }

        public IActionResult Delete(int id)
        {
            Product Product = repoProduct.GetBy(x => x.ID == id);
            if (Product != null) repoProduct.Delete(Product);
            return RedirectToAction("Index");
        }
    }
}