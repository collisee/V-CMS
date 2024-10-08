/****** Object:  UserDefinedFunction [dbo].[fn_ConvertStringToArray]    Script Date: 04/16/2010 09:18:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_ConvertStringToArray] ( 
	@ilist varchar(2000)=null, 
	@delim varchar(50)= null 
) 
RETURNS  @results TABLE (retval nvarchar(50)  NOT NULL, ik0 int NOT NULL IDENTITY PRIMARY KEY) 
AS BEGIN 
 
	IF @delim IS NULL SET @delim=',' 
 
	DECLARE @s nvarchar(2000), @i int, @ins nvarchar(2000) 
	SELECT 		 
		@s=REPLACE(@ilist,'''','`')+@delim 
	WHILE (PATINDEX('%'+@delim+'%',@s))>0 BEGIN 
		SELECT  
			@s=@s+@delim, 
			@i=PATINDEX('%'+@delim+'%',@s), 
			@ins=CASE WHEN @delim = ' ' THEN LEFT(@s,@i) ELSE RTRIM(LTRIM(LEFT(@s,@i)))END, 
			@s=REPLACE(@s,@ins,''),  
			@ins=REPLACE(@ins,@delim,''), 
			@i=0 
		IF @ins<>'' AND NOT @ins IS NULL INSERT INTO @results (retval) VALUES(@ins); 
	END ---WHILE 
 
 
RETURN 
END
GO
