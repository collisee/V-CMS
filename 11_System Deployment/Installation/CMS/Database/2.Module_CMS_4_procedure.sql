/****** Object:  StoredProcedure [dbo].[OptimizeArticleEventCategory]    Script Date: 10/13/2010 09:02:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[OptimizeArticleEventCategory]
	-- Add the parameters for the stored procedure here
	@CategoryId int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--Create tempTable
	SELECT Rank() over (Partition BY [ArticleEventCategory].[CategoryId] order by [ArticleEventCategory].[Ord], [ArticleEventCategory].[Id]) AS [Rank]
		, [ArticleEventCategory].[Id] AS [tempId]
	INTO #tempTable
	FROM [ArticleEventCategory]
	LEFT JOIN [ArticleEvent]
	ON [ArticleEvent].[Id] = [ArticleEventCategory].[ArticleEventId]
	WHERE [ArticleEventCategory].[CategoryId] = @CategoryId
	AND [ArticleEvent].[Status] = N'Đã xuất bản'
	AND ISNULL([ArticleEventCategory].flag, '') = ''
	AND ISNULL([ArticleEvent].flag, '') = ''

	--Update order
	UPDATE [ArticleEventCategory]
	SET [Ord] = ISNULL((
		SELECT TOP 1 (CASE WHEN [Rank] <= 100 THEN [Rank] ELSE 101 END) AS [Rank] FROM #tempTable WHERE [tempId] = [ArticleEventCategory].[Id]
	), [ArticleEventCategory].[Ord])
	WHERE [CategoryId] = @CategoryId
	AND ISNULL(flag, '') = ''
END
GO
/****** Object:  StoredProcedure [dbo].[GetPolicyByUserIdAndCategoryAlias]    Script Date: 10/13/2010 09:02:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPolicyByUserIdAndCategoryAlias]
	-- Add the parameters for the stored procedure here
	@UserId int = 0, 
	@CategoryAlias nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [CategoryPolicy].*
	FROM [CategoryPolicy]
	LEFT JOIN [Category]
	ON [CategoryPolicy].[CategoryId] = [Category].[Id]
	LEFT JOIN [GroupMember]
	ON [CategoryPolicy].[GroupId] = [GroupMember].[GroupId]
	WHERE (ISNULL([GroupMember].[UserId], -1) = @UserId)
	AND (ISNULL([Category].[Alias], '') = @CategoryAlias)
	AND (ISNULL([CategoryPolicy].flag, '') = '')
	AND (ISNULL([Category].flag, '') = '')
	AND (ISNULL([GroupMember].flag, '') = '')
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryByUserId]    Script Date: 10/13/2010 09:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategoryByUserId]
	-- Add the parameters for the stored procedure here
	@UserId int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF (@UserId <= 0)
	BEGIN
		SELECT [Category].* FROM [Category]
		WHERE 0 = 1
	END
	ELSE
	BEGIN
		SELECT * FROM (
			SELECT [Category].*
				, [GroupMember].[GroupId] [GroupId]
				, Rank() over (PARTITION BY [Category].[Id] ORDER BY [Category].[PId], [Category].[Ord], [GroupMember].[GroupId]) AS [Rank]
			FROM [Category]
			LEFT JOIN [CategoryPolicy]
			On [CategoryPolicy].[CategoryId] = [Category].[Id]
			LEFT JOIN [GroupMember]
			On [CategoryPolicy].[GroupId] = [GroupMember].[GroupId]
			WHERE (ISNULL([GroupMember].[UserId], -1) = @UserId)
			AND ([CategoryPolicy].[Val] = 1)
			AND (ISNULL([Category].flag, '') = '')
			AND (ISNULL([CategoryPolicy].flag, '') = '')
			AND (ISNULL([GroupMember].flag, '') = '')
		) [Category] WHERE [Rank] = 1
		ORDER BY [PId], [Ord], [Id]
	END
END
GO
/****** Object:  StoredProcedure [dbo].[OptimizeCategory]    Script Date: 10/13/2010 09:02:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[OptimizeCategory]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--Create tempTable
	SELECT Rank() over (Partition BY [PId] order by [Ord], [Id]) AS [Rank]
		, [Id] AS [tempId]
	INTO #tempTable
	FROM [Category]
	WHERE ISNULL(flag, '') = ''

	--Update order
	UPDATE [Category]
	SET [Ord] = ISNULL((
		SELECT TOP 1 [Rank] FROM #tempTable WHERE [tempId] = [Category].[Id]
	), 0)
	WHERE ISNULL(flag, '') = ''
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategoryPIdAndOrder]    Script Date: 10/13/2010 09:02:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[UpdateCategoryPIdAndOrder]
	-- Add the parameters for the stored procedure here
	@Id int = 0,
	@PId int = 0,
	@Ord int = 0,
	@Last_Modified_At datetime,
	@Last_Modified_By int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- STEP 1: Start the transaction
	BEGIN TRANSACTION

    -- Insert statements for procedure here
	-- Update other order
	UPDATE [Category]
	SET [Ord] = [Ord] + 1
	WHERE ISNULL([PId], 0) = ISNULL(@PId, 0)
	AND [Ord] >= @Ord
	AND ISNULL(flag, '') = ''

	-- Rollback the transaction if there were any errors
	IF @@ERROR <> 0
	 BEGIN
		-- Rollback the transaction
		ROLLBACK

		-- Raise an error and return
		RAISERROR ('Error in updating Category step 1.', 16, 1)
		RETURN
	 END

	--Update Category
	UPDATE [Category]
	SET [PId] = @PId
		, [Ord] = @Ord
		, [Last_Modified_At] = @Last_Modified_At
		, [Last_Modified_By] = @Last_Modified_By
	WHERE [Id] = @Id
	AND ISNULL(flag, '') = ''

	-- Rollback the transaction if there were any errors
	IF @@ERROR <> 0
	 BEGIN
		-- Rollback the transaction
		ROLLBACK

		-- Raise an error and return
		RAISERROR ('Error in updating Category step 2.', 16, 1)
		RETURN
	 END

	-- STEP 4: If we reach this point, the commands completed successfully
	--         Commit the transaction....
	COMMIT

END
GO
/****** Object:  StoredProcedure [dbo].[GetPolicyByUserIdAndCategoryId]    Script Date: 10/13/2010 09:02:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPolicyByUserIdAndCategoryId]
	-- Add the parameters for the stored procedure here
	@UserId int = 0, 
	@CategoryId int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [CategoryPolicy].*
	FROM [CategoryPolicy]
	LEFT JOIN [GroupMember]
	ON [CategoryPolicy].[GroupId] = [GroupMember].[GroupId]
	WHERE (ISNULL([GroupMember].[UserId], -1) = @UserId)
	AND (ISNULL([CategoryPolicy].[CategoryId], -1) = @CategoryId)
	AND (ISNULL([CategoryPolicy].flag, '') = '')
	AND (ISNULL([GroupMember].flag, '') = '')
	
END
GO
/****** Object:  StoredProcedure [dbo].[OptimizeArticleCategory]    Script Date: 10/13/2010 09:02:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[OptimizeArticleCategory]
	-- Add the parameters for the stored procedure here
	@CategoryId int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @PartitionId int
	SELECT @PartitionId = [PartitionId] 
	FROM [Category] 
	WHERE [Id] = @CategoryId

	--Create tempTable
	SELECT Rank() over (Partition BY [ArticleCategory].[CategoryId] order by [ArticleCategory].[Ord], [ArticleCategory].[Id]) AS [Rank]
		, [ArticleCategory].[Id] AS [tempId]
	INTO #tempTable
	FROM [ArticleCategory]
	LEFT JOIN [Article]
	ON [Article].[Id] = [ArticleCategory].[ArticleId]
	WHERE [ArticleCategory].[PartitionId] = @PartitionId
	AND [ArticleCategory].[CategoryId] = @CategoryId
	AND [Article].[Status] = N'Đã xuất bản'
	AND ISNULL([ArticleCategory].flag, '') = ''
	AND ISNULL([Article].flag, '') = ''

	--Update order
	UPDATE [ArticleCategory]
	SET [Ord] = ISNULL((
		SELECT TOP 1 (CASE WHEN [Rank] <= 100 THEN [Rank] ELSE 101 END) AS [Rank] FROM #tempTable WHERE [tempId] = [ArticleCategory].[Id]
	), [ArticleCategory].[Ord])
	WHERE [PartitionId] = @PartitionId
	AND [CategoryId] = @CategoryId
	AND ISNULL(flag, '') = ''
END
GO
