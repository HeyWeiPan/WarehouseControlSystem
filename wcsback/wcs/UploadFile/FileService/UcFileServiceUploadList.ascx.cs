using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using EntpClass.BizLogic.Security;
using EntpClass.Common;
using System.Data;

public partial class UploadFile_UcFileServiceUploadList : GridControlBase<File>
{
    /// <summary>
    /// 文件存放的文件目录的Id
    /// 预留文档管理中使用,如果实现文档管理,默认为 ApplicationID
    /// </summary>
    private int FolderId
    {
        get
        {
            return Fn.ToInt(Request.QueryString["FolderId"]);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private int ApplicationId
    {
        get
        {
            return Fn.ToInt(Request.QueryString["ApplicationId"]);
        }
    }

    /// <summary>
    /// 实例Id
    /// </summary>
    private int InstanceId
    {
        get
        {
            return Fn.ToInt(Request.QueryString["InstanceId"]);
        }
    }

    /// <summary>
    /// 文件的版本
    /// 预留文档管理中使用,默认为空
    /// </summary>
    private string Version
    {
        get
        {
            return Fn.ToString(Request.QueryString["Version"]);
        }
    }

    /// <summary>
    /// 文件上传用户
    /// </summary>
    private int CreateUserId
    {
        get
        {
            return Fn.ToInt(Request.QueryString["CreateUserId"]);
        }
    }

    /// <summary>
    /// 删除权限
    /// </summary>
    private bool DeleteRight
    {
        get
        {
            string deleteRight = Request.QueryString["DeleteRight"];
            if (string.IsNullOrEmpty(deleteRight))
                return true;

            return Fn.ToBoolean(deleteRight);
        }
    }

    /// <summary>
    /// 验证每一文件是否可以删除的存储过程
    /// </summary>
    private string CheckDeleteProc
    {
        get
        {
            return Fn.ToString(Request.QueryString["CheckDeleteProc"]);
        }
    }

    protected override DataSet GetGridDataSet()
    {
        //根据folder_id取用户文件
        if (FolderId == 0)
        {
            return FileServiceHelper.GetFileList(ApplicationId, InstanceId, Version, CreateUserId);
        }
        else
        {
            return FileServiceHelper.GetFileListByFolder(ApplicationId, InstanceId, FolderId, Version, CreateUserId);
        }
    }

    protected override GridView GetGridViewControl()
    {
        return GrdAttachment;
    }

    protected override void SetParameter(GridControlParameter p)
    {
        base.SetParameter(p);

        p.DialogMode = false;
        p.AddRight = false;
        p.EditRight = false;

        p.DeleteRight = DeleteRight;
    }

    protected override void SetRowRight(GridView gv, GridViewRowEventArgs e, string keyValue, ref bool editRight, ref bool deleteRight)
    {
        base.SetRowRight(gv, e, keyValue, ref editRight, ref deleteRight);

        if (!DeleteRight)
        {
            deleteRight = false;
        }

        //删除之前,根据传递的存储过程的名字,来检查是否可以删除
        if (!string.IsNullOrEmpty(CheckDeleteProc))
        {
            bool b = FileServiceHelper.CheckDeleteAttachment(keyValue, CheckDeleteProc);
            if (!b)
            {
                deleteRight = false;
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        GrdAttachment.RowDataBound += new GridViewRowEventHandler(GrdAttachment_RowDataBound);
    }

    void GrdAttachment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                e.Row.Cells[4].Text = Convert.ToDateTime(e.Row.Cells[4].Text).ToString("yyyy/MM/dd");
            }
            catch { }
        }
    }
    

    //protected override bool OnDelete(string id)
    //{
    //    //删除之前,根据传递的存储过程的名字,来检查是否可以删除
    //    if (!string.IsNullOrEmpty(CheckDeleteProc))
    //    {
    //        bool b = FileHelper.CheckDeleteAttachment(id, CheckDeleteProc);
    //        if (!b)
    //        {
    //            RM rm = new RM(ResourceFile.Msg);
    //            PageBase page = this.Page as PageBase;

    //            page.Alert(rm["DataReference"]);
    //            return false;
    //        }
    //    }

    //    return base.OnDelete(id);
    //}
}
