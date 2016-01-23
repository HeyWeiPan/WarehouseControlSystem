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
drop proc WCS.UpdateFloorCells
go
CREATE PROCEDURE WCS.UpdateFloorCells
	@pFloorId int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	delete from  wcs_cell  where exists(select 1 from wcs_floor b where b.wh_id=wcs_cell.wh_id and b.floor_num=wcs_cell.floor_num and b.floor_id=@pFloorId)

	declare @floorNum int
	declare @whId int
	declare @x_from int
	declare @x_to int
	declare @y_from int
	declare @y_to int
	declare @x int
	declare @y int

	select 
	@floorNum=floor_num,
	@whId=wh_id
	from wcs_floor where floor_id=@pFloorId


	select
	@x_from=x_num_from,
	@x_to=x_num_to,
	@y_from=y_num_from,
	@y_to=y_num_to
	from wcs_wh where wh_id=@whId


	if(@x_from>@x_to or @y_from>@y_to )
	begin
		raiserror('x.y编号错误',16,2)
		return
	end

	set @x=@x_from

	while(@x<(@x_to+1))
	begin

		set @y=@y_from
		while(@y<(@y_to+1))
		begin
			
			insert into wcs_cell
			(	
				cell_num,
				wh_id,
				floor_num,
				x_num,
				y_num,
				celltype_code,
				create_by,
				create_date
			)
			values(cast(@x as varchar(10))+'.'+cast(@y as varchar(10)),@whId,@floorNum,@x,@y,'3',2,getdate())


			set @y=@y+1


		end

		set @x=@x+1

	end
	
	
END
GO
