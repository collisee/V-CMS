using VietNamNet.Framework.Module;

/// <summary>
/// Constants of VietNamNet.AddOn.Advertisement
/// </summary>
namespace VietNamNet.AddOn.Advertisement.Common
{
    public class AdvertisementConstants
    {
        #region Entities

        public class Entities : BaseEntities
        {
            #region AdvertisementBlock

            public class AdvertisementBlock
            {
                public const string Name = "AdvertisementBlock";
                public const string Items = "Items";
                public static string[] SearchColumns = { "Name", "Detail" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string Detail = "Detail";
                    public const string Height = "Height";
                    public const string Mode = "Mode";
                    public const string Name = "Name";
                    public const string TimeDelay = "TimeDelay";
                    public const string Width = "Width";
                }

                #endregion
            }

            #endregion

            #region AdvertisementBlockItem

            public class AdvertisementBlockItem
            {
                public const string Name = "AdvertisementBlockItem";

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string BlockId = "BlockId";
                    public const string ItemId = "ItemId";
                    public const string Ord = "Ord";
                    //public const string OldOrd = "OldOrd";
                    public const string SaveStatus = "SaveStatus";
                    public const string ItemName = "ItemName";
                }

                #endregion
            }

            #endregion

            #region AdvertisementItem

            public class AdvertisementItem
            {
                public const string Name = "AdvertisementItem";
                public static string[] SearchColumns = { "Name", "Detail" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string CodeJS = "CodeJS";
                    public const string Detail = "Detail";
                    public const string EndTime = "EndTime";
                    public const string ExHeight = "ExHeight";
                    public const string ExMode = "ExMode";
                    public const string ExWidth = "ExWidth";
                    public const string FileJS = "FileJS";
                    public const string FileLink1 = "FileLink1";
                    public const string FileLink2 = "FileLink2";
                    public const string History = "History";
                    public const string Link = "Link";
                    public const string Name = "Name";
                    public const string StartTime = "StartTime";
                    public const string TypeId = "TypeId";
                }

                #endregion
            }

            #endregion

            #region AdvertisementLayout

            public class AdvertisementLayout
            {
                public const string Name = "AdvertisementLayout";
                public const string Categories = "Categories";
                public const string Zones = "Zones";
                public static string[] SearchColumns = { "Name", "Detail" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string Detail = "Detail";
                    public const string Name = "Name";
                }

                #endregion
            }

            #endregion

            #region AdvertisementLayoutCategory

            public class AdvertisementLayoutCategory
            {
                public const string Name = "AdvertisementLayoutCategory";

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string CategoryId = "CategoryId";
                    public const string LayoutId = "LayoutId";
                    public const string SaveStatus = "SaveStatus";
                    public const string CategoryName = "CategoryName";
                    public const string CategoryAlias = "CategoryAlias";
                }

                #endregion
            }

            #endregion

            #region AdvertisementLayoutZone

            public class AdvertisementLayoutZone
            {
                public const string Name = "AdvertisementLayoutZone";

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string LayoutId = "LayoutId";
                    public const string ZoneId = "ZoneId";
                    public const string SaveStatus = "SaveStatus";
                    public const string ZoneName = "ZoneName";
                }

