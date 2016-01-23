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
-- Create date: 2015-3-11
-- Description: 
-- =============================================
drop proc WCS.SendNextCmd
go
CREATE PROCEDURE WCS.SendNextCmd
	@address varchar(100),
	@pCmdId int output
with encryption
AS
BEGIN	
	SET NOCOUNT ON;
	
	declare @cmd_id	int
	declare @asrv_x_num  int
	declare @asrv_y_num	 int
	declare @to_x_num int
	declare @to_y_num int
	declare @from_x_num int
	declare @from_y_num int

	select @cmd_id = b.cmd_id from wcs_asrv a,wcs_asrv_cmd b where a.asrv_id = b.asrv_id and a.has_task_flag = -1 and b.task_finish_flag = 0 and address = @address

	set @pCmdId = @cmd_id

	if @cmd_id = 0
	begin
		return
	end


	select @asrv_x_num = a.x_num,@asrv_y_num = a.y_num,@to_x_num = to_x_num,@to_y_num = to_y_num ,@from_x_num = b.from_x_num,@from_y_num = from_y_num
	from wcs_asrv a,wcs_asrv_cmd b
	where a.asrv_id = b.asrv_id and b.cmd_id = @cmd_id

	if @asrv_x_num <> @from_x_num and @asrv_y_num <> @from_y_num
	begin
		set @pCmdId = 0
		return
	end
	else
	begin
		set @pCmdId = @cmd_id
		return
	end


	--如果小车当前位置与任务终点位置一样，本次任务完成
	if @asrv_x_num = @to_x_num and @asrv_y_num = @to_y_num 
	begin
		set @pCmdId = 0
	end

END
GO
