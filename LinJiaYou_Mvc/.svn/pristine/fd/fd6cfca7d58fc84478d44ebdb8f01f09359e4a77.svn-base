using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LinJiaYou.Models
{
    internal enum ResultCode
    {
        [System.ComponentModel.Description("执行成功")]
        success= 1,
        [System.ComponentModel.Description("执行失败")]
        failed
    }
    public class JsonModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public JsonModel()
        {
            Status = ResultCode.success.ToString();
        }
    }
}