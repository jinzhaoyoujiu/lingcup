using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LinJiaYou.Models;

namespace LinJiaYou.Areas.Manage.Controllers
{
    public class EssaysController : Controller
    {
        private LinJiaYouContext db = new LinJiaYouContext();

        // GET: Manage/Essays
        public ActionResult Index()
        {
            var essays = db.Essays.Include(e => e.Tourist);
            return View(essays.ToList());
        }

        // GET: Manage/Essays/Details/5
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

        // GET: Manage/Essays/Create
        public ActionResult Create()
        {
            ViewBag.TouristID = new SelectList(db.Tourists, "PrimaryTrackingKeyID", "Name");
            return View();
        }

        // POST: Manage/Essays/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Content,Author,EssayType,TouristID")] Essay essay)
        {
            if (ModelState.IsValid)
            {
                db.Essays.Add(essay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TouristID = new SelectList(db.Tourists, "PrimaryTrackingKeyID", "Name", essay.TouristID);
            return View(essay);
        }

        // GET: Manage/Essays/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.TouristID = new SelectList(db.Tourists, "PrimaryTrackingKeyID", "Name", essay.TouristID);
            return View(essay);
        }

        // POST: Manage/Essays/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Content,Author,EssayType,TouristID")] Essay essay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(essay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TouristID = new SelectList(db.Tourists, "PrimaryTrackingKeyID", "Name", essay.TouristID);
            return View(essay);
        }

        // GET: Manage/Essays/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Manage/Essays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Essay essay = db.Essays.Find(id);
            db.Essays.Remove(essay);
            db.SaveChanges();
            return RedirectToAction("Index");
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
