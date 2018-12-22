using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using LinJiaYou.Models;
using LinJiaYou.App_Start;
using System.Data.Entity;
using LinJiaYou.Collections;

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
            Shops shops = new Shops();
            shops.Add(new Shop { });
            Shop s = shops[0];
            ViewBag.essays = db.Essays.ToList();

            return View();
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
