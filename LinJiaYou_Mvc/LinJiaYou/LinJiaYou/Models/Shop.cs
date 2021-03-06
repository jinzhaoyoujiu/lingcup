﻿using LinJiaYou.App_Start;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LinJiaYou.Models
{
    [Model(ViewTitleName = "商店")]
    /// <summary>
    /// 商店
    /// </summary>
    public class Shop : BaseModel, IHaveNameModel, System.ICloneable, System.IComparable
    {
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
        public object Clone()
        {
            Shop shop = new Shop();
            shop.ID = ID;
            return shop;
        }

        public int CompareTo(object obj)
        {
            int result = 0;
            Shop shop = (Shop)obj;
            if (shop.ID < this.ID)
            {
                result = 1;
            }
            else if (shop.ID == this.ID)
            {
                result = 0;
            }
            else if (shop.ID > this.ID)
            {
                result= - 1;
            }
            return result;
        }

        public static Shop operator +(Shop shop1, Shop shop2)
        {
            Shop shop = new Shop();
            shop.ID = shop1.ID + shop2.ID;
            return shop;
        }
        public static Shop operator -(Shop shop1, Shop shop2)
        {
            Shop shop = new Shop();
            shop.ID = System.Math.Abs(shop1.ID - shop2.ID);
            return shop;
        }
        public static Shop operator *(Shop shop1, Shop shop2)
        {
            Shop shop = new Shop();
            shop.ID = shop1.ID * shop2.ID;
            return shop;
        }
        public static Shop operator /(Shop shop1, Shop shop2)
        {
            Shop shop = new Shop();
            var a = decimal.Parse((shop1.ID / shop2.ID).ToString());
            shop.ID = (int)System.Math.Ceiling(a);
            return shop;
        }
        public static bool operator true(Shop shop1)
        {
            bool result = false;
            if (shop1.ID>1) { result = true; }
            return result;
        }
        public static bool operator false(Shop shop1)
        {
            bool result = false;
            if (shop1.ID > 1) { result = true; }
            return result;
        }
        public static explicit operator Essay(Shop shop)
        {
            Essay essay = new Essay();
            checked { essay.ID = shop.ID; }
            return essay;
        }
    }
}