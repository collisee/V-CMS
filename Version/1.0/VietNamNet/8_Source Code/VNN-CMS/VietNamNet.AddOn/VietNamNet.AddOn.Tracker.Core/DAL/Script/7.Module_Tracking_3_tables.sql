-- =============================================
-- Author:		SonDN
-- Create date:   2010/11/08
-- Description:	Deploy on Tracking db server
-- =============================================

/* Tracking Articles */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tracking_Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IPAddress] [nvarchar](20) NOT NULL CONSTRAINT [DF_Tracking_Articles_IPAddress]  DEFAULT (N'0.0.0.0'),
	[NationId] [int] NULL CONSTRAINT [DF_Tracking_Articles_NationId]  DEFAULT ((0)),
	[ProvinceId] [int] NULL CONSTRAINT [DF_Tracking_Articles_ProvinceId]  DEFAULT ((0)),
	[ISPId] [int] NULL CONSTRAINT [DF_Tracking_Articles_ISPId]  DEFAULT ((0)),
	[ArticleId] [int] NOT NULL,
	[CategoryAlias] [nvarchar](255) NOT NULL,
	[CreatedOn] [datetime] NULL CONSTRAINT [DF_Tracking_Articles_CreatedOn]  DEFAULT (getdate()),
	[ModifyOn] [datetime] NULL CONSTRAINT [DF_Tracking_Articles_ModifyOn]  DEFAULT (getdate()),
 CONSTRAINT [PK_Tracking_Articles] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [TrackingPartitionScheme]([ModifyOn])
GO





/* Tracking Survey */
USE [master]
GO
ALTER DATABASE [VietNamNet_Tracking] ADD FILEGROUP [Survey]
GO
ALTER DATABASE [VietNamNet_Tracking] ADD FILE ( NAME = N'Tracking_Survey_01', FILENAME = N'D:\Databases\VietNamNet_Tracking\Tracking_Survey_01.ndf' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Survey]
GO
ALTER DATABASE [VietNamNet_Tracking] ADD FILE ( NAME = N'Tracking_Survey_02', FILENAME = N'D:\Databases\VietNamNet_Tracking\Tracking_Survey_02.ndf' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Survey]
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tracking_SurveyResults]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tracking_SurveyResults](
	[SurveyResultId] [int] IDENTITY(1,1) NOT NULL,
	[SurveyOptionId] [int] NOT NULL,
	[Notes] [nvarchar](500) NULL DEFAULT ((0)),
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL CONSTRAINT [DF_Tracking_SurveyResults_CreatedOn]  DEFAULT (getdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiOn] [datetime] NULL CONSTRAINT [DF_Tracking_SurveyResults_ModifiOn]  DEFAULT (getdate()),
	[IsDeleted] [bit] NULL DEFAULT ((0)),
	[IsActive] [bit] NULL DEFAULT ((1)),
 CONSTRAINT [PK_Tracking_SurveyResults] PRIMARY KEY CLUSTERED 
(
	[SurveyResultId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [Survey]
) ON [Survey]
END

/* Use for thethao.vietnamnet.vn */
ALTER TABLE [Tracking_SurveyResults]
	ADD [userName]  nvarchar(100)
GO

ALTER TABLE [Tracking_SurveyResults]
	ADD [userIdentityCard]  varchar(20)
GO

ALTER TABLE [Tracking_SurveyResults]
	ADD [userAddress] nvarchar(200)
GO 

ALTER TABLE [Tracking_SurveyResults]
	ADD [userEmail] varchar(100)
GO 
		 
 
 
 
 
 
 