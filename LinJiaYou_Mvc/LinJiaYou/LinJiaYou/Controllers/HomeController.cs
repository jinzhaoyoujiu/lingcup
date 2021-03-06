﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using LinJiaYou.Models;
using LinJiaYou.App_Start;
using System.Data.Entity;
using LinJiaYou.Collections;
using LinJiaYou.Comparers;
using LinJiaYou.Helper;


namespace LinJiaYou.Controllers
{
    [MyHandleError(View = "/Views/Shared/Error.cshtml")]
    public class HomeController : Controller
    {
        private LinJiaYouContext db = new LinJiaYouContext();
        /// <summary>
        /// index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            Test();
            ViewBag.essays = db.Essays.ToList();
            return View();
        }
        private void Test()
        {
            LinJiaYou.Collections.Shops shops = new LinJiaYou.Collections.Shops();
            if (shops.GetType() == typeof(Shops))
            {
                if (shops is Shops)
                {
                    int tt = 9;
                }
            }
            LinJiaYou.Dictionarys.Shops shops2 = new Dictionarys.Shops();
            Shop a = new Shop { ID = 1 };
            Shop b = a;
            a.ID = 2;
            Shop d = (Shop)a.Clone();
            a.ID = 3;
            foreach (Shop item in shops2)
            {
                int ti = item.ID;
            }
            Shop shop = a + d;
            shop = a - d;
            shop = a * d;
            shop = a / d;
            if (a) { }
            if (a.CompareTo(b) > 0) { }
            Essay essay = new Essay { ID = 43 };
            Shop shop1 = essay;
            if (shop is BaseModel)
            {
                string teee = "";
            }

            essay = (Essay)shop1;

            BaseModel baseModel = new BaseModel();
            //Essay s = (Essay)baseModel;
            baseModel = essay;
            Essay s = baseModel as Essay;
            if (s == null)
            {
                string ta = "";
            }
            else
            {
                string ee = "";
            }
            ShopIDComparer shopIDComparer = new ShopIDComparer();
            int r= shopIDComparer.Compare(a, b);

            ModelHelper<Shop> modelHelper = new ModelHelper<Shop>(a);
            int aa = modelHelper.GetID();
            ModelHelper<Essay> modelHelper1 = new ModelHelper<Essay>(essay);
            modelHelper1.ChangeID();
            aa = modelHelper1.GetID();

            modelHelper = modelHelper + modelHelper;
            aa = modelHelper.GetID();

            NameModelHelper<Shop> shop11 = new NameModelHelper<Shop>(a);
            shop11 = shop11 + shop11;
            string rr = shop11.GetName();
            NameModelHelper<Tourist> t = new NameModelHelper<Tourist>(new Tourist ());

            MyStruct<Shop> @struct = new MyStruct<Shop>(new Shop());
            string e = @struct.GetName();
            var result = (from n in db.Shops
                         where n.Name.Length > 0
                         orderby n.ID descending,n.Name ascending
                         select n).Distinct();
            var bR = db.Shops.Any(x => x.ID > 0);
            bR = db.Shops.All(x => x.ID > 0);
            var ts = from n in db.Shops
                     group n by n.Address into ng
                     select new { ids=ng.Sum(m=>m.ID),ad=ng.Key };
           var yu= db.Shops.GroupBy(x => x.Address).Select(x=>new { ids=x.Sum(tu=>tu.ID),ad=x.Key});
           var aw = db.Shops.Take(3);
            var aww = db.Shops.Skip(3);
            var ert = aw.Intersect(aww);
            ert = aw.Except(aww);
            ert = aw.Union(aww);
            var rw = from n in db.Shops
                     join ertw in db.Essays on n.ID equals ertw.ID
                     select new { id=n.ID};
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult TouristInfo()
        {
            return View();
        }
        /// <summary>
        /// 景点列表
        /// </summary>
        /// <returns></returns>
        public ActionResult TouristInfoList()
        {
            List<Tourist> touristInfoList = new List<Tourist>();
            try
            {
                    touristInfoList = (from n in db.Tourists where n.Name != null select n).ToList();
            }
            catch(Exception e)
            {
                string aaaa = e.Message;
            }
            return View(touristInfoList);
        }
        /// <summary>
        /// 超市列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ShopList()
        {

            return View();
        }
        /// <summary>
        /// 超市列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Shop()
        {
            return View();
        }
        /// <summary>
        /// 旅店列表
        /// </summary>
        /// <returns></returns>
        public ActionResult HotelList()
        {
            return View();
        }
        /// <summary>
        /// 照片列表
        /// </summary>
        /// <returns></returns>
        public ActionResult PhotoList()
        {
            return View();
        }
        /// <summary>
        /// 二手列表
        /// </summary>
        /// <returns></returns>
        public ActionResult UsedList()
        {
            return View();
        }
        /// <summary>
        /// 招聘列表
        /// </summary>
        /// <returns></returns>
        public ActionResult JobList()
        {
            return View();
        }
        /// <summary>
        /// 农收列表
        /// </summary>
        /// <returns></returns>
        public ActionResult DealList()
        {
            return View();
        }
        /// <summary>
        /// 头条列表
        /// </summary>
        /// <returns></returns>
        public ActionResult NewsList()
        {
            return View();
        }
        /// <summary>
        /// 本地列表 
        /// </summary>
        /// <returns></returns>
        public ActionResult ServiceList()
        {
            return View();
        }
        /// <summary>
        /// 超市特价列表
        /// </summary>
        /// <returns></returns>
        public ActionResult SpecialPriceList()
        {
            return View();
        }
        public string GetAreas()
        {
            var result = new object();
            List<Province> pList = new List<Province>();
            List<City> cityList = new List<City>();
            List<County> countyList = new List<County>();
            result = db.Provinces.Select(x =>
                    new
                    {
                        id = x.Id,
                        name = x.Name,
                        children = db.Citys.Where(y => y.ProvinceId == x.Id)
                                                   .Select(z => new
                                                   {
                                                       id = z.Id,
                                                       name = z.Name,
                                                       children = db.Countys.Where(w => w.CityId == z.Id).Select(co => new { id = co.Id, name = co.Name }).OrderBy(h => h.name)
                                                   }).OrderBy(uz=> uz.name)
                    }
               ).OrderBy(wz => wz.name).ToList();
            return Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }
    }
}
