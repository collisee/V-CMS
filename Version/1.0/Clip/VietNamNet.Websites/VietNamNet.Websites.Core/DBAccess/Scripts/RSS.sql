

if exists (select * from dbo.sysobjects where id = object_id(N'Layout_GetRSSHome') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure Layout_GetRSSHome
GO
CREATE PROCEDURE Layout_GetRSSHome
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

--Layout_GetRSSHome




if exists (select * from dbo.sysobjects where id = object_id(N'Layout_GetRSSByCategory') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure Layout_GetRSSByCategory
GO
CREATE PROCEDURE Layout_GetRSSByCategory
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
 
--Layout_GetRSSByCategory 'xa-hoi'