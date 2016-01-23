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
drop proc WCS.DeleteFloor
go
CREATE PROCEDURE WCS.DeleteFloor
	@pKeyValue int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	delete from  wcs_cell  where exists(select 1 from wcs_floor b where b.wh_id=wcs_cell.wh_id and b.floor_num=wcs_cell.floor_num and b.floor_id=@pKeyValue)
	
	
	
	
END
GO
