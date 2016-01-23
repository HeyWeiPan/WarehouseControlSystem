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
drop proc WCS.GetTaskCmdByWhCode
go
CREATE PROCEDURE WCS.GetTaskCmdByWhCode
	@pWhCode nvarchar(60)
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	declare @whId int

	select @whId=wh_id from wcs_wh where wh_code=@pWhCode


	
	declare @t table(cmd_id int,send_cnt int,cmd varbinary(max),status binary(2))
	declare @asrvId int
	declare @status binary(2)
	declare c_a cursor for select asrv_id,current_status from wcs_asrv where enable_flag=-1 and wh_id=@whId
	open c_a
	fetch next from c_a into @asrvId,@status
	while(@@fetch_status=0)
	begin
		
		insert into @t
		select 
		top 1
		b.cmd_id,
		b.send_cnt,
		cmd_b_code,
		@status
		from wcs_cmd_breakdown a,wcs_asrv_cmd b
		where a.asrv_id=b.asrv_id and a.cmd_id=b.cmd_id and b.end_flag=0 and b.asrv_id=@asrvId and b.error_flag=0 order by b.create_date


		fetch next from c_a into @asrvId,@status
	end
	close c_a
	deallocate c_a

	select 
	cmd_id,
	send_cnt,
	cmd,
	status
	from @t

END
GO
