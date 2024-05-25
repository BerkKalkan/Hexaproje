using Hexa.DAL.Entities;
using Hexa.UI.Models;

namespace Hexa.UI.ViewModels
{
	public class CheckoutVM
	{
		public Order Order { get; set; }
		public IEnumerable<Cart> Carts { get; set; }
	}
}
