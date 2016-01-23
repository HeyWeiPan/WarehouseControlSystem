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
drop proc WCS.UpdateCellsType
go
CREATE PROCEDURE WCS.UpdateCellsType
	@pWhId int,
	@pXml xml
with encryption
AS
BEGIN	
	SET NOCOUNT ON;
	
		declare @SourceTable table
		(
			wh_id int,
			cell_num varchar(20),
			celltype_code varchar(20)
		)

		insert into @SourceTable(wh_id,cell_num,celltype_code)
		select 
		@pWhId,
		a.value('(CellNum/text())[1]', 'varchar(20)') cell_num,
		a.value('(CellType/text())[1]', 'varchar(20)') celltype_code
		from @pXml.nodes('/NewDataSet/Table') as T(a)


		update a
		set a.celltype_code=b.celltype_code
		from wcs_cell a,@SourceTable b
		where a.wh_id=b.wh_id and a.cell_num=b.cell_num


		delete wcs_lift where wh_id=@pWhId


		insert into wcs_lift
		(
			wh_id,
			lift_code,
			x_num,
			y_num,
			create_by,
			create_date
		)
		select
		@pWhId,
		row_number() over(order by x_num),
		x_num,
		y_num,
		2,
		getdate()
		from wcs_cell where wh_id=@pWhId and celltype_code='2' group by x_num,y_num
			

	
END
GO
