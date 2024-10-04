/****** Object:  Table [dbo].[Group]    Script Date: 07/11/2010 14:33:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Detail] [nvarchar](4000) NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_Group_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_Group_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_Group_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_Group_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Module]    Script Date: 07/11/2010 14:33:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Module](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Alias] [nvarchar](255) NOT NULL CONSTRAINT [DF_Module_Alias]  DEFAULT (N''),
	[Detail] [nvarchar](4000) NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_Module_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_Module_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_Module_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_Module_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 07/11/2010 14:33:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](255) NOT NULL CONSTRAINT [DF_User_Status]  DEFAULT (N'Hoạt động'),
	[LoginName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Avatar] [nvarchar](255) NULL,
	[Birthday] [datetime] NULL,
	[Sex] [nvarchar](50) NOT NULL CONSTRAINT [DF_User_Sex]  DEFAULT (N'Nam'),
	[FullName] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL CONSTRAINT [DF_User_Password]  DEFAULT (N'AnhDT'),
	[Address] [nvarchar](255) NOT NULL,
	[Phone] [nvarchar](255) NOT NULL,
	[Mobile] [nvarchar](255) NOT NULL,
	[Yahoo] [nvarchar](255) NOT NULL CONSTRAINT [DF_User_Yahoo]  DEFAULT (''),
	[Skype] [nvarchar](255) NOT NULL CONSTRAINT [DF_User_Skype]  DEFAULT (''),
	[Facebook] [nvarchar](255) NOT NULL CONSTRAINT [DF_User_Facebook]  DEFAULT (''),
	[Detail] [nvarchar](4000) NULL,
	[Skin] [nvarchar](255) NOT NULL CONSTRAINT [DF_User_Skin]  DEFAULT (N'Office2007'),
	[LastLogin] [datetime] NULL CONSTRAINT [DF_User_LastLogin]  DEFAULT (getdate()),
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_User_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_User_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_User_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_User_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Configuration]    Script Date: 07/11/2010 14:33:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Configuration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Val] [nvarchar](255) NOT NULL,
	[Detail] [nvarchar](4000) NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_Configuration_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_Configuration_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_Configuration_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_Configuration_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GroupMember]    Script Date: 07/11/2010 14:33:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GroupMember](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL CONSTRAINT [DF_Table_1_Ord]  DEFAULT ((0)),
	[UserId] [int] NOT NULL CONSTRAINT [DF_GroupMember_UserId]  DEFAULT ((0)),
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_GroupMember_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_GroupMember_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_GroupMember_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_GroupMember_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_GroupMember] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Policy]    Script Date: 07/11/2010 14:33:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Policy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL CONSTRAINT [DF_Table_1_GId]  DEFAULT ((0)),
	[ModuleId] [int] NOT NULL CONSTRAINT [DF_Table_1_MId_1]  DEFAULT ((0)),
	[Val] [int] NOT NULL CONSTRAINT [DF_Policy_Val]  DEFAULT ((0)),
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_Policy_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_Policy_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_Policy_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_Policy_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_Policy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 07/11/2010 14:33:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PId] [int] NULL,
	[Ord] [int] NOT NULL CONSTRAINT [DF_Menu_Ord]  DEFAULT ((0)),
	[Name] [nvarchar](50) NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
	[Link] [nvarchar](255) NULL,
	[ModuleId] [int] NOT NULL CONSTRAINT [DF_Table_1_MId_2]  DEFAULT ((0)),
	[Access] [int] NOT NULL CONSTRAINT [DF_Menu_Access]  DEFAULT ((0)),
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_Menu_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_Menu_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_Menu_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_Menu_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Function]    Script Date: 07/11/2010 14:33:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Function](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL CONSTRAINT [DF_Table_1_MId]  DEFAULT ((0)),
	[Ord] [int] NOT NULL CONSTRAINT [DF_Function_Ord]  DEFAULT ((0)),
	[Name] [nvarchar](255) NOT NULL,
	[Alias] [nvarchar](255) NOT NULL,
	[Detail] [nvarchar](4000) NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_Function_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_Function_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_Function_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_Function_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_Function] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Logging]    Script Date: 07/11/2010 14:33:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Logging](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LogTime] [datetime] NOT NULL CONSTRAINT [DF_Logging_LogTime]  DEFAULT (getdate()),
	[LogLevel] [int] NOT NULL CONSTRAINT [DF_Logging_LogLevel]  DEFAULT ((0)),
	[IP] [nvarchar](50) NOT NULL CONSTRAINT [DF_Logging_IP]  DEFAULT (N'0.0.0.0'),
	[UId] [int] NOT NULL CONSTRAINT [DF_Logging_UId]  DEFAULT ((0)),
	[UserFullName] [nvarchar](255) NOT NULL CONSTRAINT [DF_Logging_UserFullName]  DEFAULT (''),
	[Action] [nvarchar](255) NOT NULL CONSTRAINT [DF_Logging_Action]  DEFAULT (N'none'),
	[Detail] [nvarchar](4000) NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_Logging_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_Logging_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_Logging_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_Logging_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_Logging] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [LoggingPartitionScheme]([LogTime])
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Policy_Group]    Script Date: 07/11/2010 14:33:09 ******/
ALTER TABLE [dbo].[Policy]  WITH CHECK ADD  CONSTRAINT [FK_Policy_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[Policy] CHECK CONSTRAINT [FK_Policy_Group]
GO
/****** Object:  ForeignKey [FK_Policy_Module]    Script Date: 07/11/2010 14:33:09 ******/
ALTER TABLE [dbo].[Policy]  WITH CHECK ADD  CONSTRAINT [FK_Policy_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([Id])
GO
ALTER TABLE [dbo].[Policy] CHECK CONSTRAINT [FK_Policy_Module]
GO
/****** Object:  ForeignKey [FK_Menu_Module]    Script Date: 07/11/2010 14:33:09 ******/
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([Id])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_Module]
GO
/****** Object:  ForeignKey [FK_GroupMember_Group]    Script Date: 07/11/2010 14:33:09 ******/
ALTER TABLE [dbo].[GroupMember]  WITH CHECK ADD  CONSTRAINT [FK_GroupMember_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[GroupMember] CHECK CONSTRAINT [FK_GroupMember_Group]
GO
/****** Object:  ForeignKey [FK_GroupMember_User]    Script Date: 07/11/2010 14:33:09 ******/
ALTER TABLE [dbo].[GroupMember]  WITH CHECK ADD  CONSTRAINT [FK_GroupMember_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[GroupMember] CHECK CONSTRAINT [FK_GroupMember_User]
GO
/****** Object:  ForeignKey [FK_Function_Module]    Script Date: 07/11/2010 14:33:09 ******/
ALTER TABLE [dbo].[Function]  WITH CHECK ADD  CONSTRAINT [FK_Function_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([Id])
GO
ALTER TABLE [dbo].[Function] CHECK CONSTRAINT [FK_Function_Module]
GO
