using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBookshop
{
	class Customer
	{
		private ShoppingCart shoppingCart;

		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public ShoppingCart ShoppingCart
		{
			get
			{
				if (shoppingCart == null)
				{
					shoppingCart = new ShoppingCart();
				}
				return shoppingCart;
			}
			set
			{
				shoppingCart = value;
			}
		}
	}
}
