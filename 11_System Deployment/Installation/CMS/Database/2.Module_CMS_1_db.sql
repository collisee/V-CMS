DECLARE @DBName varchar(255)
SET @DBName = 'VietNamNet_V1'

DECLARE @DBPath varchar(255)
SET @DBPath = 'E:\Databases\VietNamNet_V1\'

DECLARE @SQL varchar(8000)
SET @SQL = '
USE [master]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Advertise]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Advertise'', FILENAME = N''' + @DBPath + 'Advertise.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Advertise]
GO


ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Event]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Event'', FILENAME = N''' + @DBPath + 'Event.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Event]
GO


--ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Survey]
--GO
--ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Survey'', FILENAME = N''' + @DBPath + 'Survey.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Survey]
--GO


ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Layout]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Layout'', FILENAME = N''' + @DBPath + 'Layout.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Layout]
GO


ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Article]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Article'', FILENAME = N''' + @DBPath + 'Article.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Article]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Article_01]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Article_01'', FILENAME = N''' + @DBPath + 'Article_01.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Article_01]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Article_02]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Article_02'', FILENAME = N''' + @DBPath + 'Article_02.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Article_02]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Article_03]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Article_03'', FILENAME = N''' + @DBPath + 'Article_03.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Article_03]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Article_04]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Article_04'', FILENAME = N''' + @DBPath + 'Article_04.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Article_04]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Article_05]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Article_05'', FILENAME = N''' + @DBPath + 'Article_05.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Article_05]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Article_06]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Article_06'', FILENAME = N''' + @DBPath + 'Article_06.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Article_06]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Article_07]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Article_07'', FILENAME = N''' + @DBPath + 'Article_07.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Article_07]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Article_08]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Article_08'', FILENAME = N''' + @DBPath + 'Article_08.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Article_08]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Article_09]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Article_09'', FILENAME = N''' + @DBPath + 'Article_09.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Article_09]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Article_10]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Article_10'', FILENAME = N''' + @DBPath + 'Article_10.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Article_10]
GO
'
PRINT @SQL

SET @SQL = '

ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category'', FILENAME = N''' + @DBPath + 'Category.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_01]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_01'', FILENAME = N''' + @DBPath + 'Category_01.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_01]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_02]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_02'', FILENAME = N''' + @DBPath + 'Category_02.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_02]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_03]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_03'', FILENAME = N''' + @DBPath + 'Category_03.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_03]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_04]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_04'', FILENAME = N''' + @DBPath + 'Category_04.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_04]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_05]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_05'', FILENAME = N''' + @DBPath + 'Category_05.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_05]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_06]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_06'', FILENAME = N''' + @DBPath + 'Category_06.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_06]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_07]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_07'', FILENAME = N''' + @DBPath + 'Category_07.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_07]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_08]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_08'', FILENAME = N''' + @DBPath + 'Category_08.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_08]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_09]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_09'', FILENAME = N''' + @DBPath + 'Category_09.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_09]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_10]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_10'', FILENAME = N''' + @DBPath + 'Category_10.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_10]
GO

ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_11]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_11'', FILENAME = N''' + @DBPath + 'Category_11.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_11]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_12]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_12'', FILENAME = N''' + @DBPath + 'Category_12.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_12]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_13]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_13'', FILENAME = N''' + @DBPath + 'Category_13.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_13]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_14]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_14'', FILENAME = N''' + @DBPath + 'Category_14.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_14]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_15]
GO
'
PRINT @SQL

SET @SQL = '
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_15'', FILENAME = N''' + @DBPath + 'Category_15.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_15]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_16]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_16'', FILENAME = N''' + @DBPath + 'Category_16.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_16]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_17]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_17'', FILENAME = N''' + @DBPath + 'Category_17.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_17]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_18]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_18'', FILENAME = N''' + @DBPath + 'Category_18.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_18]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_19]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_19'', FILENAME = N''' + @DBPath + 'Category_19.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_19]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_20]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_20'', FILENAME = N''' + @DBPath + 'Category_20.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_20]
GO

ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_21]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_21'', FILENAME = N''' + @DBPath + 'Category_21.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_21]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_22]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_22'', FILENAME = N''' + @DBPath + 'Category_22.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_22]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_23]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_23'', FILENAME = N''' + @DBPath + 'Category_23.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_23]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_24]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_24'', FILENAME = N''' + @DBPath + 'Category_24.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_24]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_25]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_25'', FILENAME = N''' + @DBPath + 'Category_25.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_25]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_26]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_26'', FILENAME = N''' + @DBPath + 'Category_26.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_26]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_27]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_27'', FILENAME = N''' + @DBPath + 'Category_27.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_27]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_28]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_28'', FILENAME = N''' + @DBPath + 'Category_28.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_28]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_29]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_29'', FILENAME = N''' + @DBPath + 'Category_29.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_29]
GO
ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [Category_30]
GO
ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''Category_30'', FILENAME = N''' + @DBPath + 'Category_30.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ) TO FILEGROUP [Category_30]
GO
'
--EXEC(@SQL)
PRINT @SQL
