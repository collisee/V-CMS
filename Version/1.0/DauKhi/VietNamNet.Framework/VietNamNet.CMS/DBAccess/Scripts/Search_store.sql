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
		AND DATEDIFF(DD, [Article].[PublishDate], getdate()) <= 0  
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
		AND DATEDIFF(DD, [Article].[PublishDate], getdate()) <= 0  
		 AND ISNULL([Article].flag, '') = ''
	
) 


SELECT COUNT(*) FROM tArticle   

GO
 