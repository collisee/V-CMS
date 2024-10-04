-- =============================================
-- Author:		SonDN
-- Create date:   2010/09/29
-- Description:	Script tạo Module
-- =============================================

BEGIN

DECLARE @intErrorCode INT
DECLARE @moduleId INT
BEGIN TRAN
	INSERT INTO [dbo].[Module]
           ([Name] ,[Alias] ,[Detail]
           ,[Created_At] ,[Created_By] ,[Last_Modified_At]  ,[Last_Modified_By],[flag])
     VALUES
           (N'AddOn - Quản lý Bình chọn'
           ,'VietNamNet.AddOn.Survey'
           ,N'Quản lý Bình chọn'
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
           ,N'Xem'
           ,'VietNamNet.AddOn.Survey.View'
           ,N'Xem'
           ,getdate() ,1 ,getdate() ,1 ,null)

INSERT INTO [dbo].[Function]
           ([ModuleId],[Ord],[Name] ,[Alias],[Detail]
           ,[Created_At] ,[Created_By] ,[Last_Modified_At] ,[Last_Modified_By] ,[flag])
     VALUES
           (@moduleId
           ,2
           ,N'Thêm mới'
           ,'VietNamNet.AddOn.Survey.AddNew'
           ,N'Thêm mới'
           ,getdate() ,1 ,getdate() ,1 ,null)

INSERT INTO [dbo].[Function]
           ([ModuleId],[Ord],[Name] ,[Alias],[Detail]
           ,[Created_At] ,[Created_By] ,[Last_Modified_At] ,[Last_Modified_By] ,[flag])
     VALUES
           (@moduleId
           ,3
           ,N'Sửa'
           ,'VietNamNet.AddOn.Survey.Update'
           ,N'Sửa'
           ,getdate() ,1 ,getdate() ,1 ,null)

INSERT INTO [dbo].[Function]
           ([ModuleId],[Ord],[Name] ,[Alias],[Detail]
           ,[Created_At] ,[Created_By] ,[Last_Modified_At] ,[Last_Modified_By] ,[flag])
     VALUES
           (@moduleId
           ,4
           ,N'Xóa'
           ,'VietNamNet.AddOn.Survey.Delete'
           ,N'Xóa'
           ,getdate() ,1 ,getdate() ,1 ,null)

INSERT INTO [dbo].[Function]
           ([ModuleId],[Ord],[Name] ,[Alias],[Detail]
           ,[Created_At] ,[Created_By] ,[Last_Modified_At] ,[Last_Modified_By] ,[flag])
     VALUES
           (@moduleId
           ,7
           ,N'Hệ thống'
           ,'VietNamNet.AddOn.Survey.System'
           ,N'Quản trị Hệ thống'
           ,getdate() ,1 ,getdate() ,1 ,null)

INSERT INTO [dbo].[Function]
           ([ModuleId],[Ord],[Name] ,[Alias],[Detail]
           ,[Created_At] ,[Created_By] ,[Last_Modified_At] ,[Last_Modified_By] ,[flag])
     VALUES
           (@moduleId
           ,5
           ,N'Xuất bản'
           ,'VietNamNet.AddOn.Survey.Publish'
           ,N'Quản trị Xuất bảng'
           ,getdate() ,1 ,getdate() ,1 ,null)
/*
72	17	1	Xem	VietNamNet.AddOn.Survey.View		2010-08-09 14:26:21.000	1	2010-08-09 14:26:30.000	1	NULL
73	17	2	Thêm mới	VietNamNet.AddOn.Survey.AddNew		2010-08-09 14:26:21.000	1	2010-08-09 14:26:58.000	1	NULL
74	17	3	Sửa	VietNamNet.AddOn.Survey.Update		2010-08-09 14:26:21.000	1	2010-08-09 14:27:24.000	1	NULL
75	17	4	Xóa	VietNamNet.AddOn.Survey.Delete		2010-08-09 14:26:21.000	1	2010-08-09 14:27:16.000	1	NULL
76	17	7	Hệ thống	VietNamNet.AddOn.Survey.System	Quản trị Hệ thống	2010-08-09 14:26:21.000	1	2010-08-17 09:22:35.173	10	NULL
77	17	5	Xuất bản	VietNamNet.AddOn.Survey.Publish	Quản trị Xuất bản	2010-08-09 14:26:21.000	1	2010-08-17 09:23:21.313	10	NULL
*/
	SELECT @intErrorCode = @@ERROR
    IF (@intErrorCode <> 0) GOTO PROBLEM

COMMIT TRAN

PROBLEM:
IF (@intErrorCode <> 0) BEGIN
PRINT 'Unexpected error occurred!'
    ROLLBACK TRAN
END


 END