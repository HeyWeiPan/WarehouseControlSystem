using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.Common;
using System.Data;
using EntpClass.BizLogic.Setup;
using System.IO;

public partial class CommonUI_WebForm_GetFileService : System.Web.UI.Page
{
    private void RenderFile(string fileGUID)
    {
        DataView dtvFile = FileServiceHelper.GetFileByID(fileGUID).Tables[0].DefaultView;
        string fileName = Fn.ToString(dtvFile[0]["FRIENDLY_NAME"]).Trim();
        string ext = FileHelper.GetFileExtension(fileName);
        string origionalFileName = Fn.ToString(dtvFile[0]["FILE_NAME"]);

        if (ext == string.Empty || ext != FileHelper.GetFileExtension(origionalFileName))
        {
            fileName = fileName + FileHelper.GetFileExtension(origionalFileName);
        }

        string fileGuid = string.Empty;
        if (Fn.ToLength(dtvFile[0]["copy_from_guid"]) == 0)
        {
            fileGuid = Fn.ToString(dtvFile[0]["file_guid"]).Trim() + "." + Fn.ToString(dtvFile[0]["file_extension"]);
        }
        else
        {
            fileGuid = Fn.ToString(dtvFile[0]["copy_file_guid"]).Trim() + "." + Fn.ToString(dtvFile[0]["file_extension"]);
        }

        string physicalPath = Fn.ToString(AppParameter.GetPValue("File_Physical_Path"));
        string storepackage = Fn.ToString(dtvFile[0]["store_package"]);

        //使用webservice
        //FileService.FileService s = new FileService.FileService();
        //byte [] bytes = s.DownFile(physicalPath, fileGuid);

        byte[] bytes = DownFile((physicalPath + @"\" + storepackage), fileGuid, origionalFileName);

        Response.AppendHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName));
        Response.ContentType = Fn.ToString(dtvFile[0]["CONTENT_TYPE"]);
        //Response.OutputStream.Write(Convert.ChangeType(dtvFile[0]["CONTENT"], Byte[]), 0, Fn.ToInt(dtvFile[0]["CONTENT_SIZE"]));
        Response.OutputStream.Write(bytes, 0, bytes.Length);
        Response.End(); 
    }


    public byte[] DownFile(string filePath, string fileGuid,string origionalfileName)
    {
        string filepath = filePath + @"\" + fileGuid;
        if (File.Exists(filepath))    //先使用filepath +guid(带扩展名)查找
        {
            try
            {
                FileStream s = File.OpenRead(filepath);
                return ConvertStreamToByteBuffer(s);

            }
            catch
            {
                return new byte[0];
            }
        }
        else
        {
            filepath = filePath + @"\" + origionalfileName;  //如果不存在，使用filepath +原名称（带扩展名）查找,(老系统导入的文件，不是以guid存放)
            if (File.Exists(filepath))
            {
                try
                {
                    FileStream s = File.OpenRead(filepath);
                    return ConvertStreamToByteBuffer(s);

                }
                catch
                {
                    return new byte[0];
                }
            }

            return new byte[0];
        }
    }


    //将Stream流转换为byte数组的方法。   
    public byte[] ConvertStreamToByteBuffer(Stream s)
    {      
        MemoryStream ms = new MemoryStream();
        int b;
        while ((b = s.ReadByte()) != -1)
        {
            ms.WriteByte((byte)b);
        }
        return ms.ToArray();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        RenderFile(GetFuncID());
    }

    protected string GetFuncID()
    {
        return Request.QueryString["FileID"];
    }
}
