-- =============================================
-- Author:		SonDN
-- Create date:   2010/09/29
-- Description:	Script tạo Module Royalty
-- =============================================

BEGIN

DECLARE @intErrorCode INT
DECLARE @moduleId INT
BEGIN TRAN
	INSERT INTO [dbo].[Module]
           ([Name] ,[Alias] ,[Detail]
           ,[Created_At] ,[Created_By] ,[Last_Modified_At]  ,[Last_Modified_By],[flag])
     VALUES
           (N'AddOn - Quản lý Nhuận bút'
           ,'VietNamNet.AddOn.Royalty'
           ,N'Quản lý Nhuận bút'
           ,getdate() ,1 ,getdate() ,1 ,null)
	
set @moduleId = (SELECT SCOPE_IDENTITY() )

    SELECT @intErrorCode = @@ERROR
    IF (@intErrorCode <> 0) GOTO PROBLEM
  


INSERT INTO [dbo].[Function]
           ([ModuleId],[Ord],[Name] ,[Alias],[Detail]
           ,[Created_At] ,[Created_By] ,[Last_Modified_At] ,[Last_Modified_By] ,[flag])
     VALUES
           (@moduleId
           ,1
           ,N'Danh mục'
           ,'VietNamNet.AddOn.Royalty.Types'
           ,N'Quản lý Danh mục Nhuận bút'
           ,getdate() ,1 ,getdate() ,1 ,null)
           
 INSERT INTO [dbo].[Function]
           ([ModuleId],[Ord],[Name] ,[Alias],[Detail]
           ,[Created_At] ,[Created_By] ,[Last_Modified_At] ,[Last_Modified_By] ,[flag])
     VALUES
           (@moduleId
           ,1
           ,N'Chấm Nhuận bút'
           ,'VietNamNet.AddOn.Royalty.Fund'
           ,N'Quản lý Chấm Nhuận bút'
           ,getdate() ,1 ,getdate() ,1 ,null)
           
 INSERT INTO [dbo].[Function]
           ([ModuleId],[Ord],[Name] ,[Alias],[Detail]
           ,[Created_At] ,[Created_By] ,[Last_Modified_At] ,[Last_Modified_By] ,[flag])
     VALUES
           (@moduleId
           ,1
           ,N'Thống kê'
           ,'VietNamNet.AddOn.Royalty.Statistics'
           ,N'Quản lý Thống kê Nhuận bút'
           ,getdate() ,1 ,getdate() ,1 ,null)
           
 INSERT INTO [dbo].[Function]
           ([ModuleId],[Ord],[Name] ,[Alias],[Detail]
           ,[Created_At] ,[Created_By] ,[Last_Modified_At] ,[Last_Modified_By] ,[flag])
     VALUES
           (@moduleId
           ,1
           ,N'Hệ thống'
           ,'VietNamNet.AddOn.Royalty.System'
           ,N'Quản lý hệ thống'
           ,getdate() ,1 ,getdate() ,1 ,null)
           
           
	SELECT @intErrorCode = @@ERROR
    IF (@intErrorCode <> 0) GOTO PROBLEM

COMMIT TRAN

PROBLEM:
IF (@intErrorCode <> 0) BEGIN
PRINT 'Unexpected error occurred!'
    ROLLBACK TRAN
END


END