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
drop proc WCS.UpdateAsrvMacAdress
go
CREATE PROCEDURE WCS.UpdateAsrvMacAdress
	@pKeyValue int,
	@pMac binary(8)
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	update wcs_asrv
	set mac_adress=@pMac
	where asrv_id=@pKeyValue
	
	
END
GO
