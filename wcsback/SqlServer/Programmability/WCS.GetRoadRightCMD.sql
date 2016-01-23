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
drop proc WCS.GetRoadRightCMD
go
CREATE PROCEDURE WCS.GetRoadRightCMD
	
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	declare @t table(cmd_id int,step_num int,address binary(8),asrv_id int)

	
	--更新路权
	--exec WCS.UpdateRoadRight @whId
	--exec WCS.UpdateCellRight

	declare @cmd_id int
	declare @asrv_id int

	declare c_c cursor for select cmd_id,asrv_id from wcs_road_right group by cmd_id,asrv_id order by cmd_id 
	open c_c
	fetch next from c_c into @cmd_id,@asrv_id
	while(@@fetch_status = 0)
	begin
		insert into @t(cmd_id,step_num,address,asrv_id)
		select @cmd_id,(select count(*) from wcs_asrv_cmd_route where cmd_id = @cmd_id and right_flag = -1),(select address from wcs_asrv where asrv_id = @asrv_id),@asrv_id

		fetch next from c_c into @cmd_id,@asrv_id
	end
	close c_c
	deallocate c_c
	
	select cmd_id,step_num,address,asrv_id from @t

END
GO
