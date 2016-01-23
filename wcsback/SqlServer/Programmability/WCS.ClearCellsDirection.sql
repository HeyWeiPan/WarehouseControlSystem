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
drop proc WCS.ClearCellsDirection
go
CREATE PROCEDURE WCS.ClearCellsDirection
	@pWhId int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	update a set a.cell_direction = 0 from wcs_cell a where a.wh_id = @pWhId	
	
	update wcs_cell_direction set cell_xf = 0,cell_xb = 0,cell_yf = 0,cell_yb = 0 where wh_id = @pWhId
	
END
GO
