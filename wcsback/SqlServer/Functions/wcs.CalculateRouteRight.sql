drop function wcs.CalculateRouteRight
go
create function wcs.CalculateRouteRight
(
	@wh_id int,
	@route xml,
	@b_cmd_id int
)
returns xml
with encryption
as
begin
	declare @route_xml xml
	declare @min_a_id int	--A车在冲突区的最小步数
	declare @min_b_id int  --B车在冲突区的最小步数
	declare @a_level_flag int
	declare @b_level_flag int 
		
	--冲突路段
	declare @t_conflict_route table
	(
		x_num	int,
		y_num	int,
		floor_num int,
		a_id	int,
		b_id	int,
		wh_id int,
		level_flag int
	)

	----a车路径
	declare @t_a_route table
	(	
		id int identity(1,1),
		cmd_id int,
		asrv_id int,
		wh_id int,
		floor_num int,
		x_num int,
		y_num int,
		step_id int
	)	

	----b车路径
	declare @t_b_route table
	(
		id int identity(1,1),
		cmd_id int,
		floor_num int,
		x_num int,
		y_num int,
		step_id int
	)	

	--将A车剩余路径存入临时表中
	insert into @t_a_route(
		cmd_id,
		asrv_id,
		wh_id,
		floor_num,
		x_num,
		y_num,
		step_id)		
	select 
		a.value('(cmd_id/text())[1]', 'int') cmd_id,
		a.value('(asrv_id/text())[1]', 'int') asrv_id,
		a.value('(wh_id/text())[1]', 'int') wh_id,
		a.value('(floor_num/text())[1]', 'int') floor_num,
		a.value('(x_num/text())[1]', 'int') x_num,
		a.value('(y_num/text())[1]', 'int') y_num,
		a.value('(step_id/text())[1]', 'int') step_id
		from @route.nodes('/route/row') as T(a)

	--将B车剩余路径存入临时表中
	insert into @t_b_route(cmd_id,floor_num,x_num,y_num,step_id)
	select cmd_id,floor_num,x_num,y_num,step_id from wcs_asrv_cmd_route where cmd_id = @b_cmd_id and pass_flag = 0 and right_Flag = 0


		--将两车重叠的路经存入临时表
	insert into @t_conflict_route(x_num,y_num,floor_num,wh_id)
	select x_num,y_num,floor_num,@wh_id from @t_a_route
		intersect 
	select x_num,y_num,floor_num,@wh_id from @t_b_route
	
	select @a_level_flag = level_flag from wcs_asrv_cmd where cmd_id = (select top 1 cmd_id from @t_a_route)
	select @b_level_flag = level_flag from wcs_asrv_cmd where cmd_id = (select top 1 cmd_id from @t_b_route)

	--判断两车的优先级

	--如果有冲突区
	if exists(select 1 from @t_conflict_route)
	begin

		--更新每个坐标点的id
		update a set a.a_id = b.id  from @t_conflict_route a,@t_a_route b where a.x_num = b.x_num and a.y_num = b.y_num and a.floor_num = b.floor_num
		update a set a.b_id = b.id  from @t_conflict_route a,@t_b_route b where a.x_num = b.x_num and a.y_num = b.y_num and a.floor_num = b.floor_num 

		--找到冲突区中AB两车的最小步数
		select @min_a_id = min(a_id)  from @t_conflict_route  
		select @min_b_id = min(b_id) from @t_conflict_route	

		--数字越小，优先级高
		if @a_level_flag < @b_level_flag
		begin
			set @route_xml = @route
		end
		else if @a_level_flag = @b_level_flag --如果两个任务的优先级
		begin
			if @min_a_id < @min_b_id
			begin
				set @route_xml = @route
			end
			else
			begin
				set @route_xml = (SELECT cmd_id,asrv_id,wh_id,floor_num,x_num,y_num,step_id FROM @t_a_route where id < @min_a_id FOR XML PATH,ROOT('route'))
			end
		end
		
	end
	else --不存在冲突区，将A车待分配的所有路径返回
	begin
		set @route_xml = @route
	end

	return @route_xml
end

go