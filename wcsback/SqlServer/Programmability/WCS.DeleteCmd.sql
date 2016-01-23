use biz
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
drop proc WCS.DeleteCmd
go
CREATE PROCEDURE WCS.DeleteCmd
	@pCmdId int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	declare @temp table
	(
		wh_id int,
		cmd_id int,
		step_id int,
		floor_num int,
		x_num int,
		y_num int
	) 

	insert into @temp(wh_id,cmd_id,step_id,floor_num,x_num,y_num)
	select b.wh_id,a.cmd_id,step_id,floor_num,x_num,y_num 
	from  wcs_asrv_cmd_route a,wcs_asrv_cmd b
	where a.cmd_id = b.cmd_id and a.cmd_id = @pCmdId order by a.step_id

	update a set a.road_right_flag = 0 from wcs_cell a,@temp b
	where a.wh_id = b.wh_id and a.floor_num = b.floor_num and a.x_num = b.x_num and a.y_num = b.y_num

	update a set a.need_right_flag = -1 from wcs_asrv a ,wcs_asrv_cmd b where a.asrv_id = b.asrv_id and b.cmd_id = @pCmdId

	update a set a.has_task_flag = 0 from wcs_asrv a,wcs_asrv_cmd b where a.asrv_id = b.asrv_id and b.cmd_id = @pCmdId
	delete wcs_asrv_cmd_route where cmd_id=@pCmdId
	delete wcs_cmd_breakdown where cmd_id=@pCmdId
	delete wcs_asrv_cmd where cmd_id=@pCmdId
	delete wcs_road_right where cmd_id=@pCmdId
	
	

	
	
END
GO
