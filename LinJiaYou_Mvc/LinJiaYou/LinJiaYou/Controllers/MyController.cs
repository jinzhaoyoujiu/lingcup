using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinJiaYou.Models;
using LinJiaYou.App_Start;
using System.Data.Entity.Core.EntityClient;


namespace LinJiaYou.Controllers
{
    public class MyController : Controller
    {
        LinJiaYou.Models.LinJiaYouContext dbContext = new Models.LinJiaYouContext();
        //
        // GET: /My/
        [MyHandleError(View = "/Views/Shared/Error.cshtml")]
        public ActionResult Index(string phone="")
        {
            User user = new User();
            if (Session["veriPhone"] != null)
            {
                user.Phone= Session["veriPhone"].ToString();
                //ViewBag.phone =
            }
            else if (Session["veriPhone"] == null && phone =="")
            {
                return Redirect("login");
            }
            else
            {
                user.Phone = phone;
                //ViewBag.phone = phone;
            }            
            return View(user);
        }
        [HttpGet]
        public ActionResult Login(string phone="")
        {
            if (phone != "")
            {
                ViewBag.phone = phone;
            }
            else
            {
                if (Request.Cookies.Count > 0)
                {
                    if (Request.Cookies["loginPhone"] != null)
                    {
                        if (Request.Cookies["loginPhone"]["userName"] != null)
                        {
                            //ViewBag.phone = Request.Cookies["loginPhone"]["userName"];
                            return Redirect("index?phone=" + Request.Cookies["loginPhone"]["userName"]);
                        }
                    }
                }
            }
            return View();
        }
        [MyHandleError(View = "/Views/Shared/Error.cshtml")]
        [HttpPost]
        public ActionResult Login(string name,string password)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                return Content("<script>alert(\"请输入邮箱或手机号\");history.back();</script>");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                return Content("<script>alert(\"请输入密码\");history.back();</script>");
            }
            JsonModel result = CheckUser(name, password);
            if (result.Status == ResultCode.failed.ToString())
            {
                return Content("<script>alert('" + result.Message + "');location.href='/my/login'</script>");
            }
            else
            {

                Session["veriPhone"] = name;
                HttpCookie httpCookie = new HttpCookie("loginPhone")
                {
                    //Domain = "127.0.0.1",
                    //Domain = "lingcup.com",
                    Expires = DateTime.Now.AddYears(1),
                    Path = "/",
                    Secure = false
                };
                httpCookie.Values.Add("userName",name);
                httpCookie.Values.Add("userPhone",name);
                Response.Cookies.Add(httpCookie);
                return Redirect("index?phone=" + name);
           }
        }
        internal JsonModel CheckUser(string userName, string password)
        {
            JsonModel result = new JsonModel { Message = "成功", Status = ResultCode.success.ToString() };
            using (var dbContext = new LinJiaYouContext())
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    List<User> userList = dbContext.Users.Where(u => u.Name == userName ).ToList();
                    if (userList == null || userList.Count >0)
                    {
                        result.Status = ResultCode.failed.ToString();
                        result.Message = "该手机号已经注册过了，请登录";
                    }
                }
                else
                {
                 List<User> userList = dbContext.Users.Where(u => u.Name == userName && u.Password == password).ToList();
                if (userList == null || userList.Count == 0)
                {
                    result.Status = ResultCode.failed.ToString();
                    result.Message = "手机号或密码错误";
                }
               }
            }
            return result;
        }
        public ActionResult LogOut()
        {
            if (Request.Cookies.Count > 0)
            {
                if (Request.Cookies["loginPhone"] != null)
                {
                    if (Request.Cookies["loginPhone"]["userName"] != null)
                    {
                        Response.Cookies["loginPhone"].Expires = DateTime.Now.AddDays(-1);
                    }
                }
            }
            Session.RemoveAll();
            return Redirect("/home/index");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string phone,string verificationCode,string password)
        {
            try
            {
                if (Session["veriCode"] != null)
                {
                    JsonModel result = AddUser(phone, verificationCode, password, Session["veriCode"].Cstr());
                    if (result.Status == ResultCode.success.ToString())
                    {
                        return Content("<script>alert('" + result.Message + "');location.href='/my/index'</script>");
                    }
                    else
                    {
                        ViewBag.result = result.Message;
                    }
                }
                else
                {
                    ViewBag.result = "动态码已经失效";
                }
            }
            catch(Exception e)
            {
                ViewBag.result = e.Message;
            }
            return View();
        }
        internal JsonModel AddUser(string phone, string verificationCode, string password, string sessionCode)
        {
            JsonModel result = new JsonModel { Message = "注册成功", Status = ResultCode.success.ToString() };
            if (!string.IsNullOrWhiteSpace(phone) && !string.IsNullOrWhiteSpace(verificationCode) && !string.IsNullOrWhiteSpace(password))
            {
                User user = new User { Phone = phone, Name = phone, Password = password };
                using (var dbContext = new LinJiaYouContext())
                {
                    int a = dbContext.Users.Where(x => x.Phone == phone).Count();
                    if (a == 0)
                    {
                        JsonModel checkResult = CheckCode(verificationCode, sessionCode);
                        if (checkResult.Status == ResultCode.success.ToString())
                        {
                            dbContext.Users.Add(user);
                            dbContext.SaveChanges();
                        }
                        else
                        {
                            result = checkResult;
                        }
                    }
                    else
                    {
                        //result = false;
                        result.Status = ResultCode.failed.ToString();
                        result.Message = "该手机号码已经注册过了";
                    }
                }
            }
            else
            {
                //result = false;
                result.Status = ResultCode.failed.ToString();
                result.Message = "手机号码，动态码，密码都不能为空";
            }
            return result;
        }
        internal JsonModel CheckCode(string veriCode, string sessionCode)
        {
            JsonModel result = new JsonModel { Message = "", Status = ResultCode.success.ToString() };
            if (!string.IsNullOrWhiteSpace(sessionCode))
            {
                if (sessionCode != veriCode)
                {
                    result.Status = ResultCode.failed.ToString();
                    result.Message = "动态码错误";
                }
                else
                {
                    result.Status = ResultCode.success.ToString();
                    result.Message = "动态码正确";
                }
            }
            else
            {
                result.Status = ResultCode.failed.ToString();
                result.Message = "动态码已经失效";
            }
            return result;
        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetVerificationCode(string mobile)
        {

            string requestURL = "https://open.ucpaas.com/ol/sms/sendsms", postData = string.Empty, result = string.Empty;
            LinJiaYou.Models.JsonModel jsonModel = new LinJiaYou.Models.JsonModel ();
            jsonModel =CheckUser(mobile,"");
            if (jsonModel.Status == ResultCode.failed.ToString())
            {
                return Json(jsonModel);
            }
            else
            {
            VerificationResponse verResponse = new VerificationResponse();
            int countDownNum = 60;
            bool canGet = true;
            string veriCode = Session["veriCode"].Cstr();
            string veriPhone = Session["veriPhone"].Cstr();
            string veriTime = Session["veriTime"].Cstr();
            if (Session["veriCode"] != null && (Session["veriPhone"] != null && Session["veriPhone"].ToString() == mobile) && Session["veriTime"] != null)
            {
                TimeSpan ts1=new TimeSpan(((DateTime)Session["veriTime"]).Ticks);
                TimeSpan ts2 = new TimeSpan(DateTime.Now.Ticks);
                TimeSpan ts = ts2.Subtract(ts1).Duration();
                if (ts.TotalSeconds <= countDownNum)
                {
                    canGet = false;
                    jsonModel.Status = ResultCode.success.ToString();
                    jsonModel.Data = "NONEED";
                    jsonModel.Message = ResultCode.success.GetDescription();
                }
            }
            if (Session["getCount"] != null && (Int32)Session["getCount"]>5)
            {
                canGet = false;
                jsonModel.Status = ResultCode.success.ToString();
                jsonModel.Data = "FREQUENT";
                jsonModel.Message = ResultCode.success.GetDescription();
            }
            if (canGet)
            {
                try
                {
                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LinJiaYouContext"].ConnectionString;
                    System.Data.SqlClient.SqlConnection SqlConnection = new System.Data.SqlClient.SqlConnection(connectionString);
                    Random a = new Random();
                    int verCode = a.Next(1000, 9999);
                    VerificationCodeParam param = new VerificationCodeParam
                    {
                        Appid = "74ebbef0d7cb4d829db2f38d76822469",
                        Mobile = mobile,
                        Param = verCode.ToString(),
                        Sid = "665e4f9d9e6e39ff1428e945bfdc46c1",
                        Templateid = "263569",
                        Token = "9d72c2d6ad08dcf6cd93bd7fc11e055b",
                        Uid = ""
                    };
                    postData = Newtonsoft.Json.JsonConvert.SerializeObject(param);
                        System.Net.WebRequest verificationRequest = System.Net.WebRequest.Create(requestURL);
                        verificationRequest.Method = "post";
                        verificationRequest.ContentType = "application/json;charset=utf-8";
                        verificationRequest.ContentLength = System.Text.Encoding.UTF8.GetBytes(postData).Length;
                        System.IO.Stream requestStream = verificationRequest.GetRequestStream();
                        requestStream.Write(System.Text.Encoding.UTF8.GetBytes(postData), 0, System.Text.Encoding.UTF8.GetBytes(postData).Length);
                        requestStream.Close();
                        System.Net.WebResponse verificationResponse = verificationRequest.GetResponse();
                        System.IO.Stream responseStream = ((System.Net.HttpWebResponse)verificationResponse).GetResponseStream();
                        System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream, System.Text.Encoding.UTF8);
                        result = streamReader.ReadToEnd();
                        verResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<VerificationResponse>(result);
                    //    verResponse = new VerificationResponse
                    //{
                    //    Code = "000000",
                    //    Count = "1",
                    //    Create_date = "2018-01-11 23:49:00",
                    //    Mobile = "15832578508",
                    //    Msg = "OK",
                    //    Smsid = "a0b912c08b3f77000e04a6a167bc2b06",
                    //    Uid = ""
                    //};
                    if (verResponse.Code == "000000")
                    {
                        try
                        {
                            Session["veriCode"] = param.Param;
                            if(Session["getCount"]!=null)
                            {
                                Session["getCount"] = ((Int32)Session["getCount"])+1;
                            }
                            else
                            {
                                 Session["getCount"] =1;
                            }
                            Session["veriPhone"] = param.Mobile;
                            Session["veriTime"] = DateTime.Now;
                            AddVerificode(param.Mobile, param.Param);
                        }
                        catch (Exception ex)
                        {
                            bool logResult = Fun.LogExceptionInfo(ControllerContext, ex);
                        }
                    }
                    jsonModel.Status = ResultCode.success.ToString();
                    jsonModel.Data = verResponse;
                    jsonModel.Message = ResultCode.success.GetDescription();
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                    jsonModel.Status = ResultCode.failed.ToString();
                    //jsonModel.message = (typeof(ResultCode).GetField(ResultCode.failed.ToString()).GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false)[0] as System.ComponentModel.DescriptionAttribute).Description;
                    jsonModel.Message = ResultCode.failed.GetDescription();
                    bool logResult = Fun.LogExceptionInfo(ControllerContext, ex);
                }
            }
            }
            return Json(jsonModel);
        }
        internal JsonModel AddVerificode(string phone, string veriCode)
        {
            JsonModel result = new JsonModel { Message = "添加成功", Status = ResultCode.success.ToString() };
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LinJiaYouContext"].ConnectionString;
            System.Data.SqlClient.SqlConnection SqlConnection = new System.Data.SqlClient.SqlConnection(connectionString);
            using (LinJiaYouContext dbContext = new LinJiaYouContext(SqlConnection, true))
            {
                PhoneVeriCode phoneVeriCode = new PhoneVeriCode { Phone = phone, VerificationCode = veriCode, AddTime = DateTime.Now };
                dbContext.PhoneVeriCodes.Add(phoneVeriCode);
                dbContext.SaveChanges();
            }
            return result;
        }

    }
}