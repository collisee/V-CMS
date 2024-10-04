-- =============================================
-- Author:		SonDN
-- Create date:   2010/10/29
-- Description:	Tao StoredProcedure trong module Royalty
-- ============================================= 
/****** Object:  Stored Procedure Royalty_ListByArticle    Script Date: Friday, February 15, 2008 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'Royalty_ListByArticle') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure Royalty_ListByArticle
GO
CREATE PROCEDURE Royalty_ListByArticle
 @Article_Id int
AS

Select	a.[Name],a.PublishDate,	a.Status,
		r.*
		
From [RoyaltyFund] r
		inner join Article a on a.Id=r.Article_id

Where	(ISNULL(r.flag, '') = '') 
		and r.Article_Id=@Article_Id

GO

--Royalty_ListByArticle 133

/****** Object:  Stored Procedure Royalty_ListByArticle    Script Date: Friday, February 15, 2008 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'Royalty_FundListByArticle') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure Royalty_FundListByArticle
GO
CREATE PROCEDURE Royalty_FundListByArticle
 @Article_Id int
AS

Select	Case When r.Author_IsMember = 1 Then u.[FullName] Else c.[Name] end Author_Name,
		(r.Text_Fund + r.Image_Fund + r.Audio_Fund + r.Video_Fund + r.Other_Fund) as TotalFund ,
		us.[FullName] Setter_Name,
		t.Title Type_Title,
		r.*		 
From [RoyaltyFund] r
		--[User] u, [Collaborator] c
		left join [User] u on u.Id=r.Author_Id
		left join [Collaborator] c on c.Id=r.Author_Id
		left join [User] us on us.Id=r.Setter_id

		left join RoyaltyTypes t on t.Type_Id= r.Type_Id
Where	(ISNULL(r.flag, '') = '') 
		and r.Article_Id=@Article_Id
		
		--and (u.Id=r.Article_id)

GO

--Royalty_FundListByArticle 127



/* Reports */
/****** Object:  Stored Procedure Royalty_ListByArticle    Script Date: Friday, February 15, 2008 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'Royalty_Reports21b') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure Royalty_Reports21b
GO
CREATE PROCEDURE Royalty_Reports21b
	@UserId int,
	@DateFrom datetime,
	@DateTo datetime
AS

Select	
		Case When r.Author_IsMember = 1 Then N'Phóng viên' else  N'Cộng tác viên' end  Author_Group,
		Case When r.Author_IsMember = 1 Then u.[FullName] Else c.[Name] end Author_Name,
		Case When r.Author_IsMember = 1 Then u.[Detail] Else '' end ID_NS,
		a.[Name] as [Name], 
		a.[URL] as URL,a.PublishDate, a.NumberOfVisited,
		(r.Text_Fund + r.Image_Fund + r.Audio_Fund + r.Video_Fund + r.Other_Fund) as TotalFund ,
		us.[FullName] Setter_Name,
		t.Title Type_Title,
		r.*		 
From  [RoyaltyFund] r	
		--[User] u, [Collaborator] c
		left join [User] u on u.Id=r.Author_Id
		left join [Collaborator] c on c.Id=r.Author_Id
		left join [User] us on us.Id=r.Setter_id

		left join RoyaltyTypes t on t.Type_Id= r.Type_Id
		left join 
				(
					select ar.Id, ar.Name, ar.URL, ar.PublishDate, count(track.Id) NumberOfVisited from Article ar
					left join VietNamNet_V1_tracker.dbo.Tracking_Articles track
					on ar.Id=track.ArticleId
					group by ar.Id, ar.Name, ar.URL, ar.PublishDate 
				) a 		
				on a.Id= r.Article_Id 

Where	(ISNULL(r.flag, '') = '')   
		AND r.Created_At between @DateFrom and @DateTo
		AND ((Author_Id=@UserId AND Author_IsMember=1) OR @UserId=0)
GO

 

-- Royalty_Reports21b '2010-08-08','2010-09-13' 

/****** Object:  Stored Procedure Royalty_ListByArticle    Script Date: Friday, February 15, 2008 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'Royalty_Reports21a') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure Royalty_Reports21a
GO
CREATE PROCEDURE Royalty_Reports21a
	@IsMember int,
	@UserId int,
	@DateFrom datetime,
	@DateTo datetime
AS

Select	 
		cat.Alias, cat.DisplayName,
		Case When a.IsMember = 1 Then N'Phóng viên' else  N'Cộng tác viên' end  AuthorGroup,
		a.AuthorId,
		Case When a.IsMember = 1 Then u.[FullName] Else c.[Name] end AuthorName,
		Case When a.IsMember = 1 Then u.[Detail] Else '' end ID_NS,
		
			
		SetterName, at.[Name] TypeName ,r.*,
		(r.Text_Fund + r.Image_Fund + r.Audio_Fund + r.Video_Fund + r.Other_Fund) as TotalFund ,
		a.*
From Article a
		left join [User] u on u.Id=a.AuthorId
		left join [Collaborator] c on c.Id=a.AuthorId
		left join dbo.Category cat on cat.Id=a.CategoryId
		left join dbo.ArticleType at on at.Id=a.ArticleTypeId
		left join 
				(select f.*, t.Title, us.[FullName] SetterName from [RoyaltyFund] f 
					left join RoyaltyTypes t on t.Type_Id= f.Type_Id 
					left join [User] us on us.Id=f.Setter_Id
					where (ISNULL(f.flag, '') = '') and (ISNULL(t.flag, '') = '')  ) r
				on r.Article_Id=a.Id
				 
		/*--	[RoyaltyFund] r
		
		

		left join RoyaltyTypes t on t.Type_Id= r.Type_Id
		left join Article a on a.Id= r.Article_Id
*/
Where	(ISNULL(a.flag, '') = '') 
		--AND CategoryId in (select * from fn_GetCategoriesByUserId(@UserId))
		AND a.PublishDate between @DateFrom and @DateTo
		AND AuthorID<>0
		
		AND (a.IsMember = @IsMember OR @IsMember = -1 )
		
		AND (a.AuthorId = @UserId OR @UserId = 0 OR @IsMember = -1 OR @IsMember =0) 
GO

--  Royalty_Reports21a 1,10,'2010-08-09','2010-11-16'




