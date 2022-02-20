using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InternetBookshop
{
	class Processor
	{
		internal static void ProcessRequests(ModelStore modelStore, Reader reader)
		{
			string request;
			while ((request = reader.ReadLine()) != null)
			{
				ProcessRequest(request, modelStore);
			}
		}

		private static void ProcessRequest(string request, ModelStore modelStore)
		{
			bool InvalidPage = false;
			string[] splitRequest = request.Split();

			if (splitRequest.Length < 3)
			{
				Print.InvalidPage();
				return;
			}
			splitRequest[2] = splitRequest[2].Replace("http://www.nezarka.net/", "");
			string[] splitRequestCommands = splitRequest[2].Split('/');

			if (checkRequest(splitRequest, splitRequestCommands, modelStore))
			{
				int customerID = int.Parse(splitRequest[1]);
				if (splitRequestCommands.Length == 1)
				{
					if (splitRequestCommands[0] == "Books")
					{
						Print.Books(customerID, modelStore);
					}
					else if(splitRequestCommands[0] == "ShoppingCart")
					{
						Print.ShoppingCart(customerID, modelStore);
					}
					else
					{
						InvalidPage = true;
					}
				}
				else if (splitRequestCommands.Length == 3)
				{
					if (splitRequestCommands[0] == "Books" && splitRequestCommands[1] == "Detail")
					{
						Print.BookDetail(customerID, modelStore, splitRequestCommands[2]);
					}
					else if (splitRequestCommands[0] == "ShoppingCart" && splitRequestCommands[1] == "Add")
					{
						AddBook(customerID, modelStore, splitRequestCommands[2]);
					}
					else if (splitRequestCommands[0] == "ShoppingCart" && splitRequestCommands[1] == "Remove")
					{
						RemoveBook(customerID, modelStore, splitRequestCommands[2]);
					}
					else
					{
						InvalidPage = true;
					}
				}
				else
				{
					InvalidPage = true;
				}
			}
			else
			{
				InvalidPage = true;
			}
			if (InvalidPage) { Print.InvalidPage(); }
		}

		private static void RemoveBook(int customerID, ModelStore modelStore, string v)
		{
			int bookID = int.Parse(v);
			if (BookFound(customerID, modelStore, bookID,false))
			{
				
				ShoppingCartItem BookToBeRemoved = findBook(customerID, modelStore,bookID);
				BookToBeRemoved.Count--;
				if (BookToBeRemoved.Count == 0)
				{
					modelStore.GetCustomer(customerID).ShoppingCart.Items.Remove(BookToBeRemoved);
				}
				Print.ShoppingCart(customerID, modelStore);
			}
			else
			{
				Print.InvalidPage();
			}
			
		}

		private static ShoppingCartItem findBook(int customerID, ModelStore modelStore,int bookID)
		{
			foreach (ShoppingCartItem item in modelStore.GetCustomer(customerID).ShoppingCart.Items)
			{
				if (bookID == item.BookId)
				{
					return item;
				}
			}
			return null;
		}

		private static bool BookFound(int customerID, ModelStore modelStore, int bookID,bool add)
		{
			foreach (ShoppingCartItem item in modelStore.GetCustomer(customerID).ShoppingCart.Items)
			{
				if (bookID == item.BookId)
				{
					if (add) { item.Count++; }
					return true;
				}
			}
			return false;
		}

		private static void AddBook(int customerID, ModelStore modelStore, string v)
		{
			int bookID = int.Parse(v);
			if (!BookFound(customerID, modelStore, bookID,true))
			{
				ShoppingCartItem Book = new ShoppingCartItem();
				Book.BookId = bookID;
				Book.Count = 1;
				modelStore.GetCustomer(customerID).ShoppingCart.Items.Add(Book);
			}
			else
			{
				
			}
			Print.ShoppingCart(customerID, modelStore);
		}

		private static bool checkRequest(string[] splitRequest, string[] splitRequestCommands, ModelStore modelStore)
		{
			if (splitRequest.Length != 3) { return false; }
			if (splitRequest[0] != "GET") { return false; }

			bool Validity = true;
			try
			{
				if (modelStore.GetCustomer(int.Parse(splitRequest[1])) == null)
				{
					Validity = false;
				}
			}
			catch
			{
				Validity = false;
			}

			if (splitRequestCommands.Length == 3)
			{
				try
				{
					if (modelStore.GetBook(int.Parse(splitRequestCommands[2])) == null)
					{
						Validity = false;
					}
				}
				catch
				{
					Validity = false;
				}
			}
			return Validity;
		}
	}
}
