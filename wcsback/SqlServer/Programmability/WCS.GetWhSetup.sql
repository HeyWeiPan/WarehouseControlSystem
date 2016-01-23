-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Liberty
-- Create date: 2012/07/23
-- Description: 
-- =============================================
drop proc WCS.GetWhSetup
go
CREATE PROCEDURE WCS.GetWhSetup
	@pWhCode nvarchar(60)
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	
	declare @cnt int

	select @cnt=count(*) from wcs_wh where wh_code=@pWhCode

	if(@cnt=0)
	begin

		raiserror('仓库配置不正确,请检查appconfig文件',16,2);
		return

	end
	

	select ip_adress host,port from wcs_wh where wh_code=@pWhCode
	


END
GO
