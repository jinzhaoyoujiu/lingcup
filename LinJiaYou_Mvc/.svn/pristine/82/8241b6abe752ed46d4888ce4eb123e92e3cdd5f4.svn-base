using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace LinJiaYou.Models
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    internal static class Extension
    {
        public static string GetDescription(this Enum en)
        {
            string result = string.Empty;
            Type a = en.GetType();
            System.Reflection.FieldInfo fildInfo = a.GetField(en.ToString());
            object[] os= fildInfo.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            if(os!=null && os.Length>=1)
            {
                System.ComponentModel.DescriptionAttribute descrip = os[0] as System.ComponentModel.DescriptionAttribute;
                result = descrip.Description;
            }
            return result;
        }
    }
}