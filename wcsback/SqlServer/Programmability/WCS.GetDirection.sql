
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
drop proc WCS.GetDirection
go
CREATE PROCEDURE WCS.GetDirection
	@pCmdId int,
	@pCellNum	varchar(20),
	@pCellXf int output,
	@pCellXb int output,
	@pCellYf int output,
	@pCellYb int output
with encryption
AS
BEGIN	
	SET NOCOUNT ON

	declare @asrv_id int
	declare @wh_id int
	declare @floor_num int

	select @asrv_id = a.asrv_id,@wh_id = b.wh_id,@floor_num = a.floor_num from wcs_asrv a,wcs_asrv_cmd b
	where a.asrv_id = b.asrv_id and b.cmd_id = @pCmdId


	select @pCellXf = a.cell_xf,@pCellXb = a.cell_xb,@pCellYf = a.cell_yf,@pCellYb = cell_yb from wcs_cell_direction a,wcs_cell b
	where a.cell_id = b.cell_id and a.wh_id = @wh_id and b.floor_num = @floor_num and b.cell_num = @pCellNum
	
END
GO
