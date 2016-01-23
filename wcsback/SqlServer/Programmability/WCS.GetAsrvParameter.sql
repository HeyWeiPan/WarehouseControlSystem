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
drop proc WCS.GetAsrvParameter
go
CREATE PROCEDURE WCS.GetAsrvParameter
	@pAsrvId int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;
	select
	b.ip_adress ip,
	b.port,
	a.address mac_address
	from wcs_asrv a,wcs_wh b
	where a.wh_id=b.wh_id and a.asrv_id=@pAsrvId

	
	
END
GO
