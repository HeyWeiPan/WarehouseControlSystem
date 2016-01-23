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
drop proc WCS.DeleteWH
go
CREATE PROCEDURE WCS.DeleteWH
	@pKeyValue int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	delete wcs_cell where wh_id=@pKeyValue
	delete wcs_floor where wh_id=@pKeyValue
	delete wcs_lift where wh_id=@pKeyValue
	delete wcs_asrv_status where asrv_id in (select asrv_id from wcs_asrv where wh_id=@pKeyValue)
	delete wcs_asrv where wh_id=@pKeyValue
	
	
	
END
GO
