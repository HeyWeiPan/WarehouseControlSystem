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
drop proc WCS.GetAsrvRoute
go
CREATE proc WCS.GetAsrvRoute
	@pCmdId int
with encryption
AS
BEGIN	


	select cell_num,x_num,y_num,floor_num from wcs_asrv_cmd_route where cmd_id=@pCmdId order by step_id 

	

END
GO
