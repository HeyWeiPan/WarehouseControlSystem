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
drop proc WCS.UpdateAsrvStatus
go
CREATE PROCEDURE WCS.UpdateAsrvStatus
	@pArea	int,
	@pAdress binary(8),
	@pFloor int,
	@pX int,
	@pY int,
	@pTaskId int,
	@pPower int,
	@pStatus binary(2),
	@pError binary(1)
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	declare @asrv_id int
	declare @wh_id int
	declare @floor_num int
	declare @x_num int
	declare @y_num int
	declare @cmd_id int

	declare @maxStep int
	declare @currentStep int

	declare @to_x_num int
	declare @to_y_num int
	declare @to_floor_num int

	declare @from_x_num int
	declare @from_y_num int
	declare @from_floor_num int

	--UPDATE a SET a.road_right_flag = 0 FROM wcs_cell a,wcs_asrv b
	--WHERE a.wh_id = b.wh_id AND a.floor_num = b.floor_num AND a.x_num = b.x_num AND a.y_num = b.y_num and b.address = @pAdress and has_task_flag = -1

	--UPDATE a SET a.road_right_flag = 2 FROM wcs_cell a,wcs_asrv b
	--WHERE a.wh_id = b.wh_id AND a.floor_num = b.floor_num AND a.x_num = b.x_num AND a.y_num = b.y_num and b.address = @pAdress and has_task_flag = 0

	update wcs_asrv
	set area_id = @pArea,
		floor_num=@pFloor,
		x_num=@pX,
		y_num=@pY,
		task_id=@pTaskId,
		bat_vol=@pPower,
		current_status=@pStatus,
		error_status=@pError
	where address=@pAdress


	select @asrv_id = asrv_id,@wh_id = wh_id,@floor_num = floor_num,@x_num = x_num,@y_num = y_num from wcs_asrv where address = @pAdress 

	--获取未完成的任务编号
	select @cmd_id = cmd_id from wcs_asrv_cmd where task_finish_flag = 0 and asrv_id = @asrv_id

	select @to_x_num = to_x_num,@to_y_num = to_y_num,@to_floor_num = to_floor_num,@from_x_num = from_x_num,@from_y_num = from_y_num,@from_floor_num = from_floor_num from wcs_asrv_cmd where cmd_id = @cmd_id

	--已发令牌的最大步数
	select @maxStep = max(step_id) from wcs_asrv_cmd_route where cmd_id = @cmd_id and right_flag = -1

	--小车当前位置的步数
	select @currentStep = step_id from wcs_asrv_cmd_route where cmd_id = @cmd_id and floor_num = @pFloor and x_num = @pX and y_num = @pY

	declare @CmdId	int
	declare @StepId	int
	declare @FloorNum	int
	declare @xNum	int
	declare @yNum	int

	--路权释放临时表
	declare @t_road_right_release table (
		cmd_id	int,
		step_id	int,
		floor_num	int,
		x_num	int,
		y_num	int,
		wh_id	int
	)
	
	insert into @t_road_right_release(cmd_id,step_id,floor_num,x_num,y_num,wh_id)
	select b.cmd_id,b.step_id,b.floor_num,b.x_num,b.y_num,a.wh_id 
	from wcs_asrv_cmd a,wcs_asrv_cmd_route b
	where a.cmd_id = b.cmd_id AND a.cmd_id = @cmd_id and b.step_id between 0 and @currentStep - 1 and b.release_flag = 0 and b.right_flag= -1 and a.task_finish_flag = 0

	update a set a.road_right_flag = 0
	from wcs_cell a , @t_road_right_release b 
	where a.wh_id = b.wh_id 
	and a.floor_num = b.floor_num
	and a.x_num = b.x_num
	and a.y_num = b.y_num
	--and a.road_right_flag = 1

	update a set a.pass_flag = -1 
	from wcs_asrv_cmd_route a,@t_road_right_release b
	where a.cmd_id = b.cmd_id and a.floor_num = b.floor_num and a.x_num = b.x_num and a.y_num = b.y_num  

	--已释放的路权设置为-1
	update a set a.release_flag = -1 
	from wcs_asrv_cmd_route a,@t_road_right_release b 
	where a.cmd_id = b.cmd_id and a.step_id = b.step_id

	--如果小车当前位置的步数等于任务路径的最大步数，将任务状态改为已完成
	if @pX = @to_x_num and @pY = @to_y_num and @pFloor = @to_floor_num
	BEGIN
		update a set a.right_flag = -1,a.pass_flag = -1,a.release_flag = -1 
		from wcs_asrv_cmd_route a where a.step_id in(
		select top 2 step_id from wcs_asrv_cmd_route where cmd_id = @cmd_id order by step_id desc)

		--update a set a.road_right_flag = 0 from wcs_cell a,wcs_asrv_cmd_route b
		--where a.x_num = b.x_num and a.y_num = b.y_num and a.floor_num = b.floor_num 
		--and a.wh_id = @wh_id and step_id = @currentStep - 1
		
		--将小车状态设置为需要分配令牌
		update wcs_asrv set need_right_flag = -1 where asrv_id = @asrv_id
		
		--将储物格的权限设置为2, 2:格子被小车占用,且小车可以移动
		update wcs_cell set road_right_flag = 2 where wh_id =  @wh_id and floor_num = @floor_num and x_num = @pX and y_num = @pY
		
		--将任务状态设置为已完成
		update wcs_asrv_cmd set Task_finish_flag = -1 where cmd_id = @cmd_id

		--将小车设置为空车状态
		update wcs_asrv set has_task_flag  = 0 where asrv_id = @asrv_id

		update wcs_asrv_cmd_route set pass_flag = -1 where cmd_id = @cmd_id and step_id = @currentStep

		--清空当前小车的任务路权记录
		--delete wcs_road_right where cmd_id = @cmd_id and asrv_id = @asrv_id

		return
	end


	--当前小车路径数量少于规定数量
 	if (@maxStep - @currentStep) < 3 
	begin
		--将小车状态设置为需要发放令牌
		update wcs_asrv set need_right_flag = -1 where asrv_id = @asrv_id

		
	end

	--发放令牌命令
		--exec WCS.SetRoadRight
	
END
GO

