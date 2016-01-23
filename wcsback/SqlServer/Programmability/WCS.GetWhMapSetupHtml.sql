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
drop proc WCS.GetWhMapSetupHtml
go
CREATE PROCEDURE WCS.GetWhMapSetupHtml
	@pWhId int,
	@pOut varchar(max) output
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	declare @x varchar(10)
	declare @y varchar(10)
	declare @num varchar(10)
	declare @cellType varchar(20)
	declare @class varchar(10)
	declare @cellTypeName varchar(20)
	declare @fristfloor int

	select top 1 @fristfloor=floor_num from wcs_floor where wh_id=@pWhId

	set @pOut=''
	declare c_y cursor for select cast(y_num as varchar(10)) from wcs_cell where wh_id=@pWhId group by y_num order by y_num
	open c_y
	fetch next from c_y into @y
	while(@@fetch_status=0)
	begin
		set @pOut=@pOut+'<tr y="'+@y+'" >'

		declare c_x cursor for select a.cell_num,a.celltype_code,b.celltype_name from wcs_cell a,wcs_celltype b where a.wh_id=@pWhId and a.y_num=@y and a.celltype_code=b.celltype_code  and a.floor_num=@fristfloor order by x_num
		open c_x
		fetch next from c_x into @num,@cellType,@cellTypeName
		while(@@fetch_status=0)
		begin
			
			set @class=case @cellType  when '0' then 'xd'
								when '1' then 'hd'
								when '2' then 'lift'
								when '3' then 'cell'
								when '4' then 'un'
								when '5' then 'cd'
								end


			set @pOut=@pOut+'<td id="'+@num+'" celltype="'+@cellType+'" class="'+@class+'" c="'+@class+'" title="'+@num+'" ></td>'		


			
			fetch next from c_x into @num,@cellType,@cellTypeName
		end
		close c_x
		deallocate c_x

		set @pOut=@pOut+'</tr>'
		fetch next from c_y into @y
	end
	close c_y
	deallocate c_y

	
END
GO
