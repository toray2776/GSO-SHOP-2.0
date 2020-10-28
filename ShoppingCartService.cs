using Bedienungshilfe.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedienungshilfe
{
    public class ShoppingCartService
    {
        private ShoppingCart shoppingCart;

        public ShoppingCartService(ShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public bool AddProductToShoppingCart(Product product, int amount)
        {
            ShoppingCartItem shoppingCartItem;

            if (this.ShoppingCartContainsProduct(shoppingCart, product))
            {
                shoppingCartItem = this.GetShoppingCartItemByProduct(product);

                shoppingCartItem.IncreaseAmount(amount);

                using(var db = new ShopContext())
                {
                    db.Update(shoppingCartItem);
                    db.SaveChanges();
                }

                return true;
            }

            shoppingCartItem = new ShoppingCartItem();
            shoppingCartItem.amount = amount;
            shoppingCartItem.product = product;
            shoppingCart.AddShoppingCartItem(shoppingCartItem);

            using (var db = new ShopContext())
            {
                db.Update(shoppingCart);
                db.SaveChanges();
            }

            return true;
        }

        private ShoppingCartItem GetShoppingCartItemByProduct(Product product)
        {
            List<ShoppingCartItem> shoppingCartItems = shoppingCart.shoppingCartItems;

            for (int i = 0; i < shoppingCartItems.Count; i++)
            {
                if (shoppingCartItems[i].product == product)
                {
                    return shoppingCartItems[i];
                }
            }

            return null;
        }

        private bool ShoppingCartContainsProduct(ShoppingCart shoppingCart, Product product)
        {
            List<ShoppingCartItem> shoppingCartItems = shoppingCart.shoppingCartItems;

            for(int i = 0; i < shoppingCartItems.Count; i++)
            {
                if (shoppingCartItems[i].product == product)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
