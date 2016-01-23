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
drop proc WCS.GetWhTrafficHtml
go
CREATE PROCEDURE WCS.GetWhTrafficHtml
	@pWhId int,
	@pOut varchar(max) output
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	declare @x varchar(10)
	declare @y varchar(10)
	declare @num varchar(10)
	declare @cellDirection varchar(20)
	declare @class varchar(10)
	declare @fristfloor int
	declare @cellTypeCode varchar(20)
	declare @spanClass varchar(20)

	select top 1 @fristfloor=floor_num from wcs_floor where wh_id=@pWhId

	set @pOut=''
	declare c_y cursor for select cast(y_num as varchar(10)) from wcs_cell where wh_id=@pWhId group by y_num order by y_num
	open c_y
	fetch next from c_y into @y
	while(@@fetch_status=0)
	begin
		set @pOut=@pOut+'<tr y="'+@y+'" >'

		declare c_x cursor for select a.cell_num,a.cell_direction,a.celltype_code from wcs_cell a where a.wh_id=@pWhId and a.y_num=@y  and a.floor_num=@fristfloor order by x_num
		open c_x
		fetch next from c_x into @num,@cellDirection,@cellTypeCode
		while(@@fetch_status=0)
		begin
			
			set @class=case @cellTypeCode  when '0' then 'xd'
								when '1' then 'hd'
								when '2' then 'lift'
								when '3' then 'cell'
								when '4' then 'un'
								when '5' then 'cd'
								end

			set @spanClass = case @cellDirection when 1 then 'top'
							when 2 then 'down'
							when 3 then 'left'
							when 4 then 'right'
							when 5 then 'topdown'
							when 6 then 'leftdown'
							when 7 then 'rightdown'
							when 8 then 'righttop'
							when 9 then 'lefttop'
							when 10 then 'leftright'
							when 11 then 'topdownleft'
							when 12 then 'topdownright'
							when 13 then 'leftrighttop'
							when 14 then 'leftrightdown'
							when 15 then 'topdownleftright'
							when 0 then 'no'
							end

			set @pOut=@pOut+'<td id="'+@num+'" class="'+@class+'" title="'+@num+'" ><span class="'+@spanClass+'"></span></td>'		


			print @spanClass
			fetch next from c_x into @num,@cellDirection,@cellTypeCode
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
