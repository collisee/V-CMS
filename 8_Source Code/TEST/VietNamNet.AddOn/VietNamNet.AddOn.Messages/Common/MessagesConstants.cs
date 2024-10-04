using VietNamNet.Framework.Common;
using VietNamNet.Framework.Module;

/// <summary>
/// Constants of VietNamNet.AddOn.Messages
/// </summary>
namespace VietNamNet.AddOn.Messages.Common
{
    public class MessagesConstants
    {
        #region Entities

        public class Entities : BaseEntities
        {
            #region Message

            public class Message
            {
                public const string Name = "Message";
                public static string[] SearchColumns = { "Status", "Name", "Subject", "Detail" };

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string Detail = "Detail";
                    public const string MsgType = "MsgType";
                    public const string Name = "Name";
                    public const string Status = "Status";
                    public const string Subject = "Subject";
                    public const string ReceiverId = "ReceiverId";
                }

                #endregion
            }

            #endregion

            #region MessageDelivery

            public class MessageDelivery
            {
                public const string Name = "MessageDelivery";

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string FromUserId = "FromUserId";
                    public const string MessageId = "MessageId";
                    public const string Status = "Status";
                    public const string ToUserId = "ToUserId";
                }

                #endregion
            }

            #endregion
        }

        #endregion

        #region Services

        public class Services : BaseServices
        {
            #region MessageManager

            public class MessageManager
            {
                public const string Name = "MessageManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                    public const string GetNewPrivateMessages = "GetNewPrivateMessages";
                    public const string ViewGetAllMessages = "ViewGetAllMessages";
                    public const string ViewGetAllMyMessages = "ViewGetAllMyMessages";
                    public const string ViewGetAllMyMessagesByStatus = "ViewGetAllMyMessagesByStatus";
                    public const string ViewGetAllPrivateMessages = "ViewGetAllPrivateMessages";
                    public const string ViewGetAllPrivateMessagesByStatus = "ViewGetAllPrivateMessagesByStatus";
                }

                #endregion
            }

            #endregion

            #region MessageDeliveryManager

            public class MessageDeliveryManager
            {
                public const string Name = "MessageDeliveryManager";

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
            public const string MsgType = "MsgType";
            public const string ReceiverId = "ReceiverId";
            public const string Subject = "Subject";
        }

        #endregion

        #region Paging

        public class Paging
        {
            public class Direction : Constants.Paging.Direction
            {
                public const string MessageId = "MessageId";
            }
        }

        #endregion

        #region Session

        public class Session : ModuleConstants.Session
        {
        }

        #endregion

        #region ViewState

        public class ViewState : ModuleConstants.ViewState
        {
            public const string ModuleId = "ModuleId";
            public const string Values = "Values";
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
            public const string ReceiverNotSelect = "ReceiverNotSelect";
            public const string SubjectCantEmpty = "SubjectCantEmpty";
        }

        #endregion

        #region FormNames

        public class FormNames : ModuleConstants.FormNames
        {
            #region Nested type: Messages

            public class Messages
            {
                public const string MessageDisplay = "~/Messages/MessageDisplay.aspx";
                public const string MessageEdit = "~/Messages/MessageEdit.aspx";
                public const string MessageView = "~/Messages/MessageView.aspx";
                public const string MessageManagerView = "~/Messages/MessageManagerView.aspx";
                public const string MessageViewByStatus = "~/Messages/MessageViewByStatus.aspx";
                public const string MessageDraft = "~/Messages/MessageDraft.aspx";
                public const string MessageSent = "~/Messages/MessageSent.aspx";
                public const string PopupMessageDisplay = "~/Messages/PopupMessageDisplay.aspx";
            }

            #endregion
        }

        #endregion

        #region MessageStatus

        public class MessageStatus
        {
            public const string Draft = "Bản nháp";
            public const string Sent = "Đã gửi";
            public const string Read = "Đã đọc";
            public const string UnRead = "Chưa đọc";
        }

        #endregion

        #region CommandNames

        public class CommandNames
        {
            public const string Send = "Send";
        }

        #endregion

    }
}