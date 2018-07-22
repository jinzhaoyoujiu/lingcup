namespace LinJiaYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExceptionLog
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string Source { get; set; }

        public string TargetSite { get; set; }

        public DateTime? AddDate { get; set; }
    }
}
