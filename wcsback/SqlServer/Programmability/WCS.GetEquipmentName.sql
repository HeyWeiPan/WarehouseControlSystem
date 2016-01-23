﻿-- ================================================
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
drop function WCS.GetEquipmentName
go
CREATE function WCS.GetEquipmentName
	(
		@pTypeId int
	)
	returns nvarchar(60)
with encryption
AS
BEGIN	
	

	if(@pTypeId=0)
	begin

		return '小车'

	end

	declare @name nvarchar(60)

	select @name=equipment_code+'--'+equipment_name from wcs_equipment where equipment_id=@pTypeId


	return @name
	


END
GO
