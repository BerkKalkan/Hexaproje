using Hexa.BL.Repositories;
using Hexa.DAL.Entities;
using Hexa.UI.Models;
using Hexa.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Protocol;
namespace Hexa.UI.Controllers
{
	public class CartController : Controller
	{
		IRepository<Product> repoProduct;
        IRepository<Order> repoOrder;
        IRepository<OrderDetail> repoOrderDetail;
        public CartController(IRepository<Product> _repoProduct, IRepository<Order> _repoOrder, IRepository<OrderDetail> _repoOrderDetail)
        {
            repoProduct = _repoProduct;
            repoOrder = _repoOrder;
            repoOrderDetail = _repoOrderDetail;
        }


        [Route("/sepet/sepeteekle"), HttpPost]
		public string AddCart(int productid, int quantity)
		{
			Product product = repoProduct.GetAll(x => x.ID == productid).Include(x => x.ProductPictures).FirstOrDefault();
			bool varMi = false;
			if (product != null)
			{
				Cart cart = new Cart()
				{
					ProductID = productid,
					ProductName = product.Name,
					ProductPicture = product.ProductPictures.FirstOrDefault().Picture,
					ProductPrice = product.Price,
					Quantity = quantity
				};
				List<Cart> carts = new List<Cart>();
				if (Request.Cookies["MyCart"] != null)//sepete daha önce ürün eklenmişse
				{
					carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]);
					foreach (Cart c in carts)
					{
						if (c.ProductID == productid)
						{
							varMi = true;
							if (c.ProductID == productid) c.Quantity += quantity;
							break;
						}
					}
				}
				if (!varMi)
					carts.Add(cart);
				CookieOptions options = new CookieOptions();
				options.Expires = DateTime.Now.AddHours(3); ;
				Response.Cookies.Append("MyCart", JsonConvert.SerializeObject(carts), options);
				return product.Name;
			}
			else return "~ Ürün Bulunamadı";
		}

		[Route("/sepet/sepetsayisi")]
		public int CartCount()
		{
			int geri = 0;
			if (Request.Cookies["MyCart"] != null)
			{
				List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]);
				geri = carts.Sum(x => x.Quantity);
			}
			return geri;
		}

		[Route("/sepet")]
		public IActionResult Index()
		{
			if (Request.Cookies["MyCart"] != null)
			{
				List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]);
				return View(carts);
			}
			else
				return Redirect("/");
		}

		[Route("/sepet/sepettensil"), HttpPost]
		public string RemoveCart(int productid)
		{
			string rtn = "";
			if (Request.Cookies["MyCart"] != null)
			{
				List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]);
				bool varMi = false;
				foreach (Cart c in carts)
				{
					if (c.ProductID == productid)
					{
						varMi = true;
						carts.Remove(c);
						break;
					}
				}
				if (varMi)
				{
					CookieOptions options = new();
					options.Expires = DateTime.Now.AddHours(3);
					Response.Cookies.Append("MyCart", JsonConvert.SerializeObject(carts), options);
					rtn = "OK";
				}
			}
			return rtn;
		}


		[Route("/sepet/alisverisitamamla")]
        public IActionResult CheckOut()
		{
			ViewBag.ShippingFee = 1000;
			if (Request.Cookies["MyCart"] != null)
			{
				List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]);
				CheckoutVM checkoutVM = new CheckoutVM
				{
					Order = new Order(),
					Carts = carts
				};

				return View(checkoutVM);
			}
			else
			{
				return Redirect("/");
			}
		}


        [Route("/sepet/alisverisitamamla"), HttpPost, ValidateAntiForgeryToken]
        public IActionResult CheckOut(CheckoutVM model)
        {

            model.Order.RecDate = DateTime.Now;
            string orderNumber = DateTime.Now.Microsecond.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Microsecond.ToString() + DateTime.Now.Microsecond.ToString();
            if (orderNumber.Length > 20) orderNumber = orderNumber.Substring(0, 20);
            model.Order.OrderNumber = orderNumber;
            model.Order.OrderStatus = EOrderStatus.Hazırlanıyor;
			repoOrder.Add(model.Order);
            List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["MyCart"]);
            foreach (Cart c in carts)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    OrderID = model.Order.ID,
                    ProductID = c.ProductID,
                    ProductName = c.ProductName,
                    ProductPicture = c.ProductPicture,
                    ProductPrice = c.ProductPrice,
                    Quantity = c.Quantity,
                };
                repoOrderDetail.Add(orderDetail);
            }
            return Redirect("/");
        }

    }
}
