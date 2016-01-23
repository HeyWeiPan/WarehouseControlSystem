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
drop proc WCS.RouteTest
go
CREATE PROCEDURE WCS.RouteTest
	@pXml xml
with encryption
AS
BEGIN	
	SET NOCOUNT ON;
	
		
		insert into wcs_test(pre_num,next_num,step)
		select 
		a.value('(pre_num/text())[1]', 'varchar(20)') next_num,
		a.value('(next_num/text())[1]', 'varchar(20)') next_num,
		a.value('(step/text())[1]', 'int') step
		from @pXml.nodes('/NewDataSet/Table1') as T(a)


			

	
END
GO
