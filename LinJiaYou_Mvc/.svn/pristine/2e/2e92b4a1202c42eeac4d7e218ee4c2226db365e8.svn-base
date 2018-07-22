namespace LinJiaYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    public partial class Picture
    {
        [Key,ForeignKey("QiNiuPicture")]
        public int QiNiuPictureID { get; set; }
        //[DisplayName("图片")]
        //public string Url { get; set; }
        /// <summary>
        /// 景点
        /// </summary>
        public int? TouristID { get; set; }
        [ForeignKey("TouristID")]
        [DisplayName("景点")]
        public virtual Tourist Tourist { get; set; }
        [DisplayName("用户二手物品")]
        public int? UserFromUsedID { get; set; }

        [ForeignKey("UserFromUsedID")]
        public virtual User FromUsed { get; set; }
        [DisplayName("用户头像")]
        public int? UserFromHeadshot { get; set; }

        [ForeignKey("UserFromHeadshot")]
        public virtual User FromHeadshot { get; set; }
        [DisplayName("用户交易")]
        public int? UserFromDealshot { get; set; }

        [ForeignKey("UserFromDealshot")]
        public virtual User FromDealshot { get; set; }
        [DisplayName("是否是商店的头像")]
        /// <summary>
        /// 是否是商店的头像
        /// </summary>
        public bool? Is_Cover { get; set; }
        [DisplayName("商店")]
        public int? ShopID { get; set; }

        [ForeignKey("ShopID")]
        public virtual Shop Shop { get; set; }
        //[DisplayName("七牛云图片")]
        //public int? QiNiuPictureID { get; set; }
        //[ForeignKey("QiNiuPictureID")]
        public virtual QiNiuPicture QiNiuPicture { get; set; }
    }
}
