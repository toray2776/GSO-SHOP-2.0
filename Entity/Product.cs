using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bedienungshilfe.Entity
{
    [Table("product")]
    public class Product
    {
        [Column("id")]
        [Key]
        public int id { get; set; }
       
        [Column("title", TypeName = "varchar(255)")]
        public string title { get; set; }

        [Column("ean", TypeName = "varchar(255)")]
        public string ean { get; set; }

        [Column("price", TypeName = "float")]
        public float price { get; set; }

        [Column("release_date", TypeName = "datetime")]
        public DateTime releaseDate { get; set; }

        public Publisher publisher { get; set; }

        public Author author { get; set; }

        public Format format { get; set; }

        public Category category { get; set; }
    }
}
