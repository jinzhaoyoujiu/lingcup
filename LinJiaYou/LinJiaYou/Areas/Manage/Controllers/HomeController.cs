using LinJiaYou.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinJiaYou.Areas.Manage.Controllers
{
    [MyAuthorize]
    public class HomeController : Controller
    {
        // GET: Manage/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}