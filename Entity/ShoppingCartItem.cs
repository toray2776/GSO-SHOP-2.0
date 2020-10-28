using SQLitePCL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bedienungshilfe.Entity
{
    [Table("shopping_cart_item")]
    public class ShoppingCartItem
    {
        [Column("id")]
        [Key]
        public int id { get; set; }

        public ShoppingCart shoppingCart { get; set; }

        public Product product { get; set; }

        [Column("amount", TypeName = "integer")]
        public int amount { get; set; }

        internal void IncreaseAmount(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
