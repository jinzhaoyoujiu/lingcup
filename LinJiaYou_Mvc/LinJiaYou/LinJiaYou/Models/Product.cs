using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinJiaYou.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="商品名称")]
        [StringLength(10,ErrorMessage ="{0}应该在{2}位至{1}位之间。",MinimumLength =1)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="{0}是必需的。")]
        public decimal? Price { get; set; } 
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }        
    }
}