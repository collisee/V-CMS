using System.Data;
using System.Web;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;

/// <summary>
/// Utils of VietNamNet.CMS
/// </summary>
namespace VietNamNet.CMS.Common
{
    public class CMSUtils
    {
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

        public static int GetLeadMaxWords()
        {
            return Utilities.ParseInt(Utilities.GetConfigKey(CMSConstants.ConfigKey.LeadMaxWords));
        }

        public static int GetLeadMaxChars()
        {
            return Utilities.ParseInt(Utilities.GetConfigKey(CMSConstants.ConfigKey.LeadMaxChars));
        }
    }
}