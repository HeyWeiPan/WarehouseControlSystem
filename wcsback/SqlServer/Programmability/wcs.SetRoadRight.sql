drop procedure wcs.SetRoadRight
go
create procedure wcs.SetRoadRight

with encryption
as
begin
	declare @wh_id int

	declare c_wh cursor for select wh_id from wcs_asrv_cmd group by wh_id order by wh_id
	open c_wh
	fetch next from c_wh into @wh_id
	while(@@fetch_status = 0)
	begin
		exec WCS.UpdateCellRight @wh_id
		fetch next from c_wh into @wh_id
	end
	close c_wh
	deallocate c_wh

	 --exec WCS.GetRoadRightCMD
end
go