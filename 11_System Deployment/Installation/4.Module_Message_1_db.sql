USE [master]
GO
ALTER DATABASE [VietNamNet] ADD FILEGROUP [Message]
GO
ALTER DATABASE [VietNamNet] ADD FILE ( NAME = N'Message', FILENAME = N'E:\Databases\VietNamNet\Message.ndf' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Message]
GO
