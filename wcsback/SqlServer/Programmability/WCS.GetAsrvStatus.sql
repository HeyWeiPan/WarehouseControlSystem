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
drop proc WCS.GetAsrvStatus
go
CREATE proc WCS.GetAsrvStatus
	@pAsrvId int
with encryption
AS
BEGIN	


	select current_status,error_status,bat_vol from wcs_asrv where asrv_id=@pAsrvId

END
GO
