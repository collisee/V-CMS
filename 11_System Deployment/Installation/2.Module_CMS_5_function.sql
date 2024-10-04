/****** Object:  UserDefinedFunction [dbo].[fn_GetCategoriesByUserId]    Script Date: 07/13/2010 17:34:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[fn_GetCategoriesByUserId]
(	
	-- Add the parameters for the function here
	@UserId int = 0
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
		SELECT DISTINCT([Category].[Id])
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
)
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetPartitionsByUserId]    Script Date: 07/13/2010 17:34:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[fn_GetPartitionsByUserId]
(	
	-- Add the parameters for the function here
	@UserId int = 0
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
		SELECT DISTINCT([Category].[PartitionId])
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
)
GO
