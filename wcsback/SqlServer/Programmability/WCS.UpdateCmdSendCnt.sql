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
drop proc WCS.UpdateCmdSendCnt
go
CREATE PROCEDURE WCS.UpdateCmdSendCnt
	@pCmdId int,
	@pCnt int,
	@pMaxSendCnt int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;


	--如果发送次数大于定义的最大发送次数 则任务报错
	update wcs_asrv_cmd
	set send_cnt=@pCnt,
		error_flag=case when @pCnt>@pMaxSendCnt then -1 else 0 end
	where cmd_id=@pCmdId

	
END
GO
