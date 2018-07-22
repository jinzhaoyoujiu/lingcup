using LinJiaYou.App_Start;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LinJiaYou.Models
{
    [Model(ViewTitleName = "商店")]
    /// <summary>
    /// 商店
    /// </summary>
    public class Shop
    {
        /// <summary>
        /// id
        /// </summary>
        public int ID { get; set; }
        [Required]
        [DisplayName("商店名称")]
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        [DisplayName("联系方式")]
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 面积
        /// </summary>
        [DisplayName("面积")]
        public double? Area { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public virtual List<Picture> Pictures { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [DisplayName("地址")]
        public string Address { get; set; }

        /// <summary>
        /// 地图位置
        /// </summary>
        [DisplayName("地图位置")]
        public string Position { get; set; }
    }
}