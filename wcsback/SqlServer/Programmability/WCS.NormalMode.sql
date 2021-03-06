﻿-- ================================================
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
-- Author:		lly
-- Create date: 2015-3-11
-- Description: 
-- =============================================
drop proc WCS.NormalMode
go
CREATE PROCEDURE WCS.NormalMode
	@pWhId int,
	@wh_mode_id int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	declare @rack_direction  varchar(20) --货道方向
	--declare @wh_mode_id int

	select @rack_direction = rack_direction from wcs_wh where wh_id = @pWhId

	--如果当前货道的方向是x方向
	if @rack_direction = 'x' 
	begin
		if @wh_mode_id = 1 --如果该仓库是普通模式
		begin
			update wcs_cell set cell_xf1 = -1,cell_xb1 = -1 where  celltype_code = 3 and wh_mode_id = 1
		end	
		else if @wh_mode_id = 2
		begin
			update wcs_cell set  cell_xf1 = -1,cell_xb1 = -1 where  celltype_code = 3 and wh_mode_id = 1
		end
	end
	else
	begin
		update wcs_cell  set cell_yf1 = -1,cell_yb1 = -1 where celltype_code  = 3 and wh_mode_id = 1
	end 

	--如果格子类型为巷道，车子可以上下左右开。
	update wcs_cell set cell_xf1 = -1,cell_xb1 = -1,cell_yf1 = -1,cell_yb1 = -1 where celltype_code = 0 and wh_mode_id = 

	--如果格子类型为货道并且没有货物，车子只能往左右开。
	update wcs_cell set cell_xf1 = -1,cell_xb1 = -1 where celltype_code = 3

	--如果x轴坐标值为最小值，车子不能往左开，最大则不能往右开；如果y轴坐标值为最小，车子不能往下开，最大则不能往上开。
	update wcs_cell set cell_xb1 = 0,cell_xb2 = 0 where x_num = (select min(x_num) from  wcs_cell) 
	update wcs_cell set cell_xf1 = 0,cell_xf2 = 0 where x_num = (select max(x_num) from  wcs_cell)
	update wcs_cell set cell_yb1 = 0,cell_yb2 = 0 where y_num = (select min(y_num) from wcs_cell)
	update wcs_cell set cell_yf1 = 0,cell_yf2 = 0 where y_num = (select max(y_num) from wcs_cell)

	
END
GO
