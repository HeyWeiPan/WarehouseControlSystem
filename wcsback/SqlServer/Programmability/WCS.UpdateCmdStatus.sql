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
drop proc WCS.UpdateCmdStatus
go
CREATE PROCEDURE WCS.UpdateCmdStatus
	@pAdress binary(8)
with encryption
AS
BEGIN	
	SET NOCOUNT ON;


	declare @cmdId int





	select top 1 @cmdId=cmd_id from wcs_asrv_cmd a,wcs_asrv b where a.asrv_id=b.asrv_id and a.end_flag=0 and a.error_Flag=0 and b.address=@pAdress order by a.create_date

	update a
	set current_flag=0
	from wcs_asrv_cmd a,wcs_asrv b
	where a.asrv_id=b.asrv_id and a.end_flag=0 and a.error_Flag=0 and b.address=@pAdress 




	update wcs_Asrv_cmd
	set end_flag=-1,
		current_flag=-1
	where cmd_id=@cmdId

	--路权初始化
	
	update a
	set current_task_cells=0
	from wcs_asrv a,wcs_Asrv_cmd b
	where a.asrv_id=b.asrv_id and b.cmd_id=@cmdId
	






	
END
GO
