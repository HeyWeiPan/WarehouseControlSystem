use biz
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
drop proc WCS.GetEquipmentDetail
go
CREATE PROCEDURE WCS.GetEquipmentDetail
	@pKeyValue int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	select
	a.equipment_id,
	a.equipment_code,
	a.equipment_name,
	a.equipment_type_id,
	b.equipment_type_name,
	a.equipment_model,
	a.floor_num,
	a.x_num,
	a.y_num,
	a.enable_flag,
	a.remark,
	a.wh_id,
	c.wh_code
	from wcs_equipment a,wcs_equipment_type b,wcs_wh c
	where a.equipment_id=@pKeyValue and a.equipment_type_id=b.equipment_type_id and c.wh_id=a.wh_id
	
	
END
GO
