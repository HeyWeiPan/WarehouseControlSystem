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
drop proc WCS.GetEquipmentLinkList
go
CREATE PROCEDURE WCS.GetEquipmentLinkList
	@pWhId int,
	@pTaskTypeId int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	select
	a.link_id,
	a.equipment_id,
	a.seq_id,
	WCS.GetEquipmentName(a.equipment_id) equipment_name
	from wcs_equipment_link a
	where a.wh_id=@pWhId and a.task_type_id=@pTaskTypeId order by seq_id
	
	
END
GO
