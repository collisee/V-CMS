USE [master]
GO
ALTER DATABASE [VietNamNet] ADD FILEGROUP [Survey]
GO
ALTER DATABASE [VietNamNet] ADD FILE ( NAME = N'Survey', FILENAME = N'E:\Databases\VietNamNet\Survey.ndf' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Survey]
GO