                #endregion
            }

            #endregion

            #region AdvertisementType

            public class AdvertisementType
            {
                public const string Name = "AdvertisementType";
                public static string[] SearchColumns = { "Name", "Alias", "Detail" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string Alias = "Alias";
                    public const string Detail = "Detail";
                    public const string Name = "Name";
                }

                #endregion
            }

            #endregion

            #region AdvertisementZone

            public class AdvertisementZone
            {
                public const string Name = "AdvertisementZone";
                public const string Blocks = "Blocks";
                public static string[] SearchColumns = { "Name", "Detail" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string Detail = "Detail";
                    public const string Direction = "Direction";
                    public const string Height = "Height";
                    public const string HolderId = "HolderId";
                    public const string Mode = "Mode";
                    public const string Name = "Name";
                    public const string Width = "Width";
                }

                #endregion
            }

            #endregion

            #region AdvertisementZoneBlock

            public class AdvertisementZoneBlock
            {
                public const string Name = "AdvertisementZoneBlock";

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string BlockId = "BlockId";
                    public const string Ord = "Ord";
                    public const string ZoneId = "ZoneId";
                    //public const string OldOrd = "OldOrd";
                    public const string SaveStatus = "SaveStatus";
                    public const string BlockName = "BlockName";
                }

                #endregion
            }

            #endregion
        }

        #endregion

        #region Services

        public class Services : BaseServices
        {
            #region AdvertisementBlockManager

            public class AdvertisementBlockManager
            {
                public const string Name = "AdvertisementBlockManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string ViewGetAllAdvertisementBlock = "ViewGetAllAdvertisementBlock";
                }

                #endregion
            }

            #endregion

            #region AdvertisementBlockItemManager

            public class AdvertisementBlockItemManager
            {
                public const string Name = "AdvertisementBlockItemManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                }

                #endregion
            }

            #endregion

            #region AdvertisementItemManager

            public class AdvertisementItemManager
            {
                public const string Name = "AdvertisementItemManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string ViewGetAllAdvertisementItem = "ViewGetAllAdvertisementItem";
                }

                #endregion
            }

            #endregion

            #region AdvertisementLayoutManager

            public class AdvertisementLayoutManager
            {
                public const string Name = "AdvertisementLayoutManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string ViewGetAllAdvertisementLayout = "ViewGetAllAdvertisementLayout";
                }

                #endregion
            }

            #endregion

            #region AdvertisementLayoutCategoryManager

            public class AdvertisementLayoutCategoryManager
            {
                public const string Name = "AdvertisementLayoutCategoryManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                }

                #endregion
            }

            #endregion

            #region AdvertisementLayoutZoneManager

            public class AdvertisementLayoutZoneManager
            {
                public const string Name = "AdvertisementLayoutZoneManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                }

                #endregion
            }

            #endregion

            #region AdvertisementTypeManager

            public class AdvertisementTypeManager
            {
                public const string Name = "AdvertisementTypeManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string GetAdvertisementTypeByAlias = "GetAdvertisementTypeByAlias";
                    public const string ViewGetAllAdvertisementType = "ViewGetAllAdvertisementType";
                }

                #endregion
            }

            #endregion

            #region AdvertisementZoneManager

            public class AdvertisementZoneManager
            {
                public const string Name = "AdvertisementZoneManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string ViewGetAllAdvertisementZone = "ViewGetAllAdvertisementZone";
                }

                #endregion
            }

            #endregion

            #region AdvertisementZoneBlockManager

            public class AdvertisementZoneBlockManager
            {
                public const string Name = "AdvertisementZoneBlockManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                }

                #endregion
            }

            #endregion
        }

        #endregion

        #region ParameterName

        public class ParameterName : ModuleConstants.ParameterName
        {
            public const string AdvType = "AdvType";
        }

        #endregion

        #region Session

        public class Session : ModuleConstants.Session
        {
            public class AdvertisementData
            {
                public const string Categories = "AdvertisementCategories";
                public const string Zones = "AdvertisementZones";
                public const string Blocks = "AdvertisementBlocks";
                public const string Items = "AdvertisementItems";
                public const string NotLayoutZone = "NotLayoutZone";
                public const string NotZoneBlock = "NotZoneBlock";
                public const string NotBlockItem = "NotBlockItem";
            }
        }

        #endregion

        #region ViewState

        public class ViewState : ModuleConstants.ViewState
        {
            public const string EditOption = "EditOption";
        }

        #endregion

        #region ConfigKey

        public class ConfigKey : ModuleConstants.ConfigKey
        {
        }

        #endregion

        #region Message

        public class Message : ModuleConstants.Message
        {
            public const string LayoutNameCantEmpty = "LayoutNameCantEmpty";
            public const string ZoneNameCantEmpty = "ZoneNameCantEmpty";
            public const string ZoneHolderIdCantEmpty = "ZoneHolderIdCantEmpty";
            public const string BlockNameCantEmpty = "BlockNameCantEmpty";
            public const string ItemNameCantEmpty = "ItemNameCantEmpty";
            public const string ItemLinkCantEmpty = "ItemLinkCantEmpty";
            public const string StartTimeCantEmpty = "StartTimeCantEmpty";
            public const string EndTimeCantEmpty = "EndTimeCantEmpty";
            public const string EndTimeLessThanStartTime = "EndTimeLessThanStartTime";
        }

        #endregion

        #region FormNames

        public class FormNames : ModuleConstants.FormNames
        {
            #region Nested type: Advertisements

            public class Advertisements
            {
                public const string AdvertisementTypeDisplay = "~/Advertisements/AdvertisementTypeDisplay.aspx";
                public const string AdvertisementTypeEdit = "~/Advertisements/AdvertisementTypeEdit.aspx";
                public const string AdvertisementTypeView = "~/Advertisements/AdvertisementTypeView.aspx";
                public const string AdvertisementItemDisplay = "~/Advertisements/AdvertisementItemDisplay.aspx";
                public const string AdvertisementItemEdit = "~/Advertisements/AdvertisementItemEdit.aspx";
                public const string AdvertisementItemView = "~/Advertisements/AdvertisementItemView.aspx";
                public const string AdvertisementZoneDisplay = "~/Advertisements/AdvertisementZoneDisplay.aspx";
                public const string AdvertisementZoneEdit = "~/Advertisements/AdvertisementZoneEdit.aspx";
                public const string AdvertisementZoneView = "~/Advertisements/AdvertisementZoneView.aspx";
                public const string AdvertisementBlockDisplay = "~/Advertisements/AdvertisementBlockDisplay.aspx";
                public const string AdvertisementBlockEdit = "~/Advertisements/AdvertisementBlockEdit.aspx";
                public const string AdvertisementBlockView = "~/Advertisements/AdvertisementBlockView.aspx";
                public const string AdvertisementLayoutDisplay = "~/Advertisements/AdvertisementLayoutDisplay.aspx";
                public const string AdvertisementLayoutEdit = "~/Advertisements/AdvertisementLayoutEdit.aspx";
                public const string AdvertisementLayoutView = "~/Advertisements/AdvertisementLayoutView.aspx";
            }

            #endregion
        }

        #endregion
    }
}