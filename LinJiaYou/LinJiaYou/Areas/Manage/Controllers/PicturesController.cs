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
    public class PicturesController : Controller
    {
        private LinJiaYouContext db = new LinJiaYouContext();

        // GET: Manage/Pictures
        public ActionResult Index()
        {
            var pictures = db.Pictures.Include(p => p.FromDealshot).Include(p => p.FromHeadshot).Include(p => p.FromUsed).Include(p => p.QiNiuPicture).Include(p => p.Shop).Include(p => p.Tourist);
            return View(pictures.ToList());
        }

        // GET: Manage/Pictures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // GET: Manage/Pictures/Create
        public ActionResult Create()
        {
            ViewBag.UserFromDealshot = new SelectList(db.Users, "Id", "Name");
            ViewBag.UserFromHeadshot = new SelectList(db.Users, "Id", "Name");
            ViewBag.UserFromUsedID = new SelectList(db.Users, "Id", "Name");
            ViewBag.QiNiuPictureID = new SelectList(db.QiNiuPictures, "ID", "Name");
            ViewBag.ShopID = new SelectList(db.Shops, "ID", "Name");
            ViewBag.TouristID = new SelectList(db.Tourists, "PrimaryTrackingKeyID", "Name");
            return View();
        }

        // POST: Manage/Pictures/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QiNiuPictureID,TouristID,UserFromUsedID,UserFromHeadshot,UserFromDealshot,Is_Cover,ShopID")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                db.Pictures.Add(picture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserFromDealshot = new SelectList(db.Users, "Id", "Name", picture.UserFromDealshot);
            ViewBag.UserFromHeadshot = new SelectList(db.Users, "Id", "Name", picture.UserFromHeadshot);
            ViewBag.UserFromUsedID = new SelectList(db.Users, "Id", "Name", picture.UserFromUsedID);
            ViewBag.QiNiuPictureID = new SelectList(db.QiNiuPictures, "ID", "Name", picture.QiNiuPictureID);
            ViewBag.ShopID = new SelectList(db.Shops, "ID", "Name", picture.ShopID);
            ViewBag.TouristID = new SelectList(db.Tourists, "PrimaryTrackingKeyID", "Name", picture.TouristID);
            return View(picture);
        }

        // GET: Manage/Pictures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserFromDealshot = new SelectList(db.Users, "Id", "Name", picture.UserFromDealshot);
            ViewBag.UserFromHeadshot = new SelectList(db.Users, "Id", "Name", picture.UserFromHeadshot);
            ViewBag.UserFromUsedID = new SelectList(db.Users, "Id", "Name", picture.UserFromUsedID);
            ViewBag.QiNiuPictureID = new SelectList(db.QiNiuPictures, "ID", "Name", picture.QiNiuPictureID);
            ViewBag.ShopID = new SelectList(db.Shops, "ID", "Name", picture.ShopID);
            ViewBag.TouristID = new SelectList(db.Tourists, "PrimaryTrackingKeyID", "Name", picture.TouristID);
            return View(picture);
        }

        // POST: Manage/Pictures/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QiNiuPictureID,TouristID,UserFromUsedID,UserFromHeadshot,UserFromDealshot,Is_Cover,ShopID")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(picture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserFromDealshot = new SelectList(db.Users, "Id", "Name", picture.UserFromDealshot);
            ViewBag.UserFromHeadshot = new SelectList(db.Users, "Id", "Name", picture.UserFromHeadshot);
            ViewBag.UserFromUsedID = new SelectList(db.Users, "Id", "Name", picture.UserFromUsedID);
            ViewBag.QiNiuPictureID = new SelectList(db.QiNiuPictures, "ID", "Name", picture.QiNiuPictureID);
            ViewBag.ShopID = new SelectList(db.Shops, "ID", "Name", picture.ShopID);
            ViewBag.TouristID = new SelectList(db.Tourists, "PrimaryTrackingKeyID", "Name", picture.TouristID);
            return View(picture);
        }

        // GET: Manage/Pictures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: Manage/Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Picture picture = db.Pictures.Find(id);
            db.Pictures.Remove(picture);
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
