USE [master]
GO
ALTER DATABASE [VietNamNet] ADD FILEGROUP [Calendar]
GO
ALTER DATABASE [VietNamNet] ADD FILE ( NAME = N'Calendar', FILENAME = N'E:\Databases\VietNamNet\Calendar.ndf' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Calendar]
GO
