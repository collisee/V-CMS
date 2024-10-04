/****** Object:  Table [dbo].[ArticleType]    Script Date: 10/29/2010 09:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Detail] [nvarchar](4000) NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_ArticleType_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_ArticleType_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_ArticleType_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_ArticleType_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_ArticleType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Article]
) ON [Article]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticleContentType]    Script Date: 10/29/2010 09:54:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticleContentType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Detail] [nvarchar](4000) NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_ArticleContentType_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_ArticleContentType_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_ArticleContentType_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_ArticleContentType_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_ArticleContentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Article]
) ON [Article]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticleEvent]    Script Date: 10/29/2010 09:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticleEvent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](255) NOT NULL CONSTRAINT [DF_ArticleEvent_Status]  DEFAULT (N'Chưa xử lý'),
	[Name] [nvarchar](255) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[ImageLink] [nvarchar](255) NOT NULL CONSTRAINT [DF_ArticleEvent_ImageLink]  DEFAULT (''),
	[Lead] [nvarchar](4000) NOT NULL,
	[Detail] [ntext] NOT NULL,
	[PublishDate] [datetime] NOT NULL CONSTRAINT [DF_ArticleEvent_PublishDate]  DEFAULT (getdate()),
	[TotalView] [int] NOT NULL CONSTRAINT [DF_ArticleEvent_TotalView]  DEFAULT ((0)),
	[History] [ntext] NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_ArticleEvent_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_ArticleEvent_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_ArticleEvent_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_ArticleEvent_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_ArticleEvent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Event]
) ON [Event] TEXTIMAGE_ON [Event]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Collaborator]    Script Date: 10/29/2010 09:55:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Collaborator](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Detail] [nvarchar](4000) NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_Collaborator_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_Collaborator_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_Collaborator_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_Collaborator_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_Collaborator] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Article]
) ON [Article]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/29/2010 09:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PartitionId] [int] NOT NULL CONSTRAINT [DF_Category_PartitionId]  DEFAULT ((1)),
	[PId] [int] NULL,
	[Ord] [int] NOT NULL CONSTRAINT [DF_Category_Ord]  DEFAULT ((0)),
	[Name] [nvarchar](255) NOT NULL,
	[Alias] [nvarchar](255) NOT NULL CONSTRAINT [DF_Category_Alias]  DEFAULT (N''),
	[DisplayName] [nvarchar](255) NOT NULL,
	[Url] [nvarchar](255) NULL,
	[Detail] [nvarchar](4000) NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_Category_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_Category_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_Category_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_Category_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Category]
) ON [Category]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticleEventCategory]    Script Date: 10/29/2010 09:55:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticleEventCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleEventId] [int] NOT NULL CONSTRAINT [DF_ArticleEventCategory_ArticleEventId]  DEFAULT ((0)),
	[CategoryId] [int] NOT NULL CONSTRAINT [DF_Table_1_ArticleId]  DEFAULT ((0)),
	[Ord] [int] NOT NULL CONSTRAINT [DF_ArticleEventCategory_Ord]  DEFAULT ((0)),
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_ArticleEventCategory_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_ArticleEventCategory_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_ArticleEventCategory_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_ArticleEventCategory_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_ArticleEventCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Event]
) ON [Event]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CategoryPolicy]    Script Date: 10/29/2010 09:55:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CategoryPolicy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL CONSTRAINT [DF_CategoryPolicy_GroupId]  DEFAULT ((0)),
	[CategoryId] [int] NOT NULL CONSTRAINT [DF_CategoryPolicy_CategoryId]  DEFAULT ((0)),
	[Val] [int] NOT NULL CONSTRAINT [DF_CategoryPolicy_Val]  DEFAULT ((0)),
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_CategoryPolicy_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_CategoryPolicy_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_CategoryPolicy_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_CategoryPolicy_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_CategoryPolicy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Category]
) ON [Category]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticleEventItem]    Script Date: 10/29/2010 09:55:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticleEventItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleEventId] [int] NOT NULL CONSTRAINT [DF_Table_1_Status]  DEFAULT ((0)),
	[ArticleId] [int] NOT NULL CONSTRAINT [DF_Table_1_ArticleEventId1]  DEFAULT ((0)),
	[Ord] [int] NOT NULL CONSTRAINT [DF_Table_1_ArticleEventId2]  DEFAULT ((0)),
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_ArticleEventItem_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_ArticleEventItem_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_ArticleEventItem_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_ArticleEventItem_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_ArticleEventItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [Event]
) ON [Event]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticleVersion]    Script Date: 10/29/2010 09:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticleVersion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleId] [int] NOT NULL CONSTRAINT [DF_ArticleVersion_ArticleId]  DEFAULT ((0)),
	[VersionId] [int] NOT NULL CONSTRAINT [DF_ArticleVersion_VersionId]  DEFAULT ((1)),
	[Status] [nvarchar](255) NOT NULL CONSTRAINT [DF_ArticleVersion_Status]  DEFAULT (N'Bản nháp'),
	[ArticleTypeId] [int] NOT NULL CONSTRAINT [DF_ArticleVersion_ArticleType]  DEFAULT ((0)),
	[ArticleContentTypeId] [int] NOT NULL CONSTRAINT [DF_ArticleVersion_ArticleContentType]  DEFAULT ((0)),
	[Name] [nvarchar](255) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[SubTitle1] [nvarchar](255) NULL,
	[SubTitle2] [nvarchar](255) NULL,
	[SubTitle3] [nvarchar](255) NULL,
	[SubTitle4] [nvarchar](255) NULL,
	[SubTitle5] [nvarchar](255) NULL,
	[SubTitle6] [nvarchar](255) NULL,
	[ImageLink] [nvarchar](255) NOT NULL CONSTRAINT [DF_ArticleVersion_ImageLink]  DEFAULT (''),
	[ImageLink1] [nvarchar](255) NOT NULL CONSTRAINT [DF_ArticleVersion_ImageLink1]  DEFAULT (''),
	[ImageLink2] [nvarchar](255) NOT NULL CONSTRAINT [DF_ArticleVersion_ImageLink2]  DEFAULT (''),
	[ImageLink3] [nvarchar](255) NOT NULL CONSTRAINT [DF_ArticleVersion_ImageLink3]  DEFAULT (''),
	[ImageLink4] [nvarchar](255) NOT NULL CONSTRAINT [DF_ArticleVersion_ImageLink4]  DEFAULT (''),
	[ImageLink5] [nvarchar](255) NOT NULL CONSTRAINT [DF_ArticleVersion_ImageLink5]  DEFAULT (''),
	[Lead] [ntext] NOT NULL,
	[Detail] [ntext] NOT NULL,
	[PublishDate] [datetime] NOT NULL CONSTRAINT [DF_ArticleVersion_PublishDate]  DEFAULT (getdate()),
	[Author] [nvarchar](255) NULL,
	[AuthorInfo] [nvarchar](4000) NULL,
	[IsMember] [int] NOT NULL CONSTRAINT [DF_ArticleVersion_IsMember]  DEFAULT ((0)),
	[TotalView] [int] NOT NULL CONSTRAINT [DF_ArticleVersion_TotalView]  DEFAULT ((0)),
	[History] [ntext] NOT NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_ArticleVersion_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_ArticleVersion_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_ArticleVersion_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_ArticleVersion_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_ArticleVersion] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [ArticlePartitionScheme]([ArticleId])
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticleComment]    Script Date: 10/29/2010 09:54:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticleComment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleId] [int] NOT NULL CONSTRAINT [DF_Table_1_MId_3]  DEFAULT ((0)),
	[PId] [int] NOT NULL CONSTRAINT [DF_ArticleComment_PId]  DEFAULT ((0)),
	[Status] [nvarchar](255) NOT NULL CONSTRAINT [DF_ArticleComment_Status]  DEFAULT (N'Chưa xử lý'),
	[Name] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Phone] [nvarchar](255) NOT NULL,
	[Subject] [nvarchar](4000) NOT NULL,
	[Detail] [ntext] NOT NULL,
	[History] [ntext] NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_ArticleComment_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_ArticleComment_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_ArticleComment_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_ArticleComment_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_ArticleComment] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [ArticlePartitionScheme]([ArticleId])
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Article]    Script Date: 10/29/2010 09:54:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VersionId] [int] NOT NULL CONSTRAINT [DF_Article_VersionId]  DEFAULT ((0)),
	[Status] [nvarchar](255) NOT NULL CONSTRAINT [DF_Article_Status]  DEFAULT (N'Bản nháp'),
	[ArticleTypeId] [int] NOT NULL CONSTRAINT [DF_Article_ArticleType]  DEFAULT ((0)),
	[ArticleContentTypeId] [int] NOT NULL CONSTRAINT [DF_Article_ArticleContentType]  DEFAULT ((0)),
	[Name] [nvarchar](255) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[Url] [nvarchar](255) NULL,
	[CategoryId] [int] NOT NULL CONSTRAINT [DF_Article_CategoryId]  DEFAULT ((0)),
	[PartitionId] [int] NOT NULL CONSTRAINT [DF_Article_PartitionId]  DEFAULT ((0)),
	[SubTitle1] [nvarchar](255) NULL,
	[SubTitle2] [nvarchar](255) NULL,
	[SubTitle3] [nvarchar](255) NULL,
	[SubTitle4] [nvarchar](255) NULL,
	[SubTitle5] [nvarchar](255) NULL,
	[SubTitle6] [nvarchar](255) NULL,
	[ImageLink] [nvarchar](255) NOT NULL CONSTRAINT [DF_Article_ImageLink]  DEFAULT (''),
	[ImageLink1] [nvarchar](255) NOT NULL CONSTRAINT [DF_Article_ImageLink1]  DEFAULT (''),
	[ImageLink2] [nvarchar](255) NOT NULL CONSTRAINT [DF_Article_ImageLink2]  DEFAULT (''),
	[ImageLink3] [nvarchar](255) NOT NULL CONSTRAINT [DF_Article_ImageLink3]  DEFAULT (''),
	[ImageLink4] [nvarchar](255) NOT NULL CONSTRAINT [DF_Article_ImageLink4]  DEFAULT (''),
	[ImageLink5] [nvarchar](255) NOT NULL CONSTRAINT [DF_Article_ImageLink5]  DEFAULT (''),
	[Lead] [nvarchar](4000) NOT NULL,
	[Detail] [ntext] NOT NULL,
	[PublishDate] [datetime] NOT NULL CONSTRAINT [DF_Article_PublishDate]  DEFAULT (getdate()),
	[ShowComment] [int] NOT NULL CONSTRAINT [DF_Article_ShowComment]  DEFAULT ((1)),
	[AuthorId] [int] NOT NULL CONSTRAINT [DF_Article_AuthorId]  DEFAULT ((0)),
	[Author] [nvarchar](255) NULL,
	[AuthorInfo] [nvarchar](4000) NULL,
	[IsMember] [int] NOT NULL CONSTRAINT [DF_Article_IsMember]  DEFAULT ((0)),
	[TotalView] [int] NOT NULL CONSTRAINT [DF_Article_TotalView]  DEFAULT ((0)),
	[History] [ntext] NOT NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_Article_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_Article_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_Article_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_Article_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [ArticlePartitionScheme]([Id])
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticleMedia]    Script Date: 10/29/2010 09:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticleMedia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticleId] [int] NOT NULL,
	[MediaType] [nvarchar](50) NOT NULL CONSTRAINT [DF_Table_1_FileType]  DEFAULT (N'Image'),
	[Ord] [int] NOT NULL CONSTRAINT [DF_ArticleMedia_Ord]  DEFAULT ((0)),
	[FileLink] [nvarchar](255) NOT NULL,
	[Thumbnail] [nvarchar](255) NOT NULL,
	[Detail] [nvarchar](4000) NULL,
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_ArticleMedia_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_ArticleMedia_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_ArticleMedia_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_ArticleMedia_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
 CONSTRAINT [PK_ArticleMedia] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [ArticlePartitionScheme]([ArticleId])
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticleCategory]    Script Date: 10/29/2010 09:54:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticleCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL CONSTRAINT [DF_ArticleCategory_CategoryId]  DEFAULT ((0)),
	[PartitionId] [int] NOT NULL CONSTRAINT [DF_ArticleCategory_PartitionId]  DEFAULT ((0)),
	[ArticleId] [int] NOT NULL CONSTRAINT [DF_ArticleCategory_ArticleId]  DEFAULT ((0)),
	[Ord] [int] NOT NULL CONSTRAINT [DF_ArticleCategory_Ord]  DEFAULT ((1)),
	[ArticleContentTypeId] [int] NOT NULL CONSTRAINT [DF_ArticleCategory_ArticleContentType]  DEFAULT ((0)),
	[Url] [nvarchar](255) NULL,
	[PublishDate] [datetime] NOT NULL CONSTRAINT [DF_ArticleCategory_PublishDate]  DEFAULT (getdate()),
	[PrimaryCategory] [int] NOT NULL CONSTRAINT [DF_Table_1_PrimaryCategory]  DEFAULT ((0)),
	[Created_At] [datetime] NOT NULL CONSTRAINT [DF_ArticleCategory_Created_At]  DEFAULT (getdate()),
	[Created_By] [int] NOT NULL CONSTRAINT [DF_ArticleCategory_Created_By]  DEFAULT ((0)),
	[Last_Modified_At] [datetime] NOT NULL CONSTRAINT [DF_ArticleCategory_Last_Modified_At]  DEFAULT (getdate()),
	[Last_Modified_By] [int] NOT NULL CONSTRAINT [DF_ArticleCategory_Last_Modified_By]  DEFAULT ((0)),
	[flag] [char](1) NULL,
	[PartitionNumber]  AS ([PartitionId]*(10000)+datepart(year,[PublishDate])) PERSISTED,
 CONSTRAINT [PK_ArticleCategory] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [CategoryPartitionScheme]([PartitionNumber])
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Article_ArticleContentType]    Script Date: 10/29/2010 09:54:46 ******/
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_Article_ArticleContentType] FOREIGN KEY([ArticleContentTypeId])
REFERENCES [dbo].[ArticleContentType] ([Id])
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_Article_ArticleContentType]
GO
/****** Object:  ForeignKey [FK_Article_ArticleType]    Script Date: 10/29/2010 09:54:46 ******/
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_Article_ArticleType] FOREIGN KEY([ArticleTypeId])
REFERENCES [dbo].[ArticleType] ([Id])
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_Article_ArticleType]
GO
/****** Object:  ForeignKey [FK_ArticleCategory_Article]    Script Date: 10/29/2010 09:54:51 ******/
ALTER TABLE [dbo].[ArticleCategory]  WITH CHECK ADD  CONSTRAINT [FK_ArticleCategory_Article] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Article] ([Id])
GO
ALTER TABLE [dbo].[ArticleCategory] CHECK CONSTRAINT [FK_ArticleCategory_Article]
GO
/****** Object:  ForeignKey [FK_ArticleCategory_Category]    Script Date: 10/29/2010 09:54:51 ******/
ALTER TABLE [dbo].[ArticleCategory]  WITH CHECK ADD  CONSTRAINT [FK_ArticleCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[ArticleCategory] CHECK CONSTRAINT [FK_ArticleCategory_Category]
GO
/****** Object:  ForeignKey [FK_ArticleComment_Article]    Script Date: 10/29/2010 09:54:56 ******/
ALTER TABLE [dbo].[ArticleComment]  WITH CHECK ADD  CONSTRAINT [FK_ArticleComment_Article] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Article] ([Id])
GO
ALTER TABLE [dbo].[ArticleComment] CHECK CONSTRAINT [FK_ArticleComment_Article]
GO
/****** Object:  ForeignKey [FK_ArticleEventCategory_ArticleEvent]    Script Date: 10/29/2010 09:55:06 ******/
ALTER TABLE [dbo].[ArticleEventCategory]  WITH CHECK ADD  CONSTRAINT [FK_ArticleEventCategory_ArticleEvent] FOREIGN KEY([ArticleEventId])
REFERENCES [dbo].[ArticleEvent] ([Id])
GO
ALTER TABLE [dbo].[ArticleEventCategory] CHECK CONSTRAINT [FK_ArticleEventCategory_ArticleEvent]
GO
/****** Object:  ForeignKey [FK_ArticleEventCategory_Category]    Script Date: 10/29/2010 09:55:07 ******/
ALTER TABLE [dbo].[ArticleEventCategory]  WITH CHECK ADD  CONSTRAINT [FK_ArticleEventCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[ArticleEventCategory] CHECK CONSTRAINT [FK_ArticleEventCategory_Category]
GO
/****** Object:  ForeignKey [FK_ArticleEventItem_Article]    Script Date: 10/29/2010 09:55:10 ******/
ALTER TABLE [dbo].[ArticleEventItem]  WITH CHECK ADD  CONSTRAINT [FK_ArticleEventItem_Article] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Article] ([Id])
GO
ALTER TABLE [dbo].[ArticleEventItem] CHECK CONSTRAINT [FK_ArticleEventItem_Article]
GO
/****** Object:  ForeignKey [FK_ArticleEventItem_ArticleEvent]    Script Date: 10/29/2010 09:55:10 ******/
ALTER TABLE [dbo].[ArticleEventItem]  WITH CHECK ADD  CONSTRAINT [FK_ArticleEventItem_ArticleEvent] FOREIGN KEY([ArticleEventId])
REFERENCES [dbo].[Article] ([Id])
GO
ALTER TABLE [dbo].[ArticleEventItem] CHECK CONSTRAINT [FK_ArticleEventItem_ArticleEvent]
GO
/****** Object:  ForeignKey [FK_ArticleMedia_Article]    Script Date: 10/29/2010 09:55:14 ******/
ALTER TABLE [dbo].[ArticleMedia]  WITH CHECK ADD  CONSTRAINT [FK_ArticleMedia_Article] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Article] ([Id])
GO
ALTER TABLE [dbo].[ArticleMedia] CHECK CONSTRAINT [FK_ArticleMedia_Article]
GO
/****** Object:  ForeignKey [FK_ArticleVersion_Article]    Script Date: 10/29/2010 09:55:26 ******/
ALTER TABLE [dbo].[ArticleVersion]  WITH CHECK ADD  CONSTRAINT [FK_ArticleVersion_Article] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Article] ([Id])
GO
ALTER TABLE [dbo].[ArticleVersion] CHECK CONSTRAINT [FK_ArticleVersion_Article]
GO
/****** Object:  ForeignKey [FK_ArticleVersion_ArticleContentType]    Script Date: 10/29/2010 09:55:27 ******/
ALTER TABLE [dbo].[ArticleVersion]  WITH CHECK ADD  CONSTRAINT [FK_ArticleVersion_ArticleContentType] FOREIGN KEY([ArticleContentTypeId])
REFERENCES [dbo].[ArticleContentType] ([Id])
GO
ALTER TABLE [dbo].[ArticleVersion] CHECK CONSTRAINT [FK_ArticleVersion_ArticleContentType]
GO
/****** Object:  ForeignKey [FK_ArticleVersion_ArticleType]    Script Date: 10/29/2010 09:55:27 ******/
ALTER TABLE [dbo].[ArticleVersion]  WITH CHECK ADD  CONSTRAINT [FK_ArticleVersion_ArticleType] FOREIGN KEY([ArticleTypeId])
REFERENCES [dbo].[ArticleType] ([Id])
GO
ALTER TABLE [dbo].[ArticleVersion] CHECK CONSTRAINT [FK_ArticleVersion_ArticleType]
GO
/****** Object:  ForeignKey [FK_CategoryPolicy_Category]    Script Date: 10/29/2010 09:55:34 ******/
ALTER TABLE [dbo].[CategoryPolicy]  WITH CHECK ADD  CONSTRAINT [FK_CategoryPolicy_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[CategoryPolicy] CHECK CONSTRAINT [FK_CategoryPolicy_Category]
GO
/****** Object:  ForeignKey [FK_CategoryPolicy_Group]    Script Date: 10/29/2010 09:55:34 ******/
ALTER TABLE [dbo].[CategoryPolicy]  WITH CHECK ADD  CONSTRAINT [FK_CategoryPolicy_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[CategoryPolicy] CHECK CONSTRAINT [FK_CategoryPolicy_Group]
GO
