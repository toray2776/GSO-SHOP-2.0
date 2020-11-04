using Bedienungshilfe.Entity;
using Bedienungshilfe.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedienungshilfe
{
    class ShoppingCartView
    {
        private ShoppingCart shoppingCart { get; }

        private ProductContext productContext;
        private ShoppingCartItemContext shoppingCartItemContext;

        public ShoppingCartView(ShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
            this.productContext = new ProductContext();
            this.shoppingCartItemContext = new ShoppingCartItemContext();
        }

        public void ShowShoppingCartItems(User user)
        {
            do
            {
                Console.Clear();

                Menu menu = new Menu("Einkaufswagen", user);

                List<ShoppingCartItem> shoppingCartItems = this.shoppingCart.shoppingCartItems;

                foreach (ShoppingCartItem shoppingCartItem in shoppingCartItems)
                {
                    menu.addMenuItem(shoppingCartItem.product.title);
                }

                menu.addMenuItem("Zurück");
                menu.MenuText = "Das ist der Einkaufswagen Text";
                menu.Prefix = "-";
                menu.WhiteSpaceBeforePrefix = true;
                menu.mark = MenuMark.Prefix;
                menu.ShowMenu();
                if (menu.value == "Zurück")
                {
                    return;
                }

                this.ShowItemDetails(menu.value, user);
            } while (true);
        }

        private void ShowItemDetails(string productTitle, User user)
        {
            Console.Clear();

            Product product = this.GetProductByTitle(productTitle);

            if (product == null)
            {
                return;
            }

            Menu shoppingCartItemMenu = new Menu("Einkaufswagen Item", user);
            shoppingCartItemMenu.addMenuItem("Zurück");
            shoppingCartItemMenu.MenuText = this.GetShoppingCartItemText(product);
            shoppingCartItemMenu.Prefix = "-";
            shoppingCartItemMenu.WhiteSpaceBeforePrefix = true;
            shoppingCartItemMenu.mark = MenuMark.Prefix;
            shoppingCartItemMenu.ShowMenu();

            if (shoppingCartItemMenu.value == "Zurück")
            {
                return;
            }
        }

        private string GetShoppingCartItemText(Product product)
        {
            ShoppingCartItem shoppingCartItem = this.shoppingCartItemContext.FindByProductTitleAndShoppingCart(this.shoppingCart, product.title);

            string menuText = String.Format("{0, 2}{1, -20}: {2}\n", "", "Titel", product.title);
            menuText += String.Format("{0, 2}{1, -20}: {2}\n", "", "Category", product.category.name);
            menuText += String.Format("{0, 2}{1, -20}: {2}\n", "", "Format", product.format.name);
            menuText += String.Format("{0, 2}{1, -20}: {2}\n", "", "Autor", product.author.name);
            menuText += String.Format("{0, 2}{1, -20}: {2}\n", "", "EAN", product.ean);
            menuText += String.Format("{0, 2}{1, -20}: {2}\n", "", "Publisher", product.publisher.name);
            menuText += String.Format("{0, 2}{1, -20}: {2}\n", "", "Preis", product.price);
            menuText += String.Format("{0, 2}{1, -20}: {2}\n", "", "Anzahl", shoppingCartItem.amount);

            return menuText;
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
    }
}
