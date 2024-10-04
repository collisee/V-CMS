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