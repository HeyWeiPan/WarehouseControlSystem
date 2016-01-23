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
drop proc WCS.GetTaskDetail
go
CREATE PROCEDURE WCS.GetTaskDetail
	@pCmdId int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	declare @from_x_num int
	declare @from_y_num int
	declare @asrv_x_num int
	declare @asrv_y_num int

	select @asrv_x_num = a.x_num ,@asrv_y_num = a.y_num,@from_x_num = b.from_x_num,@from_y_num = b.from_y_num 
	from wcs_asrv a,wcs_asrv_cmd b
	where a.asrv_id = b.asrv_id and b.cmd_id = @pCmdId

	--如果小车当前所在位置与任务A点位置是同一点
	if @from_x_num = @asrv_x_num and @from_y_num = @asrv_y_num
	begin
		select 
		a.x_num current_x_num,
		a.y_num current_y_num,
		cast(a.x_num as varchar)+'.'+cast(a.y_num as varchar) as current_cell_num,
		a.channel_direction,
		a.floor_num current_floor,
		b.to_x_num,
		b.to_y_num,
		b.to_floor_num,
		b.cell_num to_cell_num,
		b.task_type_id,
		cast(b.from_x_num as varchar) +'.'+cast(b.from_y_num as varchar) as from_cell_num,
		xf,
		xb,
		yf,
		yb,
		a.mac_adress
		from wcs_asrv a,wcs_asrv_cmd b
		where a.asrv_id=b.asrv_id and b.cmd_id=@pCmdId
	end
	else
	begin
		select 
		a.x_num current_x_num,
		a.y_num current_y_num,
		cast(a.x_num as varchar)+'.'+cast(a.y_num as varchar) as current_cell_num,
		a.channel_direction,
		a.floor_num current_floor,
		b.from_x_num to_x_num,
		b.from_y_num to_y_num,
		b.to_floor_num,
		b.cell_num to_cell_num,
		b.task_type_id,
		cast(b.from_x_num as varchar) +'.'+cast(b.from_y_num as varchar) as from_cell_num,
		xf,
		xb,
		yf,
		yb,
		a.mac_adress
		from wcs_asrv a,wcs_asrv_cmd b
		where a.asrv_id=b.asrv_id and b.cmd_id=@pCmdId
	end

	
	
END
GO
