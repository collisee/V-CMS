-- =============================================
-- Author:		SonDN
-- Create date:   2010/10/29
-- Description:	Deploy on Master db - sync to Slave
-- =============================================

CREATE TABLE [dbo].[Tracking_ArticlesTopRead](
	[Id] [int] IDENTITY(1,1) NOT NULL, 
	[ArticleId] [int] NULL,
	[CategoryAlias] [nvarchar](255)  NULL,
	[TotalView] [int]  NULL  DEFAULT 0,
	[CreatedOn] [datetime] NULL CONSTRAINT [DF_Tracking_ArticlesTopRead_CreatedOn]  DEFAULT (getdate()), 
 CONSTRAINT [PK_Tracking_ArticlesTopRead] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [Article]
) ON [Article]

-- =============================================
-- Author:		AnhDT
-- Create date:   2010/11/04
-- Description:	Deploy on Master db - sync to Slave
-- =============================================

CREATE TABLE [dbo].[Tracking_ArticlesTopComment](
	[Id] [int] IDENTITY(1,1) NOT NULL, 
	[ArticleId] [int] NULL,
	[TotalComment] [int]  NULL  DEFAULT 0,
	[Created_At] [datetime] NULL CONSTRAINT [DF_Tracking_ArticlesTopComment_Created_At]  DEFAULT (getdate()), 
 CONSTRAINT [PK_Tracking_ArticlesTopComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [Article]
) ON [Article]
