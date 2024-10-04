using System.Data;
using VietNamNet.Framework.Biz;
using  VietNamNet.AddOn.Report.Core.DBAccess;
using Constants = VietNamNet.AddOn.Report.Core.Common.Constants;

namespace  VietNamNet.AddOn.Report.Core.BizLogic
{
	/// <summary>
	/// Summary description for ReportTypesManager.
	/// </summary>
    public class ReportManager : Facade
	{
		#region Override Execute
		public override Packet Execute(Packet param)
		{
			switch (param.Action)
			{  
                case Constants.Services.ReportManager.Actions.ReportByCat:
                    ReportByCat(param);
                    break;
                case Constants.Services.ReportManager.Actions.ReportByGroup:
                    ReportByGroup(param);
                    break;
				default:
					break;
				}
			return param;
		}
		#endregion
 
		#region Function List 
        private void ReportByCat(Packet param)
        {
            DataTable dt = ReportDAO.ReportByCat(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }
 
        private void ReportByGroup(Packet param)
        {
            DataTable dt = ReportDAO.ReportByGroup(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }
		#endregion
	}
}
