using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.Security;
using EntpClass.BizLogic.HR.UserProfile;

public partial class HR_UserProfile_UcUserTabGroup : UserControlBase
{
    string _userID = string.Empty;
    private string UserId
    {
        get
        {
            if (_userID == string.Empty)
            {
                SetUpDetailPageBase<HRUser> page = (SetUpDetailPageBase<HRUser>)this.Page;
                _userID = Fn.ToString(page.RowData["user_id"]);
            }

            return _userID;
        }
    }

    int _paySetId = 0;
    private int PaySetId
    {
        get
        {
            if (_paySetId == 0)
            {
                SetUpDetailPageBase<HRUser> page = (SetUpDetailPageBase<HRUser>)this.Page;
                _paySetId = Fn.ToInt(page.RowData["payset_id"]);
            }

            return _paySetId;
        }
    }

    private string DefaultTabColumnName
    {
        get { return Fn.ToString(Request.QueryString["DefaultTab"]); }
    }

    private UcHyperLink GetCurrentTab()
    {
        string defaultTabColumnName = string.Empty;

        if (!string.IsNullOrEmpty(HidSelectedTab.Value))
        {
            defaultTabColumnName = HidSelectedTab.Value;
        }
        else
        {
            defaultTabColumnName = DefaultTabColumnName;
        }


        if (!string.IsNullOrEmpty(defaultTabColumnName))
        {
            UcHyperLink lnk = null;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is UcHyperLink)
                {
                    lnk = ctrl as UcHyperLink;

                    if (lnk.ColumnName == defaultTabColumnName || lnk.ClientID == defaultTabColumnName)
                    {
                        if (lnk.Visible)
                        {
                            return lnk;
                        }
                        else
                        {
                            return GetFirstTab();
                        }
                    }
                }
            }
        }


        return GetFirstTab();
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        SetUpDetailPageBase<HRUser> page = (SetUpDetailPageBase<HRUser>)this.Page;
        //page.PageModeChanged += new EventHandler<PageModeChangedEventArgs>(page_PageModeChanged);
        if (!page.IsPostBack)
        {
            bool contactRight = true;
            bool personalRight = false;
            bool jobRight = false;
            bool familyRight = false;
            bool familyMemberRight = false;
            bool contractRight = false;
            bool workBeforeRight = false;
            bool workAfterRight = false;
            bool trainingBeforeRight = false;
            bool trainingAfterRight = false;
            bool rewardBeforeRight = false;
            bool rewardAfterRight = false;
            bool leaveRight = false;
            bool educationRight = false;
            bool salaryRight = false;
            bool payRight = false;
            bool bankInfoRight = false;

            if (page.KeyValue != string.Empty)
            {
                string userID = this.UserId;
                contactRight = RightHelper.CheckFuncRescRight(HRUser.USER_CONTACT, OperationCode.READ, ScrUser.ResourceTypeID, userID);
                personalRight = RightHelper.CheckFuncRescRight(HRUser.USER_PERSONAL, OperationCode.READ, ScrUser.ResourceTypeID, userID);
                jobRight = RightHelper.CheckFuncRescRight(HRUser.USER_JOB, OperationCode.READ, ScrUser.ResourceTypeID, userID);
                familyRight = RightHelper.CheckFuncRescRight(HRUser.USER_FAMILY, OperationCode.READ, ScrUser.ResourceTypeID, userID);//家庭信息
                familyMemberRight = RightHelper.CheckFuncRescRight(HRUser.USER_FAMILY_MEMBER, OperationCode.READ, ScrUser.ResourceTypeID, userID);//家庭成员
                contractRight = RightHelper.CheckFuncRescRight(HRUser.USER_CONTRACT, OperationCode.READ, ScrUser.ResourceTypeID, userID);
                workBeforeRight = RightHelper.CheckFuncRescRight(HRUser.USER_WORK_BEFORE, OperationCode.READ, ScrUser.ResourceTypeID, userID);
                workAfterRight = RightHelper.CheckFuncRescRight(HRUser.USER_WORK_AFTER, OperationCode.READ, ScrUser.ResourceTypeID, userID);
                trainingBeforeRight = RightHelper.CheckFuncRescRight(HRUser.USER_TRAINING_BEFORE, OperationCode.READ, ScrUser.ResourceTypeID, userID);
                trainingAfterRight = RightHelper.CheckFuncRescRight(HRUser.USER_TRAINING_AFTER, OperationCode.READ, ScrUser.ResourceTypeID, userID);
                rewardBeforeRight = RightHelper.CheckFuncRescRight(HRUser.USER_REWARD_BEFORE, OperationCode.READ, ScrUser.ResourceTypeID, userID);
                rewardAfterRight = RightHelper.CheckFuncRescRight(HRUser.USER_REWARD_AFTER, OperationCode.READ, ScrUser.ResourceTypeID, userID);
                leaveRight = RightHelper.CheckFuncRescRight(HRUser.USER_LEAVE, OperationCode.READ, ScrUser.ResourceTypeID, userID);
                educationRight = RightHelper.CheckFuncRescRight(HRUser.USER_EDUCATION, OperationCode.READ, ScrUser.ResourceTypeID, userID);
                salaryRight = RightHelper.CheckFuncRescRight(HRUser.USER_SALARY, OperationCode.READ, ScrUser.ResourceTypeID, userID);
                bankInfoRight = RightHelper.CheckFuncRescRight(HRUser.USER_BANKINFO, OperationCode.READ, ScrUser.ResourceTypeID, userID);
                //payRight = true;
                payRight = RightHelper.CheckFuncRescRight(HRUser.USER_PAY, OperationCode.READ, ScrUser.ResourceTypeID, userID);
            }

            if (!contactRight)
            {
                TabContact.Visible = false;
                LnkUserContact.Visible = false;
                this.UcUserContact1.Visible = false;
                this.Controls.Remove(this.UcUserContact1);
            }

            if (!personalRight)
            {
                TabPersonal.Visible = false;
                LnkUserPersonal.Visible = false;
                this.UcUserPersonalInfo1.Visible = false;
                this.Controls.Remove(this.UcUserPersonalInfo1);
            }

            if (!jobRight)
            {
                TabJob.Visible = false;
                LnkUserJob.Visible = false;
                this.UcUserJob1.Visible = false;
                this.Controls.Remove(this.UcUserJob1);
            }

            if (!familyRight)
            {
                TabFamily.Visible = false;
                this.UcUserFamilyInfo1.Visible = false;
                this.Controls.Remove(this.UcUserFamilyInfo1);
            }

            if (!familyRight && !familyMemberRight)
            {
                LnkUserFamily.Visible = false;
            }

            if (!contractRight)
            {
                TabUserContract.Visible = false;
                //this.Controls.Remove(this.UcUserContractInfo1);

                LnkUserContract.Visible = false;
            }

            if (!workBeforeRight & !workAfterRight)
            {
                LnkUserWork.Visible = false;
                TabWorkExpand.Visible = false;
                this.UcUserWorkExpand1.Visible = false;
                this.Controls.Remove(this.UcUserWorkExpand1);
            }

            if (!trainingBeforeRight & !trainingAfterRight)
            {
                LnkUserTraining.Visible = false;
            }

            if (!rewardBeforeRight & !rewardAfterRight)
            {
                LnkUserRewards.Visible = false;
            }

            if (!leaveRight)
            {
                LnkUserLeave.Visible = false;
            }

            if (!educationRight)
            {
                LnkUserEducation.Visible = false;
            }

            if (!salaryRight)
            {
                LnkUserSalary.Visible = false;
                TabSalary.Visible = false;
                this.UcUserSalary1.Visible = false;
                this.Controls.Remove(this.UcUserSalary1);
            }

            if (!payRight)
            {

                this.UcUserPay1.Visible = false;
                this.Controls.Remove(this.UcUserPay1);
            }

            if (!payRight && !bankInfoRight)
            {
                LnkUserPay.Visible = false;
                TabUserPay.Visible = false;
            }

            LnkUserContact.Attributes.Add("onclick", string.Format("setSelectedTab(this);SwitchTab(this,'{0}','{1}');", LnkUserContact.ColumnName, HidSelectedTab.ClientID));
            LnkUserPersonal.Attributes.Add("onclick", string.Format("setSelectedTab(this);SwitchTab(this,'{0}','{1}');", LnkUserPersonal.ColumnName, HidSelectedTab.ClientID));
            LnkUserJob.Attributes.Add("onclick", string.Format("setSelectedTab(this);SwitchTab(this,'{0}','{1}');", LnkUserJob.ColumnName, HidSelectedTab.ClientID));
            LnkUserFamily.Attributes.Add("onclick", string.Format("setSelectedTab(this);SwitchTab(this,'{0}','{1}');", LnkUserFamily.ColumnName, HidSelectedTab.ClientID));
            LnkUserWork.Attributes.Add("onclick", string.Format("setSelectedTab(this);SwitchTab(this,'{0}','{1}');", LnkUserWork.ColumnName, HidSelectedTab.ClientID));
            LnkUserTraining.Attributes.Add("onclick", string.Format("setSelectedTab(this);SwitchTab(this,'{0}','{1}');", LnkUserTraining.ColumnName, HidSelectedTab.ClientID));
            LnkUserLeave.Attributes.Add("onclick", string.Format("setSelectedTab(this);SwitchTab(this,'{0}','{1}');", LnkUserLeave.ColumnName, HidSelectedTab.ClientID));
            LnkUserRewards.Attributes.Add("onclick", string.Format("setSelectedTab(this);SwitchTab(this,'{0}','{1}');", LnkUserRewards.ColumnName, HidSelectedTab.ClientID));
            LnkUserEducation.Attributes.Add("onclick", string.Format("setSelectedTab(this);SwitchTab(this,'{0}','{1}');", LnkUserEducation.ColumnName, HidSelectedTab.ClientID));
            LnkUserContract.Attributes.Add("onclick", string.Format("setSelectedTab(this);SwitchTab(this,'{0}','{1}');", LnkUserContract.ColumnName, HidSelectedTab.ClientID));
            LnkUserSalary.Attributes.Add("onclick", string.Format("setSelectedTab(this);SwitchTab(this,'{0}','{1}');", LnkUserSalary.ColumnName, HidSelectedTab.ClientID));
            LnkUserPay.Attributes.Add("onclick", string.Format("setSelectedTab(this);SwitchTab(this,'{0}','{1}');", LnkUserPay.ColumnName, HidSelectedTab.ClientID));
        }
    }

    //private void SetTabHyperLinkVisible()
    //{
    //    SetUpDetailPageBase<HRUser> page = (SetUpDetailPageBase<HRUser>)this.Page;

    //    #region
    //    //一
    //    //暂时使用,需要一次性取出
    //    //LnkUserContact.Visible = RightHelper.CheckFuncRescRight(HRUser.USERCONTACT_FUNID, OperationCode.READ, ScrUser.ResourceTypeID, UserId);
    //    //LnkUserHR.Visible = RightHelper.CheckFuncRescRight(HRUser.USERHR_FUNID, OperationCode.READ, ScrUser.ResourceTypeID, UserId);
    //    //LnkUserJob.Visible = RightHelper.CheckFuncRescRight(HRUser.USERJOB_FUNID, OperationCode.READ, ScrUser.ResourceTypeID, UserId);
    //    //LnkUserPersonal.Visible = RightHelper.CheckFuncRescRight(HRUser.USERPERSONAL_FUNID, OperationCode.READ, ScrUser.ResourceTypeID, UserId);
    //    //LnkUserWork.Visible = RightHelper.CheckFuncRescRight(HRUser.USERWORK_FUNID, OperationCode.READ, ScrUser.ResourceTypeID, UserId) || page.PageRight.ReadRight;
    //    //LnkUserTraining.Visible = RightHelper.CheckFuncRescRight(HRUser.USERTRAINING_FUNID, OperationCode.READ, ScrUser.ResourceTypeID, UserId);
    //    //LnkUserLeave.Visible = RightHelper.CheckFuncRescRight(HRUser.USERLEAVE_FUNID, OperationCode.READ, ScrUser.ResourceTypeID, UserId);
    //    //LnkRewards.Visible = RightHelper.CheckFuncRescRight(HRUser.USERREWARD_FUNID, OperationCode.READ, ScrUser.ResourceTypeID, UserId);
    //    //LnkEducation.Visible = RightHelper.CheckFuncRescRight(HRUser.USEREDUCATION_FUNID, OperationCode.READ, ScrUser.ResourceTypeID, UserId);
    //    #endregion

    //    DataSet ds = ScrFunction.GetTabGroupList(HRUser.FUNCTIONID, 1, ScrUser.ResourceTypeID, UserId);

    //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        switch (Fn.ToInt(ds.Tables[0].Rows[i]["function_id"]))
    //        {
    //            case HRUser.USER_CONTACT:
    //                LnkUserContact.Visible = true;
    //                break;
    //            case HRUser.USER_PERSONAL:
    //                LnkUserPersonal.Visible = true;
    //                break;
    //            case HRUser.USER_FAMILY:
    //                LnkUserFamily.Visible = true;
    //                break;
    //            case HRUser.USER_CONTRACT:
    //                LnkUserContract.Visible = true;
    //                break;
    //            case HRUser.USER_WORK_BEFORE:
    //                LnkUserWork.Visible = true;
    //                break;
    //            case HRUser.USER_TRAINING_BEFORE:
    //                LnkUserTraining.Visible = true;
    //                break;
    //            case HRUser.USER_EDUCATION:
    //                LnkUserEducation.Visible = true;
    //                break;
    //            case HRUser.USER_REWARD_BEFORE:
    //                LnkUserRewards.Visible = true;
    //                break;
    //            case HRUser.USER_JOB:
    //                LnkUserJob.Visible = true;
    //                break;
    //            case HRUser.USER_SALARY:
    //                LnkUserSalary.Visible = true;
    //                break;
    //            case HRUser.USER_LEAVE:
    //                LnkUserLeave.Visible = true;
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //}

    //private void SetTabHyperLinkVisibleAdd()
    //{
    //    //新增的时候,如果有第一个Tab的权限的话,就显示,否则的话,不显示。其他的Tab不显示。
    //    //LnkUserContact.Visible = RightHelper.CheckFuncRescRight(HRUser.USER_CONTACT, OperationCode.READ, ScrUser.ResourceTypeID, UserId);
    //    LnkUserContact.Visible = true;
    //    LnkUserPersonal.Visible = false;
    //    LnkUserJob.Visible = false;
    //    LnkUserFamily.Visible = false;
    //    LnkUserWork.Visible = false;
    //    LnkUserTraining.Visible = false;
    //    LnkUserLeave.Visible = false;
    //    LnkUserRewards.Visible = false;
    //    LnkUserEducation.Visible = false;
    //    LnkUserContract.Visible = false;
    //    LnkUserSalary.Visible = false;
    //}

    public UcHyperLink GetFirstTab()
    {
        if (LnkUserContact.Visible)
            return LnkUserContact;
        else if (LnkUserPersonal.Visible)
            return LnkUserPersonal;
        else if (LnkUserFamily.Visible)
            return LnkUserFamily;
        else if (LnkUserContract.Visible)
            return LnkUserContract;
        else if (LnkUserWork.Visible)
            return LnkUserWork;
        else if (LnkUserTraining.Visible)
            return LnkUserTraining;
        else if (LnkUserEducation.Visible)
            return LnkUserEducation;
        else if (LnkUserRewards.Visible)
            return LnkUserRewards;
        else if (LnkUserJob.Visible)
            return LnkUserJob;
        else if (LnkUserSalary.Visible)
            return LnkUserSalary;
        else if (LnkUserLeave.Visible)
            return LnkUserLeave;
        else if (LnkUserPay.Visible)
            return LnkUserPay;
        else
            return null;
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        PageBase page = (PageBase)this.Page;

        string urlWork = string.Format("UserWorkExperience.aspx?UserId={0}", UserId);
        string urlFamily = string.Format("UserFamily.aspx?UserId={0}", UserId);
        string urlRewards = string.Format("UserRewardsPunishment.aspx?UserId={0}", UserId);
        string urlEducation = string.Format("UserEducation.aspx?UserId={0}", UserId);
        string urlContract = string.Format("UserContract.aspx?UserId={0}", UserId);
        string urlTraining = string.Format("UserTraining.aspx?UserId={0}", UserId);
        string urlLeave = string.Format("UserLeave.aspx?UserId={0}", UserId);
        string urlSalary = string.Format("UserInsurance.aspx?UserId={0}", UserId);
        //string urlPay = string.Format("UserPayInitValue.aspx?UserId={0}&PaySetId={1}", UserId, PaySetId);
        string urlBankInfo = string.Format("UserBankInfo.aspx?UserId={0}", UserId);

        LnkUserWork.NavigateUrl = urlWork;
        LnkUserFamily.NavigateUrl = urlFamily;
        LnkUserRewards.NavigateUrl = urlRewards;
        LnkUserEducation.NavigateUrl = urlEducation;
        LnkUserContract.NavigateUrl = urlContract;
        LnkUserTraining.NavigateUrl = urlTraining;
        LnkUserLeave.NavigateUrl = urlLeave;
        LnkUserSalary.NavigateUrl = urlSalary;
        LnkUserPay.NavigateUrl = urlBankInfo;

        UcHyperLink LnkCurrent = GetCurrentTab();
        //LnkFirst = LnkFirst == null ? GetFirstTab() : LnkFirst;

        //if (string.IsNullOrEmpty(HidSelectedTab.Value))
        //{
        //    if (LnkFirst != null)
        //    {
        //        page.AttachClientEvent("windowonload", "window", "onload", string.Format("document.getElementById('{0}').click();", LnkFirst.ClientID));
        //    }
        //}
        //else
        //{
        //    page.AttachClientEvent("windowonload", "window", "onload", string.Format("document.getElementById('{0}').click();", HidSelectedTab.Value));
        //}

        page.AttachClientEvent("windowonload", "window", "onload", string.Format("document.getElementById('{0}').click();", LnkCurrent.ClientID));
        RegditDetailScript();        
    }

    private void RegditDetailScript()
    {
        if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegditDetailScript"))
        {
            StringBuilder s = new StringBuilder();

            s.Append("function SwitchTab(oSelectedTab,columnName,HidSelectedTab)");
            s.Append("{");
            s.Append("document.getElementById(HidSelectedTab).value=oSelectedTab.id;");//保存客户端每次点击TabId

            if (TabContact.Visible)
            {
                s.AppendFormat("var TabContact = document.getElementById('{0}');", TabContact.ClientID);
                s.Append("TabContact.style.display='none';");
            }

            if (TabPersonal.Visible)
            {
                s.AppendFormat("var TabPersonal = document.getElementById('{0}');", TabPersonal.ClientID);
                s.Append("TabPersonal.style.display='none';");
            }
            if (TabFamily.Visible)
            {
                s.AppendFormat("var TabFamily = document.getElementById('{0}');", TabFamily.ClientID);
                s.Append("TabFamily.style.display='none';");
            }
            if (TabJob.Visible)
            {
                s.AppendFormat("var TabJob = document.getElementById('{0}');", TabJob.ClientID);
                s.Append("TabJob.style.display='none';");
            }

            if (TabSalary.Visible)
            {
                s.AppendFormat("var TabSalary = document.getElementById('{0}');", TabSalary.ClientID);
                s.Append("TabSalary.style.display='none';");
            }

            if (TabUserContract.Visible)
            {
                s.AppendFormat("var TabUserContract = document.getElementById('{0}');", TabUserContract.ClientID);
                s.Append("TabUserContract.style.display='none';");
            }

            if (TabUserPay.Visible)
            {
                s.AppendFormat("var TabUserPay = document.getElementById('{0}');", TabUserPay.ClientID);
                s.Append("TabUserPay.style.display='none';");
            }

            if (TabWorkExpand.Visible)
            {
                s.AppendFormat("var TabWorkExpand = document.getElementById('{0}');", TabWorkExpand.ClientID);
                s.Append("TabWorkExpand.style.display='none';");
            }

            s.AppendFormat("var TabIfra = document.getElementById('{0}');", TabIfra.ClientID);

            s.Append("TabIfra.style.display='none';");

            s.Append("switch(columnName.toLowerCase())");
            s.Append("{");
            //联系方式
            s.Append("case 'tabcontact':");
            s.Append("TabContact.style.display='inline';");
            s.Append("break;");
            //人事信息
            s.Append("case 'tabpersonal':");
            s.Append("TabPersonal.style.display='inline';");
            s.Append("break;");
            //职位信息
            s.Append("case 'tabjob':");
            s.Append("TabJob.style.display='inline';");
            s.Append("break;");
            //薪酬信息
            s.Append("case 'tabpay':");
            s.Append("TabUserPay.style.display='inline';");
            s.Append("TabIfra.style.display='inline';");
            s.Append("break;");
            //个人信息
            s.Append("case 'tabfamily':");
            if (TabFamily.Visible)
            {
                s.Append("TabFamily.style.display='inline';");
            }
            s.Append("TabIfra.style.display='inline';");
            s.Append("break;");
            //薪资信息
            s.Append("case 'tabsalary':");
            s.Append("TabSalary.style.display='inline';");
            s.Append("TabIfra.style.display='inline';");
            s.Append("break;");
            //用工信息
            s.Append("case 'tabcontract':");
            s.Append("TabUserContract.style.display='inline';");
            s.Append("TabIfra.style.display='inline';");
            s.Append("break;");
            //工作经历
            s.Append("case 'tabwork':");
            s.Append("TabIfra.style.display='inline';");
            s.Append("TabWorkExpand.style.display='inline';");
            s.Append("break;");
            //休假和加班                                    
            //奖惩信息
            //教育背景   
            //培训信息
            s.Append("case 'tableave':");
            s.Append("case 'tabrewards':");
            s.Append("case 'tabeducation':");
            s.Append("case 'tabtraining':");
            s.Append("TabIfra.style.display='inline';");
            s.Append("break;");
            s.Append("}");

            s.Append("}");

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegditDetailScript", s.ToString(), true);
        }
    }
}
