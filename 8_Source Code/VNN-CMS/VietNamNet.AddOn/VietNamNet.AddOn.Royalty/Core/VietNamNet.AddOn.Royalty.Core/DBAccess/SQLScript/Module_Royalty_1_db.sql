/** Create Datafile**/
USE [master]
GO
ALTER DATABASE [VietNamNet_V1] ADD FILEGROUP [Royalty]
GO
ALTER DATABASE [VietNamNet_V1] ADD FILE ( NAME = N'Royalty', FILENAME = N'E:\Databases\VietNamNet\Royalty.ndf' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Royalty]
GO
