using System;
using System.Collections;
using System.Web.UI;
using EntpClass.BizLogic.HR.Public;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.WebUI;

public partial class Home_Notification_Notification : SetUpDetailPageBase<Notification>
{
    private void RegeditClientScript()
    {
        if (!ClientScript.IsClientScriptBlockRegistered(this.GetType(), "JsClientScript"))
        {
            string str
                = string.Format("var PageMode = '{0}';", CurrentPageMode)
                + string.Format("var FCKeditor1 = '{0}';", FCKeditor1.ClientID);

            ClientScript.RegisterClientScriptBlock(this.GetType(), "JsClientScript", str, true);
        }
    }

    private void SetFCKeditor()
    {        
        FCKeditor1.Config["AutoDetectLanguage"] = "false";        
        FCKeditor1.Config["SkinPath"] = UrlHelper.UrlBase + @"/FCKeditor/editor/skins/office2003/";
        FCKeditor1.Config["SkinEditorCSS"] = "";
        FCKeditor1.Config["ToolbarStartExpanded"] = "true";

        if (CurrentUser.UseLanguage == Language.English)
            FCKeditor1.Config["DefaultLanguage"] = "en";
        else
            FCKeditor1.Config["DefaultLanguage"] = "zh-cn";

        if (CurrentPageMode == PageMode.View)
        {
            FCKeditor1.Config["ToolbarStartExpanded"] = "false";
            FCKeditor1.Config["SkinEditorCSS"] = UrlHelper.UrlBase + @"/FCKeditor/editor/skins/fck_editor.css";
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
       
        UcUserAttachment1.ApplicationId = Notification.FUNCTIONID;
        UcUserAttachment1.InstanceId = Fn.ToInt(KeyValue);
        UcUserAttachment1.Version = "";
        UcUserAttachment1.AddRight = PageRight.AddRight;
        UcUserAttachment1.DeleteRight = PageRight.DeleteRight;
        UcUserAttachment1.Title = TxtTilte.Text;
    }

    protected override void OnLoadComplete(EventArgs e)
    {
        base.OnLoadComplete(e);

        trIfraFile.Visible = false;
        trContent1.Visible = true;
        trContent2.Visible = true;

        UcUserAttachment1.Visible = false;

        string mode = Fn.ToString(Request.QueryString["Mode"]).ToUpper();
        bool b = Fn.ToBoolean(DrpAttachmentNotifyFlag.Text);

        if (b) 
        {
            trContent1.Visible = false;
            trContent2.Visible = false; 
        }

        if (mode == "VIEW" && b) 
        { 
            trIfraFile.Visible = true; 
        }
                
        if (mode == "VIEW" && trIfraFile.Visible)
        {
            UcUserAttachment1.Title = TxtTilte.Text;
            UcUserAttachment1.Visible = true;
        }
    }

    protected override void OnAfterSetControlValue(SetControlValueEventArgs e)
    {
        base.OnAfterSetControlValue(e);

        FCKeditor1.Value = Fn.ToString(RowData["notify_content"]);        
    }

    public override bool OnCheckRequired(bool autoAlertErrorInfo, out Control requiredControl, out string outputMsg)
    {
        Hashtable dataControlCollection = DataControlCollection;

        //notify_content       
        UcHiddenField HidNotifyContent = new UcHiddenField();
        HidNotifyContent.ID = "HidNotifyContent";
        HidNotifyContent.ColumnName = "notify_content";
        HidNotifyContent.Value = FCKeditor1.Value.Replace("\r\n", "");

        AddControl(HidNotifyContent);
     
        return base.OnCheckRequired(autoAlertErrorInfo, out requiredControl, out outputMsg);
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        UcButton btnSave = (UcButton)GetMasterPageControl("BtnSave");
        btnSave.OnClientClick = "";

        if (trContent2.Visible)
        {
            SetFCKeditor();

            RegeditClientScript();
            
            btnSave.OnClientClick = "if(!onClientSave()){return false;}" + btnSave.OnClientClick;
        }       
    }
}
