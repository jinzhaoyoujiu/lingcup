﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinJiaYou.Models;

namespace LinJiaYou.Areas.Manage.Controllers
{
    public class DefaultController : Controller
    {
        LinJiaYouContext dbContext = new LinJiaYouContext();
        // GET: Manage/Default
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Name,Password")] Manager manager)
        {
            //string name = form["Name"];
            //string password = form["password"];
            if (ModelState.IsValid)
            {
                List<Manager> mList = new List<Manager>();
                mList = dbContext.Managers.Where<Manager>(
                    new Func<Manager, bool>(
                                delegate (Manager m)
                                {
                                    bool result = false;
                                    if (m.Name == manager.Name && m.Password == manager.Password)
                                    {
                                        result = true;
                                    }
                                    return result;
                                }
                            )
                ).ToList();
                if (mList.Count > 0)
                {
                    Session["adminName"] = manager.Name;
                    return Redirect("/manage/home/index");
                }
            }
            return View();
        }
        //[HttpPost,ActionName("Login")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Lo([Bind(Include ="Name,Password")] Manager manager)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (dbContext.Managers.Where<Manager>(new Func<Manager, bool>(delegate (Manager m)
        //        {
        //            bool result = false;
        //            if (m.Name==manager.Name && m.Password==manager.Password)
        //            {
        //                result = true;
        //            }
        //            return result;
        //        })).Count() > 0)
        //        {
        //            Session["adminName"] = manager.Name;
        //            return Redirect("/manage/home/index");
                    
        //        }
        //    }
        //    return RedirectToAction("Login");
        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session["adminName"] = null;
            return Redirect("/Home/Index");
        }
        public ActionResult TestCurrencyCheck()
        {
            Manager m1 = null;
            Manager m2 = null;
            using (var dbC=new LinJiaYouContext())
            {
                m1 = dbC.Managers.Where(x => x.Id == 1).Single();
            }
            using (var dbC = new LinJiaYouContext())
            {
                m2 = dbC.Managers.Where(x => x.Id == 1).Single();
            }
            m1.Password = "eee";
            m2.Password = "333";
            try
            {
                using (var dbc=new LinJiaYouContext())
                {
                    dbc.Entry(m1).State = System.Data.Entity.EntityState.Modified;
                    dbc.SaveChanges();
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ViewBag.ex1 = ex.Message;
            }
            try
            {
                using (var dbc = new LinJiaYouContext())
                {
                    dbc.Entry(m2).State = System.Data.Entity.EntityState.Modified;
                    dbc.SaveChanges();
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ViewBag.ex2 = ex.Message;
            }
            return View();
        }
    }
}