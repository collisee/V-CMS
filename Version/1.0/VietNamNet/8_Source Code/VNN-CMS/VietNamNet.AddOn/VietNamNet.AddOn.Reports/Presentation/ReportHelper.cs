using System.Data;
using VietNamNet.Framework.Biz;
using  VietNamNet.AddOn.Report.Core.Common;
using  VietNamNet.AddOn.Report.Core.Common.ValueObject;

namespace  VietNamNet.AddOn.Report.Core.Presentation
{

	/// <summary>
	/// Summary description for ReportTypesHelper.
	/// </summary>
	public class ReportHelper
	{

        private ReportSearch o;

		#region ReportTypesHelper(ReportTypes o)
        public ReportHelper(ReportSearch o)
		{
			ValueObject = o;
		}
		#endregion

		#region ValueObject
        public ReportSearch ValueObject
		{
			get { return o; }
			set { o = value; }
		}
		#endregion

		#region GetPacket
		private Packet GetPacket()
		{
			Packet p = PacketUtils.TranslateFrom(ValueObject);
			p.ServiceName = Constants.Services.ReportManager.Name;
			return p;
		}
		#endregion

	 
 

		#region Search
        public DataTable ReportByCat()
		{
			Packet p = GetPacket();
			p.Action = Constants.Services.ReportManager.Actions.ReportByCat;
			ServiceFacade.Execute(p);
			return p.RawData.Tables[0];
        }
        public DataTable ReportByGroup()
        {
            Packet p = GetPacket();
            p.Action = Constants.Services.ReportManager.Actions.ReportByGroup;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }
       
		#endregion

	}
}
