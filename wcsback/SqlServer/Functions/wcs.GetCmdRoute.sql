drop function wcs.GetCmdRoute
go
create function wcs.GetCmdRoute
(
	@wh_id int,
	@cmd_id int
)
returns @t_cmd_route table (
		id int identity(1,1),
		cmd_id int,
		asrv_id int,
		wh_id int,
		floor_num int,
		x_num int,
		y_num int,
		step_id int,
		celltype_code int
		)
with encryption
as
begin
	
	declare @CelltypeCode int	--格子的类型
	declare @forward_cell_num int	--巷道中可以走的步数
	declare @min_step_id int
	set @min_step_id = 0

	select  @forward_cell_num = a.forward_cell_num from wcs_token_strategy a,wcs_wh b where a.token_strategy_id = b.token_strategy_id and  b.wh_id = @wh_id

	--将待分配路权的路径存入临时表
	insert into @t_cmd_route(cmd_id,asrv_id,wh_id,floor_num,x_num,y_num,step_id)
	select a.cmd_id,b.asrv_id,b.wh_id,a.floor_num,a.x_num,a.y_num,step_id from wcs_asrv_cmd_route a,wcs_asrv_cmd b
	where a.cmd_id = b.cmd_id and b.wh_id = @wh_id and a.cmd_id = @cmd_id and a.right_flag  = 0 order by a.step_id

	--更新路径中每个格子的类型
	--1 货道无货； 0 巷道 ； 3 货道有货
	update a set a.celltype_code = case b.celltype_code when 3 then 1 
														when 0 then 0 
														when 1 then 1 end  
	from @t_cmd_route a,wcs_cell b 
	where  a.wh_id = b.wh_id 
	and a.floor_num = b.floor_num 
	and a.x_num = b.x_num 
	and a.y_num = b.y_num 

	--如果临时表中存在格子类型为空的情况
	--if exists(select 1 from @t_cmd_route where celltype_code is null)
	--begin		
	--	delete @t_cmd_route where step_id >= (select min(step_id) from @t_cmd_route where celltype_code is null)
	--end

	--待分配路径中存在已经有权限的格子，且找到它的最小步数
	select @min_step_id = min(step_id) from 
	(select a.* from @t_cmd_route a,wcs_cell b where a.wh_id = b.wh_id and a.floor_num = b.floor_num and a.x_num = b.x_num and a.y_num = b.y_num and b.road_right_flag <> 0) t

	if @min_step_id <> 0
	begin
		delete from @t_cmd_route where step_id >= @min_step_id
	end	

	--找到最小步数的格子的类型
	select top 1 @CelltypeCode = celltype_code
    from @t_cmd_route 
	order by step_id

	--如果是巷道
	if @CelltypeCode = 0
	begin
		--找到货道的最小步数,删除大于等于最小步数的数据
		delete @t_cmd_route where step_id >= (select min(step_id+1) from @t_cmd_route where celltype_code <> 0)
		
		--如果剩余的格子数量大于指定分配的数量,把多余的部分删除。如果巷道的数量刚好等于规定的数量，保留剩下的全部数据
		--if (select count(*) from @t_cmd_route where celltype_code = 0) > @forward_cell_num
		--begin
			delete @t_cmd_route where id > @forward_cell_num
		--end
	end

	--如果是货道
	else if @CelltypeCode <>0
	begin
		--找到巷道的最小步数,删除大于等于最小步数的数据
		delete @t_cmd_route where step_id >= (select min(step_id) from @t_cmd_route where celltype_code = 0)
	end

	return
end
go