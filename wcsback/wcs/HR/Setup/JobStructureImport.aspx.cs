using System;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.HR.Setup;

public partial class HR_Setup_JobStructureImport : PageBase
{
    public override void SetPageInfo(ref PageParameter p)
    {
        return;
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        for (int i = 0; i < GrdList.Rows.Count; i++)
        {
            UcLabel LabJobCode = (UcLabel)GrdList.Rows[i].FindControl("LabJobCode");
            int pOut = Fn.ToInt(LabJobCode.Attributes["a"]);

            if(pOut == 0)
            {
                GrdList.Rows[i].ForeColor = Color.Red;                
            }
        }
    }

    protected void BtnImport_Click(object sender, EventArgs e)
    {
        PageBase page = (PageBase)this.Page;

        if (UpdFile.PostedFile.FileName != "")
        {
            string timeStr = DateTime.Now.ToString("yyyyMMddhhmmss");
            string filePath = Request.PhysicalApplicationPath + @"Export\" + "jobstructure"+ timeStr +".xls" ;
            UpdFile.SaveAs(filePath);

            string errorMessage;
            string[] sheetNames = ExcelHelper.GetExcelSheetNames(filePath);

            DataSet ds = ExcelHelper.GetDataSetFromExcel(filePath, sheetNames[0], out errorMessage);

            JobStructure job = new JobStructure();
            bool b = job.ImportJobStructure(ds, out errorMessage);
            if (!b)
                page.Alert(errorMessage);
            else
                page.Alert(new RM(ResourceFile.Msg)["SaveSuccess"]);

            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "pOut = 0";

            if (dv.Count > 0)
            {
                GrdList.DataSource = dv;
                GrdList.DataBind();
            }

            File.Delete(filePath);
        }
    }
}
