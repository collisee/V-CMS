/****** Object:  Table [dbo].[Tracking_Articles]    Script Date: 11/04/2010 09:14:22 ******/
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
