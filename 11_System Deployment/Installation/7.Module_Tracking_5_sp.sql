-- =============================================
-- Author:		SonDN
-- Create date:   2010/10/29
-- Description:	
-- =============================================


/* SP will be excute every 15 minutes - deploy on Master DB */
if exists (select * from dbo.sysobjects where id = object_id(N'Tracking_ArticlesTopRead_Update') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure Tracking_ArticlesTopRead_Update
GO
/****** Object:  StoredProcedure [dbo].[Tracking_ArticlesTopRead_Update]    Script Date: 11/12/2010 10:38:38 ******/
CREATE PROCEDURE [dbo].[Tracking_ArticlesTopRead_Update] 
	@Hour int
AS
declare @i int
set @i=1
while(	select   count(ArticleId)
					from VietNamNet_V1_tracker.dbo.Tracking_Articles
					where DATEDIFF(hh, ModifyOn, getdate()) <= (@Hour*@i) 
	) < 31   
	BEGIN
		set @i=@i+1
	END

	delete from Tracking_ArticlesTopRead

	insert Tracking_ArticlesTopRead (ArticleId, CategoryAlias, TotalView,CreatedOn) 
		select top 30 ArticleId, '', count(*) TotalView, max(ModifyOn)
		from VietNamNet_V1_tracker.dbo.Tracking_Articles
		where DATEDIFF(hh, ModifyOn, getdate()) <= (@Hour*@i)
		group by ArticleId
		order by TotalView DESC


GO

/* SP will be excute every 60 minutes */
if exists (select * from dbo.sysobjects where id = object_id(N'Tracking_ArticlesTotalView_Update') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure Tracking_ArticlesTotalView_Update
GO
CREATE PROCEDURE Tracking_ArticlesTotalView_Update
	@Date datetime
AS
BEGIN
	-- Cập nhật số lượng View theo ngày
	-- Select trong bảng Traking, sử dụng fetch để update cho từng article
	UPDATE Article 
	SET TotalView = TotalView + XXXX
END
GO

/* AnhDT add for top comment */
/* SP will excute every 1 day */
CREATE PROCEDURE [dbo].[Tracking_ArticlesTopComment_Update] 
	@Day datetime
AS

Begin

IF (EXISTS(
	SELECT TOP 10 [ArticleId], COUNT(*) [TotalComment]
	FROM [ArticleComment]
	WHERE DATEDIFF(dd, [Created_At], getdate()) <= @Day
	AND Status = N'Đã xuất bản'
	AND ISNULL(flag, '') = ''
	GROUP BY [ArticleId]
	))
BEGIN
	DELETE FROM [Tracking_ArticlesTopComment]

	INSERT INTO [Tracking_ArticlesTopComment]
		([ArticleId], [TotalComment])
	SELECT TOP 10 [ArticleId], COUNT(*) [TotalComment]
	FROM [ArticleComment]
	WHERE DATEDIFF(dd, [Created_At], getdate()) <= @Day
	AND Status = N'Đã xuất bản'
	AND ISNULL(flag, '') = ''
	GROUP BY [ArticleId]
	ORDER BY [TotalComment] DESC
END
End