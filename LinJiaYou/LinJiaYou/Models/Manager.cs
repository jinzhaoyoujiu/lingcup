using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using LinJiaYou.App_Start;

namespace LinJiaYou.Models
{
    public class Manager:IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name != null && Name.ToString().Contains(" ") )
            {
                yield return new ValidationResult("white space is not permitted", new [] { "Name" });
            }
            //throw new NotImplementedException();
        }
        
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="请输入{0}")]
        [StringLength(12, ErrorMessageResourceName = "stringLength", ErrorMessageResourceType = typeof(ManagerName), MinimumLength = 3)]
        [NameValidation(notString: "胡锦涛")] 
        [Display(Name="用户名", Order =12000)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "请输入{0}"),ConcurrencyCheck]
        [Display(Name = "密码", Order = 12040)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Timestamp]
        public byte[] TimeStamp { get; set; }

    }
}