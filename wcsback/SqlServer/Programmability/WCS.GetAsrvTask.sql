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
use biz
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Liberty
-- Create date: 2012/07/23
-- Description: 
-- =============================================
drop proc WCS.GetAsrvTask
go
CREATE PROCEDURE WCS.GetAsrvTask
	@pEndFlag smallint
with encryption
AS
BEGIN	

	select 
	top 20
	a.asrv_id,
	a.asrv_code,
	b.cmd_id,
	b.wh_id,
	b.from_floor_num,
	b.to_floor_num,
	task_desc=a.asrv_code+'从'+cast(isnull(b.from_floor_num,1) as varchar(10))+'楼'+cast(b.from_x_num as varchar(10))+'.'+cast(b.from_y_num as varchar(10))
	+'到'+cast(b.to_floor_num as varchar(10))+'楼'+cast(b.to_x_num as varchar(10))+'.'+cast(b.to_y_num as varchar(10)) 
	from wcs_asrv a,wcs_asrv_cmd b
	where a.asrv_id=b.asrv_id and b.task_finish_flag=@pEndFlag order by b.create_date desc
	
END
GO
