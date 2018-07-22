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
    public class QiNiuPicturesController : Controller
    {
        private LinJiaYouContext db = new LinJiaYouContext();

        // GET: Manage/QiNiuPictures
        public ActionResult Index()
        {
            var qiNiuPictures = db.QiNiuPictures.Include(q => q.Picture);
            return View(qiNiuPictures.ToList());
        }

        // GET: Manage/QiNiuPictures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QiNiuPicture qiNiuPicture = db.QiNiuPictures.Find(id);
            if (qiNiuPicture == null)
            {
                return HttpNotFound();
            }
            return View(qiNiuPicture);
        }

        // GET: Manage/QiNiuPictures/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Pictures, "QiNiuPictureID", "QiNiuPictureID");
            return View();
        }

        // POST: Manage/QiNiuPictures/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Url")] QiNiuPicture qiNiuPicture)
        {
            if (ModelState.IsValid)
            {
                db.QiNiuPictures.Add(qiNiuPicture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Pictures, "QiNiuPictureID", "QiNiuPictureID", qiNiuPicture.ID);
            return View(qiNiuPicture);
        }

        // GET: Manage/QiNiuPictures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QiNiuPicture qiNiuPicture = db.QiNiuPictures.Find(id);
            if (qiNiuPicture == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Pictures, "QiNiuPictureID", "QiNiuPictureID", qiNiuPicture.ID);
            return View(qiNiuPicture);
        }

        // POST: Manage/QiNiuPictures/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Url")] QiNiuPicture qiNiuPicture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qiNiuPicture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Pictures, "QiNiuPictureID", "QiNiuPictureID", qiNiuPicture.ID);
            return View(qiNiuPicture);
        }

        // GET: Manage/QiNiuPictures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QiNiuPicture qiNiuPicture = db.QiNiuPictures.Find(id);
            if (qiNiuPicture == null)
            {
                return HttpNotFound();
            }
            return View(qiNiuPicture);
        }

        // POST: Manage/QiNiuPictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QiNiuPicture qiNiuPicture = db.QiNiuPictures.Find(id);
            db.QiNiuPictures.Remove(qiNiuPicture);
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
