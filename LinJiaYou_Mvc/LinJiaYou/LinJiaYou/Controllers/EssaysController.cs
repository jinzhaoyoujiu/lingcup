using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using LinJiaYou.Models;

namespace LinJiaYou.Controllers
{
    public class EssaysController : Controller
    {
        private LinJiaYouContext db = new LinJiaYouContext();

        // GET: Essays
        public ActionResult Index()
        {
            var essays = db.Essays.Include(e => e.Tourist);
            return View(essays.ToList());
        }

        // GET: Essays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Essay essay = db.Essays.Find(id);
            if (essay == null)
            {
                return HttpNotFound();
            }
            return View(essay);
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
