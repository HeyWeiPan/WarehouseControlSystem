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
drop proc WCS.GetEquipmentTypeList
go
CREATE PROCEDURE WCS.GetEquipmentTypeList
	with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	select 
	equipment_type_id,
	equipment_type_name,
	show_order,
	enable_flag,
	remark
	from wcs_equipment_type order by show_order
	
	
END
GO
