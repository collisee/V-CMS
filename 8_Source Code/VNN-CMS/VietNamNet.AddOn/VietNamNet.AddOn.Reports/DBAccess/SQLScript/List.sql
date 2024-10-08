
/****** Object:  Stored Procedure Report_ReportByCat    Script Date: Friday, February 15, 2008 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'Report_ReportByCat') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure Report_ReportByCat
GO
CREATE PROCEDURE Report_ReportByCat
	@UserId int,
	@CategoryId int,
	@DateFrom datetime,
	@DateTo datetime
AS 
	select cat.Id CategoryId, cat.[Name],cat.Alias, cat.DisplayName, ISNULL(sum(acTotal), 0) as Total
	from dbo.Category cat
		left join  (select 
						CategoryId, count(*) acTotal
					from dbo.Article
					where (ISNULL(flag, '') = '')	
						and PublishDate between @DateFrom and @DateTo
						and Status=N'Đã xuất bản'
						and PartitionId IN (SELECT PartitionId FROM fn_getPartitionsByUserId(@UserId))
						and CategoryId IN (SELECT Id FROM fn_getCategoriesByUserId(@UserId))
					group by CategoryId
			) ac  on cat.Id=ac.CategoryId
	Where	(ISNULL(cat.flag, '') = '') 
			AND (CategoryId=@CategoryId or @CategoryId=0)
			AND CategoryId IN (SELECT Id FROM fn_getCategoriesByUserId(@UserId))	
	group by cat.Id,  cat.[Name],Alias,DisplayName
	order by cat.[Name]
 
GO

--Report_ReportByCat 10, 0,'2010-08-08','2010-09-13'


/****** Object:  Stored Procedure Report_ReportByCat    Script Date: Friday, February 15, 2008 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'Report_ReportByGroup') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure Report_ReportByGroup
GO
CREATE PROCEDURE Report_ReportByGroup
	@GroupId int, 
	@DateFrom datetime,
	@DateTo datetime
AS
	select 
		m.GroupId, m.GroupName,
		u.Id, u.Status, u.LoginName, u.Email, 	u.FullName,	
		u.Detail ID_NS,
		a.aTotal Total
	from [User] u
		left join 
			(select [Group].Id GroupId, [Name] GroupName, UserId from GroupMember,[Group] where [Group].Id=GroupMember.GroupId )
			m on m.UserId=u.Id
		left join 
			(select Created_By UserId, count(id) aTotal from Article 
					where  1=1 
						and PublishDate between @DateFrom and @DateTo
						and (ISNULL(flag, '') = '')
						and Status=N'Đã xuất bản'
					group by Created_By	) 
			a on a.UserId=u.Id
	where  (ISNULL(u.flag, '') = '')
		and (m.GroupId=@GroupId or @GroupId=0)

GO


--Report_ReportByGroup 0, '2010-06-01','2010-11-13'

