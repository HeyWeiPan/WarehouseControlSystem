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
drop proc WCS.GetWCSWHDetail
go
CREATE PROCEDURE WCS.GetWCSWHDetail
	@pKeyValue int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	select
	wh_id,
	wh_code,
	wh_name,
	enable_flag,
	cell_width,
	cell_depth,
	cell_margin,
	aisle_margin,
	channel_gap,
	x_num_from,
	x_num_to,
	y_num_from,
	y_num_to,
	channel_direction,
	ip_adress,
	port
	from wcs_wh where wh_id=@pKeyValue
	
	
END
GO
