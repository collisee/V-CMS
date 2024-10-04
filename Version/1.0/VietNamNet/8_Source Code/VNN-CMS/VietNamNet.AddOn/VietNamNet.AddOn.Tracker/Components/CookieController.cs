/************************************************************************/
/* File Name  : CookieController.cs                                     */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Tracker                             */
/* Product Version : 1.0                                                */
/* Copyright(C) 2010 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : Ghi và đọc các thông tin của Tracker Cookie            */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/* File history                                                         */
/* 26/10/2010 File Create                                               */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/
using System;
using System.Web;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Tracker.Components
{
    public class CookieController
    {
        #region Members

        private string _cookieName;
        private string _cookieValue;
        private DateTime _expiresTime;

        #endregion

        #region Public Properties

        public string CookieName
        {
            get { return _cookieName; }
            set { _cookieName = value; }
        }

        public string CookieValue
        {
            get { return _cookieValue; }
            set { _cookieValue = value; }
        }

        public DateTime ExpiresTime
        {
            get { return _expiresTime; }
            set { _expiresTime = value; }
        }

        #endregion

        #region Contructor

        public CookieController()
        {
        }

        public CookieController(string cookieName)
        {
            _cookieName = cookieName;
            _cookieValue = "1";
        }

        public CookieController(string cookieName, string cookieValue)
        {
            _cookieName = cookieName;
            _cookieValue = cookieValue;
        }

        public CookieController(string cookieName, string cookieValue, DateTime expiresTime)
        {
            _cookieName = cookieName;
            _cookieValue = cookieValue;
            _expiresTime = expiresTime;
        }

        #endregion

        #region Public Methods

        #region Check cookie
        public string CheckCookie(string cookieName)
         {
             CookieName = cookieName;
             return CheckCookie();
         }

        public string CheckCookie()
         {
             if (Utilities.IsNullOrEmpty(CookieName)) return null;

             if (HttpContext.Current.Request.Cookies[CookieName] != null)
                 return HttpContext.Current.Request.Cookies[CookieName].Value;

             return null;
         }

        #endregion

        #region Set cookie
        public void SetCookie()
        {
            if (!Utilities.IsNullOrEmpty(CookieName) &&
                !Utilities.IsNullOrEmpty(ExpiresTime))
            {
                //if (HttpContext.Current.Request.Cookies[CookieName] == null)
                //{
                    HttpCookie objCookie = new HttpCookie(CookieName);
                    objCookie.Value = Utilities.IsNullOrEmpty(CookieValue) ? "1" : CookieValue;
                    objCookie.Expires = ExpiresTime;
                    HttpContext.Current.Response.Cookies.Add(objCookie); 
               //}  
            }

        }

        public void SetCookie(string cookieName, DateTime expiresTime)
        {
            CookieName = cookieName;
            CookieValue = "1";
            ExpiresTime = expiresTime;
            SetCookie();
        }

        public void SetCookie(string cookieName, string cookieValue, DateTime expiresTime)
        {
            CookieName = cookieName;
            CookieValue = cookieValue;
            ExpiresTime = expiresTime;
            SetCookie();
        }
         #endregion

        #endregion

    }
}
