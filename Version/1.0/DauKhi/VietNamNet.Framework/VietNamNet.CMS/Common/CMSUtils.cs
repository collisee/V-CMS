/************************************************************************/
/* File Name  : CMSUtils.cs                                             */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.CMS.Common                                */
/* Product Version : 1.0                                                */
/* Creator : Dao Tuan Anh                                               */
/* Copyright(C) 2010 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/*                                                                      */
/* File history                                                         */
/* xx/08/2010 File Create                                               */
/* 16/09/2011 Update GetRoyaltyPolicy & Comment                         */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/
using System.Data;
using System.Web;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.Common
{
    public class CMSUtils
    {
        /**
         * Method name: GetCategoryPolicy
         * Parameters:
         *          int userId
         *          int categoryId
         * Return: User has right with category OR not
         * */
        public static bool GetCategoryPolicy(int userId, int categoryId)
        {
            if (userId <= 0 || categoryId <= 0) return false;

            string policyName = string.Format("{0}_{1}_{2}", CMSConstants.Session.USER_CATEGORY_POLICY, userId, categoryId);
            if (HttpContext.Current.Session[policyName] != null)
            {
                return Utilities.ParseInt(HttpContext.Current.Session[policyName]) == 1;
            }

            CategoryPolicyHelper helper = new CategoryPolicyHelper(new CategoryPolicy());
            helper.ValueObject.UserId = userId;
            helper.ValueObject.CategoryId = categoryId;
            DataTable dt = helper.GetPolicyByUserIdAndCategoryId();

            if (dt != null && dt.Rows.Count > 0)
            {
                int values = 0;

                foreach (DataRow row in dt.Rows)
                {
                    int v = Utilities.ParseInt(row[CMSConstants.Entities.CategoryPolicy.FieldName.Val]);
                    values |= v;
                }

                HttpContext.Current.Session[policyName] = values;
                return values == 1;
            }

            HttpContext.Current.Session.Remove(policyName);
            return false;
        }

        /**
         * Method name: GetCategoryPolicy
         * Parameters:
         *          int userId
         *          string categoryAlias
         * Return: User has right with category OR not
         * */
        public static bool GetCategoryPolicy(int userId, string categoryAlias)
        {
            if (userId <= 0 || Nulls.IsNullOrEmpty(categoryAlias)) return false;

            string policyName = string.Format("{0}_{1}_{2}", CMSConstants.Session.USER_CATEGORY_POLICY, userId, categoryAlias);
            if (HttpContext.Current.Session[policyName] != null)
            {
                return Utilities.ParseInt(HttpContext.Current.Session[policyName]) == 1;
            }

            CategoryPolicyHelper helper = new CategoryPolicyHelper(new CategoryPolicy());
            helper.ValueObject.UserId = userId;
            helper.ValueObject.CategoryAlias = categoryAlias;
            DataTable dt = helper.GetPolicyByUserIdAndCategoryAlias();

            if (dt != null && dt.Rows.Count > 0)
            {
                int values = 0;

                foreach (DataRow row in dt.Rows)
                {
                    int v = Utilities.ParseInt(row[CMSConstants.Entities.CategoryPolicy.FieldName.Val]);
                    values |= v;
                }

                HttpContext.Current.Session[policyName] = values;
                return values == 1;
            }

            HttpContext.Current.Session.Remove(policyName);
            return false;
        }

        /**
         * Method name: GetLeadMaxWords
         * Parameters:
         * Return: Lead max words in web.config
         * */
        public static int GetLeadMaxWords()
        {
            return Utilities.ParseInt(Utilities.GetConfigKey(CMSConstants.ConfigKey.LeadMaxWords));
        }

        /**
         * Method name: GetLeadMaxChars
         * Parameters:
         * Return: Lead max characters in web.config
         * */
        public static int GetLeadMaxChars()
        {
            return Utilities.ParseInt(Utilities.GetConfigKey(CMSConstants.ConfigKey.LeadMaxChars));
        }

        /**
         * Method name: GetRoyaltyPolicy
         * Parameters:
         *          int userId
         * Return: User has right for Royalty OR not
         * */
        public static bool GetRoyaltyPolicy(int userId)
        {
            return
                SystemUtils.GetPolicy(userId, "VietNamNet.AddOn.Royalty", "VietNamNet.AddOn.Royalty.Fund") ||
                SystemUtils.GetPolicy(userId, "VietNamNet.AddOn.Royalty", "VietNamNet.AddOn.Royalty.System");
        }

        /**
         * Method name: GetRoyaltyPage
         * Parameters:
         * Return: Royalty page url
         * */
        public static string GetRoyaltyPage()
        {
            return "~/Royalty/FundsManager/FundByArticle.aspx";
        }
    }
}