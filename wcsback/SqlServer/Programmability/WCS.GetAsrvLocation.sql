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
drop function WCS.GetAsrvLocation
go
CREATE function WCS.GetAsrvLocation
	(
	@pWhID int,
	@floorNum int,
	@cellNum varchar(20)
	)
	returns varchar(500)
with encryption
AS
BEGIN	
	
	declare @asrvCode varchar(20)

	select @asrvCode=asrv_code from wcs_asrv where (cast(x_num as varchar(20))+'.'+cast(y_num as varchar(20)))=@cellNum and wh_id=@pWhId and floor_num=@floorNum


	if(isnull(@asrvCode,'')='')
	begin
	  return '';
	end


	return '<img src="images\teamfree.png" title="'+@asrvCode+'" width="30px" height="30px" />'
	


END
GO
