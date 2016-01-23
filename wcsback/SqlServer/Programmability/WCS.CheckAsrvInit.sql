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
drop proc WCS.CheckAsrvInit
go
CREATE PROCEDURE WCS.CheckAsrvInit
	@pKeyValue int,
	@pAddress binary(8)
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	declare @rack nvarchar(20)
	declare @enter smallint
	declare @rack_direction nvarchar(20)
	
	select @rack_direction = rack_direction from wcs_asrv where asrv_id = @pKeyValue

	if @rack_direction = 'x'
	begin
		update wcs_asrv set channel_direction = 'y' where  asrv_id = @pKeyValue
	end
	else
	begin
		update wcs_asrv set channel_direction = 'x' where  asrv_id = @pKeyValue
	end

	select @rack=channel_direction,@enter=enter_direction
	from wcs_asrv where asrv_id=@pKeyValue

	update wcs_asrv
	set address=@pAddress
	where asrv_id=@pKeyValue



	if(@rack='x' and @enter=1)
	begin
		
		update wcs_asrv
		set  xf_1 ='反',
			 xf_2 ='正',
			 xf_3 ='正',
			 xf_4 ='反',

			 xb_1 ='正',
			 xb_2 ='反',
			 xb_3 ='反',
			 xb_4 ='正',

			 yf_1 ='正',
			 yf_2 ='正',
			 yf_3 ='反',
			 yf_4 ='反',

			 yb_1 ='反',
			 yb_2 ='反',
			 yb_3 ='正',
			 yb_4 ='正',

			 xf=0x46,
			 xb=0x49,
			 yf=0x43,
			 yb=0x4c
	    where asrv_id=@pKeyValue



		return
	end

	if(@rack='x' and @enter=0)
	begin


		update wcs_asrv
		set  xf_1 ='正',
			 xf_2 ='反',
			 xf_3 ='反',
			 xf_4 ='正',

			 xb_1 ='反',
			 xb_2 ='正',
			 xb_3 ='正',
			 xb_4 ='反',

			 yf_1 ='反',
			 yf_2 ='反',
			 yf_3 ='正',
			 yf_4 ='正',

			 yb_1 ='正',
			 yb_2 ='正',
			 yb_3 ='反',
			 yb_4 ='反',

			 xf=0x49,
			 xb=0x46,
			 yf=0x4c,
			 yb=0x43

	    where asrv_id=@pKeyValue


		return
	end
	
	if(@rack='y' and @enter=1)
	begin

		update wcs_asrv
		set  xf_1 ='反',
			 xf_2 ='反',
			 xf_3 ='正',
			 xf_4 ='正',

			 xb_1 ='正',
			 xb_2 ='正',
			 xb_3 ='反',
			 xb_4 ='反',

			 yf_1 ='反',
			 yf_2 ='正',
			 yf_3 ='正',
			 yf_4 ='反',

			 yb_1 ='正',
			 yb_2 ='反',
			 yb_3 ='反',
			 yb_4 ='正',

			 xf=0x4C,
			 xb=0x43,
			 yf=0x46,
			 yb=0x49

	    where asrv_id=@pKeyValue	


		return
	end
	
	if(@rack='y' and @enter=0)
	begin

		update wcs_asrv
		set  xf_1 ='正',
			 xf_2 ='正',
			 xf_3 ='反',
			 xf_4 ='反',

			 xb_1 ='反',
			 xb_2 ='反',
			 xb_3 ='正',
			 xb_4 ='正',

			 yf_1 ='正',
			 yf_2 ='反',
			 yf_3 ='反',
			 yf_4 ='正',

			 yb_1 ='反',
			 yb_2 ='正',
			 yb_3 ='正',
			 yb_4 ='反',

			 xf=0x43,
			 xb=0x4c,
			 yf=0x49,
			 yb=0x46

	    where asrv_id=@pKeyValue	

		return
	end			
	
END
GO
