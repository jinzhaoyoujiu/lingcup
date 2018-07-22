using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinJiaYou.Models
{
    /// <summary>
    /// 市
    /// </summary>
    public class City
    {
        /// <summary>
        /// 标识
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        public int? ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        /// <summary>
        /// 省
        /// </summary>
        public virtual Province Province { get; set; }
        /// <summary>
        /// 县
        /// </summary>
        public virtual List<County> Countys { get; set; }
        


    }
}