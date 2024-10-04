-- =============================================
-- Author:		SonDN
-- Create date:   2010/08/05
-- Description:	
-- =============================================
 
/****** Object:  Stored Procedure SurveyOptions_ListTop    Script Date: Friday, February 15, 2008 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'SurveyOptions_ListBySurvey') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure SurveyOptions_ListBySurvey
GO
CREATE PROCEDURE SurveyOptions_ListBySurvey
 @SurveyId int
AS

SELECT
	 *
FROM	SurveyOptions  
WHERE IsDeleted=0
ORDER BY [ViewOrder] ASC

GO

-- SurveyOptions_ListBySurvey 1



/****** Object:  Stored Procedure SurveyOptions_ListTop    Script Date: Friday, February 15, 2008 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'SurveyResults_ListBySurvey') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure SurveyResults_ListBySurvey
GO
CREATE PROCEDURE SurveyResults_ListBySurvey
 @SurveyId int
AS

SELECT
	 *
FROM	dbo.SurveyResults
WHERE IsDeleted=0

GO

--SurveyResults_ListBySurvey 1


/****** Object:  Stored Procedure SurveyOptions_ListTop    Script Date: Friday, February 15, 2008 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'CatListBySurvey') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure CatListBySurvey
GO 
CREATE PROCEDURE  [CatListBySurvey]
 @SurveyId int
AS

SELECT
  *
FROM   dbo.SurveyPublishs sp,
  dbo.Category c
WHERE sp.IsDeleted=0
	and sp.CategoryId=c.Id
	and sp.SurveyId=@SurveyId
ORDER BY sp.ExpireDate DESC
GO 


--[CatListBySurvey] 14



if exists (select * from dbo.sysobjects where id = object_id(N'ArticleListBySurvey') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure ArticleListBySurvey
GO 
CREATE PROCEDURE  [ArticleListBySurvey]
 @SurveyId int
AS
SELECT
  *
FROM   dbo.SurveyPublishs sp,
  dbo.Article a
WHERE sp.IsDeleted=0
	and sp.ArticleId=a.Id
	and sp.SurveyId=@SurveyId
ORDER BY sp.ExpireDate DESC

GO 

--ArticleListBySurvey 1



/****** Object:  Stored Procedure SurveyOptions_ListTop    Script Date: Friday, February 15, 2008 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'Survey_ListByCat') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure Survey_ListByCat
GO
CREATE PROCEDURE Survey_ListByCat 
	@CategoryAlias NVarChar(255)
AS
DECLARE  @CatId int
set @CatId = (select top 1 Id from Category where Alias=@CategoryAlias AND ISNULL(flag, '') = '')


select * from Surveys
where SurveyId  in
				(
					SELECT DISTINCT
						 SurveyId
					FROM	SurveyPublishs
					WHERE IsDeleted=0 and status=1
						AND getdate() between StartDate and ExpireDate
						AND CategoryId=@CatId
				)
and IsDeleted=0 and status=1
order by SurveyId DESC

GO

--Survey_ListByCat 'xa-hoi'

 
 
if exists (select * from dbo.sysobjects where id = object_id(N'Survey_ListByArticle') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure Survey_ListByArticle
GO
CREATE PROCEDURE Survey_ListByArticle 
	@ArticleId int
AS

select * from Surveys
where SurveyId  in
				(
					SELECT DISTINCT
						 SurveyId
					FROM	SurveyPublishs
					WHERE IsDeleted=0 and status=1
						AND getdate() between StartDate and ExpireDate
						AND ArticleId=@ArticleId
				)
and IsDeleted=0 and status=1
GO 

--Survey_ListByArticle 21


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

CREATE PROCEDURE [dbo].[SurveyResultsGet]
 @SurveyId int
AS

SELECT SurveyId, SurveyOptionId, OptionName, SUM(Choice) Result
FROM
	(
	SELECT o.SurveyId,o.SurveyOptionId, o.OptionName, 
		CASE WHEN r.IsDeleted IS NULL THEN 0
		ELSE 1
		END AS CHoice
	FROM SurveyOptions o  
	left join dbo.SurveyResults r
	ON r.SurveyOptionId = o.SurveyOptionId
	WHERE o.IsDeleted=0 AND ISNULL(r.IsDeleted, 0)=0
		AND o.SurveyId = @SurveyId
) X
Group BY SurveyId,SurveyOptionId, OptionName
 
GO

 