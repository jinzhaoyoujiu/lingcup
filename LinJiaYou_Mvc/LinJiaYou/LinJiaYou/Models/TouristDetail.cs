using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace LinJiaYou.Models
{
    [ComplexType]
    public class TouristDetail
    {
        [Column("touristDescription",TypeName="nvarchar")]
        public string Description { get; set; }
    }
}