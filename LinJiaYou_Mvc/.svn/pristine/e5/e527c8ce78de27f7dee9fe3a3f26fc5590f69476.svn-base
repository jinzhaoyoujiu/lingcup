namespace LinJiaYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;
    public partial class Tourist
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Tourists()
        //{
        //    Pictures = new HashSet<Pictures>();
        //    Pictures1 = new HashSet<Pictures>();
        //}

        [Key]
        public int PrimaryTrackingKeyID { get; set; }
        [DisplayName("¾°µãÃû³Æ")]
        [Required]
        public string Name { get; set; }

        public string FirstPicUrl { get; set; }

        public string Intro { get; set; }

        public bool? Is_delete { get; set; }
        public TouristDetail TouristDetail { get; set; }
        public virtual List<Picture> Pictures { get; set; }
        public virtual ICollection<Essay> Essays { get; set; } 
    }
}
