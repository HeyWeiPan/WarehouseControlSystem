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
drop proc WCS.GetWCSFloorDetail
go
CREATE PROCEDURE WCS.GetWCSFloorDetail
	@pKeyValue int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	select
	floor_id,
	wh_id,
	floor_num,
	floor_code,
	floor_description
	from wcs_floor where floor_id=@pKeyValue
	
	
END
GO
