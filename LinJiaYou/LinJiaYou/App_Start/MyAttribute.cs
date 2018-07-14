using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinJiaYou.Models;
namespace LinJiaYou.App_Start
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool result=false;
            if (!string.IsNullOrWhiteSpace(httpContext.Session["adminName"].Cstr()))
            {   
                result = true;
            }
            return result;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("/manage/Default/Login", true);
        }
    }
    public class MyHandleErrorAttribute:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            bool result = Fun.LogExceptionInfo(filterContext);
            //filterContext.Exception.HelpLink="http://www.baidu.com";
            base.OnException(filterContext);
        }
    }
    public class NameValidationAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        private readonly string _notString;
        public NameValidationAttribute(string notString=" "):base("{0} is not validate")
        {
            _notString = notString;
        }
        protected override System.ComponentModel.DataAnnotations.ValidationResult IsValid(object value,
            System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            if (value!=null && value.ToString().Trim(new char[] {' '}).Contains(_notString))
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new System.ComponentModel.DataAnnotations.ValidationResult(errorMessage);
            }
            return System.ComponentModel.DataAnnotations.ValidationResult.Success;
        }
    }
    /// <summary>
    /// 应用于model的自定义特性类
    /// </summary>
    public class ModelAttribute : Attribute
    {
        /// <summary>
        /// 后台页面标题
        /// </summary>
        public string ViewTitleName { get; set; }
    }
    public class MethodAttribute : Attribute
    {
        public string ViewMethodName { get; set; }
    }
}