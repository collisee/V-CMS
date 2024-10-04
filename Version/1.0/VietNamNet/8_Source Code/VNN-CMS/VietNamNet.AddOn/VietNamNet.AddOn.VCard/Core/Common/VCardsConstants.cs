// ReSharper disable RedundantUsingDirective
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Module;



namespace VietNamNet.AddOn.VCard.Core.Common
{

public class VCardsConstants
{
	#region Entities
    public class Entities : BaseEntities
	{
		#region VCards
		public class VCards
		{
			public const string Name = "VCards";
            public class FieldName : BaseFieldName
			{
				public const string ContactId="ContactId";
				public const string Fullname="Fullname";
				public const string OrgTitle="OrgTitle";
				public const string OrgName="OrgName";
				public const string OrgUnit="OrgUnit";
				public const string OrgPhone="OrgPhone";
				public const string OrgMobile="OrgMobile";
				public const string OrgFax="OrgFax";
				public const string OrgAdr1="OrgAdr1";
				public const string OrgAdr2="OrgAdr2";
				public const string OrgEmail1="OrgEmail1";
				public const string OrgEmail2="OrgEmail2";
				public const string OrgWebsite="OrgWebsite";
				public const string Sex="Sex";
				public const string Bday="Bday";
				public const string HomePhone="HomePhone";
				public const string HomeMobile="HomeMobile";
				public const string HomeFax="HomeFax";
				public const string HomeAdr1="HomeAdr1";
				public const string HomeAdr2="HomeAdr2";
				public const string HomeEmail1="HomeEmail1";
				public const string HomeEmail2="HomeEmail2";
				public const string Homepage="Homepage";
				public const string Notes="Notes";
				public const string Owner="Owner";
                public const string OwnerLoginName = "OwnerLoginName";
                public const string OwnerFullName = "OwnerFullName";
                public const string OwnerEmail = "OwnerEmail";
                public const string GroupName = "GroupName";

				public const string GroupID="GroupID";
				public const string Scope="Scope";

                public const string Nickname="Nickname";
                 public const string Paper="Paper";
                 public const string HomeCountry="HomeCountry";
                 public const string Nationality="Nationality";
                public const string OrgCountry="OrgCountry";
                public const string OrgDescription="OrgDescription";
                public const string OrgOffice="OrgOffice";
    

			}
		}
		#endregion

		#region VCardsGroups
		public class VCardsGroups
		{
			public const string Name = "VCardsGroups";
            public class FieldName : BaseFieldName
			{
				public const string GroupId="GroupId";
				public const string GroupName="GroupName";
				public const string Description="Description";
				public const string Owner="Owner";
			}
		}
		#endregion

	}
	#endregion

	#region Services
    public class Services : BaseServices
	{

		#region VCardsManager
		public class VCardsManager
		{
			public const string Name = "VCardsManager";
			public class Actions : CommonActions
			{
                public const string LISTALLBYUSER = "ListAllByUser";
			}
		}
		#endregion

		#region VCardsGroupsManager
		public class VCardsGroupsManager
		{
			public const string Name = "VCardsGroupsManager";
			public class Actions : CommonActions
			{
                public const string LISTALLBYUSER = "ListAllByUser";
            }
		}
		#endregion

	}
	#endregion

    #region ParameterName

    public class ParameterName : ModuleConstants.ParameterName
    {
    }

    #endregion

    #region Paging

    public class Paging
    {
        public class Direction : Constants.Paging.Direction
        {
            public const string Fullname = "Fullname";
            public const string OrgTitle = "OrgTitle";
            public const string OrgName = "OrgName";
        }
    }

    #endregion

    #region FormNames

    public class FormNames : ModuleConstants.FormNames
    {
        #region Nested type: VCard

        public class VCard
        {
            public const string VCardEdit = "~/VCard/PopupVCardEdit.aspx";
            public const string VCardView = "~/VCard/PopupVCardDetail.aspx";
            public const string PopupVCardDisplay = "~/VCard/PopupVCardDetail.aspx";
        }

        #endregion
    }

    #endregion

}
}
// ReSharper restore RedundantUsingDirective