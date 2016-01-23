
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Liberty
-- Create date: 2012/07/23
-- Description: 
-- =============================================
drop proc WCS.UpdateCellRight
go
CREATE PROCEDURE WCS.UpdateCellRight
	@wh_id int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	--A与B分别代表两辆小车
	declare @A_cmd_id int --任务id
	declare @B_cmd_id int

	declare @route_xml xml

	declare @t_road_right_route table (
		cmd_id int,
		asrv_id int,
		wh_id int,
		floor_num int,
		x_num int,
		y_num int,
		step_id int)


	--小车信息
	declare @t_Asrv table
	(
		cmd_id	int,
		deal_flag int

	)
	--如果小车有任务且任务还未执行完成。把该小车的信息存入临时表中
	insert into @t_Asrv(cmd_id,deal_flag)
	select 
	a.cmd_id,
	0
	from wcs_asrv_cmd a,wcs_asrv b
	where a.asrv_id = b.asrv_id 
	and a.cmd_id in(select cmd_id from wcs_asrv_cmd_route where pass_flag = 0 ) 
	and b.need_right_flag = -1 --是否需要设置权限
	--and a.operate_type = -1 --?
	and a.Task_finish_flag = 0
	and a.wh_id = @wh_id
	order by a.wh_id,a.cmd_id

	--根据任务先后相互进行比较，且任务还未被处理过
	declare c_a_route cursor for select cmd_id from @t_Asrv where deal_flag = 0 order by cmd_id
	open c_a_route
	fetch next from c_a_route into @A_cmd_id
	while(@@fetch_status = 0)
	begin		
		--将A车标志为已处理		
		update @t_Asrv set deal_flag = -1 where cmd_id = @A_cmd_id
		

		--将A车可行驶路径转换为XML格式
		set @route_xml = (SELECT cmd_id,asrv_id,wh_id,floor_num,x_num,y_num,step_id FROM wcs.GetCmdRoute(@wh_id,@A_cmd_id) FOR XML PATH,ROOT('route'))		

		--如果未处理的任务条数大于0
	
		--任务A与任务B比较
		declare c_b_route cursor for select cmd_id from @t_Asrv 
		where deal_flag = 0 order by cmd_id
		
		open c_b_route
		fetch next from c_b_route into @B_cmd_id
		while(@@fetch_status = 0)
		begin
			set @route_xml = wcs.CalculateRouteRight(@wh_id,@route_xml,@B_cmd_id)
				
			fetch next from c_b_route into @B_cmd_id
		end
		close c_b_route
		deallocate c_b_route
		

		--将获得的路径存入临时表中
		insert into @t_road_right_route(cmd_id,
		asrv_id,
		wh_id,
		floor_num,
		x_num,
		y_num,
		step_id)		
		exec wcs.XmlToTable @route_xml --将XML转换成为table
		
		--将小车标志为不需要分配权限
		update a set a.need_right_flag = 0 from wcs_asrv a,@t_road_right_route b
		where a.asrv_id = b.asrv_id

		----将路径表中的是否已经有路权的标志设置为-1
		update a set a.right_flag = -1 
		from wcs_asrv_cmd_route a, @t_road_right_route b 
		where a.cmd_id = b.cmd_id 
		and a.floor_num = b.floor_num 
		and a.x_num = b.x_num
		and a.y_num = b.y_num
		
		--设置路权
		update a set road_right_flag = 1 
		from wcs_cell a, @t_road_right_route b 
		where a.wh_id = b.wh_id 
		and a.floor_num = b.floor_num 
		and a.x_num = b.x_num 
		and a.y_num = b.y_num


		--将获得路权的路径信息存入路权表中
		insert into wcs_road_right(cell_id,asrv_id,step_id,cmd_id)
		select a.cell_id,b.asrv_id,b.step_id,b.cmd_id
		from wcs_cell a,@t_road_right_route b
		where a.wh_id = b.wh_id 
		and a.floor_num = b.floor_num 
		and a.x_num = b.x_num 
		and a.y_num = b.y_num
							
		fetch next from c_a_route into @A_cmd_id
	end
	close c_a_route
	deallocate c_a_route

	
END
GO
