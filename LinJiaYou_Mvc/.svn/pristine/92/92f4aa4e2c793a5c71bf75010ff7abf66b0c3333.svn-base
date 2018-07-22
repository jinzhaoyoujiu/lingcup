using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinJiaYou.Models
{
    [Table("fManager")]
    public class Class1
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("manangerName",Order =3,TypeName ="nvarchar")]
        public string Name { get; set; }
        public string Password { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}