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
drop proc WCS.IsChannel
go
CREATE PROCEDURE WCS.IsChannel
	@pCmdId int,
	@start_x int,
	@start_y int,
	@end_x	int,
	@end_y	int,
	@result int output
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	
	declare @direction varchar(10)

	--如果终点坐标在巷道上
	if (SELECT TOP 1 celltype_code from wcs_cell 
	    where wh_id = (select wh_id from wcs_asrv_cmd where cmd_id = @pCmdId) 
	    and x_num = @end_x and y_num = @end_y) = 0
	begin	
		set @result = 0
		return
	end

	select @direction = h.channel_direction from wcs_wh h,wcs_asrv_cmd c where h.wh_id = c.wh_id and c.cmd_id = @pCmdId

	
	--如果x方向为货道
	if @direction = 'x'
	begin
		--x坐标相等
		if @start_x = @end_x
		begin
			--y轴终点坐标大于起点坐标
			if @end_y > @start_y
			begin
				--如果存在大于y轴终点坐标的巷道
				if exists(select top 1 1 from wcs_cell where  wh_id = (select wh_id from wcs_asrv_cmd where cmd_id = @pCmdId) and celltype_code = 0 and y_num > @end_y ) 
				begin
					--如果巷道y轴坐标与路径终点坐标相差为1
					if(select top 1 y_num from wcs_cell where  wh_id = (select wh_id from wcs_asrv_cmd where cmd_id = @pCmdId) and celltype_code = 0 and y_num > @end_y) - @end_y  = 1
					begin
						set  @result = 1
						return
					end
				end
			end
			else
			begin
				if exists(select top 1 1 from wcs_cell where  wh_id = (select wh_id from wcs_asrv_cmd where cmd_id = @pCmdId) and celltype_code = 0 and y_num < @end_y ) 
				begin
					if @end_y - (select top 1 y_num from wcs_cell where  wh_id = (select wh_id from wcs_asrv_cmd where cmd_id = @pCmdId) and celltype_code = 0 and y_num < @end_y)  = 1
					begin
						set  @result = 1
						return
					end
				end
			end
		end
	end
	else 
	begin
		--x坐标相等
		if @start_y = @end_y
		begin
			--y轴终点坐标大于起点坐标
			if @end_x > @start_x
			begin
				if exists(select top 1 1 from wcs_cell where  wh_id = (select wh_id from wcs_asrv_cmd where cmd_id = @pCmdId) and celltype_code = 0 and x_num > @end_x ) 
				begin
					if(select top 1 x_num from wcs_cell where  wh_id = (select wh_id from wcs_asrv_cmd where cmd_id = @pCmdId) and celltype_code = 0 and x_num > @end_x) - @end_x  = 1
					begin
						set  @result = 1
						return
					end
				end
			end
			else
			begin
				if exists(select top 1 1 from wcs_cell where  wh_id = (select wh_id from wcs_asrv_cmd where cmd_id = @pCmdId) and celltype_code = 0 and x_num < @end_x ) 
				begin
					if @end_x - (select top 1 x_num from wcs_cell where  wh_id = (select wh_id from wcs_asrv_cmd where cmd_id = @pCmdId) and celltype_code = 0 and x_num < @end_x)  = 1
					begin
						set  @result = 1
						return
					end
				end
			end
		end
	end

	set @result = 0
END
GO
