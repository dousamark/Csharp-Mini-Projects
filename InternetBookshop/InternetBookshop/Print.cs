using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace InternetBookshop
{
	public static class Print
	{
		public static void Header()
		{
			Console.WriteLine("<!DOCTYPE html>");
			Console.WriteLine("<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\">");
			Console.WriteLine("<head>");
			Console.WriteLine("    <meta charset=\"utf-8\" />");
			Console.WriteLine("    <title>Nezarka.net: Online Shopping for Books</title>");
			Console.WriteLine("</head>");
			Console.WriteLine("<body>");
			Console.WriteLine("    <style type=\"text/css\">");
			Console.WriteLine("        table, th, td {");
			Console.WriteLine("            border: 1px solid black;");
			Console.WriteLine("            border-collapse: collapse;");
			Console.WriteLine("        }");
			Console.WriteLine("        table {");
			Console.WriteLine("            margin-bottom: 10px;");
			Console.WriteLine("        }");
			Console.WriteLine("        pre {");
			Console.WriteLine("            line-height: 70%;");
			Console.WriteLine("        }");
			Console.WriteLine("    </style>");
			Console.WriteLine("    <h1><pre>  v,<br />Nezarka.NET: Online Shopping for Books</pre></h1>");
		}

		internal static void BookDetail(int customerID, ModelStore modelStore, string v)
		{
			int bookID = int.Parse(v);
			Header();
			Intro(customerID, modelStore);

			Console.WriteLine("    Book details:");
			Console.WriteLine("    <h2>" + modelStore.GetBook(bookID).Title + "</h2>");
			Console.WriteLine("    <p style=\"margin-left: 20px\">");
			Console.WriteLine("    Author: " + modelStore.GetBook(bookID).Author + "<br />");
			Console.WriteLine("    Price: " + modelStore.GetBook(bookID).Price + " EUR<br />");
			Console.WriteLine("    </p>");
			Console.WriteLine("    <h3>&lt;<a href=\"/ShoppingCart/Add/" + bookID + "\">Buy this book</a>&gt;</h3>");
			Console.WriteLine("</body>");
			Console.WriteLine("</html>");
			Console.WriteLine("====");
		}

		internal static void ShoppingCart(int customerID, ModelStore modelStore)
		{
			Header();
			Intro(customerID, modelStore);

			if (modelStore.GetCustomer(customerID).ShoppingCart.Items.Count == 0)
			{
				Console.WriteLine("    Your shopping cart is EMPTY.");
			}
			else
			{
				Console.WriteLine("    Your shopping cart:");
				Console.WriteLine("    <table>");
				Console.WriteLine("        <tr>");
				Console.WriteLine("            <th>Title</th>");
				Console.WriteLine("            <th>Count</th>");
				Console.WriteLine("            <th>Price</th>");
				Console.WriteLine("            <th>Actions</th>");
				Console.WriteLine("        </tr>");
				int totalPrice = 0;
				foreach (ShoppingCartItem item in modelStore.GetCustomer(customerID).ShoppingCart.Items)
				{
					Book book = modelStore.GetBook(item.BookId);
					int price = (int)book.Price;
					if (item.Count != 1) { price *= item.Count; }

					totalPrice += price;
					Console.WriteLine("        <tr>");
					Console.WriteLine("            <td><a href=\"/Books/Detail/" + book.Id + "\">" + book.Title + "</a></td>");
					Console.WriteLine("            <td>" + item.Count + "</td>");
					if (item.Count == 1)
					{
						Console.WriteLine("            <td>" + book.Price + " EUR</td>");
					}
					else
					{
						Console.WriteLine("            <td>" + getPrice(book.Price, item.Count) + " EUR</td>");
					}
					Console.WriteLine("            <td>&lt;<a href=\"/ShoppingCart/Remove/" + book.Id + "\">Remove</a>&gt;</td>");
					Console.WriteLine("        </tr>");
				}
				Console.WriteLine("    </table>");
				Console.WriteLine("    Total price of all items: " + totalPrice + " EUR");
			}
			Console.WriteLine("</body>");
			Console.WriteLine("</html>");
			Console.WriteLine("====");
		}

		private static string getPrice(decimal price, int count)
		{
			return count + " * " + price + " = "+(price* count);

		}

		internal static void Books(int customerID, ModelStore modelStore)
		{
			Header();
			Intro(customerID, modelStore);

			Console.WriteLine("    Our books for you:");
			Console.WriteLine("    <table>");

			int counter = 0;
			foreach (Book Book in modelStore.GetBooks())
			{
				if (counter == 0)
				{
					Console.WriteLine("        <tr>");
				}
				Console.WriteLine("            <td style=\"padding: 10px;\">");
				Console.WriteLine("                <a href=\"/Books/Detail/" + Book.Id + "\">" + Book.Title + "</a><br />");
				Console.WriteLine("                Author: " + Book.Author + "<br />");
				Console.WriteLine("                Price: " + Book.Price + " EUR &lt;<a href=\"/ShoppingCart/Add/" + Book.Id + "\">Buy</a>&gt;");
				Console.WriteLine("            </td>");
				counter++;
				if (counter == 3)
				{
					Console.WriteLine("        </tr>");
					counter = 0;
				}
			}
			if (counter != 0)
			{
				Console.WriteLine("        </tr>");
			}

			Console.WriteLine("    </table>");
			Console.WriteLine("</body>");
			Console.WriteLine("</html>");
			Console.WriteLine("====");
		}
		private static void Intro(int customerID, ModelStore modelStore)
		{
			Console.WriteLine("    " + modelStore.GetCustomer(customerID).FirstName + ", here is your menu:");
			Console.WriteLine("    <table>");
			Console.WriteLine("        <tr>");
			Console.WriteLine("            <td><a href=\"/Books\">Books</a></td>");
			Console.WriteLine("            <td><a href=\"/ShoppingCart\">Cart (" + modelStore.GetCustomer(customerID).ShoppingCart.Items.Count + ")</a></td>");
			Console.WriteLine("        </tr>");
			Console.WriteLine("    </table>");
		}
		public static void InvalidPage()
		{
			Console.WriteLine("<!DOCTYPE html>");
			Console.WriteLine("<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\">");
			Console.WriteLine("<head>");
			Console.WriteLine("    <meta charset=\"utf-8\" />");
			Console.WriteLine("    <title>Nezarka.net: Online Shopping for Books</title>");
			Console.WriteLine("</head>");
			Console.WriteLine("<body>");
			Console.WriteLine("<p>Invalid request.</p>");
			Console.WriteLine("</body>");
			Console.WriteLine("</html>");
			Console.WriteLine("====");
		}
	}
}
