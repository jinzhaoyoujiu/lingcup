using LinJiaYou.Helper;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WxPayAPI
{
    /// <summary>
    /// 支付结果通知回调处理类
    /// 负责接收微信支付后台发送的支付结果并对订单有效性进行验证，将验证结果反馈给微信支付后台
    /// </summary>
    public class ResultNotify:Notify
    {
        //public ResultNotify(Page page):base(page)
        //{
        //}
        //public ResultNotify(LinJiaYou.Controllers.WChatPayController homeController) : base(homeController)
        //{
        //}
        public ResultNotify() : base()
        {
        }
        public override void ProcessNotify()
        {
            WxPayData notifyData = GetNotifyData();
            //检查支付结果中transaction_id是否存在
            if (!notifyData.IsSet("transaction_id"))
            {
                //若transaction_id不存在，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "支付结果中微信订单号不存在");
                Log.Error(this.GetType().ToString(), "The Pay result is error : " + res.ToXml());
                HttpContext.Current.Response.Write(res.ToXml());
                HttpContext.Current.Response.End();
            }

            string transaction_id = notifyData.GetValue("transaction_id").ToString();

            //查询订单，判断订单真实性
            if (!QueryOrder(transaction_id))
            {
                //若订单查询失败，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "订单查询失败");
                Log.Error(this.GetType().ToString(), "Order query failure : " + res.ToXml());
                HttpContext.Current.Response.Write(res.ToXml());
                HttpContext.Current.Response.End();
            }
            //查询订单成功
            else
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "SUCCESS");
                res.SetValue("return_msg", "OK");
                Log.Info(this.GetType().ToString(), "order query success : " + res.ToXml());
                try
                {
                    string attach = notifyData.GetValue("attach").ToString();
                    string[] a = attach.Split('&');
                    string phoneNumber = "", UUID = "";
                    if (a.Length > 0)
                    {
                        phoneNumber = a[0].Split('=')[1];
                        UUID = a[1].Split('=')[1];
                    }
                    string sqlStr = string.Format("insert into esdtekp2.wx_pay_record(userPhone,uuid,totalFee,appid,attach,bank_type," +
                        "cash_fee,fee_type,is_subscribe,mch_id,nonce_str,openid," +
                        "out_trade_no,result_code,return_code,sign,time_end," +
                        "total_fee,trade_type,transaction_id,tradeCompleted)" +
                        " values('{0}','{1}',{2},'{3}','{4}','{5}',{6},'{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}',{20})",
                       phoneNumber, UUID, Convert.ToDecimal(Convert.ToInt32(notifyData.GetValue("total_fee"))) / 100,
                       notifyData.GetValue("appid").ToString(),
                       notifyData.GetValue("attach").ToString(),
                       notifyData.GetValue("bank_type").ToString(),
                       Convert.ToInt32(notifyData.GetValue("cash_fee")),
                       notifyData.GetValue("fee_type").ToString(),
                       notifyData.GetValue("is_subscribe").ToString(),
                       notifyData.GetValue("mch_id").ToString(),
                       notifyData.GetValue("nonce_str").ToString(),
                       notifyData.GetValue("openid").ToString(),
                       notifyData.GetValue("out_trade_no").ToString(),
                       notifyData.GetValue("result_code").ToString(),
                       notifyData.GetValue("return_code").ToString(),
                       notifyData.GetValue("sign").ToString(),
                       notifyData.GetValue("time_end").ToString(),
                       notifyData.GetValue("total_fee").ToString(),
                       notifyData.GetValue("trade_type").ToString(),
                       notifyData.GetValue("transaction_id").ToString(),
                       0
                        );
                    int r = MySQLHelper.ExecuteSql(sqlStr);
                }
                catch (Exception ex)
                {
                    Log.Info(this.GetType().ToString(), "error message : " + ex.Message);
                }
                HttpContext.Current.Response.Write(res.ToXml());
                HttpContext.Current.Response.End();
            }
        }

        //查询订单
        private bool QueryOrder(string transaction_id)
        {
            WxPayData req = new WxPayData();
            req.SetValue("transaction_id", transaction_id);
            WxPayData res = WxPayApi.OrderQuery(req);
            if (res.GetValue("return_code").ToString() == "SUCCESS" &&
                res.GetValue("result_code").ToString() == "SUCCESS")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}