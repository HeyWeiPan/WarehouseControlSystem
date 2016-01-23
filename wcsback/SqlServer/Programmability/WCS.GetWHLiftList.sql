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
drop proc WCS.GetWHLiftList
go
CREATE PROCEDURE WCS.GetWHLiftList
	@pWhId int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	select
	lift_id,
	wh_id,
	lift_code,
	description,
	x_num,
	y_num
	from wcs_lift where wh_id=@pWhId
	
	
END
GO
