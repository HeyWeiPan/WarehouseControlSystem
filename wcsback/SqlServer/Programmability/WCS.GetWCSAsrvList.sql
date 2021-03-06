﻿
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
-- Create date: 2014/4/15
-- Description: 
-- =============================================
drop proc WCS.GetWCSAsrvList
go
CREATE PROCEDURE WCS.GetWCSAsrvList
	@pTableSql		nvarchar(4000),
	@pTableAlias	nvarchar(20),
	@pLanguage		nvarchar(10) = 'CN'
with encryption	
AS
BEGIN	
	SET NOCOUNT ON;
       		
    declare @v_sql nvarchar(4000);
	declare @temp_alias	table(id int,show_order int);
	
	set @v_sql = @pTableSql;
	set @v_sql = rtrim(ltrim(@v_sql));
	set @v_sql = substring(@v_sql,2,len(@v_sql) - 1)			
	set @v_sql = replace(@v_sql,'S__p','');
	set @v_sql = rtrim(@v_sql);
	set @v_sql = substring(@v_sql,1,len(@v_sql) - 1)
		
	set @pLanguage = upper(@pLanguage);
	
	insert into @temp_alias exec(@v_sql);
	
   	 select 
	p.asrv_id,
	p.asrv_code,
	b.wh_code,
	b.wh_name,
	p.channel_direction,
	case p.enter_direction when 1 then '正方向' when 0 then '负方向' end enter_direction,
	p.enable_flag,
	p.wh_id
	from wcs_asrv p   INNER JOIN @temp_alias ON p.asrv_id = id  left join wcs_wh b on p.wh_id=b.wh_id
	ORDER BY show_order


END
GO