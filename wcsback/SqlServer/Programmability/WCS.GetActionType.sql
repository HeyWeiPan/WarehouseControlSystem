drop procedure WCS.GetActionType
go
create procedure WCS.GetActionType
	@pCmdId int,
	@start_x int,
	@start_y int,
	@end_x	int,
	@end_y	int,
	@result binary output
with encryption
as
begin
	
	if (select step_id from wcs_asrv_cmd_route where cmd_id = @pCmdId and x_num = @start_x and y_num = @start_y) = 1
	begin
		if (select task_type_id from wcs_asrv_cmd where cmd_id = @pCmdId) = 1
		begin
			set @result = 3
			return 
		end
		if (select task_type_id from wcs_asrv_cmd where cmd_id = @pCmdId) = 2
		begin
			set @result = 2
			return 
		end
	end
	if (select step_id from wcs_asrv_cmd_route where cmd_id = @pCmdId and x_num = @end_x and y_num = @end_y) = (select max(step_id) from wcs_asrv_cmd_route where cmd_id = @pCmdId)
	begin
		if (select task_type_id from wcs_asrv_cmd where cmd_id = @pCmdId) = 1
		begin
			set @result = 3
			return 
		end
		if (select task_type_id from wcs_asrv_cmd where cmd_id = @pCmdId) = 2
		begin
			set @result = 2
			return 
		end
	end

	set @result = 00
end
