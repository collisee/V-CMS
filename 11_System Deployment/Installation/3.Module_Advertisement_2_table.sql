/****** Object:  Table [dbo].[AdvertisementType]    Script Date: 08/11/2010 16:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdvertisementType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Alias] [nvarchar](255) NOT NULL,
	[Detail] [nvarchar](4000) NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementType_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_AdvertisementType_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementType_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_AdvertisementType_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_AdvertisementType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Advertise]
) ON [Advertise]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdvertisementLayout]    Script Date: 08/11/2010 16:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdvertisementLayout](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Detail] [nvarchar](4000) NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementLayout_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_AdvertisementLayout_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementLayout_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_AdvertisementLayout_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_AdvertisementLayout] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Advertise]
) ON [Advertise]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdvertisementZone]    Script Date: 08/11/2010 16:53:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdvertisementZone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[HolderId] [nvarchar](255) NOT NULL,
	[Detail] [nvarchar](4000) NULL,
	[Mode] [int] NOT NULL CONSTRAINT [DF_AdvertisementZone_Mode]  DEFAULT ((0)),
	[Direction] [int] NOT NULL CONSTRAINT [DF_AdvertisementZone_Direction]  DEFAULT ((0)),
	[Width] [int] NOT NULL CONSTRAINT [DF_AdvertisementZone_Width]  DEFAULT ((0)),
	[Height] [int] NOT NULL CONSTRAINT [DF_AdvertisementZone_Height]  DEFAULT ((0)),
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementZone_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_AdvertisementZone_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementZone_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_AdvertisementZone_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_AdvertisementZone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Advertise]
) ON [Advertise]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdvertisementBlock]    Script Date: 08/11/2010 16:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdvertisementBlock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Detail] [nvarchar](4000) NULL,
	[Mode] [int] NOT NULL CONSTRAINT [DF_AdvertisementBlock_Mode]  DEFAULT ((0)),
	[TimeDelay] [int] NOT NULL CONSTRAINT [DF_AdvertisementBlock_Timeout]  DEFAULT ((5000)),
	[Width] [int] NOT NULL CONSTRAINT [DF_AdvertisementBlock_Width]  DEFAULT ((0)),
	[Height] [int] NOT NULL CONSTRAINT [DF_AdvertisementBlock_Height]  DEFAULT ((0)),
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementBlock_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_AdvertisementBlock_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementBlock_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_AdvertisementBlock_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_AdvertisementBlock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Advertise]
) ON [Advertise]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdvertisementBlockItem]    Script Date: 08/11/2010 16:53:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdvertisementBlockItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BlockId] [int] NOT NULL CONSTRAINT [DF_AdvertisementBlockItem_LayoutId]  DEFAULT ((0)),
	[ItemId] [int] NOT NULL CONSTRAINT [DF_AdvertisementBlockItem_CategoryId]  DEFAULT ((0)),
	[Ord] [int] NOT NULL CONSTRAINT [DF_AdvertisementBlockItem_Ord]  DEFAULT ((0)),
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementBlockItem_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_AdvertisementBlockItem_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementBlockItem_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_AdvertisementBlockItem_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_AdvertisementBlockItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Advertise]
) ON [Advertise]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdvertisementItem]    Script Date: 08/11/2010 16:53:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdvertisementItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Link] [nvarchar](255) NOT NULL,
	[FileLink1] [nvarchar](255) NOT NULL,
	[FileLink2] [nvarchar](255) NULL,
	[FileJS] [nvarchar](4000) NULL,
	[CodeJS] [nvarchar](4000) NULL,
	[StartTime] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementItem_StartTime]  DEFAULT (getdate()),
	[EndTime] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementItem_EndTime]  DEFAULT (getdate()),
	[Detail] [nvarchar](4000) NULL,
	[ExWidth] [int] NULL CONSTRAINT [DF_AdvertisementItem_ExWidth]  DEFAULT ((0)),
	[ExHeight] [int] NULL CONSTRAINT [DF_AdvertisementItem_ExHeight]  DEFAULT ((0)),
	[ExMode] [int] NULL CONSTRAINT [DF_AdvertisementItem_ExMode]  DEFAULT ((0)),
	[History] [ntext] NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementItem_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_AdvertisementItem_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementItem_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_AdvertisementItem_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_AdvertisementItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Advertise]
) ON [Advertise] TEXTIMAGE_ON [Advertise]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdvertisementLayoutCategory]    Script Date: 08/11/2010 16:53:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdvertisementLayoutCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LayoutId] [int] NOT NULL CONSTRAINT [DF_AdvertisementLayoutCategory_LayoutId]  DEFAULT ((0)),
	[CategoryId] [int] NOT NULL CONSTRAINT [DF_AdvertisementLayoutCategory_CategoryId]  DEFAULT ((0)),
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementLayoutCategory_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_AdvertisementLayoutCategory_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementLayoutCategory_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_AdvertisementLayoutCategory_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_AdvertisementLayoutCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Advertise]
) ON [Advertise]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdvertisementLayoutZone]    Script Date: 08/11/2010 16:53:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdvertisementLayoutZone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LayoutId] [int] NOT NULL CONSTRAINT [DF_AdvertisementLayoutZone_LayoutId]  DEFAULT ((0)),
	[ZoneId] [int] NOT NULL CONSTRAINT [DF_Table_1_CategoryId]  DEFAULT ((0)),
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementLayoutZone_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_AdvertisementLayoutZone_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementLayoutZone_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_AdvertisementLayoutZone_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_AdvertisementLayoutZone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Advertise]
) ON [Advertise]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdvertisementZoneBlock]    Script Date: 08/11/2010 16:53:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdvertisementZoneBlock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ZoneId] [int] NOT NULL CONSTRAINT [DF_Table_1_LayoutId]  DEFAULT ((0)),
	[BlockId] [int] NOT NULL CONSTRAINT [DF_Table_1_ZoneId]  DEFAULT ((0)),
	[Ord] [int] NOT NULL CONSTRAINT [DF_AdvertisementZoneBlock_Ord]  DEFAULT ((0)),
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementZoneBlock_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_AdvertisementZoneBlock_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_AdvertisementZoneBlock_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_AdvertisementZoneBlock_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_AdvertisementZoneBlock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Advertise]
) ON [Advertise]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_AdvertisementBlockItem_AdvertisementBlock]    Script Date: 08/11/2010 16:53:29 ******/
ALTER TABLE [dbo].[AdvertisementBlockItem]  WITH CHECK ADD  CONSTRAINT [FK_AdvertisementBlockItem_AdvertisementBlock] FOREIGN KEY([BlockId])
REFERENCES [dbo].[AdvertisementBlock] ([Id])
GO
ALTER TABLE [dbo].[AdvertisementBlockItem] CHECK CONSTRAINT [FK_AdvertisementBlockItem_AdvertisementBlock]
GO
/****** Object:  ForeignKey [FK_AdvertisementBlockItem_AdvertisementItem]    Script Date: 08/11/2010 16:53:29 ******/
ALTER TABLE [dbo].[AdvertisementBlockItem]  WITH CHECK ADD  CONSTRAINT [FK_AdvertisementBlockItem_AdvertisementItem] FOREIGN KEY([ItemId])
REFERENCES [dbo].[AdvertisementItem] ([Id])
GO
ALTER TABLE [dbo].[AdvertisementBlockItem] CHECK CONSTRAINT [FK_AdvertisementBlockItem_AdvertisementItem]
GO
/****** Object:  ForeignKey [FK_AdvertisementItem_AdvertisementType]    Script Date: 08/11/2010 16:53:34 ******/
ALTER TABLE [dbo].[AdvertisementItem]  WITH CHECK ADD  CONSTRAINT [FK_AdvertisementItem_AdvertisementType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[AdvertisementType] ([Id])
GO
ALTER TABLE [dbo].[AdvertisementItem] CHECK CONSTRAINT [FK_AdvertisementItem_AdvertisementType]
GO
/****** Object:  ForeignKey [FK_AdvertisementLayoutCategory_AdvertisementLayout]    Script Date: 08/11/2010 16:53:38 ******/
ALTER TABLE [dbo].[AdvertisementLayoutCategory]  WITH CHECK ADD  CONSTRAINT [FK_AdvertisementLayoutCategory_AdvertisementLayout] FOREIGN KEY([LayoutId])
REFERENCES [dbo].[AdvertisementLayout] ([Id])
GO
ALTER TABLE [dbo].[AdvertisementLayoutCategory] CHECK CONSTRAINT [FK_AdvertisementLayoutCategory_AdvertisementLayout]
GO
/****** Object:  ForeignKey [FK_AdvertisementLayoutCategory_Category]    Script Date: 08/11/2010 16:53:38 ******/
ALTER TABLE [dbo].[AdvertisementLayoutCategory]  WITH CHECK ADD  CONSTRAINT [FK_AdvertisementLayoutCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[AdvertisementLayoutCategory] CHECK CONSTRAINT [FK_AdvertisementLayoutCategory_Category]
GO
/****** Object:  ForeignKey [FK_AdvertisementLayoutZone_AdvertisementLayout]    Script Date: 08/11/2010 16:53:41 ******/
ALTER TABLE [dbo].[AdvertisementLayoutZone]  WITH CHECK ADD  CONSTRAINT [FK_AdvertisementLayoutZone_AdvertisementLayout] FOREIGN KEY([LayoutId])
REFERENCES [dbo].[AdvertisementLayout] ([Id])
GO
ALTER TABLE [dbo].[AdvertisementLayoutZone] CHECK CONSTRAINT [FK_AdvertisementLayoutZone_AdvertisementLayout]
GO
/****** Object:  ForeignKey [FK_AdvertisementLayoutZone_AdvertisementZone]    Script Date: 08/11/2010 16:53:41 ******/
ALTER TABLE [dbo].[AdvertisementLayoutZone]  WITH CHECK ADD  CONSTRAINT [FK_AdvertisementLayoutZone_AdvertisementZone] FOREIGN KEY([ZoneId])
REFERENCES [dbo].[AdvertisementZone] ([Id])
GO
ALTER TABLE [dbo].[AdvertisementLayoutZone] CHECK CONSTRAINT [FK_AdvertisementLayoutZone_AdvertisementZone]
GO
/****** Object:  ForeignKey [FK_AdvertisementZoneBlock_AdvertisementBlock]    Script Date: 08/11/2010 16:53:49 ******/
ALTER TABLE [dbo].[AdvertisementZoneBlock]  WITH CHECK ADD  CONSTRAINT [FK_AdvertisementZoneBlock_AdvertisementBlock] FOREIGN KEY([BlockId])
REFERENCES [dbo].[AdvertisementBlock] ([Id])
GO
ALTER TABLE [dbo].[AdvertisementZoneBlock] CHECK CONSTRAINT [FK_AdvertisementZoneBlock_AdvertisementBlock]
GO
/****** Object:  ForeignKey [FK_AdvertisementZoneBlock_AdvertisementZone]    Script Date: 08/11/2010 16:53:49 ******/
ALTER TABLE [dbo].[AdvertisementZoneBlock]  WITH CHECK ADD  CONSTRAINT [FK_AdvertisementZoneBlock_AdvertisementZone] FOREIGN KEY([ZoneId])
REFERENCES [dbo].[AdvertisementZone] ([Id])
GO
ALTER TABLE [dbo].[AdvertisementZoneBlock] CHECK CONSTRAINT [FK_AdvertisementZoneBlock_AdvertisementZone]
GO
