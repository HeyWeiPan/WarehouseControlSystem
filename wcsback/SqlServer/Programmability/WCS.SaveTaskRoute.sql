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
drop proc WCS.SaveTaskRoute
go
CREATE PROCEDURE WCS.SaveTaskRoute
	@pCmdId int,
	@pXml xml
with encryption
AS
BEGIN	
	SET NOCOUNT ON;
		declare @x_num int
		declare @y_num int
		declare @floor_num int
		
		delete wcs_cmd_breakdown where  cmd_id=@pCmdId
		delete wcs_asrv_cmd_route where cmd_id=@pCmdId

		select @x_num = a.x_num,@y_num = a.y_num,@floor_Num= a.floor_Num 
		from wcs_asrv a,wcs_asrv_cmd b
		where a.asrv_id = b.asrv_id and b.cmd_id = @pCmdId

		insert into wcs_asrv_cmd_route(cmd_id,step_id,cell_num,floor_num,x_num,y_num)
		select @pCmdId,0,cast(@x_num as varchar(10))+'.'+cast(@y_num as varchar(10)),@floor_num,@x_num,@y_num 

		insert into wcs_asrv_cmd_route(cmd_id,step_id,cell_num,floor_num)
		select 
		@pCmdId,
		a.value('(step_id/text())[1]', 'int') step_id,
		a.value('(cell_num/text())[1]', 'varchar(20)') cell_num,
		a.value('(floor_num/text())[1]', 'int') floor_num
		from @pXml.nodes('/NewDataSet/Table1') as T(a)


		update wcs_asrv_cmd_route
		set x_num=cast(substring(cell_num,1,charindex('.',cell_num)-1) as int),
		    y_num=cast(substring(cell_num,charindex('.',cell_num)+1,len(cell_num)) as int)
		where cmd_id=@pCmdId

		
END
GO
