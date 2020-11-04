using Bedienungshilfe.Entity;
using Bedienungshilfe.Repository;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedienungshilfe
{
    public class Dashboard
    {
        private User user;
        private ShoppingCartContext shoppingCartContext;

        public Dashboard(User user)
        {
            this.user = user;
            this.shoppingCartContext = new ShoppingCartContext();
        }

        public void Show()
        {
            do
            {
                Menu menu = new Menu("Main Menü", this.user);
                menu.addMenuItem("Produkte ansehen");
                menu.addMenuItem("Einkaufswagen");
                menu.addMenuItem("Logout");
                menu.addMenuItem("Shosdfsdfp132");
                menu.MenuText = "Das ist der Menü Text";
                menu.Prefix = "-";
                menu.WhiteSpaceBeforePrefix = true;
                menu.mark = MenuMark.Prefix;
                menu.ShowMenu();
                switch (menu.value)
                {
                    case "Produkte ansehen":
                        Shop shop = new Shop(this.user);
                        shop.ShowAllProducts();
                        break;
                    case "Einkaufswagen":
                        ShoppingCartView shoppingCartView = new ShoppingCartView(this.shoppingCartContext.FindActualCartForUser(this.user));
                        shoppingCartView.ShowShoppingCartItems(this.user);
                        break;
                    default:
                        break;
                }
                if (menu.value == "Logout")
                {
                    return;
                }
            } while (true);
        }
    }
}
