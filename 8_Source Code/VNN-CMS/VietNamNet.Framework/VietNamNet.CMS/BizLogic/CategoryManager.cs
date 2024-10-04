using System;
using System.Data;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.DBAccess;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;

namespace VietNamNet.CMS.BizLogic
{
    /// <summary>
    /// Summary description for CategoryManager.
    /// </summary>
    public class CategoryManager : Facade
    {
        #region Override Execute

        public override Packet Execute(Packet param)
        {
            switch (param.Action)
            {
                case CMSConstants.Services.CommonActions.SAVE:
                    DoSave(param);
                    break;
                case CMSConstants.Services.CommonActions.DELETE:
                    DoDelete(param);
                    break;
                case CMSConstants.Services.CommonActions.LOAD:
                    DoLoad(param);
                    break;
                case CMSConstants.Services.CommonActions.LOAD_ENCODE:
                    DoLoadEncode(param);
                    break;
                case CMSConstants.Services.CommonActions.LISTALL:
                    ListAll(param);
                    break;
                case CMSConstants.Services.CategoryManager.Actions.ViewGetAllCategory:
                    ViewGetAllCategory(param);
                    break;
                case CMSConstants.Services.CategoryManager.Actions.ViewGetAllMyCategory:
                    ViewGetAllMyCategory(param);
                    break;
                case CMSConstants.Services.CategoryManager.Actions.GetCategoryByAlias:
                    GetCategoryByAlias(param);
                    break;
                case CMSConstants.Services.CategoryManager.Actions.UpdateCategoryPIdAndOrder:
                    UpdateCategoryPIdAndOrder(param);
                    break;
                case CMSConstants.Services.CategoryManager.Actions.OptimizeCategory:
                    OptimizeCategory(param);
                    break;
                case CMSConstants.Services.CategoryManager.Actions.GetCategoryByUserId:
                    GetCategoryByUserId(param);
                    break;
                default:
                    break;
            }
            return param;
        }

        #endregion

        #region Execute Actions

        #region Function DoSave

        private void DoSave(Packet param)
        {
            //Check PId
            if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][CMSConstants.Entities.Category.FieldName.PId]) <= 0)
            {
                param.RawData.Tables[0].Rows[0][CMSConstants.Entities.Category.FieldName.PId] = DBNull.Value;
            }
            //Save
            if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][CMSConstants.Entities.Category.FieldName.Id]) == 0)
            {
                CategoryDAO.Insert(param.RawData.Tables[0].Rows[0]);
            }
            else
            {
                CategoryDAO.Update(param.RawData.Tables[0].Rows[0]);
            }
        }

        #endregion

        #region Function DoDelete

        private void DoDelete(Packet param)
        {
            CategoryDAO.Delete(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function DoLoad

        private void DoLoad(Packet param)
        {
            DataTable dt = CategoryDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function DoLoadEncode

        private void DoLoadEncode(Packet param)
        {
            DataTable dt = CategoryDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
        }

        #endregion

        #region Function ListAll

        private void ListAll(Packet param)
        {
            DataTable dt = CategoryDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function ViewGetAllCategory

        private void ViewGetAllCategory(Packet param)
        {
            param.RawData = CategoryDAO.ViewGetAllCategory(param.RawData);
        }

        #endregion

        #region Function ViewGetAllMyCategory

        private void ViewGetAllMyCategory(Packet param)
        {
            param.RawData = CategoryDAO.ViewGetAllMyCategory(param.RawData);
        }

        #endregion

        #region Function GetCategoryByAlias

        private void GetCategoryByAlias(Packet param)
        {
            DataTable dt = CategoryDAO.GetCategoryByAlias(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function UpdateCategoryPIdAndOrder

        private void UpdateCategoryPIdAndOrder(Packet param)
        {
            int pid = Utilities.ParseInt(param.RawData.Tables[0].Rows[0][CMSConstants.Entities.Category.FieldName.PId]);
            if (pid <= 0)
            {
                param.RawData.Tables[0].Rows[0][CMSConstants.Entities.Category.FieldName.PId] = DBNull.Value;
            }
            CategoryDAO.UpdateCategoryPIdAndOrder(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function OptimizeCategory

        private void OptimizeCategory(Packet param)
        {
            CategoryDAO.OptimizeCategory(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function GetCategoryByUserId

        private void GetCategoryByUserId(Packet param)
        {
            DataTable dt = CategoryDAO.GetCategoryByUserId(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #endregion
    }
}