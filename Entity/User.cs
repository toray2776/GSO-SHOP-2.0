using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bedienungshilfe.Entity
{
    [Table("user")]
    public class User
    {
        [Column("user_id")][Key]
        public int UserId { get; set; }

        [Column("first_name", TypeName = "varchar(255)")]
        public string firstName { get; set; }
    }
}
