using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bedienungshilfe.Entity
{
    [Table("format")]
    public class Format
    {
        [Column("id")]
        [Key]
        public int id { get; set; }

        [Column("name", TypeName = "varchar(255)")]
        public string name { get; set; }

        public List<Product> products { get; set; }

        public void AddProduct(Product product)
        {
            if (products.Contains(product))
            {
                return;
            }

            products.Add(product);
        }
    }
}
