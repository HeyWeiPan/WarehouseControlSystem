using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.BizLogic.Security;
using EntpClass.BizLogic.Workflow;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

public partial class Security_WflState_WflStateDetail : SetUpDetailPageBase<WflState>
{

    protected override void OnPageModeChanged(PageModeChangedEventArgs e)
    {        
        base.OnPageModeChanged(e);
       
        //查看状态下，当操作类型为用户的时候，隐藏角色控件；
        if (CurrentPageMode == PageMode.View)
        {
            WebComboRole.Visible = false;
            TxtRoleId.Visible = true;
            TxtAssignType.Visible = true;
            DdlAssignType.Visible = false;
            if (DdlAssignType.SelectedIndex == 0)
            {
                DdlAssigntoId.Visible = false;
                TxtAssigntoId.Visible = true;
                //DdlAssignto.Visible = false;
                this.DdlAssignto.Attributes["style"] = "display:none;";
                TxtAssignto.Visible = false;

                this.LbRoleID.Visible = false;
                this.WebComboRole.Visible = false;
                this.TxtRoleId.Visible = false;
                
            }
            else if (DdlAssignType.SelectedIndex == 1)
            {
                
                DdlAssigntoId.Visible = false;
                TxtAssigntoId.Visible = false;
                //DdlAssignto.Visible = false;
                this.DdlAssignto.Attributes["style"] = "display:none;";
                TxtAssignto.Visible = true;

                this.LbRoleID.Visible = true;
                this.WebComboRole.Visible = false;
                this.TxtRoleId.Visible = true;
            }
            else if (DdlAssignType.SelectedIndex == 2)
            {
                this.LbAssignTo.Visible = false;
                DdlAssigntoId.Visible = false;
                TxtAssigntoId.Visible = false;
                //DdlAssignto.Visible = false;
                this.DdlAssignto.Attributes["style"] = "display:none;";
                TxtAssignto.Visible = false;

                this.LbRoleID.Visible = false;
                this.WebComboRole.Visible = false;
                this.TxtRoleId.Visible = false;
            }
        }
        else if (CurrentPageMode == PageMode.Add || CurrentPageMode == PageMode.Edit)
        {
            DdlAssignType.Visible = true;
            TxtAssignType.Visible = false;

            //DdlAssignto.SelectedValue = "wfl.f_GetAssignTo_StateOwner";
            DdlAssigntoId.Visible = true;
            TxtAssigntoId.Visible = false;
            //DdlAssignto.Visible = false;
            this.DdlAssignto.Attributes["style"] = "display:none;";
            TxtAssignto.Visible = false;

            this.LbRoleID.Visible = false;
            this.WebComboRole.Visible = false;
            this.TxtRoleId.Visible = false;

            
          
        }
       
    }


    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        if (DdlAssignType.SelectedIndex == 0)
        {
            
            this.LbRoleID.Visible = false;
            this.WebComboRole.Visible = false;
            this.TxtRoleId.Visible = false;
            
        }
        else if (DdlAssignType.SelectedIndex == 1)
        {
            this.LbAssignTo.ColumnName = "获取操作人函数";
            this.TrRoleId.Visible = true;
        }
        else if (DdlAssignType.SelectedIndex == 2)
        {
            this.LbRoleID.Visible = false;
            this.WebComboRole.Visible = false;
            this.TxtRoleId.Visible = false;
        }
    }
    
    protected override bool OnPreSave()
    {
       
        return base.OnPreSave();
    }
    protected void DdlAssignType_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        //改变操作类型时，当选择用户时，隐藏角色控件
        if (DdlAssignType.SelectedIndex == 0)//0为user(用户) 1为function(函数)
        {
            
            this.LbAssignTo.Visible = true;
            DdlAssigntoId.Visible = true;
            TxtAssigntoId.Visible = false;
            TxtAssignto.Visible = false;

            this.LbRoleID.Visible = false;
            this.WebComboRole.Visible = false;
            this.TxtRoleId.Visible = false;

            
            this.WebComboRole.Value = DBNull.Value.ToString();
            this.TxtRoleId.Text = DBNull.Value.ToString();
            this.DdlAssignto.Attributes["style"] = "display:none;";

        }
        else if (DdlAssignType.SelectedIndex == 1)
        {
            
            this.LbAssignTo.ColumnName = "获取操作人函数";
            this.LbAssignTo.Visible = true;

            DdlAssigntoId.Visible = false;
            TxtAssigntoId.Visible = false;

            this.DdlAssignto.Items.Remove("wfl.f_GetAssignTo_StateOwner");
            this.DdlAssignto.Attributes["style"] = "display:inline;";
            TxtAssignto.Visible = false;

            this.LbRoleID.Visible = true;
            WebComboRole.Visible = true;
            TxtRoleId.Visible = false;
            DdlAssigntoId.Value = DBNull.Value.ToString();
            TxtAssigntoId.Text = DBNull.Value.ToString();
        }
        else if (DdlAssignType.SelectedIndex == 2)
        {
            this.LbAssignTo.Visible = false;
            DdlAssigntoId.Visible = false;
            TxtAssigntoId.Visible = false;
            //DdlAssignto.Visible = false;
            this.DdlAssignto.Attributes["style"] = "display:none;";
            TxtAssignto.Visible = false;
            this.LbRoleID.Visible = false;
            this.WebComboRole.Visible = false;
            this.TxtRoleId.Visible = false;

            DdlAssignto.Text = DBNull.Value.ToString();
            TxtAssignto.Text = DBNull.Value.ToString();
            this.WebComboRole.Value = DBNull.Value.ToString();
            this.TxtRoleId.Text = DBNull.Value.ToString();
            DdlAssigntoId.Value = DBNull.Value.ToString();
            TxtAssigntoId.Text = DBNull.Value.ToString();
        }
    }

    protected override PageRights GetPageRight()
    {
        //根据数据集中字段的值判断有没有编辑权限
        PageRights p = base.GetPageRight();
        if (Fn.ToInt(this.RowData["system_flag"]) == -1)
        {
            p.EditRight = false;
        }
        return p;

    }
}