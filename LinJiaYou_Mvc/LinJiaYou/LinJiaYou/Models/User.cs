namespace LinJiaYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public User()
        //{
        //    Pictures = new HashSet<Pictures>();
        //    Pictures1 = new HashSet<Pictures>();
        //    Pictures2 = new HashSet<Pictures>();
        //}

        public int Id { get; set; }
        [DisplayName("用户")]
        public string Name { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }
        [DisplayName("二手物品名称")]
        [InverseProperty("FromUsed")]
        /// <summary>
        /// 二手物品图片
        /// </summary>
        public virtual List<Picture> Used { get; set; }
        [InverseProperty("FromHeadshot")]
        /// <summary>
        /// 用户头像
        /// </summary>
        public virtual List<Picture> Headshot { get; set; }
        [InverseProperty("FromDealshot")]
        /// <summary>
        /// 农收
        /// </summary>
        public virtual List<Picture> Deal { get; set; }
        /// <summary>
        /// 商品
        /// </summary>
        public virtual List<Product> Products { get; set; }

    }
}
