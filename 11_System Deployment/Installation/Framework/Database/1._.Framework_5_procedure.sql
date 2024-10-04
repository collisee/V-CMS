/****** Object:  StoredProcedure [dbo].[GetPolicyByUserIdAndModuleAlias]    Script Date: 07/11/2010 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPolicyByUserIdAndModuleAlias]
	-- Add the parameters for the stored procedure here
	@UserId int = 0, 
	@ModuleAlias nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Policy].*
	FROM [Policy]
	LEFT JOIN [Module]
	ON [Policy].[ModuleId] = [Module].[Id]
	LEFT JOIN [GroupMember]
	ON [Policy].[GroupId] = [GroupMember].[GroupId]
	WHERE (ISNULL([GroupMember].[UserId], -1) = @UserId)
	AND (ISNULL([Module].[Alias], '') = @ModuleAlias)
	AND (ISNULL([Policy].flag, '') = '')
	AND (ISNULL([Module].flag, '') = '')
	AND (ISNULL([GroupMember].flag, '') = '')
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetMenuByUserId]    Script Date: 07/11/2010 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMenuByUserId]
	-- Add the parameters for the stored procedure here
	@UserId int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF (@UserId <= 0)
	BEGIN
		SELECT [Menu].* FROM [Menu]
		WHERE 0 = 1
	END
	ELSE
	BEGIN
		SELECT * FROM (
			SELECT [Menu].*
				, [GroupMember].[GroupId] [GroupId]
				, Rank() over (PARTITION BY [Menu].[Id] ORDER BY [Menu].[PId], [Menu].[Ord], [GroupMember].[GroupId]) AS [Rank]
			FROM [Menu]
			LEFT JOIN [Policy]
			On [Policy].[ModuleId] = [Menu].[ModuleId]
			LEFT JOIN [GroupMember]
			On [Policy].[GroupId] = [GroupMember].[GroupId]
			WHERE (ISNULL([GroupMember].[UserId], -1) = @UserId)
			AND ([Menu].[Access] = 0 OR [Policy].[Val] & [Menu].[Access] > 0)
			AND (ISNULL([Menu].flag, '') = '')
			AND (ISNULL([Policy].flag, '') = '')
			AND (ISNULL([GroupMember].flag, '') = '')
			UNION ALL
				SELECT -1 [Id], NULL [PId], 0 [Ord]
				, N'Cá nhân' [Name], N'Cá nhân' [DisplayName]
				, '' [Link], 0 [ModuleId], 0 [Access]
				, getdate() [Created_At], 0 [Created_By], getdate() [Last_Modified_At], 0 [Last_Modified_By], NULL [flag]
				, 0 [GroupId]
				, 1 [Rank]
		) [Menu] WHERE [Rank] = 1
		ORDER BY [PId], [Ord], [Id]
	END
END
GO
/****** Object:  StoredProcedure [dbo].[OptimizeMenu]    Script Date: 07/11/2010 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[OptimizeMenu]
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
	FROM [Menu]
	WHERE ISNULL(flag, '') = ''

	--Update order
	UPDATE [Menu]
	SET [Ord] = ISNULL((
		SELECT TOP 1 [Rank] FROM #tempTable WHERE [tempId] = [Menu].[Id]
	), 0)
	WHERE ISNULL(flag, '') = ''
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateMenuPIdAndOrder]    Script Date: 07/11/2010 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[UpdateMenuPIdAndOrder]
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
	UPDATE [Menu]
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
		RAISERROR ('Error in updating menu step 1.', 16, 1)
		RETURN
	 END

	--Update menu
	UPDATE [Menu]
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
		RAISERROR ('Error in updating menu step 2.', 16, 1)
		RETURN
	 END

	-- STEP 4: If we reach this point, the commands completed successfully
	--         Commit the transaction....
	COMMIT

END
GO
/****** Object:  StoredProcedure [dbo].[SystemLogging]    Script Date: 07/11/2010 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SystemLogging]
	-- Add the parameters for the stored procedure here
	@Action nvarchar(255),
	@Detail nvarchar(4000)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
INSERT INTO [Logging]
           ([LogTime]
           ,[LogLevel]
           ,[IP]
           ,[UId]
           ,[UserFullName]
           ,[Action]
           ,[Detail]
           ,[Created_At]
           ,[Created_By]
           ,[Last_Modified_At]
           ,[Last_Modified_By])
     VALUES
           (getdate()
           ,4 -- level System
           ,N'0.0.0.0'
           ,1 -- System
           ,N'System'
           ,@Action
           ,@Detail
           ,getdate()
           ,0
           ,getdate()
           ,0)

END
GO
/****** Object:  StoredProcedure [dbo].[GetLogging]    Script Date: 07/11/2010 14:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[GetLogging]
	-- Add the parameters for the stored procedure here
	@LoggingFromDate datetime,
	@LoggingToDate datetime,
	@LogLevel int = 0,
	@LogUser int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM [Logging]
	WHERE DATEDIFF(day, [LogTime], @LoggingFromDate) <= 0
	AND DATEDIFF(day, [LogTime], @LoggingToDate) >= 0
	AND (@LogLevel = -1 OR [LogLevel] = @LogLevel)
	AND (@LogUser = -1 OR [UId] = @LogUser)
	AND ISNULL(flag, '') = ''
END
GO
