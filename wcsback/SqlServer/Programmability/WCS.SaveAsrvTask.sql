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
drop proc WCS.SaveAsrvTask
go
CREATE PROCEDURE WCS.SaveAsrvTask
	@asrvId int,
	@whId int,
	@fromXNum int,
	@fromYNum int,
	@xNum int,
	@yNum int,
	@floorNum int,
	@taskType int,
	@pOut int output
with encryption
AS
BEGIN	
	SET NOCOUNT ON;
	declare @error varchar(100)
	DECLARE @cmd_id int

	if not exists(select 1 from wcs_asrv where asrv_id = @asrvId and has_task_flag = -1)
	begin
		insert into wcs_asrv_cmd (asrv_id,wh_id,from_x_num,from_y_num,to_x_num,to_y_num,to_floor_num,create_by,create_date,cell_num,task_type_id)
		values(@asrvId,@whId,@fromXNum,@fromYNum,@xNum,@yNum,@floorNum,2,getdate(),cast(@xNum as varchar(20))+'.'+cast(@yNum as varchar(20)),@taskType)

		select @pOut=@@IDENTITY

		SELECT @cmd_id = b.cmd_id FROM wcs_asrv a,wcs_asrv_cmd b WHERE  a.asrv_id = b.asrv_id AND a.has_task_flag = -1 AND a.asrv_id = @asrvId
		
		update wcs_asrv set has_task_flag = -1,current_cmd_id = @cmd_id  where asrv_id = @asrvId
	end
	else
	begin
		set @error = @asrvId + '号小车已有完成的任务'
		raiserror(@error,18,1)
		return
	end
	
	update a set a.level_flag = b.num from wcs_asrv_cmd a,
	(SELECT cmd_id, num = ROW_NUMBER()over(order by cmd_id) FROM wcs_asrv_cmd where Task_finish_flag = 0 and wh_id = @whId ) b
	WHERE a.cmd_id = b.cmd_id and a.Task_finish_flag = 0 and wh_id = @whId
	

END
GO
