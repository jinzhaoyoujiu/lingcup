namespace LinJiaYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PhoneVeriCode
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [StringLength(4,ErrorMessage ="{0}����Ϊ��{2}λ��{1}λ֮�������",ErrorMessageResourceName = "String1", ErrorMessageResourceType=typeof(Resource1),MinimumLength =0)]
        public string VerificationCode { get; set; }

        public DateTime? AddTime { get; set; }
        [NotMapped]
        public string DeviceType { get; set; }

    }
}
