using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Helper
{
	public static class Mapping
	{
		public static List<ProductViewModel> ToProductViewModels(List<Product> products)
		{
			var productsViewModels = new List<ProductViewModel>();

			foreach (var product in products)
			{
				productsViewModels.Add(ToProductViewModel(product));
			}

			return productsViewModels;
		}

		public static ProductViewModel ToProductViewModel(Product product)
		{
			return new ProductViewModel
				{
					Id = product.Id,
					Name = product.Name,
					Coast = product.Coast,
					Description = product.Description,
					ImagePath = product.ImagePath
				};
		}

		public static CartViewModel ToCartViewModel(Cart cart)
		{
			if (cart == null)
			{
				return null;
			}

			return new CartViewModel
			{
				Id = cart.Id,
				UserId = cart.UserId,
				Items = ToCartItemViewModels(cart.Items)
			};
		}

		public static List<CartItemViewModel> ToCartItemViewModels(List<CartItem> cartDbItems)
		{
			var cartItems = new List<CartItemViewModel>();

			foreach (var cartDbItem in cartDbItems)
			{
				var cartItem = new CartItemViewModel
				{
					Id = cartDbItem.Id,
					Amount = cartDbItem.Amount,
					Product = ToProductViewModel(cartDbItem.Product)
				};
				cartItems.Add(cartItem);
			}

			return cartItems;
		}
	}
}
