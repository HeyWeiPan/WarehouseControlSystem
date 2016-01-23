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
drop proc WCS.UpdateRoadRight
go
CREATE PROCEDURE WCS.UpdateRoadRight
	@pWhId int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;
	
	--获取当前仓库正在执行的任务序列

	declare @cmdId int
	declare @asrvId int
	declare @taskCells int
	declare @cellNum varchar(10)
	declare @step int



	update a
	set asrv_road_right=null
	from wcs_cell a
	where a.wh_id= @pWhId


	declare c_r cursor for select a.cmd_id,b.asrv_id,isnull(b.current_task_cells,0),cast(x_num as varchar)+'.'+cast(y_num as varchar) from wcs_asrv_cmd a,wcs_asrv b where a.wh_id=@pWhId and a.asrv_id=b.asrv_id and a.current_Flag=-1 order by a.create_date
	open c_r
	fetch next from c_r into @cmdId,@asrvId,@taskCells,@cellNum
	while(@@fetch_status=0)
	begin
		

		update a
		set asrv_road_right=@asrvId
		from wcs_cell a,wcs_asrv_cmd_route b
		where b.step_id>@taskCells and a.asrv_road_right is null and b.cmd_id=@cmdId
		and a.wh_id=@pWhId and a.floor_num=b.floor_num and a.cell_num=b.cell_num


		fetch next from c_r into @cmdId,@asrvId,@taskCells,@cellNum
	end
	close c_r
	deallocate c_r
	



	
END
GO
