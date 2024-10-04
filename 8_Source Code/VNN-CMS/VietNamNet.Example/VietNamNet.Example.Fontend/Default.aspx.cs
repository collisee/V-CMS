/************************************************************************/
/* File Name  : Default.aspx                                            */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Example.BackEnd                     */
/* Product Version : 1.0                                                */
/* Copyright(C) 2009 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/*                                                                      */
/* File history                                                         */
/* 01/01/2011 File Create                                               */
/* 03/01/2011 Create Contructor function                                */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace VietNamNet.Example.Fontend
{
    public partial class _Default : System.Web.UI.Page
    {
        #region Members
        // các biến dùng chung khai báo tại đây
        private int _Id = 0;
        public int _Id2 = 0;
        #endregion

        #region Event Handlers
        // các Action trên form khai báo tại đây
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Grid Handlers

        #endregion

        #endregion

        #region Private Methods
        // các Hàm Private khai báo tại đây
        #endregion

        #region Public Methods
        // các Hàm Public khai báo tại đây


        /// <summary>
        /// GetStatus   Gõ 3 dấu / thì ra dòng này
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>string</returns>
        public string GetStatus(string s)
        {
            return s;
        }

        #endregion
    }
}
