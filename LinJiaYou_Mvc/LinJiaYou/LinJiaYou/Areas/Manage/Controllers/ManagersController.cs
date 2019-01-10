﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LinJiaYou.Models;
using LinJiaYou.ViewModels;

namespace LinJiaYou.Areas.Manage.Controllers
{
    public class ManagersController : Controller
    {
        private LinJiaYouContext db = new LinJiaYouContext();

        // GET: Manage/Managers
        public ActionResult Index()
        {
            return View(db.Managers.ToList());
        }

        // GET: Manage/Managers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // GET: Manage/Managers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Managers/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Password,PasswordConfirm")] CreateManagerViewModel  manager)
        {
            if (ModelState.IsValid)
            {
                Manager newM = new Manager { Name=manager.Name,Password=manager.Password };
                db.Managers.Add(newM);
                db.SaveChanges();
                string url = "/manage/managers/index";
                return Redirect(url);
            }

            return View(manager);
        }

        // GET: Manage/Managers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // POST: Manage/Managers/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken] 
        public ActionResult EditPost(int? Id)
        {
            if (Id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var managerToUpdate = db.Managers.Find(Id);
            if (TryUpdateModel(managerToUpdate,"",new string[] { "Name", "Password"}))
            {
                try
                {
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                    string url = "/manage/managers/index";
                    return Redirect(url);
                }
                catch(DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            //if (ModelState.IsValid)
            //{
            //    db.Entry(manager).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            return View(managerToUpdate);
        }

        // GET: Manage/Managers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // POST: Manage/Managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manager manager = db.Managers.Find(id);
            db.Managers.Remove(manager);
            db.SaveChanges();
            //return RedirectToAction("Index");
            string url = "/manage/managers/index";
            return Redirect(url);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public JsonResult CheckUserName(string username)
        {
            var result = db.Managers.Where(x => x.Name == username).Count() == 0;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public string GetA()
        {
            return "";
        }
    }
}
