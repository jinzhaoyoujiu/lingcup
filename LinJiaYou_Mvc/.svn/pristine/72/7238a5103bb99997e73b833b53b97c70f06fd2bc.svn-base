using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LinJiaYou.Models;

namespace LinJiaYou.Controllers
{
    public class ShopsController : Controller
    {
        private LinJiaYouContext db = new LinJiaYouContext();

        // GET: Shops
        public ActionResult Index()
        {
            return View(db.Shops.ToList().OrderBy(x=>x.Name));
        }

        // GET: Shops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
