using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinJiaYou.Models
{
    /// <summary>
    /// 县
    /// </summary>
    public class County
    {
        /// <summary>
        /// 标识
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 市ID
        /// </summary>
        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        /// <summary>
        /// 市
        /// </summary>
        public virtual City City { get; set; }
        ///// <summary>
        ///// 省ID
        ///// </summary>
        //public int? ProvinceId { get; set; }
        //[ForeignKey("ProvinceId")]
        ///// <summary>
        ///// 省
        ///// </summary>
        //public virtual Province Province { get; set; }

    }
}