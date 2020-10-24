using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bedienungshilfe.Entity
{
    [Table("author")]
    public class Author
    {
        [Column("id")]
        [Key]
        public int id { get; set; }
    }
}
