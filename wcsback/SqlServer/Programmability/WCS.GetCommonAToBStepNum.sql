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
drop proc WCS.GetCommonAToBStepNum
go
CREATE PROCEDURE WCS.GetCommonAToBStepNum
	@pCmdId int,
	@pAsrvId	int output 
with encryption
AS
BEGIN	
-------------------------------------
----declare
-------------------------------------
	declare @from_x_num	int --起始X坐标
	declare @from_y_num	int	--起始Y坐标
	DECLARE @from_floor_num int
	declare @to_x_num	int	--目标X坐标
	declare @to_y_num	int --目标Y坐标
	declare @wh_id	int	--仓库id
	declare @cell_xf1 smallint	--X前进方向
	declare @cell_xb1 smallint	--X后退方向
	declare @cell_yf1 smallint	--Y前进方向
	declare @cell_yb1 smallint	--Y后退方向
	declare @asrv_id	int	--小车ID
	declare @Distance int	--距离
	declare @to_floor_num int	--目标楼层
	declare @RoadWay_x	int	--巷道X坐标
	declare @num INT
	

	---计算距离公式：abs(@from_x_num - @RoadWay_x) + abs(@from_y_num - @to_y_num) + abs(@RoadWay_x - @to_x_num)

---------------------------------------
----找到任务表中任务的坐标以及仓库id
---------------------------------------
	select @to_x_num = from_x_num,@to_y_num = from_y_num,@wh_id = wh_id,@to_floor_num = from_floor_num from wcs_asrv_cmd where cmd_id = @pCmdId

---------------------------------------
----找到当前仓库中可用且无任务的车子
---------------------------------------
	declare @t table
	(
		asrv_id int,
		x_num	int,
		y_num	INT,
		floor_num INT
	)
	insert into @t(asrv_id,x_num,y_num,floor_num) 
	select v.asrv_id,v.x_num,v.y_num,v.floor_num
	  from wcs_asrv v,wcs_wh h where v.wh_id = h.wh_id and v.wh_id = @wh_id and  v.enable_flag = -1 and v.has_task_flag = 0

	--获取巷道的x坐标
	declare @wcs_cell table(RoadWay_x int)
	insert into @wcs_cell(RoadWay_x)
	select x_num from wcs_cell where celltype_code = 0 and floor_num = @to_floor_num and wh_id = @wh_id  group by x_num 

---------------------------------------
----分别计算每一辆车子离A点的距离
---------------------------------------
	declare c_c cursor for select asrv_id,x_num,y_num,FLOOR_num  from @t 
	open c_c 
	fetch next from c_c into @asrv_id,@from_x_num,@from_y_num,@from_floor_num
	while(@@fetch_status=0)
	begin
		set @Distance = 0
---------------------------------------------
---取A点与B点之间的最短距离
---------------------------------------------
		declare c_distance cursor for select RoadWay_x from @wcs_cell
		open c_distance
		fetch next from c_distance into @RoadWay_x
		while(@@fetch_status = 0)
		begin
			set @num = 0

			--如果起点或终点刚好在巷道上或者A点Y坐标等于B点Y坐标	
			if @RoadWay_x = @to_x_num  or @RoadWay_x = @from_x_num  or @from_y_num = @to_y_num
			begin
				set @num = abs(@from_x_num - @to_x_num) + abs(@from_y_num - @to_y_num)
			end
			else
			begin
				set @num = abs(@from_x_num - @RoadWay_x) + abs(@from_y_num - @to_y_num) + abs(@RoadWay_x - @to_x_num)
			end

			if @Distance = 0
			begin
				set @Distance = @num			
			end
			else
			begin
				if @Distance > @num
				begin
					set @Distance = @num
				end
			end
			fetch next from c_distance into @RoadWay_x
		end
		close c_distance
		deallocate c_distance

		---更新A点与B点之间的距离
		update wcs_asrv set a_b_distance = @Distance where asrv_id = @asrv_id 


		----如果车的位置未到达目标点
		--while (@from_x_num = @to_x_num and @from_y_num = @to_y_num)
		--begin
		--	--根据小车的坐标找到当前格子的类型
		--	select 
		--	@cell_xf1 = cell_xf1,
		--	@cell_xb1 = cell_xb1,
		--	@cell_yf1 = cell_yf1,
		--	@cell_yb1 = cell_yb1 
		--	from wcs_cell where x_num = @from_x_num and y_num = @from_y_num

		--	--如果A点y坐标大于B点y坐标，则y-1。小于y+1
		--	if @from_y_num - @to_y_num > 0
		--	begin
		--		if @cell_yb1 = -1 --如果y方向可以后退
		--		begin
		--			set @from_y_num = @from_y_num - 1
		--			set @Distance = @Distance + 1
		--			break;
		--		end
		--	end
		--	else if @from_y_num - @to_y_num < 0 
		--	begin
		--		if @cell_yf1 = -1 --如果y方向可以前进
		--		begin
		--			set @from_y_num = @from_y_num + 1
		--			set @Distance = @Distance + 1
		--			break;
		--		end
		--	end

			
		--	--如果A点x坐标大于B点x坐标，则x-1。小于x+1
		--	if @from_x_num - @to_x_num > 0
		--	begin
		--		if @cell_xb1 = -1 --如果x方向可以后退
		--		begin
		--			set @from_x_num = @from_x_num - 1;
		--			set @Distance = @Distance + 1
		--			break;
		--		end
		--	end 
		--	else if  @from_x_num - @to_x_num < 0
		--	begin
		--		if @cell_xf1 = -1 --如果x方向可以前进
		--		begin
		--			set @from_x_num = @from_x_num + 1;
		--			set @Distance = @Distance + 1
		--			break;
		--		end
		--	end
		
		--end

		update wcs_asrv set a_b_distance = @Distance where asrv_id = @asrv_id 
		fetch next from c_c into @asrv_id,@from_x_num,@from_y_num,@from_floor_num
	end
	close c_c
	deallocate c_c
	
	--获取距离A点最近的车子
	select top 1 @pAsrvId = v.asrv_id from wcs_asrv v,wcs_wh h 
	where v.wh_id = h.wh_id AND h.wh_id = @wh_id and  v.enable_flag = -1 and v.has_task_flag = 0
	order by v.a_b_distance

END
GO
