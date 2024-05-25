using Hexa.BL.Repositories;
using Hexa.DAL.Entities;
using Hexa.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace Hexa.UI.Controllers
{
	public class HomeController : Controller
	{
		IRepository<Slide> repoSlide;
		IRepository<Product> repoProduct;
		public HomeController(IRepository<Slide> _repoSlide, IRepository<Product> _repoProduct) 
		{
			repoSlide = _repoSlide;
			repoProduct = _repoProduct;
		}
		public IActionResult Index()
		{
			IndexVM indexVM = new IndexVM()
			{
				Slides = repoSlide.GetAll().OrderBy(x => x.DisplayIndex),
				LatestProducts= repoProduct.GetAll().Include(x => x.ProductPictures).OrderByDescending(x => x.ID).Take(8),
				SalesProduct = repoProduct.GetAll().Include(x => x.ProductPictures).OrderByDescending(x => x.ID).Take(8)
			};
			return View(indexVM);
		}
	}
}
