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
drop proc WCS.GetWhAsrvLocation
go
CREATE PROCEDURE WCS.GetWhAsrvLocation
	@pWhId int,
	@pFloorNum int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	select 
	asrv_id,
	asrv_code,
	cast(x_num as varchar)+'.'+cast(y_num  as varchar) location,
	case error_status when 0x00 then 0 else -1 end error_flag
	from wcs_Asrv where wh_id=@pWhId and floor_num=@pFloorNum and isnull(x_num,0)<>0 and isnull(y_num,0)<>0 order by asrv_code

	
END
GO
