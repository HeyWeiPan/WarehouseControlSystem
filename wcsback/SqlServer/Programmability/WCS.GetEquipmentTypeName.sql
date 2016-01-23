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
drop function WCS.GetEquipmentTypeName
go
CREATE function WCS.GetEquipmentTypeName
	(
		@pTypeId int
	)
	returns nvarchar(60)
with encryption
AS
BEGIN	
	
	declare @name nvarchar(60)

	select @name=equipment_type_name from wcs_equipment_type where equipment_type_id=@pTypeId


	return @name
	


END
GO
