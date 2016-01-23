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
drop proc WCS.GetWHEquipmentList
go
CREATE PROCEDURE WCS.GetWHEquipmentList
	@pWhId int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;
	select
	equipment_id,
	WCS.GetEquipmentTypeName(equipment_type_id) equipment_type_name,
	equipment_code,
	equipment_name,
	x_num,
	y_num,
	floor_num,
	equipment_model,
	enable_flag
	from wcs_equipment where wh_id=@pWhId
	
	
END
GO
