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
drop proc WCS.GetWhCells
go
CREATE PROCEDURE WCS.GetWhCells
	@pCmdId int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	declare @whId int
	declare @floorNum int


	select 
	@whId=a.wh_id,
	@floorNum=a.floor_num
	from wcs_asrv a,wcs_asrv_cmd b
	where a.asrv_id=b.asrv_id and b.cmd_id=@pCmdId

	select
	a.cell_num,
	a.celltype_code,
	b.cell_xf,
	b.cell_xb,
	b.cell_yf,
	b.cell_yb,
	b.wh_mode_id
	from wcs_cell a,wcs_cell_direction b
	where a.cell_id = b.cell_id and a.wh_id=@whId and a.floor_num=@floorNum order by a.cell_num

	
	
END
GO
