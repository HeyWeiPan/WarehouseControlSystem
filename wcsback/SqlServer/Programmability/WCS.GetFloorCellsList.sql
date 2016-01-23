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
drop proc WCS.GetFloorCellsList
go
CREATE PROCEDURE WCS.GetFloorCellsList
	@pFloorId int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	select
	a.cell_id,
	a.cell_num,
	a.wh_id,
	a.floor_num,
	a.celltype_code,
	c.celltype_name,
	a.x_num,
	a.y_num
	from wcs_cell a left join wcs_celltype c on a.celltype_code=c.celltype_code
	where exists(select 1 from wcs_floor b where a.wh_id=b.wh_id and a.floor_num=b.floor_num and b.floor_id=@pFloorId)
	
	
END
GO
