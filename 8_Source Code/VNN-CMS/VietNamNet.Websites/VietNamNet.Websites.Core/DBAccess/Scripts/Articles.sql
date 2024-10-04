if exists (select * from dbo.sysobjects where id = object_id(N'[Layout_GetArticleComment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [Layout_GetArticleComment]
GO

CREATE PROCEDURE [Layout_GetArticleComment]
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

[Layout_GetArticleComment] 41,1,10



ALTER PROCEDURE [dbo].[Layout_GetCategoryArticles] 
	
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