using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.WebControlLib.Derived;
using EntpClass.BizLogic.HR;
using EntpClass.BizLogic.HR.UserProfile;
using EntpClass.BizLogic.Security;

public partial class HR_UserProfile_UcUser : UserControlBase
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        WcbSearchUser.FunctionID = HRUser.FUNCTIONID;
        WcbSearchUser.IncludeInactiveUser = true;
    }

    public override void InitializeEvents()
    {
        base.InitializeEvents();

        PageBase page = (PageBase)this.Parent.Page;

        page.AfterSetControlValue += new EventHandler<SetControlValueEventArgs>(page_AfterSetControlValue);
        page.PageModeChanged += new EventHandler<PageModeChangedEventArgs>(page_PageModeChanged);
        page.PreRender += new EventHandler(page_PreRender);
        page.PreSetControlValue += new EventHandler<SetControlValueEventArgs>(page_PreSetControlValue);
        page.CheckRequired += new CancelEventHandler(page_CheckRequired);
    }

    void page_PreSetControlValue(object sender, SetControlValueEventArgs e)
    {
        if (!this.Visible)
        {
            return;
        }

        SetUpDetailPageBase<HRUser> page = (SetUpDetailPageBase<HRUser>)this.Page;

        string userID = Fn.ToString(page.RowData["user_id"]);

        bool b = false;

        if (userID == "")
        {
            b = true;
        }
        else
        {
            b = RightHelper.CheckFuncRescRight(HRUser.USER_BASIC, OperationCode.EDIT, HRUser.ResourceTypeID, userID);
        }

        if (!b)
        {
            SetControlsReadOnly(this.Controls, true);
        }

    }

    private void SetControlsReadOnly(ControlCollection cl, bool b)
    {
        foreach (Control c in cl)
        {
            if (c is IWebDataControl)
            {
                IWebDataControl dc = (IWebDataControl)c;
                dc.RequiredField = false;
                dc.ReadOnlyWhenInsert = true;
                dc.ReadOnlyWhenUpdate = true;
                dc.AllowUpdate = false;
                dc.AllowInsert = false;
            }
        }
    }

    private void RegeditUploadPhoto()
    {
        SetUpDetailPageBase<HRUser> page = (SetUpDetailPageBase<HRUser>)this.Page;

        if (!page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegeditUploadPhoto"))
        {
            DialogWindow dw = new DialogWindow();
            dw.Url = UrlHelper.UrlBase + "/UploadFile/PhotoUpload.aspx";
            dw.AddUrlParameter("UserId", Fn.ToString(page.RowData["user_id"]));
            dw.Width = 600;
            dw.Height = 450;

            Random r = new Random();
            StringBuilder s = new StringBuilder();

            //弹出文件上传的窗体
            s.Append("function onUploadPhoto()");
            s.Append("{");
            s.AppendFormat("var img = document.getElementById('{0}');", Img.ClientID);
            s.Append("var returnValue = '';" + dw.GetShowModalDialogScript("returnValue"));
            s.Append("if(returnValue =='REFRESH'){refreshImg(img);}");
            s.Append("window.event.cancelBubble = true;return false;");
            s.Append("}");

            //dw = new DialogWindow();
            //dw.Url = UrlHelper.UrlBase + "/UploadFile/PhotoOriginal.aspx";
            //dw.AddUrlParameter("UserId", Fn.ToString(page.RowData["user_id"]));
            //dw.Width = 350;
            //dw.Height = 350;

            //s.Append("function showOriginalImg()");
            //s.Append("{");
            //s.Append(dw.GetShowModalDialogScript());
            //s.Append("}");

            page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegeditUploadPhoto", s.ToString(), true);
        }
    }

    private void RegisterClientScript()
    {
        SetUpDetailPageBase<HRUser> page = (SetUpDetailPageBase<HRUser>)this.Parent.Page;

        if (!page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegisterClientScript"))
        {
            StringBuilder s = new StringBuilder("");

            s.Append("function onUserNumberTypeChange(obj)");
            s.Append("{");
            s.AppendFormat("var txt = document.getElementById('{0}');", TxtUserNumber.ClientID);
            s.Append("txt.disabled='';txt.className= \"CssRequired\";");

            s.Append("if(obj==undefined||obj[obj.selectedIndex].value==\"\"){return;}");
            s.Append("var prefix = obj[obj.selectedIndex].value;");
            s.Append("if(prefix != null){txt.disabled='disabled';txt.className= \"CssReadOnly\";}");
            s.Append("}");

            DrpUserNumberType.OnClientChange = "onUserNumberTypeChange(this);return false;";

            page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegisterClientScript", s.ToString(), true);
        }
    }

    void page_PageModeChanged(object sender, PageModeChangedEventArgs e)
    {
        if (e.NewPageMode == PageMode.Add)
        {
            WcbSearchUser.Visible = false;
            LabQuockSearch.Visible = false;

            DrpUserNumberType.Visible = true;
            LabUserNumberTypeName.Visible = true;
        }
        else
        {
            WcbSearchUser.Visible = true;
            LabQuockSearch.Visible = true;

            DrpUserNumberType.Visible = false;
            LabUserNumberTypeName.Visible = false;
        }

        if (e.NewPageMode == PageMode.Add || e.NewPageMode == PageMode.Edit)
        {
            this.TVListPrimaryTeam.Visible = true;
            this.TxtTeamPath.Visible = false;

            //DdlCostCenter.Visible = true;
            //TxtCostCenter.Visible = false;

            WcbSearchUser.Value = "";
            WcbSearchUser.ReadOnly = true;
            WcbSearchUser.CssClass = "CssReadOnly";
            //TxtReplaceUserName.Visible = false;
            //WcbReplaceUserID.Visible = true;
        }
        else
        {
            this.TVListPrimaryTeam.Visible = false;
            this.TxtTeamPath.Visible = true;

            //DdlCostCenter.Visible = false;
            //TxtCostCenter.Visible = true;

            WcbSearchUser.ReadOnly = false;
            WcbSearchUser.CssClass = "";
            //TxtReplaceUserName.Visible = true;
            //WcbReplaceUserID.Visible = false;
        }
    }

    void page_CheckRequired(object sender, CancelEventArgs e)
    {
        SetUpDetailPageBase<HRUser> page = (SetUpDetailPageBase<HRUser>)this.Parent.Page;

        if (page.CurrentPageMode == PageMode.Add)
        {
            //员工编号让用户手工输入
            //string userNumber = Fn.GetAppSequence(HRConst.ConnectionName, page.RowData.TableName, HRUser.UserNumberInitial, HRUser.UserNumberLength);
            //int userId = Fn.ToInt(userNumber.Replace(HRUser.UserNumberInitial, ""));         

            //user_number可能有不同的前缀，用户选择前缀后，系统根据该前缀已有的最大值＋1，自动获取新的编号。
            //如果前缀为null或空字符串，用户依然可以手工输入
            int userId = Fn.ToInt(Fn.GetAppSequence(HRConst.ConnectionName, page.RowData.TableName));
            string userNumberTypePrefix = DrpUserNumberType.Text;
            if (!string.IsNullOrEmpty(userNumberTypePrefix))
            {
                string userNumber = HRUser.GetUserNumberByPrefix(userNumberTypePrefix, HRUser.UserNumberLength);
                TxtUserNumber.Text = userNumber;
            }

            HidUserID.Value = userId.ToString();
            HidLoginName.Value = TxtUserNumber.Text;
        }
    }

    void page_AfterSetControlValue(object sender, SetControlValueEventArgs e)
    {
        Random r = new Random();
        Img.Src = string.Format("GetImage.ashx?Thumbnail=-1&UserId={0}&Id={1}", e.DbRowData["user_id"], r.Next());
    }

    void page_PreRender(object sender, EventArgs e)
    {
        SetUpDetailPageBase<HRUser> page = (SetUpDetailPageBase<HRUser>)this.Parent.Page;
        if (page.CurrentPageMode == PageMode.Add)
        {
            RegisterClientScript();

            TxtUserNumber.UseDefaultStyle = false;

            if (string.IsNullOrEmpty(DrpUserNumberType.Text))
            {
                TxtUserNumber.CssClass = "CssRequired";
                TxtUserNumber.Attributes.Remove("disabled");
            }
            else
            {
                TxtUserNumber.Text = "";
                TxtUserNumber.CssClass = "CssReadOnly";
                TxtUserNumber.Attributes["disabled"] = "disabled";
            }
        }

        string userId = Fn.ToString(page.RowData["user_id"]);

        if (string.IsNullOrEmpty(userId))
        {
            LnkUploadPhoto.Visible = false;
        }
        else
        {
            bool b = RightHelper.CheckFuncRescRight(HRUser.USER_UPLOAD, OperationCode.EDIT, HRUser.ResourceTypeID, userId);
            LnkUploadPhoto.Visible = b;
        }

        if (LnkUploadPhoto.Visible)
        {
            RegeditUploadPhoto();
            LnkUploadPhoto.OnClientClick = "if(!onUploadPhoto()){{window.event.cancelBubble = true; return false;}}";
        }
    }

    protected void WcbSearchUser_Change(object sender, EventArgs e)
    {
        string userId = WcbSearchUser.Value;
        if (userId == string.Empty)
        {
            return;
        }

        string userGuid = HRUser.GetUserGUID(Fn.ToInt(userId));

        //UcHiddenField HidSelectedTab = Fn.FindControlWithLoop("HidSelectedTab", this.Page.Controls) as UcHiddenField;

        //string url = string.Format("UserDetail.aspx?KeyValue={0}&DefaultTab={1}", userGuid, HidSelectedTab.Value);

        //Response.Redirect(url);
        //Response.End();
        (this.Page as SetUpDetailPageBase<HRUser>).ReloadPage(userGuid, PageMode.View);
    }
}
