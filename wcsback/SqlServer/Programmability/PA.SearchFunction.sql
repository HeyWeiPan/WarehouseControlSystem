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
-- Create date: 2012/06/26
-- Description: 
-- =============================================
drop proc PA.SearchFunction
go
CREATE PROCEDURE PA.SearchFunction
@pFunctionName nvarchar(250),
@pUserId int
with encryption	
AS
BEGIN	
	SET NOCOUNT ON;
       		
    
	declare @t table(function_id int)


	insert @t
	select
	top 1
	function_id
	from scr_function

    exec security.CheckFuncRight_UserFuncOper @pUserId,6800300,1,@rightFlag output

END
GO
