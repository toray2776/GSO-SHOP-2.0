using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bedienungshilfe.Entity
{
    [Table("shopping_cart")]
    public class ShoppingCart
    {
        [Column("id")]
        [Key]
        public int id { get; set; }

        public User user { get; set; }

        public List<ShoppingCartItem> shoppingCartItems { get; set; }

        [Column("purchased", TypeName = "boolean")]
        public bool purchased { get; set; }


        public void AddShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            if (shoppingCartItems.Contains(shoppingCartItem))
            {
                return;
            }

            
            shoppingCartItems.Add(shoppingCartItem);
        }
    }
}
