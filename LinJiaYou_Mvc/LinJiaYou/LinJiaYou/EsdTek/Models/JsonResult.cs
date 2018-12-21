using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinJiaYou.EsdTek.Models
{
    public class MyJsonResult
    {
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public dynamic Data { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
    }
}