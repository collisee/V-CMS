DECLARE @DBName varchar(255)
SET @DBName = 'VietNamNet_Tracking'

DECLARE @DBPath varchar(255)
SET @DBPath = 'E:\Databases\VietNamNet_Tracking\'

DECLARE @SQL varchar(8000)
SET @SQL = '
CREATE DATABASE [' + @DBName + '] ON 
 PRIMARY 
( NAME = N''' + @DBName + ''', FILENAME = N''' + @DBPath + '' + @DBName + '.mdf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ), 
 FILEGROUP [Tracking] 
( NAME = N''Tracking'', FILENAME = N''' + @DBPath + 'Tracking.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ), 
 FILEGROUP [Tracking_2010] 
( NAME = N''Tracking_2010'', FILENAME = N''' + @DBPath + 'Tracking_2010.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ), 
 FILEGROUP [Tracking_2011] 
( NAME = N''Tracking_2011'', FILENAME = N''' + @DBPath + 'Tracking_2011.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ), 
 FILEGROUP [Tracking_2012] 
( NAME = N''Tracking_2012'', FILENAME = N''' + @DBPath + 'Tracking_2012.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ), 
 FILEGROUP [Tracking_2013] 
( NAME = N''Tracking_2013'', FILENAME = N''' + @DBPath + 'Tracking_2013.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ), 
 FILEGROUP [Tracking_2014] 
( NAME = N''Tracking_2014'', FILENAME = N''' + @DBPath + 'Tracking_2014.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ), 
 FILEGROUP [Tracking_2015] 
( NAME = N''Tracking_2015'', FILENAME = N''' + @DBPath + 'Tracking_2015.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ), 
 FILEGROUP [Tracking_2016] 
( NAME = N''Tracking_2016'', FILENAME = N''' + @DBPath + 'Tracking_2016.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ), 
 FILEGROUP [Tracking_2017] 
( NAME = N''Tracking_2017'', FILENAME = N''' + @DBPath + 'Tracking_2017.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ), 
 FILEGROUP [Tracking_2018] 
( NAME = N''Tracking_2018'', FILENAME = N''' + @DBPath + 'Tracking_2018.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ), 
 FILEGROUP [Tracking_2019] 
( NAME = N''Tracking_2019'', FILENAME = N''' + @DBPath + 'Tracking_2019.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB ), 
 FILEGROUP [Tracking_2020] 
( NAME = N''Tracking_2020'', FILENAME = N''' + @DBPath + 'Tracking_2020.ndf'' , SIZE = 2048KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N''' + @DBName + '_log'', FILENAME = N''' + @DBPath + '' + @DBName + '_log.ldf'' , SIZE = 1024KB , FILEGROWTH = 10%)
GO
EXEC dbo.sp_dbcmptlevel @dbname=N''' + @DBName + ''', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY(''IsFullTextInstalled''))
begin
EXEC [' + @DBName + '].[dbo].[sp_fulltext_database] @action = ''disable''
end
GO
ALTER DATABASE [' + @DBName + '] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [' + @DBName + '] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [' + @DBName + '] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [' + @DBName + '] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [' + @DBName + '] SET ARITHABORT OFF 
GO
ALTER DATABASE [' + @DBName + '] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [' + @DBName + '] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [' + @DBName + '] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [' + @DBName + '] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [' + @DBName + '] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [' + @DBName + '] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [' + @DBName + '] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [' + @DBName + '] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [' + @DBName + '] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [' + @DBName + '] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [' + @DBName + '] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [' + @DBName + '] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [' + @DBName + '] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [' + @DBName + '] SET  READ_WRITE 
GO
ALTER DATABASE [' + @DBName + '] SET RECOVERY FULL 
GO
ALTER DATABASE [' + @DBName + '] SET  MULTI_USER 
GO
ALTER DATABASE [' + @DBName + '] SET PAGE_VERIFY CHECKSUM  
GO
USE [' + @DBName + ']
GO
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N''PRIMARY'') 
ALTER DATABASE [' + @DBName + '] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO
'
--EXEC(@SQL)
PRINT @SQL
