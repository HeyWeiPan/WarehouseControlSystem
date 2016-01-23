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
drop proc WCS.GetRoadRight
go
CREATE PROCEDURE WCS.GetRoadRight
	@pWhId int,
	@pFloorNum int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	declare @cmds table (cmd_id int,create_date smalldatetime)
	declare @asrvId int

		select cast(b.x_num as varchar(10))+'.'+cast(b.y_num as varchar(10)) as cell_num,c.asrv_code ,b.right_flag,b.pass_flag
	from wcs_asrv_cmd a,wcs_asrv_cmd_route b,wcs_asrv c
	where a.cmd_id = b.cmd_id
    and a.asrv_id = c.asrv_id
	and c.wh_id = @pWhId
	and c.floor_num = @pFloorNum
	AND c.has_task_flag = -1
	AND a.Task_finish_flag = 0
	AND b.right_flag = -1
	AND b.pass_flag <> -1

	--select cast(c.x_num as varchar(10))+'.'+cast(c.y_num as varchar(10)) as cell_num,d.asrv_code  
	--from wcs_road_right a,wcs_asrv_cmd b,wcs_asrv_cmd_route c,wcs_asrv d,wcs_cell e
	--where a.cmd_id = b.cmd_id
 --   and a.cmd_id = c.cmd_id
	--and a.asrv_id = d.asrv_id
	--and a.step_id = c.step_id
	--and a.cell_id = e.cell_id
	--and d.wh_id = @pWhId
	--and d.floor_num = @pFloorNum
	--and e.road_right_flag = 1
	
END
GO
