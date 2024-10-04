-- =============================================
-- Author:		SonDN
-- Create date:   2010/10/29
-- Description:	Tao bang trong module Royalty
-- ============================================= 

/** [Royalty] - Các bảng tính nhuận bút **/
USE [VietNamNet]
if not exists (select * from dbo.sysobjects where id = object_id(N'[RoyaltyTypes]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [RoyaltyTypes]
		( 
			Type_Id  [int] NOT NULL IDENTITY(1, 1),
			Title nvarchar(100), 
			Description nvarchar(500), 
			Parent_Id [int], 
			MIN_VAL numeric, 
			MAX_VAL numeric,
							
			[Created_At] [datetime] NOT NULL  DEFAULT (getdate()),
			[Created_By] [int] NOT NULL   DEFAULT ((0)),
			[Last_Modified_At] [datetime] NOT NULL   DEFAULT (getdate()),
			[Last_Modified_By] [int] NOT NULL  DEFAULT ((0)),
			[flag] [char](1)  NULL,
		) ON [Royalty]

		ALTER TABLE [RoyaltyTypes] ADD CONSTRAINT [PK_RoyaltyTypes] PRIMARY KEY CLUSTERED  ([Type_Id])
	 END
GO
 


if not exists (select * from dbo.sysobjects where id = object_id(N'[RoyaltyFund]') and OBJECTPROPERTY(id, N'IsTable') = 1)
	BEGIN
		CREATE TABLE [RoyaltyFund]
		( 
			 Fund_Id [int] NOT NULL IDENTITY(1, 1), 
			 Article_Id [int] NOT NULL , 
			 Text_Fund [int], 
			 Image_Fund [int], 
			 Audio_Fund [int], 
			 Video_Fund [int], 
			 Other_Fund [int], 
			 Notes nvarchar(500), 
			 
			 Author_Id [int] , 
			 Author_IsMember [int] , 
			 Setter_Id  [int] ,  
			 Type_Id [int], 
			 Set_Type nvarchar(500),
			 Pay_Date [datetime],
			 Pay_Status  [int]  NOT NULL  DEFAULT ((0)),
							
			[Created_At] [datetime] NOT NULL  DEFAULT (getdate()),
			[Created_By] [int] NOT NULL   DEFAULT ((0)),
			[Last_Modified_At] [datetime] NOT NULL   DEFAULT (getdate()),
			[Last_Modified_By] [int] NOT NULL  DEFAULT ((0)),
			[flag] [char](1)  NULL,
		) ON [Royalty]

		ALTER TABLE [RoyaltyFund] ADD CONSTRAINT [PK_RoyaltyFund] PRIMARY KEY CLUSTERED  (Fund_Id)
	 END
GO
