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
drop proc WCS.AddCellDirection
go
CREATE PROCEDURE WCS.AddCellDirection
	@pWhId int
with encryption
AS
BEGIN	
	SET NOCOUNT ON

	if exists(select top 1 1 from wcs_cell_direction where wh_id = @pWhId)
	begin
		return
	end

	insert into wcs_cell_direction
	(
		cell_id,
		wh_mode_id,
		cell_xf,
		cell_xb,
		cell_yf,
		cell_yb,
		create_by,
		create_date,
		wh_id
	)		
	select 
		a.cell_id,
		b.wh_mode_id,
		0,
		0,
		0,
		0,
		2,
		getdate(),
		b.wh_id
	from wcs_cell a,wcs_wh b
	where a.wh_id = b.wh_id
	and a.wh_id = @pWhId
	
END
GO
