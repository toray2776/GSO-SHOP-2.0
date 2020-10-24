using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bedienungshilfe.Entity
{
    [Table("shopping_cart_item")]
    class ShoppingCartItem
    {
        [Column("id")]
        [Key]
        public int id { get; set; }
    }
}
