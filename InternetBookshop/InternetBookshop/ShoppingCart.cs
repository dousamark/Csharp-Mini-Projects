using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBookshop
{
	class ShoppingCart
	{
		public int customerID { get; set; }
		public List<ShoppingCartItem> Items = new List<ShoppingCartItem>();
	}
}
