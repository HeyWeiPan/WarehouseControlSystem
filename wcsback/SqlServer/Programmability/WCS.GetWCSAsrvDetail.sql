use biz
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
drop proc WCS.GetWCSAsrvDetail
go
CREATE PROCEDURE WCS.GetWCSAsrvDetail
	@pKeyValue int
with encryption
AS
BEGIN	
	SET NOCOUNT ON;

	select
	a.asrv_id,
	a.wh_id,
	a.asrv_code,
	a.enable_flag,
	a.enter_direction,
	a.x_num,
	a.y_num,
	b.wh_code,
	b.wh_name,
	b.wh_code+'--'+b.wh_name wh_desc,
    a.xf_1,
	a.xb_1,
	a.yf_1,
	a.yb_1,
	a.xf_2,
	a.xb_2,
	a.yf_2,
	a.yb_2,
	a.xf_3,
	a.xb_3,
	a.yf_3,
	a.yb_3,
	a.xf_4,
	a.xb_4,
	a.yf_4,
	a.yb_4,
	a.channel_direction,
	a.mac_adress,
	a.x_num,
	a.y_num,
	a.floor_num,
	battery_type,
	battery_model,
	shuttle_type,
	shuttle_model,
	rated_ah,
	charged_cycle,
	charged_ah,
	Max_Charge_Volt,
	Min_Discharge_Volt,
	Charge_Time
	from wcs_asrv a left join  wcs_wh b on a.wh_id=b.wh_id where asrv_id=@pKeyValue
	
	
END
GO
