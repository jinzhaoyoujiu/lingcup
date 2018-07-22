using LinJiaYou.App_Start;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinJiaYou.Models
{
    [Model(ViewTitleName = "七牛云图片")]
    /// <summary>
    /// 七牛云图片
    /// </summary>
    public class QiNiuPicture
    {
        /// <summary>
        /// id
        /// </summary>
        public int ID { get; set; }
        
        [DisplayName("七牛云图片名称"),Required(AllowEmptyStrings =false,ErrorMessage ="请输入{0}")]
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        [DisplayName("七牛云图片"), Required(AllowEmptyStrings = false, ErrorMessage = "请输入{0}")]
        /// <summary>
        /// 图片路径
        /// </summary>
        public string Url { get; set; }
        //public int? PictureID { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public virtual Picture Picture { get; set; }
    }
}