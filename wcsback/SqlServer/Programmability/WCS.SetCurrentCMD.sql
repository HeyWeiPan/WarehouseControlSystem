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
drop proc WCS.SetCurrentCMD
go
CREATE PROCEDURE WCS.SetCurrentCMD
	@pCmdId int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;




	declare @asrvId int
	declare @whId int

	select @asrvId=asrv_id,@whId=wh_id from wcs_asrv_cmd where cmd_id=@pCmdId

	update wcs_asrv_cmd
	set current_flag=0
	where asrv_id=@asrvId

	update wcs_asrv_cmd
	set current_flag=-1,
		end_Flag=0
	where cmd_id=@pCmdId
	

	update a
	set current_task_cells=0
	from wcs_asrv a
	where a.asrv_id=@asrvId

	update wcs_cell
	set asrv_road_right=null
	where asrv_road_right=@asrvId
	
	exec WCS.UpdateRoadRight @whId
	exec WCS.UpdateStepRight @pCmdId
END
GO
