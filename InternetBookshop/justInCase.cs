using System;

namespace BookShop
{
    class RequestProcessor
    {
        private static void RemoveBookFromShoppingCart(ModelStore modelStore, int bookId, int customerId)
        {
            bool found = false;
            foreach (ShoppingCartItem item in modelStore.GetCustomer(customerId).ShoppingCart.Items)
            {
                if (item.BookId == bookId)
                {
                    found = true;
                    item.Count--;
                }
            }
            var itemToRemove = modelStore.GetCustomer(customerId).ShoppingCart.Items.Find(r => r.Count == 0);
            modelStore.GetCustomer(customerId).ShoppingCart.Items.Remove(itemToRemove);
            if (!found)
            {
                PrintInvalidPage();
                return;
            }
            PrintShoppingCart(modelStore, customerId);
        }

        private static void AddBookToShoppingCart(ModelStore modelStore, int bookId, int customerId)
        {
            bool found = false;
            foreach (ShoppingCartItem item in modelStore.GetCustomer(customerId).ShoppingCart.Items)
            {
                if (item.BookId == bookId)
                {
                    found = true;
                    item.Count++;
                }
            }
            if (!found)
            {
                ShoppingCartItem item = new ShoppingCartItem();
                item.BookId = bookId;
                item.Count = 1;
                modelStore.GetCustomer(customerId).ShoppingCart.Items.Add(item);
            }
            PrintShoppingCart(modelStore, customerId);
        }
        }
    }
}