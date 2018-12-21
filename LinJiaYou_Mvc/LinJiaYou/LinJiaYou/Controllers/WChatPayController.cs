using LitJson;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WxPayAPI;
using MySql.Data.MySqlClient;
using LinJiaYou.Helper;
using System.Data;
using EsdTek.Models;
using LinJiaYou.EsdTek.Models;

namespace LinJiaYou.Controllers
{
    public class WChatPayController : Controller
    {
        // GET: WChatPay
        public ActionResult Index()
        {
            Log.Info(this.GetType().ToString(), "Index page load");
            JsApiPay jsApiPay = new JsApiPay();
            try
            {
                //调用【网页授权获取用户信息】接口获取用户的openid和access_token
                jsApiPay.GetOpenidAndAccessToken();
                //获取收货地址js函数入口参数
                string wxEditAddrParam = jsApiPay.GetEditAddressParameters();
                Session["openid"] = jsApiPay.openid;
            }
            catch (Exception ex)
            {
                Response.Write("<span style='color:#FF0000;font-size:20px'>" + "页面加载出错，请重试" + "</span>");
            }

            return View();
        }
        public ActionResult ResultNotify()
        {
            ResultNotify resultNotify = new ResultNotify();
            resultNotify.ProcessNotify();
            return View();
        }
        public ActionResult GetDevices(string userPhone)
        {
            Log.Info(this.GetType().ToString(), "userPhone : " + userPhone);
            MyJsonResult myJsonResult = new MyJsonResult {Status=0,Data="",Message=""};
            if (Session["openid"] != null)
            {
                try
                {
                    string sql = string.Format("select UUID,shopName,userPhone from dev_table where userPhone={0}", userPhone);
                    DataTable dt = MySQLHelper.GetDataTable(sql);
                    List<Device> devices = dt.AsEnumerable().Select(x => {
                        return new Device
                        {
                            UUID = x["UUID"].ToString(),
                            ShopName = x["shopName"].ToString(),
                            UserPhone = x["userPhone"].ToString()
                        };
                    }).ToList();
                    myJsonResult.Data = Newtonsoft.Json.JsonConvert.SerializeObject(devices);
                    myJsonResult.Message = "成功";
                }
                catch (Exception ex)
                {
                    Log.Debug(this.GetType().ToString(), "Exception : " + ex.Message);
                }
            }
            if (!string.IsNullOrEmpty(myJsonResult.Data))
            {
                myJsonResult.Status = 1;
            }
            else {
                myJsonResult.Status = 0;
            }
            return Json(myJsonResult);
        }
        public ActionResult CallPay(string total_fee,string phoneNumber,string UUID)
        {

            MyJsonResult myJsonResult = new MyJsonResult { Status = 0, Data = "", Message = "" };
            Log.Info(this.GetType().ToString(), "JsApiPay page load");
            if (Session["openid"] != null)
            {
                Session["phoneNumber"] = phoneNumber;
                Session["UUID"] = UUID;
                Log.Info(this.GetType().ToString(), phoneNumber+ UUID);
                string openid = Session["openid"].ToString();
                //检测是否给当前页面传递了相关参数
                if (string.IsNullOrEmpty(openid) || string.IsNullOrEmpty(total_fee))
                {
                    Log.Error(this.GetType().ToString(), "This page have not get params, cannot be inited, exit...");
                    myJsonResult.Status = 0;
                    myJsonResult.Message= "页面传参出错,请返回重试";
                }
                else {
                    //若传递了相关参数，则调统一下单接口，获得后续相关接口的入口参数
                    JsApiPay jsApiPay = new JsApiPay();
                    jsApiPay.openid = openid;
                    jsApiPay.total_fee =Convert.ToInt32(decimal.Parse(total_fee)*100);
                    //JSAPI支付预处理
                    try
                    {
                        WxPayData unifiedOrderResult = jsApiPay.GetUnifiedOrderResult(phoneNumber, UUID);
                        string wxJsApiParam = jsApiPay.GetJsApiParameters();//获取H5调起JS API参数   
                        myJsonResult.Status = 1;
                        myJsonResult.Message = "成功";
                        myJsonResult.Data = wxJsApiParam;


                        Log.Debug(this.GetType().ToString(), "wxJsApiParam : " + wxJsApiParam);
                    }
                    catch (Exception ex)
                    {
                        myJsonResult.Status = 0;
                        myJsonResult.Message = "下单失败，请返回重试";
                    }
                }
            }
            return Json(myJsonResult);
        }
    }
}