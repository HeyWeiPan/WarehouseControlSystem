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
drop proc WCS.XmlToTable
go
CREATE PROCEDURE WCS.XmlToTable
	@pXml xml
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

		select 
		a.value('(cmd_id/text())[1]', 'int') cmd_id,
		a.value('(asrv_id/text())[1]', 'int') asrv_id,
		a.value('(wh_id/text())[1]', 'int') wh_id,
		a.value('(floor_num/text())[1]', 'int') floor_num,
		a.value('(x_num/text())[1]', 'int') x_num,
		a.value('(y_num/text())[1]', 'int') y_num,
		a.value('(step_id/text())[1]', 'int') step_id
		from @pXml.nodes('/route/row') as T(a)
			

	
END
GO
