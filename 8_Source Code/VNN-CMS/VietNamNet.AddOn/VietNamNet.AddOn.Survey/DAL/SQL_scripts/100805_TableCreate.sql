-- =============================================
-- Author:		SonDN
-- Create date:   2010/09/29
-- Description:	Tao bang trong module Survey
-- =============================================

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Surveys]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Surveys](
	[SurveyId] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](500) NOT NULL,
	[Tags] [nvarchar](500) NULL,
	[OptionType] [char](1) NOT NULL,
	[Notes] [nvarchar](500) NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_Surveys_CreatedOn]  DEFAULT (getdate()),
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[ModifiOn] [datetime] NOT NULL CONSTRAINT [DF_Surveys_ModifiOn]  DEFAULT (getdate()),
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Status] [tinyint] NULL CONSTRAINT [DF_Surveys_Status]  DEFAULT ((0)),
 CONSTRAINT [PK_Surveys] PRIMARY KEY CLUSTERED 
(
	[SurveyId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [Survey]
) ON [Survey]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SurveyResults]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SurveyResults](
	[SurveyResultId] [int] IDENTITY(1,1) NOT NULL,
	[SurveyOptionId] [int] NOT NULL,
	[Notes] [nvarchar](500) NULL DEFAULT ((0)),
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL CONSTRAINT [DF_SurveyResults_CreatedOn]  DEFAULT (getdate()),
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiOn] [datetime] NULL CONSTRAINT [DF_SurveyResults_ModifiOn]  DEFAULT (getdate()),
	[IsDeleted] [bit] NULL DEFAULT ((0)),
	[IsActive] [bit] NULL DEFAULT ((1)),
 CONSTRAINT [PK_SurveyResults] PRIMARY KEY CLUSTERED 
(
	[SurveyResultId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [Survey]
) ON [Survey]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SurveyOptions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SurveyOptions](
	[SurveyOptionId] [int] IDENTITY(1,1) NOT NULL,
	[SurveyId] [int] NOT NULL,
	[OptionName] [nvarchar](500) NOT NULL,
	[ViewOrder] [int] NOT NULL,
	[Notes] [nvarchar](500) NULL CONSTRAINT [DF__SurveyOpt__Notes__08EA5793]  DEFAULT ((0)),
	[IsOther] [bit] NULL CONSTRAINT [DF_SurveyOptions_IsOther]  DEFAULT ((0)),
	[IsCorrect] [bit] NULL CONSTRAINT [DF__SurveyOpt__IsCor__09DE7BCC]  DEFAULT ((0)),
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_SurveyOptions_CreatedOn]  DEFAULT (getdate()),
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[ModifiOn] [datetime] NOT NULL CONSTRAINT [DF_SurveyOptions_ModifiOn]  DEFAULT (getdate()),
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF__SurveyOpt__IsDel__0CBAE877]  DEFAULT ((0)),
	[IsActive] [bit] NOT NULL CONSTRAINT [DF__SurveyOpt__IsAct__0DAF0CB0]  DEFAULT ((1)),
 CONSTRAINT [PK_SurveyOptions] PRIMARY KEY CLUSTERED 
(
	[SurveyOptionId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [Survey]
) ON [Survey]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SurveyPublishs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SurveyPublishs](
	[SurveyPublishId] [int] IDENTITY(1,1) NOT NULL,
	[SurveyId] [int] NOT NULL,
	[ArticleId] [int] NULL,
	[CategoryId] [int] NULL,
	[StartDate] [datetime] NOT NULL CONSTRAINT [DF__SurveysPu__Start__2F10007B]  DEFAULT (getdate()),
	[ExpireDate] [datetime] NOT NULL,
	[Security] [tinyint] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_SurveysPublish_CreatedOn]  DEFAULT (getdate()),
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[ModifiOn] [datetime] NOT NULL CONSTRAINT [DF_SurveysPublish_ModifiOn]  DEFAULT (getdate()),
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF__SurveysPu__IsDel__31EC6D26]  DEFAULT ((0)),
	[IsActive] [bit] NOT NULL CONSTRAINT [DF__SurveysPu__IsAct__32E0915F]  DEFAULT ((1)),
	[Status] [tinyint] NOT NULL CONSTRAINT [DF_SurveysPublish_Status]  DEFAULT ((0)),
 CONSTRAINT [PK_SurveysPublish] PRIMARY KEY CLUSTERED 
(
	[SurveyPublishId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [Survey]
) ON [Survey]
END
GO 


IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Surveys_OptionsResults]') AND parent_object_id = OBJECT_ID(N'[dbo].[SurveyResults]'))
ALTER TABLE [dbo].[SurveyResults]  WITH CHECK ADD  CONSTRAINT [FK_Surveys_OptionsResults] FOREIGN KEY([SurveyOptionId])
REFERENCES [dbo].[SurveyOptions] ([SurveyOptionId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Surveys_SurveyOptions]') AND parent_object_id = OBJECT_ID(N'[dbo].[SurveyOptions]'))
ALTER TABLE [dbo].[SurveyOptions]  WITH CHECK ADD  CONSTRAINT [FK_Surveys_SurveyOptions] FOREIGN KEY([SurveyId])
REFERENCES [dbo].[Surveys] ([SurveyId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Surveys_SurveysPublish]') AND parent_object_id = OBJECT_ID(N'[dbo].[SurveyPublishs]'))
ALTER TABLE [dbo].[SurveyPublishs]  WITH CHECK ADD  CONSTRAINT [FK_Surveys_SurveysPublish] FOREIGN KEY([SurveyId])
REFERENCES [dbo].[Surveys] ([SurveyId])
