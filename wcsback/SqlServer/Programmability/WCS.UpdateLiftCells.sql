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
drop proc WCS.UpdateLiftCells
go
CREATE PROCEDURE WCS.UpdateLiftCells
	@pLiftId int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;
	
	declare @whId int
	declare @cellNum varchar(20)
	select 
	@whId=wh_id,
	@cellNum=cast(x_num as varchar(10))+'.'+cast(y_num as varchar(10))

	from wcs_lift where lift_id=@pLiftId


	update wcs_cell
	set celltype_code=2
	where wh_id=@whId and cell_num=@cellNum

	
END
GO
