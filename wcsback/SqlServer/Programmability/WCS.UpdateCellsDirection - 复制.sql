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
-- Author:		lly
-- Create date: 2015-3-13
-- Description: 
-- =============================================
drop proc WCS.UpdateCellsDirection
go
CREATE PROCEDURE WCS.UpdateCellsDirection
	@pWhId int,
	@pWhModeId	int,
	@pTokenStrategyId int,
	@pXml xml
with encryption
AS
BEGIN	
	SET NOCOUNT ON;
	
		declare @SourceTable table
		(
			wh_id int,
			cell_num varchar(20),
			cell_direction varchar(20)
		)

		insert into @SourceTable(wh_id,cell_num,cell_direction)
		select 
		@pWhId,
		a.value('(CellNum/text())[1]', 'varchar(20)') cell_num,
		a.value('(CellDirection/text())[1]', 'varchar(20)') cell_direction
		from @pXml.nodes('/NewDataSet/Table') as T(a)

		--更新仓库的模式和令牌策略
		update wcs_wh set wh_mode_id = @pWhModeId,token_strategy_id = @pTokenStrategyId where wh_id = @pWhId
		
		--更新每个格子的能够行驶的方向
		update a
		set a.cell_direction=b.cell_direction
		from wcs_cell a,@SourceTable b
		where a.wh_id=b.wh_id and a.cell_num=b.cell_num and b.cell_direction <> 'undefined'

		if @pWhModeId = 1
		begin
			update a set a.cell_yf1 = -1 from wcs_cell a where a.cell_direction = '1'
			update a set a.cell_yb1 = -1 from wcs_cell a where a.cell_direction = '2'
			update a set a.cell_xb1 = -1 from wcs_cell a where a.cell_direction = '3'
			update a set a.cell_xf1 = -1 from wcs_cell a where a.cell_direction = '4'
			update a set a.cell_yf1 = -1,a.cell_yb1 = -1 from wcs_cell a where a.cell_direction = '5'
			update a set a.cell_xb1 = -1,a.cell_yb1 = -1 from wcs_cell a where a.cell_direction = '6'
			update a set a.cell_xf1 = -1,a.cell_yb1 = -1 from wcs_cell a where a.cell_direction = '7'
			update a set a.cell_xf1 = -1,a.cell_yf1 = -1 from wcs_cell a where a.cell_direction = '8'
			update a set a.cell_xb1 = -1,a.cell_yf1 = -1 from wcs_cell a where a.cell_direction = '9'
			update a set a.cell_xf1 = -1,a.cell_xb1 = -1 from wcs_cell a where a.cell_direction = '10'
			update a set a.cell_xb1 = -1,a.cell_yf1 = -1,a.cell_yb1 = -1 from wcs_cell a where a.cell_direction = '11'
			update a set a.cell_xf1 = -1,a.cell_yf1 = -1,a.cell_yb1 = -1 from wcs_cell a where a.cell_direction = '12'
			update a set a.cell_xf1 = -1,a.cell_xb1 = -1,a.cell_yf1 = -1 from wcs_cell a where a.cell_direction = '13'
			update a set a.cell_xf1 = -1,a.cell_xb1 = -1,a.cell_yb1 = -1 from wcs_cell a where a.cell_direction = '14'
			update a set a.cell_xf1 = -1,a.cell_xb1 = -1,a.cell_yf1 = -1,a.cell_yb1 = -1 from wcs_cell a where a.cell_direction = '15'
		end
		else if  @pWhModeId = 2
		begin
			update a set a.cell_yf2 = -1 from wcs_cell a where a.cell_direction = '1'
			update a set a.cell_yb2 = -1 from wcs_cell a where a.cell_direction = '2'
			update a set a.cell_xb2 = -1 from wcs_cell a where a.cell_direction = '3'
			update a set a.cell_xf2 = -1 from wcs_cell a where a.cell_direction = '4'
			update a set a.cell_yf2 = -1,a.cell_yb2 = -1 from wcs_cell a where a.cell_direction = '5'
			update a set a.cell_xb2 = -1,a.cell_yb2 = -1 from wcs_cell a where a.cell_direction = '6'
			update a set a.cell_xf2 = -1,a.cell_yb2 = -1 from wcs_cell a where a.cell_direction = '7'
			update a set a.cell_xf2 = -1,a.cell_yf2 = -1 from wcs_cell a where a.cell_direction = '8'
			update a set a.cell_xb2 = -1,a.cell_yf2 = -1 from wcs_cell a where a.cell_direction = '9'
			update a set a.cell_xf2 = -1,a.cell_xb2 = -1 from wcs_cell a where a.cell_direction = '10'
			update a set a.cell_xb2 = -1,a.cell_yf2 = -1,a.cell_yb2 = -1 from wcs_cell a where a.cell_direction = '11'
			update a set a.cell_xf2 = -1,a.cell_yf2 = -1,a.cell_yb2 = -1 from wcs_cell a where a.cell_direction = '12'
			update a set a.cell_xf2 = -1,a.cell_xb2 = -1,a.cell_yf2 = -1 from wcs_cell a where a.cell_direction = '13'
			update a set a.cell_xf2 = -1,a.cell_xb2 = -1,a.cell_yb2 = -1 from wcs_cell a where a.cell_direction = '14'
			update a set a.cell_xf2 = -1,a.cell_xb2 = -1,a.cell_yf2 = -1,a.cell_yb2 = -1 from wcs_cell a where a.cell_direction = '15'
		end
		
END
GO
