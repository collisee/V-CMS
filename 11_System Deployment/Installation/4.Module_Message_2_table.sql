/****** Object:  Table [dbo].[Message]    Script Date: 06/30/2010 13:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Message](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MsgType] [int] NOT NULL CONSTRAINT [DF_Message_MsgType]  DEFAULT ((0)),
	[Status] [nvarchar](255) NOT NULL CONSTRAINT [DF_Message_Status]  DEFAULT (N'Hoạt động'),
	[Name] [nvarchar](255) NOT NULL,
	[Subject] [nvarchar](255) NOT NULL,
	[Detail] [ntext] NOT NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_Message_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_Message_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_Message_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_Message_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Message]
) ON [Message] TEXTIMAGE_ON [Message]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MessageDelivery]    Script Date: 06/30/2010 13:25:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MessageDelivery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MessageId] [int] NOT NULL CONSTRAINT [DF_MessageDelivery_MessageId]  DEFAULT ((0)),
	[Status] [nvarchar](255) NOT NULL CONSTRAINT [DF_MessageDelivery_Status]  DEFAULT (N'Chưa đọc'),
	[FromUserId] [int] NOT NULL CONSTRAINT [DF_MessageDelivery_FromUserId]  DEFAULT ((0)),
	[ToUserId] [int] NOT NULL CONSTRAINT [DF_MessageDelivery_ToUserId]  DEFAULT ((0)),
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_MessageDelivery_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_MessageDelivery_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_MessageDelivery_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_MessageDelivery_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_MessageDelivery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Message]
) ON [Message]
GO
SET ANSI_PADDING OFF
GO
