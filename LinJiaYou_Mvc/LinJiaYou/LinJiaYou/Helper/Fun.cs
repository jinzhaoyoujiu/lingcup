﻿using LinJiaYou.App_Start;
using LinJiaYou.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace LinJiaYou
{
    public static class Fun
    {
        public static string Cstr(this object o)
        {
            string result = "";
            if (o != null)
            {
                result = o.ToString();
            }
            else
            {
                result = "";
            }
            return result;
        }
        public static string GetResponseContent(string url, string d)
        {
            System.Net.HttpWebRequest requestscore = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] data = encoding.GetBytes(d);
            requestscore.Method = "post";
            requestscore.ContentType = "application/x-www-form-urlencoded";
            requestscore.ContentLength = data.Length;
            requestscore.KeepAlive = true;
            System.IO.Stream stream = requestscore.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            System.Net.HttpWebResponse responsescore;
            try
            {
                responsescore = (System.Net.HttpWebResponse)requestscore.GetResponse();
            }
            catch (System.Net.WebException ex)
            {
                responsescore = (System.Net.HttpWebResponse)ex.Response;
            }
            System.IO.StreamReader reader = new System.IO.StreamReader(responsescore.GetResponseStream(), System.Text.Encoding.UTF8);
            string content = reader.ReadToEnd();
            requestscore.Abort();
            responsescore.Close();
            reader.Dispose();
            //stream.Dispose();
            return content;
        }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns></returns>
        public static string GetMD5(string source)
        {
            string result = "";
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] sourceByte = System.Text.Encoding.UTF8.GetBytes(source);
            sourceByte = md5.ComputeHash(sourceByte);
            System.Text.StringBuilder sb = new System.Text.StringBuilder(sourceByte.Length);
            foreach (byte b in sourceByte)
            {
                sb.Append(b.ToString("X2"));
            }
            result = sb.ToString();
            return result;
        }
        public static bool LogExceptionInfo(ExceptionContext filterContext)
        {
            bool result = true;
            try
            {
                using (LinJiaYouContext dbContext = new LinJiaYouContext())
                {
                    ExceptionLog exceptionLog = new ExceptionLog
                    {
                        Message = filterContext.Exception.Message,
                        Source = filterContext.Exception.Source,
                        TargetSite = filterContext.Exception.TargetSite.ToString()
                    };
                    dbContext.ExceptionLogs.Add(exceptionLog);
                    dbContext.SaveChanges();
                }
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static bool LogExceptionInfo(ControllerContext controllerContext, Exception exception)
        {
            bool result = true;
            try
            {
                ExceptionContext filterContext = new ExceptionContext(controllerContext, exception);
                using (LinJiaYouContext dbContext = new Models.LinJiaYouContext())
                {
                    ExceptionLog exceptionLog = new ExceptionLog
                    {
                        Message = filterContext.Exception.Message,
                        Source = filterContext.Exception.Source,
                        TargetSite = filterContext.Exception.TargetSite.ToString()
                    };
                    dbContext.ExceptionLogs.Add(exceptionLog);
                    dbContext.SaveChanges();
                }
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static string GetViewTitleName(object o)
        {
            string result = "";
            Type t = o.GetType();
            foreach (Attribute attr in Attribute.GetCustomAttributes(t))
            {
                if (attr.GetType() == typeof(ModelAttribute))
                {
                    result = ((ModelAttribute)attr).ViewTitleName;
                }
            }
            return result;
        }
        public static string GetViewMethodName(object o, string methodName)
        {
            string result = "";
            Type t = o.GetType();
            foreach (MethodInfo mInfo in t.GetMethods())
            {
                if (mInfo.Name == methodName)
                {

                    foreach (Attribute attr in Attribute.GetCustomAttributes(mInfo))
                    {
                        if (attr.GetType() == typeof(MethodAttribute))
                        {
                            result = ((MethodAttribute)attr).ViewMethodName;
                        }
                    }
                }
            }

            return result;
        }
        internal delegate int C<T>(T t1, T t2);
        internal static void S<T>(this List<T> one, C<T> C)
        {
            if (one.Count > 0)
            {
                one.RemoveAt(0);
            }
        }

        internal static int ShopComparer(Shop shop1, Shop shop2)
        {
            if (shop1.ID > shop2.ID)
            {
                return 1;
            }
            else if (shop1.ID == shop2.ID)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        internal static A F<A>(this List<A> origin,D<A> d)
        {
            return origin.ElementAtOrDefault(0);
        }
        internal delegate bool D<A>(A a);
        internal static bool ShopFinder(Shop shop)
        {
            bool result = false;
            if (shop.ID>0)
            {
                result = true;
            }
            return result;
        }
    }
}