using Bedienungshilfe.Entity;
using Bedienungshilfe.Repository;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bedienungshilfe
{
    class Shop
    {
        private User user;
        private ShoppingCartContext shoppingCartContext;

        public Shop(User user)
        {
            this.user = user;
            this.shoppingCartContext = new ShoppingCartContext();
        }

        public void ShowAllProducts()
        {
            do
            {
                Console.Clear();

                Menu productsMenu = new Menu("Produkte Menü", this.user);

                List<Product> products = this.GetAllProducts();

                foreach (Product product in products)
                {
                    productsMenu.addMenuItem(product.title);
                }

                productsMenu.addMenuItem("Zurück");
                productsMenu.MenuText = "Das ist der Produkt Text";
                productsMenu.Prefix = "-";
                productsMenu.WhiteSpaceBeforePrefix = true;
                productsMenu.mark = MenuMark.Prefix;
                productsMenu.ShowMenu();
                if (productsMenu.value == "Zurück")
                {
                    return;
                }

                this.ShowProductByTitle(productsMenu.value);
            } while (true);
        }

        private void ShowProductByTitle(string productTitle)
        {
            Console.Clear();

            Product product = this.GetProductByTitle(productTitle);

            if (product == null)
            {
                return;
            }

            Menu productMenu = new Menu("Produkt Menü", this.user);
            productMenu.addMenuItem("In den Einkaufswagen");
            productMenu.addMenuItem("Zurück");
            productMenu.MenuText = this.GetProductMenuText(product);
            productMenu.Prefix = "-";
            productMenu.WhiteSpaceBeforePrefix = true;
            productMenu.mark = MenuMark.Prefix;
            productMenu.ShowMenu();
            
            if (productMenu.value == "Zurück")
            {
                return;
            }

            this.AddProductToShoppingCart(product, this.GetActualShoppingCart());
        }

        private ShoppingCart GetActualShoppingCart()
        {
            return this.shoppingCartContext.FindActualCartForUser(this.user);
        }

        private Product GetProductByTitle(string productTitle)
        {
            Product product;

            using (var repository = new ProductContext())
            {
                product = repository.FindByTitle(productTitle);
            }

            return product;
        }

        private string GetProductMenuText(Product product)
        {
            string menuText = String.Format("{0, 2}{1, -20}: {2}\n", "", "Produkt Id", product.id);
            menuText += String.Format("{0, 2}{1, -20}: {2}\n", "", "Titel", product.title);
            menuText += String.Format("{0, 2}{1, -20}: {2}\n", "", "Category", product.category.name);
            menuText += String.Format("{0, 2}{1, -20}: {2}\n", "", "Format", product.format.name);
            menuText += String.Format("{0, 2}{1, -20}: {2}\n", "", "Autor", product.author.name);
            menuText += String.Format("{0, 2}{1, -20}: {2}\n", "", "EAN", product.ean);
            menuText += String.Format("{0, 2}{1, -20}: {2}\n", "", "Publisher", product.publisher.name);
            menuText += String.Format("{0, 2}{1, -20}: {2}\n", "", "Preis", product.price);

            return menuText;
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
        }
    }
}
