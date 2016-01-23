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
drop proc WCS.InsertCmdBreakdown
go
CREATE PROCEDURE WCS.InsertCmdBreakdown
	@pCmdId int,
	@pData varbinary(max),
	@pType nvarchar(20)
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	if exists(select 1 from wcs_cmd_breakdown where cmd_id = @pCmdId and cmd_type = 'TOKEN')
	begin
		delete wcs_cmd_breakdown where cmd_id = @pCmdId and cmd_type = 'TOKEN'
	end
	
	
	insert into wcs_cmd_Breakdown
	(
		cmd_id,
		asrv_id,
		cmd_type,
		cmd_b_code,
		cmd_b_date
	)
	select 
	cmd_id,
	asrv_id,
	@pType,
	@pData,
	getdate()
	from wcs_asrv_cmd where cmd_id=@pCmdId
	
	
END
GO
