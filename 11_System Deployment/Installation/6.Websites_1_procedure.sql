/****** Object:  StoredProcedure [dbo].[Layout_GetCategoryByAlias]    Script Date: 09/29/2010 10:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetCategoryByAlias] 
		@CategoryAlias nvarchar(255)
AS
BEGIN
	SELECT [Id] [CategoryId] 
       , [Name] [CategoryName] 
       , [DisplayName] [CategoryDisplayName] 
       , [Url] [CategoryUrl] 
       , [PartitionId] [PartitionId] 
       FROM [Category] 
  WHERE [Alias] = @CategoryAlias AND (ISNULL(flag, '') = '')
END
GO
/****** Object:  StoredProcedure [dbo].[Layout_GetSubCategory]    Script Date: 09/29/2010 10:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetSubCategory] 
	@CategoryAlias nvarchar(255)
AS

begin

	SELECT [Id] [CategoryId] 
 , [Name] [CategoryName] 
       , [DisplayName] [CategoryDisplayName] 
       , [PartitionId] [PartitionId] 
       FROM [Category] 
       WHERE Pid = (SELECT [Id] FROM [Category] WHERE 
       [Alias] = @CategoryAlias) AND (ISNULL(flag, '') = '')
	
end
GO
/****** Object:  StoredProcedure [dbo].[Layout_GetPrimaryCategory]    Script Date: 09/29/2010 10:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetPrimaryCategory]
	
	(
	@ArticleId	int
	)
	
AS

Begin

	SELECT TOP 1 [Category].* 
    FROM [Category] 
    LEFT JOIN [ArticleCategory] 
    ON [Category].[PartitionId] = [ArticleCategory].[PartitionId] AND [Category].[Id] = [ArticleCategory].[CategoryId] 
    WHERE [ArticleCategory].[ArticleId] = @ArticleId 
    AND (ISNULL([ArticleCategory].flag, '') = '')
    AND (ISNULL([Category].flag, '') = '')
    ORDER BY [ArticleCategory].[PrimaryCategory] DESC, [ArticleCategory].[Id] DESC

End
GO
/****** Object:  StoredProcedure [dbo].[Layout_GetCategoryArticlesMore]    Script Date: 09/29/2010 10:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetCategoryArticlesMore] 
	
	(
	@PartitionId	int,
	@CategoryId	int,
	@ArticleId	int,
	@FirstIndexRecord	int,
	@LastIndexRecord	int
	)
	
AS

Begin
	
	SELECT * FROM (	
                 SELECT [Article].*, row_number() over(order by [ArticleCategory].[Ord], [Article].[Id] DESC) RowNum  
                 FROM [ArticleCategory] 
                 LEFT JOIN [Article] 
                 ON [Article].[Id] = [ArticleCategory].[ArticleId] 
                 WHERE [ArticleCategory].[PartitionId] = @PartitionId 
                 AND [Article].[Status] = N'Đã xuất bản' 
                 AND (DATEDIFF(ss, [Article].[PublishDate], GETDATE()) >= 0) 
                 AND [ArticleCategory].[CategoryId] = @CategoryId 
                 AND [ArticleCategory].[ArticleId] <> @ArticleId 
                 AND [ArticleCategory].[Ord] >= ( 
                 SELECT MAX([Ord]) FROM [ArticleCategory]
                 WHERE [ArticleCategory].[PartitionId] = @PartitionId 
                 AND [ArticleCategory].[CategoryId] = @CategoryId 
                 AND [ArticleCategory].[ArticleId] = @ArticleId 
                 ) 
                 AND (ISNULL([ArticleCategory].flag, '') = '')
                 AND (ISNULL([Article].flag, '') = '')
                 ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord

End
GO
/****** Object:  StoredProcedure [dbo].[Layout_GetTopMedia]    Script Date: 09/29/2010 10:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetTopMedia] 
	
	(
	@PartitionId	int,
	@CategoryId	int,
	@FirstIndexRecord	int,
	@LastIndexRecord	int,
	@MediaType	nvarchar(255)
	)
	
AS

Begin

	SELECT * FROM ( 
                       SELECT row_number() over(order by [ArticleCategory].[Ord], [Article].[Id] DESC, [ArticleMedia].[Ord]) RowNum  
                           , [Article].[Author]  [author] 
                           , '' [link] 
                           , [ArticleMedia].[FileLink] [file] 
                           , [ArticleMedia].[Thumbnail] [image] 
                           , [ArticleMedia].[Detail] [description] 
                           , [Article].[Name] [title]         
                            FROM [ArticleCategory] 
                            LEFT JOIN [Article] 
                            ON [Article].[Id] = [ArticleCategory].[ArticleId] 
                            LEFT JOIN [ArticleMedia] 
                            ON [ArticleMedia].[ArticleId] = [ArticleCategory].[ArticleId] 
                            WHERE [ArticleCategory].[PartitionId] = @PartitionId 
                            AND [Article].[Status] = N'Đã xuất bản' 
                            AND (DATEDIFF(ss, [Article].[PublishDate], GETDATE()) >= 0) 
                            AND [ArticleCategory].[CategoryId] = @CategoryId 
                            AND (ISNULL(@MediaType, '') = '' OR [ArticleMedia].[MediaType] = @MediaType) 
                            AND (ISNULL([ArticleMedia].flag, '') = '')
                            AND (ISNULL([ArticleCategory].flag, '') = '')
                            AND (ISNULL([Article].flag, '') = '')
                        ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord

End
GO
/****** Object:  StoredProcedure [dbo].[Layout_GetCategoryArticleNumber]    Script Date: 09/29/2010 10:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetCategoryArticleNumber] 
	
	(
	@PartitionId int ,
	@CategoryId int
	)
	
AS
	
Begin

	SELECT COUNT(*) 
                  FROM [ArticleCategory]
                  LEFT JOIN [Article]
                  ON [Article].[Id] = [ArticleCategory].[ArticleId]
                  WHERE [ArticleCategory].[PartitionId] = @PartitionId
                  AND [Article].[Status] = N'Đã xuất bản'
                  AND (DATEDIFF(ss, [Article].[PublishDate], GETDATE()) >= 0)
                  AND [ArticleCategory].[CategoryId] = @CategoryId
                  AND (ISNULL([ArticleCategory].flag, '') = '')
                  AND (ISNULL([Article].flag, '') = '')
End
GO
/****** Object:  StoredProcedure [dbo].[Layout_GetCategoryArticles]    Script Date: 09/29/2010 10:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetCategoryArticles] 
	
	(
	@PartitionId	int,	
	@CategoryId	int,
	@FirstIndexRecord	int,
	@LastIndexRecord	int
	)
	
AS

Begin
	SELECT * FROM (
                            SELECT [Article].*, row_number() over(order by [ArticleCategory].[Ord], [Article].[Id] DESC) RowNum  
                            FROM [ArticleCategory] 
                            LEFT JOIN [Article] 
                            ON [Article].[Id] = [ArticleCategory].[ArticleId] 
                            WHERE [ArticleCategory].[PartitionId] = @PartitionId
                            AND [Article].[Status] = N'Đã xuất bản' 
                            AND (DATEDIFF(ss, [Article].[PublishDate], GETDATE()) >= 0) 
                            AND [ArticleCategory].[CategoryId] = @CategoryId 
                            AND (ISNULL([ArticleCategory].flag, '') = '')
                            AND (ISNULL([Article].flag, '') = '')
                            ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord
End
GO
/****** Object:  StoredProcedure [dbo].[Layout_GetArticleByStatusAndId]    Script Date: 09/29/2010 10:51:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetArticleByStatusAndId] 
	@Status nvarchar(255),
	@ArticleId	int
AS
	
Begin

	SELECT [Id]  id
			, [Name] title
			, [Lead] lead
			, [Detail] [content]
			, [ImageLink] img
			, [Created_At] date
			, [SubTitle6] link
			, [SubTitle5] source
           FROM [Article] 
           WHERE [Id] = @ArticleId 
           AND [Article].[Status] = @Status
           AND (DATEDIFF(ss, [Article].[PublishDate], GETDATE()) >= 0) 
           AND (ISNULL(flag, '') = '')

End
GO
/****** Object:  StoredProcedure [dbo].[Layout_GetArticleVNNId]    Script Date: 09/29/2010 10:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetArticleVNNId] 
	@ArticleId	int
AS

Begin

	SELECT * 
           FROM [Article]
           WHERE [SubTitle1] = CONVERT(nvarchar(255), @ArticleId)

End
GO
/****** Object:  StoredProcedure [dbo].[Layout_GetArticleByStatus]    Script Date: 09/29/2010 10:51:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetArticleByStatus] 
	@Status nvarchar(255),
	@FirstIndexRecord	int,
	@LastIndexRecord	int
AS
	
Begin

	SELECT * FROM (
		SELECT [Id]  id
			, [Name] title
			, [Lead] lead
			, [ImageLink] img
			, [Created_At] date
			, [SubTitle6] link
			, [SubTitle5] source
			, row_number() over(order by [Id] DESC) RowNum  
           FROM [Article] 
           WHERE [Article].[Status] = @Status
           AND (DATEDIFF(ss, [Article].[PublishDate], GETDATE()) >= 0) 
           AND (ISNULL(flag, '') = '')
        ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord

End
GO
/****** Object:  StoredProcedure [dbo].[Layout_GetSearchArticles]    Script Date: 09/29/2010 10:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetSearchArticles] 
	
	(
	@Searchkeyword	nvarchar(255),
	@FirstIndexRecord	int,
	@LastIndexRecord	int
	)
	
AS

Begin

	SELECT * FROM ( 
                   SELECT *, row_number() over(order by [Article].[PublishDate] DESC) RowNum 
                    FROM [Article] 
                     WHERE [name] like @Searchkeyword 
                     AND [Article].[Status] = N'Đã xuất bản' 
                     AND (DATEDIFF(ss, [Article].[PublishDate], GETDATE()) >= 0) 
                     AND (ISNULL(flag, '') = '')
                  ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord

End
GO
/****** Object:  StoredProcedure [dbo].[Layout_GetArticle]    Script Date: 09/29/2010 10:51:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetArticle] 
	@ArticleId	int
AS
	
Begin

	SELECT *
           FROM [Article] 
           WHERE [Id] = @ArticleId 
           AND [Article].[Status] = N'Đã xuất bản' 
           AND (DATEDIFF(ss, [Article].[PublishDate], GETDATE()) >= 0) 
           AND (ISNULL(flag, '') = '')

End
GO
/****** Object:  StoredProcedure [dbo].[Layout_GetArticleMedia]    Script Date: 09/29/2010 10:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetArticleMedia]

	(
	@ArticleId	int,	
	@MediaType	nvarchar(255)
	)

AS

Begin

	SELECT [Article].[Author] [author] 
     , '' [link] 
     , [ArticleMedia].[FileLink] [file] 
     , [ArticleMedia].[Thumbnail] [image] 
     , [ArticleMedia].[Detail] [description] 
     , [Article].[Name] [title] 
     FROM [ArticleMedia] 
     LEFT JOIN [Article] 
     ON [Article].[Id] = [ArticleMedia].[ArticleId]
     WHERE [ArticleMedia].[ArticleId] = @ArticleId 
     AND (ISNULL(@MediaType, '') = '' OR [ArticleMedia].[MediaType] = @MediaType)
     AND (ISNULL([ArticleMedia].flag, '') = '')
     AND (ISNULL([Article].flag, '') = '')
     ORDER BY [ArticleMedia].[Ord], [ArticleMedia].[Id] DESC

End
GO
/****** Object:  StoredProcedure [dbo].[Layout_GetTopArticles]    Script Date: 09/29/2010 10:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetTopArticles] 

	(
	@FirstIndexRecord	int,	
	@LastIndexRecord	int
	)

AS

Begin

	SELECT * FROM ( 
    SELECT [Article].*, row_number() over(order by [PublishDate] DESC, [Article].[Id] DESC) RowNum
    FROM [Article]
    WHERE [Article].[Status] = N'Đã xuất bản'
    AND (DATEDIFF(ss, [Article].[PublishDate], GETDATE()) >= 0)
    AND (ISNULL([Article].flag, '') = '')
    ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord

End
GO
/****** Object:  StoredProcedure [dbo].[Layout_GetMostReadArticles]    Script Date: 09/29/2010 10:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetMostReadArticles] 
	
	(
	@FirstIndexRecord	int,
	@LastIndexRecord	int
	)
	
AS

Begin

	SELECT * FROM ( 
                  SELECT [Article].*, row_number() over(order by [Article].[TotalView] DESC) RowNum
                  FROM [Article]
                  WHERE [Article].[Status] = N'Đã xuất bản'
                  AND (DATEDIFF(ss, [Article].[PublishDate], GETDATE()) >= 0)
                  AND (ISNULL([Article].flag, '') = '')
                  ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord

End
GO
/****** Object:  StoredProcedure [dbo].[Layout_GetArticleByStatusAndCategoryId]    Script Date: 09/29/2010 10:51:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Layout_GetArticleByStatusAndCategoryId] 
	@Status nvarchar(255),
	@CategoryId int = 0,
	@FirstIndexRecord	int,
	@LastIndexRecord	int
AS
	
Begin

	SELECT * FROM (
		SELECT [Id]  id
			, [Name] title
			, [Lead] lead
			, [ImageLink] img
			, [Created_At] date
			, [SubTitle6] link
			, [SubTitle5] source
			, row_number() over(order by [Id] DESC) RowNum  
           FROM [Article] 
           WHERE [Article].[Status] = @Status
           AND [Article].[CategoryId] = @CategoryId
           AND (DATEDIFF(ss, [Article].[PublishDate], GETDATE()) >= 0) 
           AND (ISNULL(flag, '') = '')
        ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord

End
GO
/****** Object:  StoredProcedure [dbo].[Layout_GetArticleComment]    Script Date: 09/29/2010 10:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetArticleComment]
	(
	@ArticleId	int,
	@FirstIndexRecord	int,
	@LastIndexRecord	int
	)
AS  
	SELECT	pId, [Name],
			'' [Email], '' [Phone],
			[Subject], [Detail], 
			convert(varchar, [Last_Modified_At], 103) + ' ' + convert(varchar, [Last_Modified_At], 108) AS  [CreatedDate]
	FROM 
		(
          SELECT *
			, row_number() over(ORDER BY Created_At DESC) RowNum  
          FROM [ArticleComment] 
          WHERE [ArticleId] = @ArticleId
			AND [Status] = N'Đã xuất bản'
			AND (ISNULL(flag, '') = '')
          ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord

GO
/****** Object:  StoredProcedure [dbo].[Layout_GetRSSByCategory]    Script Date: 09/29/2010 11:11:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetRSSByCategory]
	@CategoryAlias nvarchar(255)
AS  
declare @CatId int
set @CatId = (select top 1 Id from dbo.Category where Alias=@CategoryAlias)
	SELECT TOP 10
			[Id]
		  ,[ArticleTypeId]
		  ,[ArticleContentTypeId]
		  ,[Name] as [Title] 
		  ,[Url] as Link
		  ,dbo.udf_StripHTML([Lead]) as [Description] 
		  ,[PublishDate] as PubDate
	FROM Article  
	WHERE Status=N'Đã xuất bản'  
		AND ISNULL([Article].flag, '') = ''
		And Id in (select ArticleId from dbo.ArticleCategory where  CategoryId = @CatId)
	ORDER BY [PublishDate] DESC
GO
/****** Object:  StoredProcedure [dbo].[Layout_GetRSSHome]    Script Date: 09/29/2010 11:11:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetRSSHome]
AS  
 
	SELECT TOP 30
			[Id]
		  ,[VersionId]
		  ,[Status]
		  ,[ArticleTypeId]
		  ,[ArticleContentTypeId]
		  ,[Name] as [Title] 
		  ,[Url] as Link
		  ,dbo.udf_StripHTML([Lead]) as [Description] 
		  ,[PublishDate] as PubDate
	FROM Article  
	WHERE Status=N'Đã xuất bản'  
		AND ISNULL([Article].flag, '') = ''
	ORDER BY [PublishDate] DESC
GO
CREATE FUNCTION [dbo].[udf_StripHTML]
(@HTMLText NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @Start INT
	DECLARE @End INT
	DECLARE @Length INT
	SET @Start = CHARINDEX('<',@HTMLText)
	SET @End = CHARINDEX('>',@HTMLText,CHARINDEX('<',@HTMLText))
	SET @Length = (@End - @Start) + 1
	WHILE @Start > 0
		AND @End > 0
		AND @Length > 0
	BEGIN
		SET @HTMLText = STUFF(@HTMLText,@Start,@Length,'')
		SET @Start = CHARINDEX('<',@HTMLText)
		SET @End = CHARINDEX('>',@HTMLText,CHARINDEX('<',@HTMLText))
		SET @Length = (@End - @Start) + 1
	END
	RETURN LTRIM(RTRIM(@HTMLText))
END
GO


/****** Object:  Stored Procedure SurveyOptions_ListTop    Script Date: Friday, February 15, 2008 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'SearchArticleByKeyword') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure SearchArticleByKeyword
GO
CREATE PROCEDURE SearchArticleByKeyword
	@KeyWords nvarchar(255),
	@FirstRow int =20,
	@LastRow int =1
AS  

WITH tArticle  AS ( 
	SELECT
	  [Id]
		  ,[VersionId]
		  ,[Status]
		  ,[ArticleTypeId]
		  ,[ArticleContentTypeId]
		  ,[Name]
		  ,[Title]
		  ,[Url]
		  ,[CategoryId]
		  ,[PartitionId]
		  ,[SubTitle1]
		  ,[SubTitle2]
		  ,[SubTitle3]
		  ,[SubTitle4]
		  ,[SubTitle5]
		  ,[SubTitle6]
		  ,[ImageLink]
		  ,[ImageLink1]
		  ,[ImageLink2]
		  ,[ImageLink3]
		  ,[ImageLink4]
		  ,[ImageLink5]
		  ,dbo.udf_StripHTML([Lead]) as [Lead]
		  ,dbo.udf_StripHTML([Detail]) as [Detail]
		  ,[PublishDate]
		  ,[Author]
		  ,[AuthorInfo]
		  ,[IsMember]
		  ,[TotalView]
		  ,[History]
		  ,[Created_At]
		  ,[Created_By]
		  ,[Last_Modified_At]
		  ,[Last_Modified_By]
		  ,[flag]
		  ,row_number() over(order by [Article].[Id] DESC) RowNum 
	FROM Article  
	WHERE Status=N'Đã xuất bản'
		AND (	[Name] like '%'+@KeyWords+'%'
			 OR [Lead] like '%'+@KeyWords+'%'
			 OR [Detail] like '%'+@KeyWords+'%'
			) 
		AND convert(int,[PublishDate])- convert(int,getdate()) <= 0  
		 AND ISNULL([Article].flag, '') = ''
	
) 


SELECT * FROM tArticle 
WHERE RowNum BETWEEN @FirstRow AND @LastRow
ORDER BY [Created_At] DESC

GO
 


/****** Object:  Stored Procedure SurveyOptions_ListTop    Script Date: Friday, February 15, 2008 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'SearchArticleByKeywordCount') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure SearchArticleByKeywordCount
GO
CREATE PROCEDURE SearchArticleByKeywordCount
	@KeyWords nvarchar(255) 
AS  

WITH tArticle  AS ( 
	SELECT
	  [Id]
		  ,[VersionId]
		  ,[Status]
		  ,[ArticleTypeId]
		  ,[ArticleContentTypeId]
		  ,[Name]
		  ,[Title]
		  ,[Url]
		  ,[CategoryId]
		  ,[PartitionId]
		  ,[SubTitle1]
		  ,[SubTitle2]
		  ,[SubTitle3]
		  ,[SubTitle4]
		  ,[SubTitle5]
		  ,[SubTitle6]
		  ,[ImageLink]
		  ,[ImageLink1]
		  ,[ImageLink2]
		  ,[ImageLink3]
		  ,[ImageLink4]
		  ,[ImageLink5]
		  ,dbo.udf_StripHTML([Lead]) as [Lead]
		  ,dbo.udf_StripHTML([Detail]) as [Detail]
		  ,[PublishDate]
		  ,[Author]
		  ,[AuthorInfo]
		  ,[IsMember]
		  ,[TotalView]
		  ,[History]
		  ,[Created_At]
		  ,[Created_By]
		  ,[Last_Modified_At]
		  ,[Last_Modified_By]
		  ,[flag]
		  ,row_number() over(order by [Article].[Id] DESC) RowNum 
	FROM Article  
	WHERE Status=N'Đã xuất bản'
		AND (	[Name] like '%'+@KeyWords+'%'
			 OR [Lead] like '%'+@KeyWords+'%'
			 OR [Detail] like '%'+@KeyWords+'%'
			) 
		AND convert(int,[PublishDate])- convert(int,getdate())  <= 0  
		 AND ISNULL([Article].flag, '') = ''
	
) 


SELECT COUNT(*) FROM tArticle   

GO
 

if exists (select * from dbo.sysobjects where id = object_id(N'SearchArticle') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure SearchArticle
GO
CREATE PROCEDURE SearchArticle
	@KeyWords nvarchar(255),
	@CategoryAlias nvarchar(255),
	@PublishDate nvarchar(8),
	@FirstIndexRecord int ,
	@LastIndexRecord int 
AS  

WITH tArticle  AS ( 
	SELECT
	  [Id]
		  ,[VersionId]
		  ,[Status]
		  ,[ArticleTypeId]
		  ,[ArticleContentTypeId]
		  ,[Name]
		  ,[Title]
		  ,[Url]
		  ,[CategoryId]
		  ,[PartitionId]
		  ,[ImageLink]
		  ,dbo.udf_StripHTML([Lead]) as [Lead] 
		  ,[PublishDate]
		  ,[Author]
		  ,[AuthorInfo]
		  ,[IsMember]
		  ,[TotalView]
		  ,[History]
		  ,[Created_At]
		  ,[Created_By]
		  ,[Last_Modified_At]
		  ,[Last_Modified_By]
		  ,[flag]
		  ,row_number() over(order by [Article].[Id] DESC) RowNum 
	FROM Article  
	WHERE Status=N'Đã xuất bản'
		AND (	[Name] like '%'+ISNULL(@KeyWords,'')+'%'
			 OR [Lead] like '%'+ISNULL(@KeyWords,'')+'%'
			) 
		AND URL like ISNULL(@CategoryAlias, '')+'%'
		AND convert(VARCHAR(8),publishDate,112) like ISNULL(@PublishDate,'')+'%'
		AND DATEDIFF(ss, GETDATE(), [Article].[PublishDate]) <= 0  
		AND ISNULL([Article].flag, '') = ''

) 


SELECT * FROM tArticle 
WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord
ORDER BY [Created_At] DESC
GO

/****** Object:  StoredProcedure [dbo].[Layout_GetArticlesTopRead]    Script Date: 11/05/2010 11:29:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetArticlesTopRead] 
	@FirstIndexRecord	int = 1,
	@LastIndexRecord	int = 10
AS

Begin
	SELECT * FROM (
		SELECT [Article].[Id]
		   , [Article].[Status]
		   , [Article].[PublishDate]
		   , [Article].[Name]
		   , [Article].[Title]
		   , [Article].[Author]
		   , [Article].[TotalView]
		   , [Article].[ArticleContentTypeId]
		   , [Article].[Url]
		   , row_number() over(order by [Tracking_ArticlesTopRead].[Id]) RowNum  
		FROM [Tracking_ArticlesTopRead]
		LEFT JOIN [Article]
		ON [Tracking_ArticlesTopRead].[ArticleId] = [Article].[Id]
		WHERE (ISNULL([Article].flag, '') = '')
	) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord
End
GO
/****** Object:  StoredProcedure [dbo].[Layout_GetArticlesTopComment]    Script Date: 11/05/2010 11:29:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Layout_GetArticlesTopComment] 
	@FirstIndexRecord	int = 1,
	@LastIndexRecord	int = 10
AS

Begin
	SELECT * FROM (
		SELECT [Article].[Id]
		   , [Article].[Status]
		   , [Article].[PublishDate]
		   , [Article].[Name]
		   , [Article].[Title]
		   , [Article].[Author]
		   , [Article].[TotalView]
		   , [Article].[ArticleContentTypeId]
		   , [Article].[Url]
		   , row_number() over(order by [Tracking_ArticlesTopComment].[Id]) RowNum  
		FROM [Tracking_ArticlesTopComment]
		LEFT JOIN [Article]
		ON [Tracking_ArticlesTopComment].[ArticleId] = [Article].[Id]
		WHERE (ISNULL([Article].flag, '') = '')
	) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord
End
GO
