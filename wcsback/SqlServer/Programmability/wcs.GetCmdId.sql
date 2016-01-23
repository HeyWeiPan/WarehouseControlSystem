drop procedure wcs.GetCmdId
go
create procedure wcs.GetCmdId
	@pCmdId int output
with encryption
as
begin
	declare @cmd_id int
	declare @asrv_id int
	declare @floor_num int
	declare @wh_id int

	if exists(select top 1 1 from wcs_asrv_cmd a,wcs_asrv b where a.asrv_id = b.asrv_id and a.from_x_num = b.x_num and a.from_y_num = b.y_num and a.task_finish_flag= 0 and b.has_task_flag = -1 and a.need_calcroute_flag = -1)
	begin
		--小车当前坐标等于任务的开始坐标
		select top 1 @cmd_id = a.cmd_id,@wh_id = b.wh_id,@floor_num = floor_num from wcs_asrv_cmd a,wcs_asrv b 
		where a.asrv_id = b.asrv_id
		 and a.from_x_num = b.x_num
		 and a.from_y_num = b.y_num 
		 and task_finish_flag= 0 
		 and b.has_task_flag = -1
		 order by a.cmd_id

		--update a set a.road_right_flag = 0 from wcs_cell a,wcs_asrv_cmd_route b where a.floor_num = b.floor_num and a.x_num =b.x_num 
		--and a.y_num = b.y_num and a.wh_id = @wh_id

		 delete from wcs_asrv_cmd_route where cmd_id = @cmd_id

		 delete from wcs_road_right where  cmd_id = @cmd_id

		 update wcs_asrv_cmd  set need_calcroute_flag = 0 where cmd_id = @cmd_id

		 set @pCmdId = @cmd_id
		 return
	end
	else
	begin
		select top 1 @cmd_id = cmd_id from wcs_asrv_cmd where task_finish_flag = 0 and asrv_id is null order by cmd_id
	end
	

	if isnull(@cmd_id,0) = 0
	begin
		set @pCmdId = 0;
		return
	end
	exec WCS.GetCommonAToBStepNum @cmd_id,@asrv_id output

	update wcs_asrv_cmd set asrv_id = @asrv_id where cmd_id = @cmd_id
	update wcs_asrv set has_task_flag = -1 where  asrv_id = @asrv_id and has_task_flag = 0
	set @pCmdId = @cmd_id

end