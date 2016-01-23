declare @djNo nvarchar(20)
declare @djId uniqueidentifier
declare @conId int
declare @qty int

declare c_c cursor for select con_id,con_num from sde.dbo.t_contract where apply_id is null
open c_c
fetch next from c_c into @conId,@qty
while(@@fetch_status=0)
begin
	exec GetNewDJNo 'pm_outdoor_apply',@djNo output
	set @djId=newid()
	
	insert into pm_outdoor_apply
    (dj_id,dj_no,area_id,customer_id,site_id,applicant_id,
	applicant_date,ad_type_id,ad_start_date,ad_end_date,
    ad_content,remark,state_id,wf_process_id,create_by,
	create_date,tasktype_id)
	select
	@djId,
	@djNo,
	b.geo_id,
	c_id,
	site_id,
	2,
	con_sign,
	1,
	con_start,
	con_end,
	con_content,
	con_lamps,
	90,8901100,
	2,
	con_sign,
	70
	from sde.dbo.t_contract a,def_geography b where con_id=@conId and a.con_area=b.geo_name
	
	insert into pm_outdoor_road(dj_detail_id,dj_id,line,road_id,road_code,road_name,road_lamp_id,road_lamp_code,face_qty,
	create_by,create_date)
	select newid(),@djId,1,5,'OLD','老路段',11,'OLD',2,2,getdate()
		
	insert into pm_outdoor_product(dj_detail_id,dj_id,m_id,qty,create_by,create_date)
	select newid(),@djId,11049,@qty,2,getdate()

	update sde.dbo.t_contract
	set apply_id=@djId
	where con_id=@conId
	
fetch next from c_c into @conId,@qty
end 
close c_c
deallocate c_c





insert into pm_contract
(contract_no,dj_date,contract_type_id,project_name,contract_start_date,contract_end_date,contract_amount,sign_date,company_id,customer_id,site_id,apply_id,state_id,wf_process_id,create_by,create_date,action_user_id,tasktype_id)
select
b.con_no,
a.applicant_date,
2,
b.con_company,
ad_start_date,
ad_end_date,
b.con_money,
a.applicant_date,
1,
a.customer_id,
a.site_id,
a.dj_id,
90,
8902100,
2,
a.applicant_date,
2,
201
from pm_outdoor_apply a,sde.dbo.t_contract b
where a.dj_id=b.apply_id




update a
set customer_contact=b.contact_name
from pm_contract a ,jxc_customer b
where a.customer_id=b.customer_id



insert into pm_project
	(
	   project_name,
	   project_code,
	   contract_id,
	   contract_amount,
	   contract_type_id,
	   company_id,
	   company_contact,
	   customer_id,
	   customer_contact,
	   site_id,
	   project_content,
	   project_start_date,
	   project_end_date,
	   create_by,
	   create_date,
	   ad_type_id,
	   end_flag
	)
	select 
	a.project_name,
	a.contract_no,
	a.contract_id,
	a.contract_amount,
	a.contract_type_id,
	a.company_id,
	a.company_contact,
	a.customer_id,
	a.customer_contact,
	a.site_id,
	a.contract_content,
	a.contract_start_date,
	a.contract_end_date,
	2,
	b.applicant_id,
	b.ad_type_id,
	-1
	from pm_contract a,pm_outdoor_apply b,sde.dbo.t_contract c where  a.apply_id=b.dj_id and c.apply_id=a.apply_id




	
	update a
	set project_id=b.project_id
	from pm_contract a,pm_project b
	where a.contract_id=b.contract_id


    update a
	set project_id=b.project_id
	from pm_outdoor_apply a,pm_contract b
	where a.dj_id=b.apply_id


update pm_project
set project_status_id=2
where submit_flag=0 and delete_flag=0


	
declare @projectId int
declare c_p cursor for select project_id from pm_project where submit_flag=0 and delete_flag=0 and end_flag=-1
open c_p
fetch next from c_p into @projectId
while(@@fetch_status=0)
begin
	exec PM.SubmitProject @projectId,2
fetch next from c_p into @projectId
end 
close c_p
deallocate c_p






declare @r_djNo nvarchar(20)
declare @r_djId uniqueidentifier
declare @contractID INT
declare @customerId int

declare c_r cursor for select contract_id,customer_id from pm_contract where contract_id not in (1,3)
open c_r
fetch next from c_r into @contractID,@customerId
while (@@fetch_status=0)
begin
	set @r_djId=newid()
	exec GetNewDJNo 'pm_receive_head',@r_djNo output
	insert into pm_receive_head	
	(dj_id,dj_no,action_user_id,dj_date,company_id,customer_id,t_amount,state_id,wf_process_id,create_by,create_date,tasktype_id
	)
	select 
	@r_djId,
	@r_djNo,
	2,
	contract_end_date,
	1,
	customer_id,
	contract_amount,
	95,
	8908100,
	2,
	contract_end_date,
	202
	from pm_contract where contract_id=@contractID
	
	
	insert into pm_receive_detail
	(dj_detail_id,dj_id,line,contract_type_id,contract_id,contract_no,project_id,contract_amount,receive_amount,receivable_amount,create_by,create_date,account_type_id)
	select newid(),@r_djId,1,2,contract_id,contract_no,project_id,contract_amount,contract_amount,0,2,contract_end_date,1
	from pm_contract where contract_id=@contractID


	
	fetch next from c_r into @contractID,@customerId

end

close c_r
deallocate c_r
