drop procedure WCS.CalcTaskLevel
go
create procedure WCS.CalcTaskLevel
as 
begin
	declare @num int
	declare @id int
	set @id = 1

	declare @w table
	(
		id int identity(1,1),
		wh_id int
	)

	insert into @w(wh_id) 
	select wh_id from wcs_asrv_cmd where task_finish_flag = 0 group by wh_id

	if (select count(*) from @w) = 0
	begin
		return
	end

	select @num = count(*) from @w

	while @id <= @num
	begin 
		declare @wh_id int
		declare @channel_direction nvarchar(10)

		select @wh_id = wh_id from @w where id = @id

		--货道方向
		select @channel_direction = channel_direction from wcs_wh where wh_id = @wh_id 

		if @channel_direction = 'x'
		begin
			
		end

		set @id = @id + 1
	end
end