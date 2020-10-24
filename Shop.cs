using Bedienungshilfe.Entity;
using Bedienungshilfe.Repository;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedienungshilfe
{
    class Shop
    {
        public void ShowAllProducts()
        {
            List<Product> products = this.GetAllProducts();

            foreach(Product product in products)
            {
                this.PrintProduct(product);
            }
        }

        private void PrintProduct(Product product)
        {
            Console.WriteLine(String.Format("{0, -20}: {1}", "Produkt Id", product.id));
            Console.WriteLine(String.Format("{0, -20}: {1}", "Titel", product.title));
            Console.WriteLine(String.Format("{0, -20}: {1}", "Category", product.category.name));
            Console.WriteLine(String.Format("{0, -20}: {1}", "Format", product.format.name));
            Console.WriteLine(String.Format("{0, -20}: {1}", "Autor", product.author.name));
            Console.WriteLine(String.Format("{0, -20}: {1}", "EAN", product.ean));
            Console.WriteLine(String.Format("{0, -20}: {1}", "Publisher", product.publisher.name));
            Console.WriteLine(String.Format("{0, -20}: {1}", "Preis", product.price));
            Console.WriteLine();
        }

        private List<Product> GetAllProducts()
        {
            List<Product> products;

            using (var repository = new ProductContext())
            {
                products = repository.FindAll();
            }

            return products;
        }

        public bool AddProductToShoppingCart(Product product, ShoppingCart shoppingCart, int amount = 1)
        {
            ShoppingCartService shoppingCartService = new ShoppingCartService(shoppingCart);

            return shoppingCartService.AddProductToShoppingCart(product, amount);

            ShoppingCartItem shoppingCartItem;

            if (this.ShoppingCartContainsProduct(shoppingCart, product))
            {

            }

            shoppingCartItem = new ShoppingCartItem();
            shoppingCartItem.SetAmount(amount);
            shoppingCartItem.AddProduct(product);
            shoppingCart.AddShoppingCartItem(shoppingCartItem);

            return true;
        }
    }
}
